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

        public ElementBuilderController(ListView LView)
        {
            this.ListView = LView;
        }

        private Hashtable ElementsGenerateRows(int Column)
        {
            Hashtable Tables = new Hashtable();
            foreach (ListViewItem item in ListView.Items)
            {
                string SubItemText = item.SubItems[Column].Text;

                if (Column == 0)
                {
                    SubItemText = SubItemText.Substring(0, 1);
                }

                if (!Tables.Contains(SubItemText))
                {
                    Tables.Add(SubItemText, new ListViewGroup(SubItemText,
                        HorizontalAlignment.Left));
                }
            }
            return Tables;
        }

        public void SetTable(int Column)
        {
            ListView.Groups.Clear();

            // Retrieve the hash table corresponding to the column.
            Hashtable Tables = ElementsGenerateRows(Column);

            // Copy the groups for the column to an array.
            ListViewGroup[] groupsArray = new ListViewGroup[Tables.Count];
            Tables.Values.CopyTo(groupsArray, 0);

            Array.Sort(groupsArray, new ListViewSorter(ListView.Sorting));
            ListView.Groups.AddRange(groupsArray);

            foreach (ListViewItem item in ListView.Items)
            {
                string Text = item.SubItems[Column].Text;

                if (Column == 0)
                {
                    Text = Text.Substring(0, 1);
                }
                item.Group = (ListViewGroup)Tables[Text];
            }
        }

        private class ListViewSorter : IComparer
        {
            private readonly SortOrder SOrder;

            public ListViewSorter(SortOrder Order)
            {
                SOrder = Order;
            }

            public int Compare(object x, object y)
            {
                int Ok = String.Compare(
                    ((ListViewGroup)x).Header,
                    ((ListViewGroup)y).Header
                );
                if (SOrder == SortOrder.Ascending)
                {
                    return Ok;
                }
                else
                {
                    return -Ok;
                }
            }
        }
    }
}
