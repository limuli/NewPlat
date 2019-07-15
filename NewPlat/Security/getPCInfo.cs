using Microsoft.Win32;
using NewPlat.MySuperSocket;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Text;

namespace NewPlat.Security
{
    class getPCInfo
    {
        public static bool IsValid(out string SerialNumber, out string KeyNow)
        {
            bool flag = false;
            string str = getPCInfo.GetMacAddressByNetworkInformation().Replace(":", "") + getPCInfo.getPhysicalID();
            SerialNumber = Decrypt.Gethash(str, "hr", 1, 5);
            string KeySave = ConfigurationManager.AppSettings["strkey"].ToString();
            KeyNow = Decrypt.Gethash(SerialNumber, "haha", 1, 10);
            if (KeySave == KeyNow)
            {
                flag = true;
            }
            return flag;
        }

        //获取硬盘序列号
        public static string getPhysicalID()
        {
            string num = "";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");

            try
            {
                foreach (ManagementObject mo in searcher.Get())
                {
                    num = mo["SerialNumber"].ToString().Trim();
                    break;
                }
            }
            catch (Exception)
            {
                num = "Z6E1NZ1Y";
                LogHelper.Error("读取硬盘序列号失败+\r\n");
            }


            return num;

        }

        public static string GetMacAddressByNetworkInformation()
        {
            string key = "SYSTEM\\CurrentControlSet\\Control\\Network\\{4D36E972-E325-11CE-BFC1-08002BE10318}\\";
            string macAddress = string.Empty;
            try
            {
                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface adapter in nics)
                {
                    if (adapter.NetworkInterfaceType == NetworkInterfaceType.Ethernet
                        && adapter.GetPhysicalAddress().ToString().Length != 0)
                    {
                        string fRegistryKey = key + adapter.Id + "\\Connection";
                        RegistryKey rk = Registry.LocalMachine.OpenSubKey(fRegistryKey, false);
                        if (rk != null)
                        {
                            string fPnpInstanceID = rk.GetValue("PnpInstanceID", "").ToString();
                            int fMediaSubType = Convert.ToInt32(rk.GetValue("MediaSubType", 0));
                            if (fPnpInstanceID.Length > 3 &&
                                fPnpInstanceID.Substring(0, 3) == "PCI")
                            {
                                macAddress = adapter.GetPhysicalAddress().ToString();
                                for (int i = 1; i < 6; i++)
                                {
                                    macAddress = macAddress.Insert(3 * i - 1, ":");
                                }
                                break;
                            }
                        }

                    }
                }
            }
            catch (Exception e)
            {
                LogHelper.Error(e.ToString());
                //这里写异常的处理  
            }
            return macAddress;
        }
    }
}