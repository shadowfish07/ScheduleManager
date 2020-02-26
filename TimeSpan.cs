using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 日程管理生成系统
{
    [SerializableAttribute]
    public  class TimeSpan:ICloneable
    {
        protected static int IDcount = 0;

        private string describsion="";
        private string outline = "";
        private int id;


        public string Describsion { get => describsion; set => describsion = value; }
        public string Outline { get => outline; set => outline = value; }
        public int ID { get => id;}

        public TimeSpan()
        {
            id = TimeSpan_Title.IDcount++;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }


    }
}
