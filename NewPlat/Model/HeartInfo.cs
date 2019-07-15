using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPlat.Model
{
#pragma warning disable CS0659 // “HeartInfo”重写 Object.Equals(object o) 但不重写 Object.GetHashCode()
   public class HeartInfo
#pragma warning restore CS0659 // “HeartInfo”重写 Object.Equals(object o) 但不重写 Object.GetHashCode()
    {
        /// <summary>
        /// 电脑号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 检测平台类型
        /// </summary>
        public String Type { get; set; }
        /// <summary>
        /// 检测平台ip
        /// </summary>
        public String IP { get; set; }
        /// <summary>
        /// 检测平台端口
        /// </summary>
        public String Port { get; set; }
        /// <summary>
        /// keep记录
        /// </summary>
        public int Ke_al { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string State { get; set; }
        public override bool Equals(object obj)
        {
            var info = obj as HeartInfo;
            return info != null &&
                   IP == info.IP &&
                   Port == info.Port;
        }
        public HeartInfo() { }
        public HeartInfo(int Id,string Type,string Ip,string Port,int Ke_al,string State) {
            this.Id = Id;
            this.Type = Type;
            this.IP = Ip;
            this.Port = Port;
            this.Ke_al = Ke_al;
            this.State = State;
        }
    }
}
