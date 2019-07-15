using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPlat.MySuperSocket
{
  public  class MyRequestInfo : IRequestInfo
    {
        /// <summary>
        /// [不使用]
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 设备类型 1字节
        /// </summary>
        public string EquipmentType { get; set; }

        /// <summary>
        /// ID    6字节
        /// </summary>
        public string EquipmentID { get; set; }

        /// <summary>
        /// 控制码 4字节 十六进制 
        /// </summary>
        public string CtrlCodeHex { get; set; }

        /// <summary>
        /// 控制码 4字节 二进制 
        /// </summary>
        public string CtrlCodeBin { get; set; }

        public bool IsEncrypt { get; set; }

        public bool IsCompress { get; set; }

        public bool IsFollowed { get; set; }

        public int intPackNum { get; set; }
        /// <summary>
        /// 数据长度  1字节
        /// </summary>
        public string DataLength { get; set; }

        /// <summary>
        /// 数据域
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// CS校验  1字节
        /// </summary>
        public string Cs { get; set; }

        /// <summary>
        /// 当前完整帧
        /// </summary>
        public string EntireFrame { get; set; }

        public byte[] DataBytes { get; set; }

        public bool result { get; set; }

        public DateTime dtUpload { get; set; }
    }
}
