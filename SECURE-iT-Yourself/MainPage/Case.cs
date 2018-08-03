using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainPage
{
    class Case
    {
        public String C_Name { get; set; }
        public String C_Id { get; }
        public String C_Desc { get; set; }
        public List<String> C_Authors { get; set; }
        public String pathAuthors { get; set; }

        public Case(String C_Name, String C_Id, String C_Desc, List<String> C_Authors) {
            this.C_Name = C_Name;
            this.C_Id = C_Id;
            this.C_Desc = C_Desc;
            this.C_Authors = C_Authors;


        }

        public Case() {


        }

        public Case(String C_Name, String C_Desc, String path) {
            this.C_Name = C_Name;
            this.C_Desc = C_Desc;
            this.pathAuthors = path;
        }


        

    }
}
