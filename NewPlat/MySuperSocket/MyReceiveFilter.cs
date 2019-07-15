using NewPlat.BLL;
using SuperSocket.Common;
using SuperSocket.Facility.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPlat.MySuperSocket
{
   public class MyReceiveFilter : FixedHeaderReceiveFilter<MyRequestInfo>
    {
        //开始和结束标记也可以是两个或两个以上的字节
        private readonly static byte[] BeginMark = new byte[] { (byte)(0x15) };
        private readonly static byte[] EndMark = new byte[] { (byte)(0x14) };

        /// <summary>
        /// 请求头的长度
        /// 14字节 1+1+6+4+2
        /// </summary>
        public MyReceiveFilter() : base(14)
        {
        }

        /// <summary>
        /// 将数据转化为MyRequestInfo（处理整个帧）
        /// </summary>
        /// <param name="readBuffer"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <param name="toBeCopied"></param>
        /// <param name="rest">接受缓冲区还剩多少数据未被解析</param>
        /// <returns></returns>
        public override MyRequestInfo Filter(byte[] readBuffer, int offset, int length, bool toBeCopied, out int rest)
        {
            rest = 0;
            string entireFrame = DataHelper.Bytes2HexStr(readBuffer.CloneRange(offset, length));
            MyRequestInfo res = new MyRequestInfo();
            if (entireFrame.Length < 32)
            {
                LogHelper.Info(entireFrame + "   帧长度小于16字节");

                return null;
            }
            if (entireFrame.Substring(0, 2) != "15")
            {
                LogHelper.Info(entireFrame + "   帧开头不为15");
                return null;
            }
            if (entireFrame.Substring(entireFrame.Length - 2, 2) != "14")
            {
                LogHelper.Info(entireFrame + "   帧结尾不为14");
                return null;
            }
            string DataLength = entireFrame.Substring(24, 4);
            int dataLen = int.Parse(DataHelper.Hex2Dec(DataLength));
            if (entireFrame.Length != (dataLen * 2 + 32))
            {
                LogHelper.Info(entireFrame + "   数据长度不对");
                return null;
            }
            if (ValidCS(entireFrame) == false)
            {
                LogHelper.Info(entireFrame + "   校验CS不正确");
                return null;
            }
            res.EntireFrame = entireFrame;
            res.EquipmentType = entireFrame.Substring(2, 2);
            res.EquipmentID = entireFrame.Substring(4, 12);
            res.CtrlCodeHex = entireFrame.Substring(16, 8);
            res.CtrlCodeBin = DataHelper.Hex2Bin(res.CtrlCodeHex);
            res.DataLength = entireFrame.Substring(24, 4);
            //res.Key = entireFrame.Substring(28, 2);
            res.Data = entireFrame.Substring(28, dataLen * 2);
            res.DataBytes = readBuffer.CloneRange(offset + 14, dataLen);
            res.Cs = entireFrame.Substring(28 + dataLen * 2, 2);
            res.IsEncrypt = (res.CtrlCodeBin[3] == '1') ? true : false;
            res.IsCompress = (res.CtrlCodeBin[2] == '1') ? true : false;
            res.IsFollowed = (res.CtrlCodeBin[4] == '1') ? true : false;
            if (res.IsEncrypt)
            {
                string UpKey;
                UpKey = res.EquipmentID + "5348414E474841495251";
                //if (CommonFunction.test.index == 15)
                //    UpKey = CommonFunction.test.strNewKey;
                byte[] AesKey = DataHelper.Str2Byte(UpKey);
                res.DataBytes = DataHelper.AesDecrypt(res.DataBytes, AesKey);
                if (res.DataBytes == null)
                {
                    LogHelper.Info(entireFrame + " 解密失败,解密密钥为" + UpKey);
                    return null;
                }
            }
            if (res.IsCompress)
            {
                res.DataBytes = DataHelper.Decompress(res.DataBytes);
                if (res.DataBytes == null)
                {
                    LogHelper.Info(entireFrame + " 解压缩失败");
                    return null;
                }
            }
            res.intPackNum = Convert.ToInt32(res.CtrlCodeHex.Substring(4, 4), 16);
            res.Data = DataHelper.Bytes2HexStr(res.DataBytes);
            res.Key = res.Data.Substring(0, 2);
            res.dtUpload = DateTime.Now;
            res.result = true;
            return res;
        }

        /// <summary>
        /// 获取数据域和结尾字节长度(根据请求头的长度，返回请求体的长度)
        /// </summary>
        /// <param name="header">请求头</param>
        /// <param name="offset">开始位置</param>
        /// <param name="length">请求头长度</param>
        /// <returns></returns>
        protected override int GetBodyLengthFromHeader(byte[] header, int offset, int length)
        {
            //length为头部(包含两字节的length)长度
            //获取高位
            byte high = header[offset + length - 2];
            //获取低位
            byte low = header[offset + length - 1];
            int len = (int)high * 256 + low;
            return len + 2;//结尾有2个字节
        }

        private bool ValidCS(string entireFrame)
        {
            string CsRaw = entireFrame.Substring(entireFrame.Length - 4, 2);
            string Cs = DataHelper.GetChecksum(entireFrame);
            return (CsRaw == Cs);
        }

        /// <summary>
        /// 实现帧内容解析（处理请求体）
        /// </summary>
        /// <param name="header">header 我们的协议头的数据</param>
        /// <param name="bodyBuffer">缓存的数据，这个并不是只单纯包含打包数据的</param>
        /// <param name="offset">打包数据在bodyBuffer里面开始的位置</param>
        /// <param name="length">打包数据的长度</param>
        /// <returns></returns>
        protected override MyRequestInfo ResolveRequestInfo(ArraySegment<byte> header, byte[] bodyBuffer, int offset, int length)
        {
            MyRequestInfo res = new MyRequestInfo();
            return res;
        }
    }
}
