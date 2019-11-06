using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 日程管理生成系统
{
    [SerializableAttribute]
    public  class TimeSpan
    {
        protected static int Index = 0;

        private string describsion;
        private string outline;
        private int index1;


        public string Describsion { get => describsion; set => describsion = value; }
        public string Outline { get => outline; set => outline = value; }
        public int Index1 { get => index1; set => index1 = value; }

        public TimeSpan()
        {
            Index1 = TimeSpan_Title.Index++;
        }


    }
}
