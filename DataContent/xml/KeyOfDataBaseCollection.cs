using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContent.xml
{
    [ConfigurationCollection(typeof(KeyOfDataBaseElement))]

    class KeyOfDataBaseCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new KeyOfDataBaseElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((KeyOfDataBaseElement)(element)).Key;
        }

        public KeyOfDataBaseElement this[int idx]
        {
            get { return (KeyOfDataBaseElement)BaseGet(idx); }
        }
    }
}
