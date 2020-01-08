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

        public string PathName { get => pathName; set => pathName = value; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName">带后缀的xml文件名</param>
        public XMLManager(string fileName)
        {

            PathName = Path.Combine(Directory.GetCurrentDirectory(), fileName) ;
            PathName += ".xml";
        }

        //TODO:实现写入时已存在同名文件，增加序列号
        //private string  getVaildPath(string pathName)
        //{
        //    string tmp = pathName;
        //    string result = pathName;
        //    int i = 0;
        //    string addS;
        //    while (File.Exists(tmp))
        //    {
                
        //    }

        //}

        public void WriteXmlBniary(Table table)
        {
            Stream fStream = new FileStream(PathName, FileMode.Create, FileAccess.ReadWrite);
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binary = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            binary.Serialize(fStream, table);
            fStream.Close();
        }

        //TODO:文件不存在时的错误处理
        public Table ReadXmlBniary(string fileName)
        {
            Table result;
            string pathName = Path.Combine(Directory.GetCurrentDirectory(), fileName);
            Stream fStream = new FileStream(pathName, FileMode.Open, FileAccess.ReadWrite);
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binary = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            result = (Table)binary.Deserialize(fStream);
            return result;
        }

    }
}
