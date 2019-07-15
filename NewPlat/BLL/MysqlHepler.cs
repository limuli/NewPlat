using MySql.Data.MySqlClient;
using NewPlat.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;


namespace NewPlat.BLL
{
    public static class MysqlHepler
    {
        static  MySqlConnection mc;
        /// <summary>
        ///数据库开启连接 
        /// </summary>
        /// <param name="Address">数据库地址ip</param>
        /// <param name="User">用户名</param>
        /// <param name="Password">密码</param>
        /// <returns>是否连接成功</returns>
         private static bool SqlConnect(string Address, string User, string Password)
        {
            string strsqlopen = String.Format(@"Database=mygas0;Data Source={0};User Id={1};Password={2};pooling=false;CharSet=utf8;port=3306", Address, User, Password);
            mc = new MySqlConnection(strsqlopen);
            try
            {
                mc.Open();
            }
            catch
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 打开数据库
        /// </summary>
        /// <returns>true打开 false失败</returns>
        public static bool SqlOpen()
        {
            string Address;
            string User;
            string Password;
            StreamReader sr = new StreamReader("server.config", Encoding.Default);
            Address = sr.ReadLine();
            User = sr.ReadLine();
            Password = sr.ReadLine();
            return SqlConnect(Address, User, Password);
        }
        /// <summary>
        /// 关闭数据库
        /// </summary>
        /// <returns>是否关闭成功</returns>
        public static bool SqlClose()
        {
            if (mc == null)
            { return true; }
            try
            {
                mc.Close();
                mc.Dispose();
            }
            catch
            {
                return false;
            }
            return true;

        }

        /// <summary>
        /// 执行数据库语句，返回dataset
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static DataSet SqlReturnDs(string cmd)
        {
            MySqlDataAdapter msqladapter = new MySqlDataAdapter(cmd, mc);
            DataSet ds = new DataSet();
            try
            {
                msqladapter.Fill(ds);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            return ds;
        }
        /// <summary>
        /// 非查询执行语句
        /// </summary>
        /// <param name="cmd">数据库语句</param>
        /// <returns></returns>
        public static bool SqlCmd(string cmd)
        {
            MySqlCommand msqlcmd = new MySqlCommand(cmd, mc);
            try
            {
                msqlcmd.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            return true;
        }


        
    }
}