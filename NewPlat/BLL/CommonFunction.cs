
using NewPlat.Model;
using NewPlat.MyDataSetTableAdapters;
using NewPlat.MySuperSocket;
using NewPlat.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPlat.BLL
{
   class CommonFunction
    {
        //饿汉单例模式
        public static HcSql hs = new HcSql();
        public static readonly object obj_66 = new object();
        public static readonly object obj_44 = new object();
        public static bool flag_listener;
        public static volatile Dictionary<string,HeartInfo> hearts = new Dictionary<string,HeartInfo>();
        //public static DT_ResultTableAdapter Myadapter_r = new DT_ResultTableAdapter();
        //public static Dt_MeterInfoTableAdapter Myadapter = new Dt_MeterInfoTableAdapter();
        //public static Dt_PlateInfoTableAdapter Myadapter_p = new Dt_PlateInfoTableAdapter();
        //public static Dt_Chu_csbTableAdapter Myadapter_csb = new Dt_Chu_csbTableAdapter();
        //public static Dt_Chu_xzyTableAdapter Myadapter_xzy = new Dt_Chu_xzyTableAdapter();
        //public static Dt_Chu_msbTableAdapter Myadapter_msb = new Dt_Chu_msbTableAdapter();
        //public static Dt_IcTableAdapter Myadapter_Ic = new Dt_IcTableAdapter();
        //public static Dt_MPTableAdapter Myadapter_Mp = new Dt_MPTableAdapter();
        //public static MyDataSet myDataSet = new MyDataSet();
        public static Dictionary<string, string> dicAppConfig = new Dictionary<string, string>();
        public static Dictionary<string, string> dicBooks = new Dictionary<string, string>();
        public static Dictionary<string, string> dic_cancel = new Dictionary<string, string>();
        public static Welcome frmWelcome = new Welcome();
        /// <summary>
        /// 存放平台信息，这里主要用于查询IP与port
        /// </summary>
        public static volatile Dictionary<int, PlatInfo> platInfos = new Dictionary<int, PlatInfo>();

        public static XmlRW xml = new XmlRW("books.xml");
        public static PlatManger platm = null;
        public static MyServer myServer = new MyServer();

    }
}
