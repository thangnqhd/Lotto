using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluggableCoreLibrary.Attributes
{
    public class ThongKePlugInAttribute : Attribute
    {
        public ThongKePlugInAttribute(string description)
        {
            Description = description;
        }

        public  string Description { get; set; }
    }
}
