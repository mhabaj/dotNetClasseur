using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bacchus.Controller
{
    /// <summary>
    /// Class that allows us to regroup the element into groups.
    /// Authors : Sean Anica & Alhabaj Mahmod
    /// </summary>
    class ElementBuilderController
    {
        public ListView ListView { get; set; } //list of elements

        /// <summary>
        /// comfort constructor of the class.
        /// </summary>
        /// <param name="ListView"></param>
        public ElementBuilderController(ListView ListView)
        {
            this.ListView = ListView;
        }

        /// <summary>
        /// Method to create groups of elements based on their Column given in parameter
        /// </summary>
        /// <param name="Column"></param> The group will be created based on this row.
        /// <returns></returns> hashtable with groups.
        private Hashtable CreateGroupsTable(int Column)
        {
            Hashtable Tables = new Hashtable();
            foreach(ListViewItem item in ListView.Items) //go through each item of the list
            {
                string SubItemText = item.SubItems[Column].Text; //get the text of the column
                if (Column.Equals(0))//if : the first column
                {
                    SubItemText = SubItemText.Substring(0, 1); //take first letter
                }
                if (!Tables.Contains(SubItemText)) //if : table doesn't already has a group
                {
                    //add a new group using the subitemtext value
                    Tables.Add(SubItemText, new ListViewGroup(SubItemText, HorizontalAlignment.Left));
                }
            }
            return Tables;
        }

        /// <summary>
        /// method to sort + display the groups created thanks to the column in parameter.
        /// </summary>
        /// <param name="Column">column used to create the groups</param>
        public void SetGroups(int Column)
        {
            ListView.Groups.Clear();//dump all the groups
            Hashtable Groups = CreateGroupsTable(Column);//generate the groups thanks to the column
            ListViewGroup[] GroupsArray = new ListViewGroup[Groups.Count];
            Groups.Values.CopyTo(GroupsArray, 0);

            Array.Sort(GroupsArray, new ListViewGroupSorter(ListView.Sorting)); //sort the groups and add them to the ListView
            ListView.Groups.AddRange(GroupsArray);

            foreach(ListViewItem Item in ListView.Items)
            {
                string SubItemText = Item.SubItems[Column].Text;//find the subitem related to the column
                if (Column.Equals(0))
                {
                    SubItemText = SubItemText.Substring(0, 1);
                }
                Item.Group = (ListViewGroup)Groups[SubItemText]; //link the item to the matching group.
            }
        }
        
        /// <summary>
        /// Private nested class used to sort the groups created above in a certain order.
        /// </summary>
        private class ListViewGroupSorter : IComparer
        {
            private readonly SortOrder Order;

            /// <summary>
            /// comfort constructor of the class.
            /// </summary>
            /// <param name="VariableOrder"> order of the sorting</param>
            public ListViewGroupSorter(SortOrder VariableOrder)
            {
                Order = VariableOrder;
            }

            /// <summary>
            /// Method to compare the header of a value to another.
            /// </summary>
            /// <param name="X">first object</param>
            /// <param name="Y">second object</param>
            /// <returns> returns an int that defines the relation of X and Y.</returns>
            public int Compare(object X, object Y)
            {
                int equal = String.Compare(((ListViewGroup)X).Header, ((ListViewGroup)Y).Header);
                if (Order == SortOrder.Ascending)
                {
                    return equal;
                }
                else
                {
                    return -equal;
                }
            }
        }
    }
}
