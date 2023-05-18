using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dl_List
{
    internal class Path
    {
        public string path { get; set; }
        public bool isHidden { get; set; }
        public Path(string path)
        {
            this.path = path;
            isHidden = false;
        }
        public override string ToString()
        {
            return path;
        }
    }
}
