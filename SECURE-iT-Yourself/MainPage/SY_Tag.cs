using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainPage
{
    class SY_Tag
    {
        public String TagName { get; set; }
        public String TagDesc { get; set; }
        public DateTime timeStart { get; set; }
        public DateTime timeEnd { get; set; }

        public SY_Tag(String TagName, String TagDesc, DateTime timeStart, DateTime timeEnd) {
            this.TagName = TagName;
            this.TagDesc = TagDesc;
            this.timeStart = timeStart;
            this.timeEnd = timeEnd;

        }



    }
}
