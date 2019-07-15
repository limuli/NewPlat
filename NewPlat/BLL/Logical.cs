using NewPlat.Model;
using NewPlat.MyDataSetTableAdapters;
using NewPlat.MySuperSocket;
using System;
using System.Data;

namespace NewPlat.BLL
{
    public static class Logical
    {
        private static Dt_PlateInfoTableAdapter Myadapter_p = new Dt_PlateInfoTableAdapter();
        /// <summary>
        /// 输入待测表,输出结果
        ///返回字符串数组
        ///string[]{id,ip,port}
        /// </summary>
        /// <param name="temp">待测表</param>
        /// <returns></returns>
        public static string[] Meter_AnPai(MeterInfo temp, bool ishavepri)
        {          
            Boolean isprivilege = false;
            if (temp.MeterPrivilege.Equals("1"))
                isprivilege = true;
            int flag = 0000;//终检，初检，IC卡控，命令检测，1不测，合格，不合格，0待测
            switch (temp.MeterComState)
            {
                case "不测":
                    flag = flag + 1;
                    break;
                case "合格":
                    flag = flag + 2;
                    break;
                case "不合格":
                    flag = flag + 3;
                    break;
                case "待测":
                    string[] re = Plat_AnPai(1,temp.MeterType, ishavepri,isprivilege);
                    if (re[2] != "空")
                        return re;
                    else break;
                default:
                    break;
            }
            switch (temp.MeterIcState)
            {
                case "不测":
                    flag = flag + 10;
                    break;
                case "合格":
                    flag = flag + 20;
                    break;
                case "不合格":
                    flag = flag + 30;
                    break;
                case "待测":
                    string[] re = Plat_AnPai(2, temp.MeterType, ishavepri,isprivilege);
                    if (re[2] != "空")
                        return re;
                    else break;
                default:
                    break;
            }
            switch (temp.MeterChuState)
            {
                case "不测":
                    flag = flag + 100;
                    break;
                case "合格":
                    flag = flag + 200;
                    break;
                case "不合格":
                    flag = flag + 300;
                    break;
                case "待测":
                    string[] re = Plat_AnPai(3, temp.MeterType, ishavepri,isprivilege);
                    if (re[2] != "空")
                        return re;
                    else break;
                default:
                    break;

            }
            switch (temp.MeterZhongState)
            {
                case "不测":
                    flag = flag + 1000;
                    break;
                case "合格":
                    flag = flag + 2000;
                    break;
                case "不合格":
                    flag = flag + 3000;
                    break;
                case "待测":
                    string[] re = Plat_AnPai(4, temp.MeterType, ishavepri,isprivilege);
                        return re;
                default:
                    break;
                }
            if ((!flag.ToString().Contains("0")) && (!flag.ToString().Contains("3")))
            {
                string[] s = new string[] { "成功", "成功", "成功", "成功" };
                return s;
            }
            else if ((!flag.ToString().Contains("0")) && (flag.ToString().Contains("3")))
            {
                string[] s = new string[] { "失败", "失败", "失败", "失败" };
                return s;
            }
            else {
                string[] s = new string[] { "空", "空", "空", "空" };
                return s;
            }

        }

