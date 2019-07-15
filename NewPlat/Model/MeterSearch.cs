using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPlat.Model
{
    class MeterSearch
    {
        /// <summary>
        /// 表id
        /// </summary>
        public String MeterId { get; set; }
        /// <summary>
        /// 表类型
        /// </summary>
        public String MeterType { get; set; }
        /// <summary>
        /// ic卡控检测状态
        /// </summary>
        public string MeterIcState { get; set; }
        /// <summary>
        /// 初检状态
        /// </summary>
        public String MeterChuState { get; set; }
        /// <summary>
        /// 命令检测状态
        /// </summary>
        public String MeterComState { get; set; }
        /// <summary>
        /// 终检状态
        /// </summary>
        public String MeterZhongState { get; set; }
        /// <summary>
        /// 总状态
        /// </summary>
        public String MeterState { get; set; }
        /// <summary>
        /// 测试状态
        /// </summary>
        public String MeterTest { get; set; }
        /// <summary>
        /// 随机数
        /// </summary>
        public string MeterRand_num { get; set; }
        /// <summary>
        /// 最近一次对表信息的更改时间
        /// </summary>
        public DateTime MeterTime { get; set; }
        /// <summary>
        /// 是否取消测试
        /// </summary>
        public string MeterCancel { get; set; }
        /// <summary>
        /// 单项测试结果
        /// </summary>
        public string MeterEvery { get; set; }
        /// <summary>
        /// 是否优先测试
        /// </summary>
        public string MeterPrivilege { get; set; }
        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime CheckTime { get; set; }
        /// <summary>
        /// 厂商ID号
        /// </summary>
        public string ManufactureName { get; set; }
        /// <summary>
        /// 提交时间
        /// </summary>
        public DateTime Subtime { get; set; }
    }
}
