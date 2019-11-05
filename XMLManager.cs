using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace 日程管理生成系统
{
    class XMLManager
    {
        private string pathName;
        private XDocument xDoc;
        private XElement xEle;

        public string PathName { get => pathName; set => pathName = value; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName">带后缀的xml文件名</param>
        public XMLManager(string fileName)
        {

            PathName = Path.Combine(Directory.GetCurrentDirectory(), fileName) ;
        }

        public void ConnectToXmlFile()
        {
            if (!File.Exists(PathName))
                ;
            else
            {
                xEle = XElement.Load(PathName);
            }

        }
    }
}
