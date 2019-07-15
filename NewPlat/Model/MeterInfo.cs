using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPlat.Model
{
#pragma warning disable CS0659 // “MeterInfo”重写 Object.Equals(object o) 但不重写 Object.GetHashCode()
   public class MeterInfo
#pragma warning restore CS0659 // “MeterInfo”重写 Object.Equals(object o) 但不重写 Object.GetHashCode()
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
        /// 记录要检测平台的IP与port
        /// </summary>
        public string Meteriport { get; set; }
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
        public int ManufactureName_id { get; set; }
        /// <summary>
        /// 提交时间
        /// </summary>
        public DateTime Subtime { get; set; }
        /// <summary>
        /// 重写equals方法，可以利用MeterId直接在BmeterInfos中利用
        /// IndexOf来查询表具是否在列表中
        /// </summary>
        /// <param name="obj">输入元素表具</param>
        /// <returns>在返回true</returns>
        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            if (this == null)
                return false;
            MeterInfo temp = (MeterInfo)obj;
            if (this.MeterId.Equals(temp.MeterId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //public override int GetHashCode()
        //{
        //    return this.MeterId.GetHashCode();
        //}
    }
}
