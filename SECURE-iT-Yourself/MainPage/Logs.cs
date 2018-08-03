using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainPage
{
    class Logs
    {
        public String Log_Name { get; set; }
        public String Log_Desc { get; set; }
        public String Log_Path { get; set; }

        public Logs(String Log_Name, String Log_Desc, String Log_Path) {
            this.Log_Name = Log_Name;
            this.Log_Desc = Log_Desc;
            this.Log_Path = Log_Path;

        }


    }
}
