using NewPlat.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NewPlat.BLL
{
    class DataHelper
    {
        /// <summary>
        /// 计算出校验码
        /// </summary>
        /// <param name="strNormalTotal">输入参数是全部string数组，不过校验码不对</param>
        /// <returns></returns>
        public static string GetChecksum(string strNormalTotal)
        {
            //chu 解密解压前的所有数据
            int snum = strNormalTotal.Length / 2 - 2;
            long[] numPart = new long[snum];
            long sum = 0;
            int numChecksumRaw = Convert.ToInt32(strNormalTotal.Substring(strNormalTotal.Length - 4, 2), 16);//截取传来的校验位

            for (int k = 0; k < snum; k++)
            {
                numPart[k] = Convert.ToInt64(strNormalTotal.Substring((k * 2), 2), 16);
                sum += numPart[k];
            }
            string strSum = Convert.ToString(sum, 16);
            strSum = strSum.Substring(strSum.Length - 2, 2).ToUpper();
            return strSum;
        }
        /// <summary>
        /// 16进制转2进制
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static string Hex2Bin(string hex)
        {
            int hexLength = hex.Length;
            int binLength = hexLength * 4;

            int tem = Convert.ToInt32(hex, 16);
            string bin = Convert.ToString(tem, 2);
            int binlen = bin.Length;
            for (int i = 0; i < binLength - binlen; i++)
                bin = "0" + bin;
            return bin;
        }

        /// <summary>
        /// 2进制转16进制
        /// </summary>
        /// <param name="bin"></param>
        /// <returns></returns>
        public static string Bin2Hex(string bin)
        {
            int hexLength;
            int binLength = bin.Length;
            if (binLength % 4 != 0)
                return "0000";
            hexLength = binLength / 4;
            int tem = Convert.ToInt32(bin, 2);
            string hex = Convert.ToString(tem, 16);
            int hexlen = hex.Length;
            for (int i = 0; i < hexLength - hexlen; i++)
                hex = "0" + hex;
            return hex;

        }

        /// <summary>
        /// 转化bytes成16进制的字符 一字节等于两个16进制
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        internal static string Bytes2HexStr(byte[] bytes)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    returnStr += bytes[i].ToString("X2");
                }
            }
            return returnStr;
        }

        /// <summary>
        /// 16进制转10进制
        /// </summary>
        /// <param name="HEX"></param>
        /// <returns></returns>
        internal static string Hex2Dec(string HEX)
        {
            return Convert.ToInt64(HEX, 16).ToString();
        }

        internal static byte[] Str2Byte(string hexString)
        {
            try
            {
                hexString = hexString.Replace(" ", "");
                hexString = hexString.ToUpper();
                if ((hexString.Length % 2) != 0)
                    hexString = "0" + hexString;
                byte[] returnBytes = new byte[hexString.Length / 2];
                for (int i = 0; i < returnBytes.Length; i++)
                    returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
                return returnBytes;
            }
            catch
            {
                return null;
            }

        }
        internal static string AesEncrypt(string strSrc, string AesKey)
        {
            try
            {
                AesCryptoServiceProvider aes = new AesCryptoServiceProvider
                {
                    KeySize = 128,
                    Key = Str2Byte(AesKey),
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                };

                using (ICryptoTransform encrypt = aes.CreateEncryptor())
                {
                    byte[] src = Str2Byte(strSrc);
                    byte[] dest = encrypt.TransformFinalBlock(src, 0, src.Length);
                    return Bytes2HexStr(dest);
                }
            }
            catch { return null; }
        }
        internal static byte[] AesDecrypt(byte[] src, byte[] AesKey)
        {
            try
            {
                AesCryptoServiceProvider aes = new AesCryptoServiceProvider
                {
                    BlockSize = 128,
                    KeySize = 128,
                    Key = AesKey,
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                };

                using (ICryptoTransform decrypt = aes.CreateDecryptor())
                {
                    byte[] dest = decrypt.TransformFinalBlock(src, 0, src.Length);
                    return (dest);
                }
            }
            catch
            {
                return null;
            }
        }

        internal static byte[] Decompress(byte[] input)
        {
            int bufferSize = 2048;
            try
            {
                MemoryStream ms = new MemoryStream(input);
                MemoryStream ms1 = new MemoryStream();
                ICSharpCode.SharpZipLib.GZip.GZipInputStream zipFile = new ICSharpCode.SharpZipLib.GZip.GZipInputStream(ms);
                byte[] output = new byte[2048];
                while (bufferSize > 0)
                {
                    bufferSize = zipFile.Read(output, 0, bufferSize);
                    ms1.Write(output, 0, bufferSize);
                }
                ms1.Close();
                return ms1.ToArray();
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 从数组中截取一部分成新的数组
        /// </summary>
        /// <param name="Source">原数组</param>
        /// <param name="StartIndex">原数组的起始位置</param>
        /// <param name="EndIndex">原数组的截止位置</param>
        /// <returns></returns>
        public static byte[] SplitArray(byte[] Source, int StartIndex, int Length)
        {
            try
            {
                byte[] result = new byte[Length];
                for (int i = 0; i < Length; i++)
                    result[i] = Source[i + StartIndex];
                return result;
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        internal static string Str2IP(string p)
        {
            try
            {
                string ip1 = Convert.ToInt32(p.Substring(0, 2), 16).ToString();
                string ip2 = Convert.ToInt32(p.Substring(2, 2), 16).ToString();
                string ip3 = Convert.ToInt32(p.Substring(4, 2), 16).ToString();
                string ip4 = Convert.ToInt32(p.Substring(6, 2), 16).ToString();
                string ip = ip1 + '.' + ip2 + '.' + ip3 + '.' + ip4;
                return ip;
            }
            catch { return ""; }
        }
        internal static string IP2Str(string IPAddress)
        {
            try
            {
                string[] strArrIP = IPAddress.Split('.');
                string strIP = "";
                for (int i = 0; i < 4; i++)
                {
                    int intIP = Convert.ToInt32(strArrIP[i]);
                    strArrIP[i] = string.Format("{0:X2}", intIP);
                    strIP += strArrIP[i];
                }
                return strIP;
            }
            catch
            {
                return "00000000";
            }
        }
        /// <summary>
        /// 将datatable转为meterinfo对象
        /// </summary>
        /// <param name="dt"></param>
        /// <returns>不是一条结果就返回null</returns>
        public static MeterInfo Dt2Ob(DataTable dt)
        {
            try
            {
                if (dt == null)
                    return null;
                else
                {
                    MeterInfo temp = (MeterInfo)Activator.CreateInstance(typeof(MeterInfo));
                    PropertyInfo[] propertys = temp.GetType().GetProperties();
                    foreach (PropertyInfo pi in propertys)
                    {
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            if (pi.Name.Equals(dt.Columns[i].ColumnName))
                            {
                                if (dt.Rows[0][i] != DBNull.Value)
                                    pi.SetValue(temp, dt.Rows[0][i], null);
                                else
                                    pi.SetValue(temp, null, null);
                                break;
                            }
                        }
                    }
                    return temp;
                }
            }
            catch (Exception)
            {
                return null;
            }
            
        }
        /// <summary>
        /// 将datatable转为platinfo对象
        /// </summary>
        /// <param name="dt"></param>
        /// <returns>不是一条结果就返回null</returns>
        public static PlatInfo Dt2pl(DataTable dt)
        {
            if (dt.Rows.Count != 1)
                return null;
            else
            {
                PlatInfo temp = (PlatInfo)Activator.CreateInstance(typeof(PlatInfo));
                PropertyInfo[] propertys = temp.GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        if (pi.Name.Equals(dt.Columns[i].ColumnName))
                        {
                            if (dt.Rows[0][i] != DBNull.Value)
                                pi.SetValue(temp, dt.Rows[0][i], null);
                            else
                                pi.SetValue(temp, null, null);
                            break;
                        }
                    }
                }
                return temp;
            }
        }
        /// <summary>
        /// dataset转化为list的platinfo
        /// </summary>
        /// <param name="ds">datable</param>
        /// <returns></returns>
        public static List<PlatInfo> DS2List(DataTable dt)
        {
            List<PlatInfo> result = new List<PlatInfo>();
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                PlatInfo temp = (PlatInfo)Activator.CreateInstance(typeof(PlatInfo));
                PropertyInfo[] propertys = temp.GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        if (pi.Name.Equals(dt.Columns[i].ColumnName))
                        {
                            // 数据库NULL值单独处理                             
                            if (dt.Rows[j][i] != DBNull.Value)
                                pi.SetValue(temp, dt.Rows[j][i], null);
                            else
                                pi.SetValue(temp, null, null);
                            break;
                        }

                    }
                }
                result.Add(temp);
            }
            return result;
        }
    }
}
