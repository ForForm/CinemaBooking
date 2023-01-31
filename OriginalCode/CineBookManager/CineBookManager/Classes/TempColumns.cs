using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineBookManager.Classes
{
    [System.Serializable]
    public class TempColumns
    {
        public int Selected { get; set; }
        public string Name { get; set; }

        Object[] RelationList = new Object[100];

        public TempColumns()
        {
            RelationList[0] = new TempColumns { Name = string.Empty, Selected = 0 };
        }
    }
    
}
