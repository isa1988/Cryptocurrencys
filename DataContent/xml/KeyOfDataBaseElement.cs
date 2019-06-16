using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContent.xml
{
    class KeyOfDataBaseElement : ConfigurationElement
    {
        [ConfigurationProperty("key", DefaultValue = "", IsKey = false, IsRequired = false)]
        public string Key
        {
            get { return ((string) (base["key"])); }
            set { base["key"] = value; }
        }
    }

}
