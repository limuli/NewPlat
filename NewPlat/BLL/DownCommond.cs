using NewPlat.MySuperSocket;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPlat.BLL
{
    public static class DownCommond
    {
        /// <summary>
        /// 组下行命令
        /// </summary>
        /// <param name="Core">cmd_data</param>
        /// <param name="info">上行命令</param>
        /// <param name="IsPassive">是否为被动应答</param>
        /// <param name="isToEncrypt">是否需要加密</param>
        /// <returns></returns>
        public static string GenerateSendFrame(string Core, MyRequestInfo info, bool IsPassive, bool isToEncrypt)
        {
            string start = "15";
            //打包的控制码
            string Ctrl = "";
            string strPackNum = "0000";
            string strBinCtrlLeft = "0000000000000000";
            char[] charBinCtrlLeft = strBinCtrlLeft.ToCharArray();
            if (IsPassive == true)
            {
                charBinCtrlLeft[0] = '1';
                strPackNum = string.Format("{0:X4}", info.intPackNum);
            }
            if (isToEncrypt == true)
                charBinCtrlLeft[3] = '1';
            if (info.result == false && IsPassive == true)
                charBinCtrlLeft[1] = '1';
            strBinCtrlLeft = new string(charBinCtrlLeft);
            string strHexCtrlLeft = DataHelper.Bin2Hex(strBinCtrlLeft);
            Ctrl = strHexCtrlLeft + strPackNum;
            //定义校验码和终止位
            string strCS = "00";
            string end = "14";
            if (isToEncrypt)
            {
                string AesKey = info.EquipmentID + "5348414E474841495251"; ;
                //加密命令码和数据域
                Core = DataHelper.AesEncrypt(Core, AesKey);
            }
            string DataLength = string.Format("{0:X4}", Core.Length / 2);
            string strSend = start + info.EquipmentType + info.EquipmentID + Ctrl + DataLength + Core + strCS + end;
            strCS = DataHelper.GetChecksum(strSend);
            strSend = start + info.EquipmentType + info.EquipmentID + Ctrl + DataLength + Core + strCS + end;
            return strSend;
        }
        /// <summary>
        /// 修改网络参数命令
        /// </summary>
        /// <param name="ip">ip</param>
        /// <param name="port">端口</param>
        /// <param name="boolDomain">是否改域名</param>
        /// <param name="strContent">域名</param>
        /// <returns></returns>
        public static string GenerateCore81(string ip, string port, bool boolDomain, string strContent,string Rand_num)
        {
            byte[] btSend = new byte[52];
            byte[] bytesCmd = DataHelper.Str2Byte("81");
            bytesCmd.CopyTo(btSend, 0);
            string Port = Convert.ToString(int.Parse(port), 16);
            byte[] bytesPort = new byte[2];
            bytesPort = DataHelper.Str2Byte(Port);
            bytesPort.CopyTo(btSend, 6);
            if (boolDomain)
            {
                //修改内容
                byte[] bytesModifyContent = DataHelper.Str2Byte("06");
                bytesModifyContent.CopyTo(btSend, 1);
                string strDomain = strContent;
                byte[] bytesDomain = Encoding.ASCII.GetBytes(strDomain);
                bytesDomain.CopyTo(btSend, 8);
            }
            else
            {
                //修改内容
                byte[] bytesModifyContent = DataHelper.Str2Byte("03");
                bytesModifyContent.CopyTo(btSend, 1);
                //IP地址
                byte[] bytesIP = new byte[4];
                string[] strArrIP = ip.Split('.');
                string strIP = "";
                for (int i = 0; i < 4; i++)
                {
                    int intIP = Convert.ToInt32(strArrIP[i]);
                    strArrIP[i] = string.Format("{0:X2}", intIP);
                    strIP += strArrIP[i];
                }
                bytesIP = DataHelper.Str2Byte(strIP);
                bytesIP.CopyTo(btSend, 2);
            }
            byte[] bytesRandnum = new byte[4];
            bytesRandnum = DataHelper.Str2Byte(Rand_num);//4位随机码 
            bytesRandnum.CopyTo(btSend, 40);
            return DataHelper.Bytes2HexStr(btSend);
        }
        /// <summary>
        /// 常规数据应答
        /// </summary>
        /// <param name="type">应答类型</param>
        /// <param name="time_upload">下次常规数据上传时间间隔</param>
        /// <param name="time_per">采集周期与上传周期</param>
        /// <returns></returns>
        public static string GenerateCore0F(string type,int time_upload,int time_per)
        {
            string strCore = type;
            //日期时间
            DateTime dtTimeNow = DateTime.Now;
            string strTimeNow = dtTimeNow.ToString("yyMMddHHmmss");
            strCore += strTimeNow;
            int intCollectPeriod = time_per;
            int intUploadPeriod = time_per;
            string strCollectPeriod = string.Format("{0:X4}", intCollectPeriod);
            strCore += strCollectPeriod;
            string strUploadPeriod = string.Format("{0:X4}", intUploadPeriod);
            strCore += strUploadPeriod;
            string strBinManageWord = "0000000000000000";
            char[] charArrBinManageWord = strBinManageWord.ToCharArray();
            strBinManageWord = new string(charArrBinManageWord);
            string strHexManageWord = DataHelper.Bin2Hex(strBinManageWord);
            strCore += strHexManageWord;
            DateTime dt = DateTime.Now;
            dt = dt.AddMinutes(time_upload);
            String strUploadTime = string.Format("{0:D2}", dt.Hour);
            strUploadTime += string.Format("{0:D2}", dt.Minute);
            strCore += strUploadTime;
            strCore += "FFFF";
            return strCore;
        }
        public static string GenerateCore8F(String Rand_num)
        {
            byte[] btSend = new byte[5];
            byte[] bytesCmd = DataHelper.Str2Byte("8F");
            bytesCmd.CopyTo(btSend, 0);
            byte[] bytesRandnum = new byte[4];
            bytesRandnum = DataHelper.Str2Byte(Rand_num);//4位随机码 
            bytesRandnum.CopyTo(btSend, 1);
            return DataHelper.Bytes2HexStr(btSend);

        }
        public static string GenerateCore8E(String Rand_num)
        {
            byte[] btSend = new byte[5];
            byte[] bytesCmd = DataHelper.Str2Byte("8E");
            bytesCmd.CopyTo(btSend, 0);
            byte[] bytesRandnum = new byte[4];
            bytesRandnum = DataHelper.Str2Byte(Rand_num);//4位随机码 
            bytesRandnum.CopyTo(btSend, 1);
            return DataHelper.Bytes2HexStr(btSend);

        }
        public static string GenerateCore33(string id)
        {
            string strCore = "33";
            strCore += id;
            //Attention 用下面这个
            //strCore += DataHelper.IP2Str("127.0.0.1");
            //strCore += string.Format("{0:X4}", int.Parse("3001"));
            strCore += DataHelper.IP2Str(CommonFunction.dicBooks["strMainHostIP"]);
            strCore += string.Format("{0:X4}", int.Parse(CommonFunction.dicBooks["strMainHostPort"]));
            return strCore;
        }
        public static string GenerateCorekeep()
        {
            string Core = "44";
            Core += DataHelper.IP2Str(CommonFunction.dicBooks["strMainHostIP"]);
            Core += string.Format("{0:X4}", int.Parse(CommonFunction.dicBooks["strMainHostPort"]));
            string start = "15";
            //打包的控制码
            string Ctrl = "";
            string strPackNum = "0000";
            string strBinCtrlLeft = "0000000000000000";
            char[] charBinCtrlLeft = strBinCtrlLeft.ToCharArray();
            strBinCtrlLeft = new string(charBinCtrlLeft);
            string strHexCtrlLeft = DataHelper.Bin2Hex(strBinCtrlLeft);
            Ctrl = strHexCtrlLeft + strPackNum;
            //定义校验码和终止位
            string strCS = "00";
            string end = "14";
            string DataLength = string.Format("{0:X4}", Core.Length / 2);
            string strSend = start + "00" + "000000000000" + Ctrl + DataLength + Core + strCS + end;
            strCS = DataHelper.GetChecksum(strSend);
            strSend = start + "00" + "000000000000" + Ctrl + DataLength + Core + strCS + end;
            return strSend;

        }
        /// <summary>
        /// 主上行+子上行+读取事件记录+文件名
        /// 表号Id+通讯号Com_no+版本号Sw_rlse+工况体积Real_vol+仪表电压Meter_v+温度值Temperature+状态Status+事件记录数Num+（事件代码RecordCode+时间RecordTime+累积量RecordAmount）+文件名FileNam
        /// 6+8+2+5+2+2+2+1+(1+3+4)*num+16
        /// </summary>
        /// <param name="dt">数据库数据</param>
        /// <returns></returns>
        public static string GenerateCore34_Chu_msb(DataTable dt)
        {
            DataRow dr = dt.Rows[0];
            string Id = dr["MeterId"].ToString();
            string Com_no = dr["Com_no_msb"].ToString().PadLeft(16, '0');
            string Sw_rlse = dr["Sw_rlse_msb"].ToString();
            string Real_vol = ((decimal)dr["Real_vol"]).ToString("00000000.00").Replace(".", "");
            string Meter_v = ((decimal)dr["Meter_v"]).ToString("00.00").Replace(".", "");
            string Temperature = ((decimal)dr["Temperature_msb"]).ToString("00.00").Replace(".", "");           
            string Status = dr["Status"].ToString().PadLeft(4, '0');
            StringBuilder s = new StringBuilder();
            int num = 0;
            //string sf = dr["DropMeter1_msb"].ToString();
            if (dr["DropMeter1_msb"].ToString() != "")
            {
                s.Append("01");
                s.Append(((DateTime)dr["DropMeter1_msb"]).ToString("MMddHH"));
                s.Append(((decimal)dr["DropMeter2_msb"]).ToString("000000.00").Replace(".",""));
                num = num + 1;
            }
            if (dr["ReverseInstall1_msb"].ToString() != "")
            {
                s.Append("02");
                s.Append(((DateTime)dr["ReverseInstall1_msb"]).ToString("MMddHH"));
                s.Append(((decimal)dr["ReverseInstall2_msb"]).ToString("000000.00").Replace(".", ""));
                num = num + 1;
            }
            if (dr["MeasureBreakdown1_msb"].ToString() != "")
            {
                s.Append("03");
                s.Append(((DateTime)dr["MeasureBreakdown1_msb"]).ToString("MMddHH"));
                s.Append(((decimal)dr["MeasureBreakdown2_msb"]).ToString("000000.00").Replace(".", ""));
                num = num + 1;
            }
            if (dr["TSensorBreakdown1_msb"].ToString() != "")
            {
                s.Append("04");
                s.Append(((DateTime)dr["TSensorBreakdown1_msb"]).ToString("MMddHH"));
                s.Append(((decimal)dr["TSensorBreakdown2_msb"]).ToString("000000.00").Replace(".", ""));
                num = num + 1;
            }
            if (dr["PSensorBreakdown1_msb"].ToString() != "")
            {
                s.Append("05");
                s.Append(((DateTime)dr["PSensorBreakdown1_msb"]).ToString("MMddHH"));
                s.Append(((decimal)dr["PSensorBreakdown2_msb"]).ToString("000000.00").Replace(".", ""));
                num = num + 1;
            }
            if (dr["TrafficAbnormality1_msb"].ToString() != "")
            {
                s.Append("06");
                s.Append(((DateTime)dr["TrafficAbnormality1_msb"]).ToString("MMddHH"));
                s.Append(((decimal)dr["TrafficAbnormality2_msb"]).ToString("000000.00").Replace(".", ""));
                num = num + 1;
            }
            if (dr["ComVol1_msb"].ToString() != "")
            {
                s.Append("07");
                s.Append(((DateTime)dr["ComVol1_msb"]).ToString("MMddHH"));
                s.Append(((decimal)dr["ComVol2_msb"]).ToString("000000.00").Replace(".", ""));
                num = num + 1;
            }
            if (dr["BaseVol1_msb"].ToString() != "")
            {
                s.Append("08");
                s.Append(((DateTime)dr["BaseVol1_msb"]).ToString("MMddHH"));
                s.Append(((decimal)dr["BaseVol2_msb"]).ToString("000000.00").Replace(".", ""));
                num = num + 1;
            }
            if (dr["CollectFault1_msb"].ToString() != "")
            {
                s.Append("09");
                s.Append(((DateTime)dr["CollectFault1_msb"]).ToString("MMddHH"));
                s.Append(((decimal)dr["CollectFault2_msb"]).ToString("000000.00").Replace(".", ""));
                num = num + 1;
            }
            if (dr["GasLeakClose1_msb"].ToString() != "")
            {
                s.Append("0A");
                s.Append(((DateTime)dr["GasLeakClose1_msb"]).ToString("MMddHH"));
                s.Append(((decimal)dr["GasLeakClose2_msb"]).ToString("000000.00").Replace(".", ""));
                num = num + 1;
            }
            if (dr["GasStolenClose1_msb"].ToString() != "")
            {
                s.Append("0B");
                s.Append(((DateTime)dr["GasStolenClose1_msb"]).ToString("MMddHH"));
                s.Append(((decimal)dr["GasStolenClose2_msb"]).ToString("000000.00").Replace(".", ""));
                num = num + 1;
            }
            if (dr["ResetClose1_msb"].ToString() != "")
            {
                s.Append("0C");
                s.Append(((DateTime)dr["ResetClose1_msb"]).ToString("MMddHH"));
                s.Append(((decimal)dr["ResetClose2_msb"]).ToString("000000.00").Replace(".", ""));
                num = num + 1;
            }
            if (dr["LowVolClose1_msb"].ToString() != "")
            {
                s.Append("0D");
                s.Append(((DateTime)dr["LowVolClose1_msb"]).ToString("MMddHH"));
                s.Append(((decimal)dr["LowVolClose2_msb"]).ToString("000000.00").Replace(".", ""));
                num = num + 1;
            }
            if (dr["CollectClose1_msb"].ToString() != "")
            {
                s.Append("0E");
                s.Append(((DateTime)dr["CollectClose1_msb"]).ToString("MMddHH"));
                s.Append(((decimal)dr["CollectClose2_msb"]).ToString("000000.00").Replace(".", ""));
                num = num + 1;
            }
            if (dr["CommandClose1_msb"].ToString() != "")
            {
                s.Append("0F");
                s.Append(((DateTime)dr["CommandClose1_msb"]).ToString("MMddHH"));
                s.Append(((decimal)dr["CommandClose2_msb"]).ToString("000000.00").Replace(".", ""));
                num = num + 1;
            }
            if (dr["ManulOpen1_msb"].ToString() != "")
            {
                s.Append("0F");
                s.Append(((DateTime)dr["ManulOpen1_msb"]).ToString("MMddHH"));
                s.Append(((decimal)dr["ManulOpen2" +
                    "_msb"]).ToString("000000.00").Replace(".", ""));
                num = num + 1;
            }
            string com85 = s.ToString();
            string Num = num.ToString("00");
            byte[] FileName = System.Text.Encoding.ASCII.GetBytes(dr["FileName_msb"].ToString());//按原程序的远程升级下行命令来写文件名
            string file =  DataHelper.Bytes2HexStr(FileName).PadRight(32, '0');
            StringBuilder outdata = new StringBuilder();
            outdata.Append(Id).Append(Com_no).Append(Sw_rlse).Append(Real_vol).Append(Meter_v).Append(Temperature).Append(Status).Append(Num).Append(com85).Append(file);
            return outdata.ToString();
        }
        /// <summary>
        /// 主上行+子上行+读取事件记录+文件名
        /// 表号Id+通讯号Com_no+版本号Sw_rlse+温度值Temperature+压力Pressure +标况累积体积Standard_vol
        /// +工况累积体积Real_vol+受扰累积体积Interfere_vol+校正系数Compress_factor+标况瞬时流量Standard _flow+工况瞬时流量Real_flow
        /// +事件记录数Num+（事件代码RecordCode+时间RecordTime+累积量RecordAmount）+文件名FileName
        /// 6+8+2+5+2+2+2+1+(1+3+4)*num+16
        /// </summary>
        /// <param name="dt">数据库数据</param>
        /// <returns></returns>
        public static string GenerateCore34_Chu_xzy(DataTable dt)
        {
            DataRow dr = dt.Rows[0];
            string Id = dr["MeterId"].ToString();
            string Com_no = dr["Com_no_xzy"].ToString().PadLeft(16, '0');
            string Sw_rlse = dr["Sw_rlse_xzy"].ToString();
            string Temperature = ((decimal)dr["Temperature_xzy"]).ToString("00.00").Replace(".", "");
            string Pressure = ((decimal)dr["Pressure"]).ToString("00000000").Replace(".", "");
            string Standard_vol = ((decimal)dr["Stan_Total_Vol"]).ToString("0000000000.00").Replace(".", "");
            string Real_vol = ((decimal)dr["Work_Total_Vol"]).ToString("0000000000.00").Replace(".", "");
            string Interfere_vol = ((decimal)dr["Disturb_Total_Vol"]).ToString("000000.00").Replace(".", "");
            string Compress_factor = ((decimal)dr["Correction_E"]).ToString("00.00").Replace(".", "");
            string Standard_flow = ((decimal)dr["Stan_Ins_Ele_xzy"]).ToString("0000.00").Replace(".", "");
            string Real_flow = ((decimal)dr["Work_Ins_Ele_xzy"]).ToString("0000.00").Replace(".", "");
            StringBuilder s = new StringBuilder();
            int num = 0;
            if (dr["DropMeter1_xzy"].ToString() != "")
            {
                s.Append("01");
                s.Append(((DateTime)dr["DropMeter1_msb"]).ToString("MMddHH"));
                s.Append(((decimal)dr["DropMeter2_msb"]).ToString("000000.00").Replace(".", ""));
                num = num + 1;
            }
            if (dr["ReverseInstall1_xzy"].ToString() != "")
            {
                s.Append("02");
                s.Append(((DateTime)dr["ReverseInstall1_msb"]).ToString("MMddHH"));
                s.Append(((decimal)dr["ReverseInstall2_msb"]).ToString("000000.00").Replace(".", ""));
                num = num + 1;
            }
            if (dr["MeasureBreakdown1_xzy"].ToString() != "")
            {
                s.Append("03");
                s.Append(((DateTime)dr["MeasureBreakdown1_msb"]).ToString("MMddHH"));
                s.Append(((decimal)dr["MeasureBreakdown2_msb"]).ToString("000000.00").Replace(".", ""));
                num = num + 1;
            }
            if (dr["TSensorBreakdown1_xzy"].ToString() != "")
            {
                s.Append("04");
                s.Append(((DateTime)dr["TSensorBreakdown1_msb"]).ToString("MMddHH"));
                s.Append(((decimal)dr["TSensorBreakdown2_msb"]).ToString("000000.00").Replace(".", ""));
                num = num + 1;
            }
            if (dr["PSensorBreakdown1_xzy"].ToString() != "")
            {
                s.Append("05");
                s.Append(((DateTime)dr["PSensorBreakdown1_msb"]).ToString("MMddHH"));
                s.Append(((decimal)dr["PSensorBreakdown2_msb"]).ToString("000000.00").Replace(".", ""));
                num = num + 1;
            }
            if (dr["TrafficAbnormality1_xzy"].ToString() != "")
            {
                s.Append("06");
                s.Append(((DateTime)dr["TrafficAbnormality1_msb"]).ToString("MMddHH"));
                s.Append(((decimal)dr["TrafficAbnormality2_msb"]).ToString("000000.00").Replace(".", ""));
                num = num + 1;
            }
            if (dr["ComVol1_xzy"].ToString() != "")
            {
                s.Append("07");
                s.Append(((DateTime)dr["ComVol1_msb"]).ToString("MMddHH"));
                s.Append(((decimal)dr["ComVol2_msb"]).ToString("000000.00").Replace(".", ""));
                num = num + 1;
            }
            if (dr["BaseVol1_xzy"].ToString() != "")
            {
                s.Append("08");
                s.Append(((DateTime)dr["BaseVol1_msb"]).ToString("MMddHH"));
                s.Append(((decimal)dr["BaseVol2_msb"]).ToString("000000.00").Replace(".", ""));
                num = num + 1;
            }
            if (dr["CollectFault1_xzy"].ToString() != "")
            {
                s.Append("09");
                s.Append(((DateTime)dr["CollectFault1_msb"]).ToString("MMddHH"));
                s.Append(((decimal)dr["CollectFault2_msb"]).ToString("000000.00").Replace(".", ""));
                num = num + 1;
            }
            if (dr["GasLeakClose1_xzy"].ToString() != "")
            {
                s.Append("0A");
                s.Append(((DateTime)dr["GasLeakClose1_msb"]).ToString("MMddHH"));
                s.Append(((decimal)dr["GasLeakClose2_msb"]).ToString("000000.00").Replace(".", ""));
                num = num + 1;
            }
            if (dr["GasStolenClose1_xzy"].ToString() != "")
            {
                s.Append("0B");
                s.Append(((DateTime)dr["GasStolenClose1_msb"]).ToString("MMddHH"));
                s.Append(((decimal)dr["GasStolenClose2_msb"]).ToString("000000.00").Replace(".", ""));
                num = num + 1;
            }
            if (dr["ResetClose1_xzy"].ToString() != "")
            {
                s.Append("0C");
                s.Append(((DateTime)dr["ResetClose1_msb"]).ToString("MMddHH"));
                s.Append(((decimal)dr["ResetClose2_msb"]).ToString("000000.00").Replace(".", ""));
                num = num + 1;
            }
            if (dr["LowVolClose1_xzy"].ToString() != "")
            {
                s.Append("0D");
                s.Append(((DateTime)dr["LowVolClose1_msb"]).ToString("MMddHH"));
                s.Append(((decimal)dr["LowVolClose2_msb"]).ToString("000000.00").Replace(".", ""));
                num = num + 1;
            }
            if (dr["CollectClose1_xzy"].ToString() != "")
            {
                s.Append("0E");
                s.Append(((DateTime)dr["CollectClose1_msb"]).ToString("MMddHH"));
                s.Append(((decimal)dr["CollectClose2_msb"]).ToString("000000.00").Replace(".", ""));
                num = num + 1;
            }
            if (dr["CommandClose1_xzy"].ToString() != "")
            {
                s.Append("0F");
                s.Append(((DateTime)dr["CommandClose1_msb"]).ToString("MMddHH"));
                s.Append(((decimal)dr["CommandClose2_msb"]).ToString("000000.00").Replace(".", ""));
                num = num + 1;
            }
            if (dr["ManulOpen1_xzy"].ToString() != "")
            {
                s.Append("0F");
                s.Append(((DateTime)dr["ManulOpen1_msb"]).ToString("MMddHH"));
                s.Append(((decimal)dr["ManulOpen2" +
                    "_msb"]).ToString("000000.00").Replace(".", ""));
                num = num + 1;
            }
            string com85 = s.ToString();
            string Num = num.ToString("00");
            byte[] FileName = System.Text.Encoding.ASCII.GetBytes(dr["FileName_xzy"].ToString());//按原程序的远程升级下行命令来写文件名
            string file = DataHelper.Bytes2HexStr(FileName).PadRight(32, '0');
            StringBuilder outdata = new StringBuilder();
            outdata.Append(Id).Append(Com_no).Append(Sw_rlse).Append(Real_vol).Append(Temperature).Append(Pressure).Append(Standard_vol).Append(Real_vol).Append(Interfere_vol).Append(Compress_factor).Append(Standard_flow).Append(Real_flow).Append(Num).Append(com85).Append(file);
            return outdata.ToString();
        }
        /// <summary>
        /// 主上行+子上行+读取事件记录+文件名
        /// 表号Id+通讯号Com_no+版本号Sw_rlse+电压值1Meter_v1+电压值2Meter_v2+表具状态字Status_word +表内状态字Meterstatus_word 
        /// 标况累积流量Total_standard_flow+工况累积流量Total_real_flow+标况瞬时流量Standard_flow+工况瞬时流量Real_flow
        /// 温度值Temperature+压力Pressure +时段峰值流量Peak_flow
        /// +事件记录数Num+（事件代码RecordCode+时间RecordTime+累积量RecordAmount）+文件名FileNam
        /// 6+8+2+5+2+2+2+1+(1+3+4)*num+16
        /// </summary>
        /// <param name="dt">数据库数据</param>
        /// <returns></returns>
        public static string GenerateCore34_Chu_csb(DataTable dt)
        {
            DataRow dr = dt.Rows[0];
            string Id = dr["MeterId"].ToString();
            string Com_no = dr["Com_no_csb"].ToString().PadLeft(16, '0');
            string Sw_rlse = dr["Sw_rlse_csb"].ToString();
            string Meter_v1 = ((decimal)dr["Vol1"]).ToString("00.00").Replace(".", "");
            string Meter_v2 = ((decimal)dr["Vol2"]).ToString("00.00").Replace(".", "");
            string Status_word = (dr["MeterStateWord"]).ToString();
            string Meterstatus_word = (dr["MeterInStateWord"]).ToString();
            string Total_standard_flow = ((decimal)dr["Stan_Total_Ele"]).ToString("00000000.00").Replace(".", "");
            string Total_real_flow = ((decimal)dr["Work_Total_Ele"]).ToString("00000000.00").Replace(".", "");
            string Standard_flow = ((decimal)dr["Stan_Ins_Ele_csb"]).ToString("000.000").Replace(".", "");
            string Real_flow = ((decimal)dr["Work_Ins_Ele_csb"]).ToString("000.000").Replace(".", "");
            string Temperature = ((decimal)dr["Temperature_csb"]).ToString("00.00").Replace(".", "");
            string Pressure = ((decimal)dr["PValue"]).ToString("00000.000").Replace(".", "");
            string Peak_flow = ((decimal)dr["Peak_Ele"]).ToString("000.000").Replace(".", "");
            StringBuilder s = new StringBuilder();
            int num = 0;
            if (dr["DropMeter1_csb"].ToString() != "")
            {
                s.Append("01");
                s.Append(((DateTime)dr["DropMeter1_msb"]).ToString("MMddHH"));
                s.Append(((decimal)dr["DropMeter2_msb"]).ToString("000000.00").Replace(".", ""));
                num = num + 1;
            }
            if (dr["ReverseInstall1_csb"].ToString() != "")
            {
                s.Append("02");
                s.Append(((DateTime)dr["ReverseInstall1_msb"]).ToString("MMddHH"));
                s.Append(((decimal)dr["ReverseInstall2_msb"]).ToString("000000.00").Replace(".", ""));
                num = num + 1;
            }
            if (dr["MeasureBreakdown1_csb"].ToString() != "")
            {
                s.Append("03");
                s.Append(((DateTime)dr["MeasureBreakdown1_msb"]).ToString("MMddHH"));
                s.Append(((decimal)dr["MeasureBreakdown2_msb"]).ToString("000000.00").Replace(".", ""));
                num = num + 1;
            }
            if (dr["TSensorBreakdown1_csb"].ToString() != "")
            {
                s.Append("04");
                s.Append(((DateTime)dr["TSensorBreakdown1_msb"]).ToString("MMddHH"));
                s.Append(((decimal)dr["TSensorBreakdown2_msb"]).ToString("000000.00").Replace(".", ""));
                num = num + 1;
            }
            if (dr["PSensorBreakdown1_csb"].ToString() != "")
            {
                s.Append("05");
                s.Append(((DateTime)dr["PSensorBreakdown1_msb"]).ToString("MMddHH"));
                s.Append(((decimal)dr["PSensorBreakdown2_msb"]).ToString("000000.00").Replace(".", ""));
                num = num + 1;
            }
            if (dr["TrafficAbnormality1_csb"].ToString() != "")
            {
                s.Append("06");
                s.Append(((DateTime)dr["TrafficAbnormality1_msb"]).ToString("MMddHH"));
                s.Append(((decimal)dr["TrafficAbnormality2_msb"]).ToString("000000.00").Replace(".", ""));
                num = num + 1;
            }
            if (dr["ComVol1_csb"].ToString() != "")
            {
                s.Append("07");
                s.Append(((DateTime)dr["ComVol1_msb"]).ToString("MMddHH"));
                s.Append(((decimal)dr["ComVol2_msb"]).ToString("000000.00").Replace(".", ""));
                num = num + 1;
            }
            if (dr["BaseVol1_csb"].ToString() != "")
            {
                s.Append("08");
                s.Append(((DateTime)dr["BaseVol1_msb"]).ToString("MMddHH"));
                s.Append(((decimal)dr["BaseVol2_msb"]).ToString("000000.00").Replace(".", ""));
                num = num + 1;
            }
            if (dr["CollectFault1_csb"].ToString() != "")
            {
                s.Append("09");
                s.Append(((DateTime)dr["CollectFault1_msb"]).ToString("MMddHH"));
                s.Append(((decimal)dr["CollectFault2_msb"]).ToString("000000.00").Replace(".", ""));
                num = num + 1;
            }
            if (dr["GasLeakClose1_csb"].ToString() != "")
            {
                s.Append("0A");
                s.Append(((DateTime)dr["GasLeakClose1_msb"]).ToString("MMddHH"));
                s.Append(((decimal)dr["GasLeakClose2_msb"]).ToString("000000.00").Replace(".", ""));
                num = num + 1;
            }
            if (dr["GasStolenClose1_csb"].ToString() != "")
            {
                s.Append("0B");
                s.Append(((DateTime)dr["GasStolenClose1_msb"]).ToString("MMddHH"));
                s.Append(((decimal)dr["GasStolenClose2_msb"]).ToString("000000.00").Replace(".", ""));
                num = num + 1;
            }
            if (dr["ResetClose1_csb"].ToString() != "")
            {
                s.Append("0C");
                s.Append(((DateTime)dr["ResetClose1_msb"]).ToString("MMddHH"));
                s.Append(((decimal)dr["ResetClose2_msb"]).ToString("000000.00").Replace(".", ""));
                num = num + 1;
            }
            if (dr["LowVolClose1_csb"].ToString() != "")
            {
                s.Append("0D");
                s.Append(((DateTime)dr["LowVolClose1_msb"]).ToString("MMddHH"));
                s.Append(((decimal)dr["LowVolClose2_msb"]).ToString("000000.00").Replace(".", ""));
                num = num + 1;
            }
            if (dr["CollectClose1_csb"].ToString() != "")
            {
                s.Append("0E");
                s.Append(((DateTime)dr["CollectClose1_msb"]).ToString("MMddHH"));
                s.Append(((decimal)dr["CollectClose2_msb"]).ToString("000000.00").Replace(".", ""));
                num = num + 1;
            }
            if (dr["CommandClose1_csb"].ToString() != "")
            {
                s.Append("0F");
                s.Append(((DateTime)dr["CommandClose1_msb"]).ToString("MMddHH"));
                s.Append(((decimal)dr["CommandClose2_msb"]).ToString("000000.00").Replace(".", ""));
                num = num + 1;
            }
            if (dr["ManulOpen1_csb"].ToString() != "")
            {
                s.Append("0F");
                s.Append(((DateTime)dr["ManulOpen1_msb"]).ToString("MMddHH"));
                s.Append(((decimal)dr["ManulOpen2" +
                    "_msb"]).ToString("000000.00").Replace(".", ""));
                num = num + 1;
            }
            string com85 = s.ToString();
            string Num = num.ToString("00");
            byte[] FileName = System.Text.Encoding.ASCII.GetBytes(dr["FileName"].ToString());//按原程序的远程升级下行命令来写文件名
            string file = DataHelper.Bytes2HexStr(FileName).PadRight(32, '0');
            StringBuilder outdata = new StringBuilder();
            outdata.Append(Id).Append(Com_no).Append(Sw_rlse).Append(Meter_v1).Append(Meter_v2).Append(Status_word).Append(Meterstatus_word).Append(Total_standard_flow).Append(Total_real_flow).Append(Standard_flow).Append(Real_flow).Append(Temperature).Append(Pressure).Append(Peak_flow).Append(Num).Append(com85).Append(file);
            return outdata.ToString();
        }
        /// <summary>
        /// Num+CommandCode
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string GenerateCore34_Com(DataTable dt,string type)
        {
            DataRow dr = dt.Rows[0];
            string Id = dr["MeterId"].ToString();
            // string Num = dr["Com_no_csb"].ToString();
            string CommandCode = "";
            if (type =="msb")
                CommandCode = dr["Sw_rlse_msb"].ToString();
            if(type == "xzy")
                CommandCode = dr["Sw_rlse_xzy"].ToString();
            if (type == "csb")
                CommandCode = dr["Sw_rlse_csb"].ToString();
            StringBuilder outdata = new StringBuilder();
            outdata.Append(Id).Append(CommandCode);
            return outdata.ToString();
        }
        /// <summary>
        /// 当前单价CurrentPrice +价格体系启用时间PriceSysDate
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string GenerateCore34_Ic(DataTable dt)
        {
            DataRow dr = dt.Rows[0];
            string Id = dr["MeterId"].ToString();
            string CurrentPrice = ((decimal)dr["CurrentPrice"]).ToString("00.00").Replace(".", "");
            string PriceSysDate = ((DateTime)dr["PriceSysDate"]).ToString("yyMMddHHmmss");
            StringBuilder outdata = new StringBuilder();
            outdata.Append(Id).Append(CurrentPrice).Append(PriceSysDate);
            return outdata.ToString();
        }
        public static string GenerateCore34_Zho(DataTable dt)
        {
            DataRow dr = dt.Rows[0];
            string Id = dr["MeterId"].ToString();
            string Com_no = dr["Com_no_csb"].ToString();
            string Sw_rlse = dr["Sw_rlse_csb"].ToString();
            string Meter_v1 = ((decimal)dr["Meter_v1"]).ToString("00.00").Replace(".", "");
            string Meter_v2 = ((decimal)dr["Meter_v2"]).ToString("00.00").Replace(".", "");
            string Meterstatus_word = ((int)dr["Meterstatus_word"]).ToString("00").Replace(".", "");
            string Total_standard_flow = ((decimal)dr["Total_standard_flow"]).ToString("00000000.00").Replace(".", "");
            string Total_real_flow = ((decimal)dr["Total_real_flow"]).ToString("00000000.00").Replace(".", "");
            string Standard_flow = ((decimal)dr["Standard_flow"]).ToString("0000.00").Replace(".", "");
            string Real_flow = ((decimal)dr["Total_real_flow"]).ToString("0000.00").Replace(".", "");
            string Temperature = ((decimal)dr["Temperature_xzy"]).ToString("00.00").Replace(".", "");
            string Pressure = ((decimal)dr["Pressure"]).ToString("00000000").Replace(".", "");
            string Peak_flow = ((decimal)dr["Peak_flow"]).ToString("0000.00").Replace(".", "");
            StringBuilder outdata = new StringBuilder();
            outdata.Append(Id).Append(Com_no).Append(Sw_rlse).Append(Meter_v1).Append(Meter_v2).Append(Meterstatus_word).Append(Total_standard_flow).Append(Total_real_flow).Append(Standard_flow).Append(Real_flow).Append(Temperature).Append(Pressure).Append(Peak_flow);
            return outdata.ToString();
        }

    }
}
