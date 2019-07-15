using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPlat.Model
{
  public class PlatInfo
    {        
        /// <summary>
        /// 检测电脑号
        /// </summary>
        public int id { get; set ; }
        /// <summary>
        /// 检测平台ip
        /// </summary>
        public string IP { get; set; }
        /// <summary>
        /// 命令检测平台状态
        /// </summary>
        public string PlatComs { get; set; }
        /// <summary>
        /// IC平台状态
        /// </summary>
        public string PlatIcs { get; set; }
        /// <summary>
        /// 模式表初检检测平台状态
        /// </summary>
        public string PlatChus_msb { get; set; }
        /// <summary>
        /// 修正仪初检检测平台状态
        /// </summary>
        public string PlatChus_xzy { get; set; }
        /// <summary>
        /// 超声波初检检测平台状态
        /// </summary>
        public string PlatChus_csb { get; set; }
        /// <summary>
        /// 终检平台状态
        /// </summary>
        public string PlatZhos { get; set; }
        /// <summary>
        /// 命令检测的port
        /// </summary>
        public string PlatComp { get; set; }
        /// <summary>
        /// IC的port
        /// </summary>
        public string PlatIcp { get; set; }
        /// <summary>
        /// 模式表初检的port
        /// </summary>
        public string PlatChup_msb { get; set; }
        /// <summary>
        /// 修正仪初检的port
        /// </summary>
        public string PlatChup_xzy { get; set; }
        /// <summary>
        /// 超声波初检的port
        /// </summary>
        public string PlatChup_csb { get; set; }
        /// <summary>
        /// 终检的port
        /// </summary>
        public string PlatZhop { get; set; }

        public PlatInfo()
        {
            this.id = 0;
            this.IP = "212.64.12.60";
            this.PlatComs = "未启用";
            this.PlatIcs = "未启用";
            this.PlatChus_msb = "未启用";
            this.PlatChus_xzy = "未启用";
            this.PlatChus_csb = "未启用";
            this.PlatZhos = "未启用";
            this.PlatComp = "0000";
            this.PlatIcp = "0000";
            this.PlatChup_msb = "0000";
            this.PlatChup_xzy = "0000";
            this.PlatChup_csb = "0000";
            this.PlatZhop = "0000";
        }

    }
}
