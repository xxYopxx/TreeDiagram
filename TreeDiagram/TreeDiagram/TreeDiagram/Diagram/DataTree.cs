using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeDiagram.Diagram
{
    public enum BranchType { Cable, Box }
    public enum Side { Left, Right }
    public class DataTree
    {
        public DataItem RootComponent = new DataItem();
        public DataTree(string Name)
        {
            RootComponent.Name = Name;
            RootComponent.Type = BranchType.Box;
            RootComponent.Children = new List<DataItem>();
        }

        public void AddRootChild(DataItem Child)
        {
            RootComponent.Children.Add(Child);
        }
    }

    public class DataItem
    {
        public string Name { get; set; }
        public string Data { get; set; }
        public bool CarriesData { get; set; }
        public BranchType Type { get; set; }
        public Side CableSide { get; set; }
        public List<DataItem> Children = new List<DataItem>();
        public bool HasChildren()
        {
            return Children != null && Children.Count > 0;
        }

    }
}
