using System;
using System.Collections;
using System.Windows.Forms;

namespace Bacchus.Controller
{
    /// <summary>
    /// Class that allows to regroup elements into groups.
    /// Inspired from: https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.listview.groups?view=net-5.0
    /// </summary>
    class ElementSortController
    {
        public ListView DataList { get; set; } //list of elements

        /// <summary>
        /// Comfort constructor of the class.
        /// </summary>
        /// <param name="ListView">DataList to sort</param>
        public ElementSortController(ListView ListView)
        {
            this.DataList = ListView;
        }

        /// <summary>
        /// Create groups of elements based on the Column given in parameter
        /// </summary>
        /// <param name="SelectedColumn"> int, The group will be created based on this row. </param>
        /// <returns>Hashtable containing the groups.</returns> 
        private Hashtable GroupData(int SelectedColumn)
        {
            Hashtable TablesByGroups = new Hashtable();
            foreach(ListViewItem item in DataList.Items) //for each item of the list
            {
                string TextToAnalyse = item.SubItems[SelectedColumn].Text; //text of the column
                if (SelectedColumn.Equals(0))//The first column
                {
                    TextToAnalyse = TextToAnalyse.Substring(0, 1); //take first letter
                }
                if (!TablesByGroups.Contains(TextToAnalyse)) //table doesn't have this group 
                {
                    //add a new group using the subitemtext value
                    TablesByGroups.Add(TextToAnalyse, new ListViewGroup(TextToAnalyse, HorizontalAlignment.Left));
                }
            }
            return TablesByGroups;
        }

        /// <summary>
        /// Sort & display the groups created. 
        /// </summary>
        /// <param name="SelectedColumn">int, column used to create the groups </param>
        public void SetGroups(int SelectedColumn)
        {
            DataList.Groups.Clear();//reset current grps
            Hashtable Groups = GroupData(SelectedColumn); // hashtable of groups by the column

            ListViewGroup[] GroupsArray = new ListViewGroup[Groups.Count];
            Groups.Values.CopyTo(GroupsArray, 0);

            Array.Sort(GroupsArray, new ListViewGroupSorter(DataList.Sorting)); //sort the groups and add them to the DataList
            DataList.Groups.AddRange(GroupsArray);

            foreach(ListViewItem Item in DataList.Items)
            {
                string SubItemText = Item.SubItems[SelectedColumn].Text;//find the subitem related to the column
                if (SelectedColumn.Equals(0))
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
            /// Compare the header of a value to another.
            /// </summary>
            /// <param name="X">first object</param>
            /// <param name="Y">second object</param>
            /// <returns> returns an int that defines the relation of X and Y.</returns>
            public int Compare(object X, object Y)
            {
                int Result = String.Compare(((ListViewGroup)X).Header, ((ListViewGroup)Y).Header);
                if (Order == SortOrder.Ascending)
                {
                    return Result;
                }
                else
                {
                    return -Result;
                }
            }
        }
    }
}
