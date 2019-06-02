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
        public BaseItem() { }
        public BaseItem(IEnumerable<BaseItem> list)
        {
            this.sort = GetSortNum(list);
        }
        public int sort = 1;
        public string text = string.Empty;

        public static int GetSortNum(IEnumerable<BaseItem> items)
        {
            if (items.Count() < 1)
            {
                return 1;
            }

            return (from i in items
                    select i.sort).Max() + 1;

        }
    }
    [Serializable]
    public class Mdl
    {
        public class Title : BaseItem
        {
            public Title() : base() { }
            public Title(IEnumerable<BaseItem> list) : base(list) { }
            public List<MajorItem> items = new List<MajorItem>();
        }
        public class MajorItem : BaseItem
        {
            public MajorItem() : base() { }
            public MajorItem(IEnumerable<BaseItem> list) : base(list) { }
            public List<MiddleItem> items = new List<MiddleItem>();
        }
        public class MiddleItem : BaseItem
        {
            public MiddleItem() : base() { }
            public MiddleItem(IEnumerable<BaseItem> list) : base(list) { }
            public List<SmallItem> items = new List<SmallItem>();
        }
        public class SmallItem : BaseItem
        {
            public SmallItem() : base() { }
            public SmallItem(IEnumerable<BaseItem> list) : base(list) { }

        }


        public enum ProcessingType
        {
            Add,
            Remove,
            Sort

        }


        public static void ProcessList(ProcessingType type, BaseItem parentItem, BaseItem item)
        {
            if (parentItem is Title)
            {
                ((Title)parentItem).items = ProcesssItems<MajorItem>(type, ((Title)parentItem).items, (MajorItem)item).Cast<MajorItem>().ToList();
            }
            if (parentItem is MajorItem)
            {
                ((MajorItem)parentItem).items = ProcesssItems<MiddleItem>(type, ((MajorItem)parentItem).items, (MiddleItem)item).Cast<MiddleItem>().ToList();
            }
            if (parentItem is MiddleItem)
            {
                ((MiddleItem)parentItem).items = ProcesssItems<SmallItem>(type, ((MiddleItem)parentItem).items, (SmallItem)item).Cast<SmallItem>().ToList();
            }
            if (parentItem is SmallItem)
            {
                return;
            }

        }

        public static IEnumerable<BaseItem> ProcesssItems<T>(ProcessingType type, List<T> list, T item)
        {
            if (type == ProcessingType.Add)
            {
                list.Add(item);
                return list.AsEnumerable().Cast<BaseItem>();
            }
            else if (type == ProcessingType.Remove)
            {
                list.Remove(item);
                return list.AsEnumerable().Cast<BaseItem>();
            }
            else
            {
                return (from l in list.Cast<BaseItem>()
                        orderby l.sort descending
                        select l).ToList();
            }
        }
    }
}
