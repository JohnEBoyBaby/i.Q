using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys
{
    public class Arg {
        public System.String name { get; set; }
        public System.String type { get; set; } //undefined,null,u|boolean,b,boolean[],b[]|date,d,date[],d[]|number,n,number[],n[]|string,s,string[],s[]
        public System.String value { get; set; }
    }
}
