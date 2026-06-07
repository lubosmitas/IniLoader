using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IniLoader;

namespace IniLoaderDemo
{ 
    public class Config
    {
        [IniItem("text")]
        public string Text { get; set; }

        [IniItem("number")]
        public int Number { get; set; }

        [IniItem("bit")]
        public bool Bit { get; set; }

        [IniItem("long_number")]
        public long LongNumber { get; set; }

        [IniItem("real")]
        public double Real { get; set; }
    }

}