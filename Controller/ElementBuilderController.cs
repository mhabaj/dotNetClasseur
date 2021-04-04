using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bacchus.Controller
{
    class ElementBuilderController
    {
        public ListView ListView { get; set; }

        public ElementBuilderController(ListView ListView)
        {
            this.ListView = ListView;
        }

        private Hashtable CreateGroupsTable(int Column)
        {
            Hashtable Tables = new Hashtable();
            foreach(ListViewItem item in ListView.Items)
            {
                string SubItemText = item.SubItems[Column].Text;
                if (Column.Equals(0))
                {
                    SubItemText = SubItemText.Substring(0, 1);
                }
                if (!Tables.Contains(SubItemText))
                {
                    Tables.Add(SubItemText, new ListViewGroup(SubItemText, HorizontalAlignment.Left));
                }
            }
            return Tables;
        }

        public void SetGroups(int Column)
        {
            ListView.Groups.Clear();
            Hashtable Groups = CreateGroupsTable(Column);
            ListViewGroup[] GroupsArray = new ListViewGroup[Groups.Count];
            Groups.Values.CopyTo(GroupsArray, 0);

            Array.Sort(GroupsArray, new ListViewGroupSorter(ListView.Sorting));
            ListView.Groups.AddRange(GroupsArray);

            foreach(ListViewItem Item in ListView.Items)
            {
                string SubItemText = Item.SubItems[Column].Text;
                if (Column.Equals(0))
                {
                    SubItemText = SubItemText.Substring(0, 1);
                }
                Item.Group = (ListViewGroup)Groups[SubItemText];
            }
        }

        private class ListViewGroupSorter : IComparer
        {
            private readonly SortOrder Order;

            public ListViewGroupSorter(SortOrder TheOrder)
            {
                Order = TheOrder;
            }

            public int Compare(object X, object Y)
            {
                int result = String.Compare(((ListViewGroup)X).Header, ((ListViewGroup)Y).Header);
                if (Order == SortOrder.Ascending)
                {
                    return result;
                }
                else
                {
                    return -result;
                }
            }
        }
    }
}
