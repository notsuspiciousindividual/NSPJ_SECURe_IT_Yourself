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
        public String C_Name { get; }
        public String C_Id { get; }
        public String C_Desc { get; }
        public ArrayList C_Authors { get; }

        public Case(String C_Name, String C_Id, String C_Desc, ArrayList C_Authors) {
            this.C_Name = C_Name;
            this.C_Id = C_Id;
            this.C_Desc = C_Desc;
            this.C_Authors = C_Authors;


        }


        

    }
}