        /// <summary>
        /// 输入检测类型，返回安排的检测平台号
        /// 有优先测表的情况下，普通表无法使用最后两台检测主机，优先表可以使用所有的检测主机
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static string[] Plat_AnPai(int number,string type,bool ishavepri,bool isprivilege)
        {
            int count_p = CommonFunction.platInfos.Count;
            string[] result = new string[] { "空", "空", "空", "空" };
            if (ishavepri && !isprivilege)
                count_p = Math.Max(0,count_p-2);
            try
            {
                switch (number)
                {
                    case 1:
                        for (int i = 0; i < count_p; i++)
                        {
                            int id = CommonFunction.platInfos[i].id;
                            //根据id查询出一条platinfo的记录
                            DataTable dt = Myadapter_p.GetDataBy1(id);
                            PlatInfo temp = DataHelper.Dt2pl(dt);
                            if (temp.PlatComs.Equals("空闲") && IsAllow(temp))
                            {
                                temp.PlatComs = "准备";
                                result[0] = id.ToString();
                                result[1] = temp.IP;
                                result[2] = temp.PlatComp;
                                result[3] = "PlatComs";
                               // Myadapter_p.UpdatePlatCom(temp.PlatComs, id);
                                return result;
                            }
                        }
                        break;
                    case 2:
                        for (int i = 0; i < count_p; i++)
                        {
                            int id = CommonFunction.platInfos[i].id;
                            //根据id查询出一条platinfo的记录
                            DataTable dt = Myadapter_p.GetDataBy1(id);
                            PlatInfo temp = DataHelper.Dt2pl(dt);
                            if (temp.PlatIcs.Equals("空闲") && IsAllow(temp))
                            {
                                temp.PlatIcs = "准备";
                                result[0] = id.ToString();
                                result[1] = temp.IP;
                                result[2] = temp.PlatIcp;
                                result[3] = "PlatIcs";
                               // Myadapter_p.UpdatePlatIc(temp.PlatIcs, id);
                                return result;
                            }
                        }
                        break;
                    case 3:
                        for (int i = 0; i < count_p; i++)
                        {
                            int id = CommonFunction.platInfos[i].id;
                            //根据id查询出一条platinfo的记录
                            DataTable dt = Myadapter_p.GetDataBy1(id);
                            PlatInfo temp = DataHelper.Dt2pl(dt);
                            if (type.Equals("膜式表")|| type.Equals("IC卡-膜式表"))
                            {
                                if (temp.PlatChus_msb.Equals("空闲") && IsAllow(temp))
                                {
                                    //temp.PlatChus_msb = "准备";
                                    result[0] = id.ToString();
                                    result[1] = temp.IP;
                                    result[2] = temp.PlatChup_msb;
                                    result[3] = "PlatChus_msb";
                                  //  Myadapter_p.UpdatePlatChu_msb(temp.PlatChus_msb, id);
                                    return result;
                                }
                            }
                            if (type.Equals("修正仪") ||type.Equals("IC卡-修正仪"))
                            {
                                if (temp.PlatChus_xzy.Equals("空闲") && IsAllow(temp))
                                {
                                    //temp.PlatChus_xzy = "准备";
                                    result[0] = id.ToString();
                                    result[1] = temp.IP;
                                    result[2] = temp.PlatChup_xzy;
                                    result[3] = "PlatChus_xzy";
                                   // Myadapter_p.UpdatePlatChu_xzy(temp.PlatChus_xzy, id);
                                    return result;
                                }
                            }
                            if (type.Equals("超声波") || type.Equals("IC卡-超声波"))
                            {
                                if (temp.PlatChus_csb.Equals("空闲") && IsAllow(temp))
                                {
                                    //temp.PlatChus_csb = "准备";
                                    result[0] = id.ToString();
                                    result[1] = temp.IP;
                                    result[2] = temp.PlatChup_csb;
                                    result[3] = "PlatChus_csb";
                                   // Myadapter_p.UpdatePlatChu_csb(temp.PlatChus_csb, id);
                                    return result;
                                }
                            }
                        }
                        break;
                    case 4:
                        for (int i = 0; i < count_p; i++)
                        {
                            int id = CommonFunction.platInfos[i].id;

                            //根据id查询出一条platinfo的记录
                            DataTable dt = Myadapter_p.GetDataBy1(id);
                            PlatInfo temp = DataHelper.Dt2pl(dt);
                            if (temp.PlatZhos.Equals("空闲") && IsAllow(temp))
                            {
                                //temp.PlatZhos = "准备";
                                result[0] = id.ToString();
                                result[1] = temp.IP;
                                result[2] = temp.PlatZhop;
                                result[3] = "PlatZhos";
                               // Myadapter_p.UpdatePlatZho(temp.PlatZhos, id);
                                return result;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (System.Exception e)
            {
                LogHelper.Error("分配时出错"+e);
            }            
            return result;
        }

        /// <summary>
        /// 检测电脑正在使用的检测平台的数目是否超过规定
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        private static bool IsAllow(PlatInfo temp)
        {
            int num = 0;
            num += (temp.PlatComs.Equals("空闲") || temp.PlatComs.Equals("未启用")) ? 0 : 1;
            num += (temp.PlatIcs.Equals("空闲") || temp.PlatIcs.Equals("未启用")) ? 0 : 1;
            num += (temp.PlatChus_msb.Equals("空闲") || temp.PlatChus_msb.Equals("未启用")) ? 0 : 1;
            num += (temp.PlatChus_xzy.Equals("空闲") || temp.PlatChus_xzy.Equals("未启用")) ? 0 : 1;
            num += (temp.PlatChus_csb.Equals("空闲") || temp.PlatChus_csb.Equals("未启用")) ? 0 : 1;
            num += (temp.PlatZhos.Equals("空闲") || temp.PlatZhos.Equals("未启用")) ? 0 : 1;
            int AllowNum = Convert.ToInt32(CommonFunction.dicBooks["AllowNum"]);
            return num < AllowNum ? true : false;
        }
    }
}
