using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manual
{
    [Serializable]
    public abstract class BaseItem
    {
        public int sort=0;
        public string text=string.Empty;
        public abstract void RemoveItem(BaseItem item);
        public abstract void AddItem(BaseItem item);

    }
}
