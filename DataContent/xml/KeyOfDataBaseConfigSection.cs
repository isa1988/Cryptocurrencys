using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContent.xml
{
    class KeyOfDataBaseConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("KeyOfDataBases")]
        public KeyOfDataBaseCollection FolderItems
        {
            get { return ((KeyOfDataBaseCollection)(base["KeyOfDataBases"])); }
        }
    }
}
