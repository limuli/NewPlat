using NewPlat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NewPlat.BLL
{
    public class XmlRW
    {
        XmlElement root, theBook;
        XmlDocument xmldoc = new XmlDocument();
        string FileTitle = "";
       // string EndNode = "";
        /// <summary>
        /// xml读写类的构造方法
        /// </summary>
        /// <param name="FileTitle">xml文件的路径及文件名</param>
        public XmlRW(string FileTitle)
        {
            try
            {
                xmldoc.Load(FileTitle);
                this.FileTitle = FileTitle;
            }
            catch
            {
                XmlDeclaration dec = xmldoc.CreateXmlDeclaration("1.0", "UTF-8", null);
                xmldoc.AppendChild(dec);
                //创建一个根节点（一级）
                XmlElement rootparams = xmldoc.CreateElement("params");
                xmldoc.AppendChild(rootparams);
                //创建节点（二级）
                XmlNode nodeparam = xmldoc.CreateElement("param");

                XmlElement element1 = xmldoc.CreateElement("name");
                element1.InnerText = "";
                nodeparam.AppendChild(element1);

                XmlElement element2 = xmldoc.CreateElement("value");
                element2.InnerText = "";
                nodeparam.AppendChild(element2);
                rootparams.AppendChild(nodeparam);
                xmldoc.Save(FileTitle);
            }
        }
        /// <summary>
        /// xml文件读取
        /// </summary>
        /// <param name="EndNode">节点名字</param>
        /// <returns>xml节点下的值,错误返回"false"</returns>
        public string XmlRead(string EndNode)
        {
            try
            {
                string xmlReadContent = "";

                root = xmldoc.DocumentElement;
                //读取信息
                theBook = (XmlElement)root.SelectSingleNode("/params/param[name='" + EndNode + "']");
                xmlReadContent = theBook.GetElementsByTagName("value").Item(0).InnerText;
                return xmlReadContent;
            }
            catch { return "false"; }

        }
        /// <summary>
        /// xml文件写入
        /// </summary>
        /// <param name="EndNode">节点名字</param>
        /// <param name="insertContent">插入内容</param>
        /// <returns>正确返回true,错误返回false</returns>
        public bool XmlWrite(string EndNode, string insertContent)
        {
            try
            {

                root = xmldoc.DocumentElement;
                //写入信息
                theBook = (XmlElement)root.SelectSingleNode("/params/param[name='" + EndNode + "']");
                //如果节点存在
                if (theBook != null)
                    theBook.GetElementsByTagName("value").Item(0).InnerText = insertContent;
                else //节点存在
                {
                    //找到一级节点
                    XmlNode elementParams = root.SelectSingleNode("/params");
                    //创建节点（二级）
                    XmlNode nodeparam = xmldoc.CreateElement("param");
                    XmlElement element1 = xmldoc.CreateElement("name");
                    element1.InnerText = EndNode;
                    nodeparam.AppendChild(element1);

                    XmlElement element2 = xmldoc.CreateElement("value");
                    element2.InnerText = insertContent;
                    nodeparam.AppendChild(element2);
                    //二级节点添加到一级节点中
                    elementParams.AppendChild(nodeparam);
                }
                xmldoc.Save(FileTitle);
                return true;
            }
            catch { return false; }
        }
    }
}
