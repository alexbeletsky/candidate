using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crawler.Core.Domain
{
    public class TddDemandRecord
    {
        public int TddDemandRecordID { get; set; }
        public string Site { get; set; }
        public string Company { get; set; }
        public string Position { get; set; }
        public string Technology { get; set; }
        public bool Demand { get; set; }
        public string Url { get; set; }
    }
}
