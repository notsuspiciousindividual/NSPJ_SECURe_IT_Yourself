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
        private String C_Name { get; }
        private String C_Id { get; }
        private String C_Desc { get; }
        private ArrayList C_Authors { get; }

        public Case(String C_Name, String C_Id, String C_Desc, ArrayList C_Authors) {
            this.C_Name = C_Name;
            this.C_Id = C_Id;
            this.C_Desc = C_Desc;
            this.C_Authors = C_Authors;


        }


        

    }
}
