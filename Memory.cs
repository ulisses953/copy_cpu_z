using SolrNet.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace extratorDeInformacao
{
    public class Memory
    {
        public string Type { get; set; }
        public int Size { 
            get { return 1; } 
            set { } 
        }
        public string Channel { get; set; }
        public double  UncoreFrequency { get; set; }

        public Memory()
        {
            
        }
    }
}