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
        public List<Item> DataSource = new List<Item>();
        public DataItem RootComponent = new DataItem();
        public DataTree()
        {
            
        }

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

        public void FillDataTree(List<Item> Source)
        {
            DataSource = Source;
            // Identify starting component
            var Initial = DataSource.Where(i => i.IsInitialComponent).FirstOrDefault();
            if (Initial != null)
            {
                FillDataItem(ref RootComponent, Initial);
            }
        }

        public void FillDataItem(ref DataItem Component, Item Data)
        {
            Component.Name = Data.Name;
            Component.Type = Data.Type;
            Component.Data = Data.Data;
            Component.CarriesData = !string.IsNullOrEmpty(Data.Data);
            Component.Children = new List<DataItem>();
            switch (Data.Type)
            {
                case BranchType.Box:
                    {
                        var Cables = DataSource.Where(i => i.Type == BranchType.Cable && i.Parent == Data.Name).ToList();
                        foreach(var cable in Cables)
                        {
                            DataItem ChildCable = new DataItem();
                            FillDataItem(ref ChildCable, cable);
                            Component.Children.Add(ChildCable);
                        }
                    }
                    break;
                case BranchType.Cable:
                    {
                        Component.CableSide = Data.CableSide;
                        var AttachedComponent = DataSource.Where(i => i.Parent == Data.Name).FirstOrDefault();
                        if (AttachedComponent != null)
                        {
                            DataItem ChildComponent = new DataItem();
                            FillDataItem(ref ChildComponent, AttachedComponent);
                            Component.Children.Add(ChildComponent);
                        }
                    }
                    break;
            }
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

    public class Item
    {
        public string Name { get; set; }
        public string Data { get; set; }
        public BranchType Type { get; set; }
        public Side CableSide { get; set; }
        public string Parent { get; set; }
        public bool IsInitialComponent { get; set; } = false;

        public Item()
        {

        }

        public Item(string ItemName)
        {
            Name = ItemName;
        }

        public Item(string ItemName, string ItemData)
        {
            Name = ItemName;
            Data = ItemData;
        }

        public Item(string ItemName, string ItemData, BranchType ItemType)
        {
            Name = ItemName;
            Data = ItemData;
            Type = ItemType;
        }

        public Item(string ItemName, string ItemData, BranchType ItemType, string ItemParent)
        {
            Name = ItemName;
            Data = ItemData;
            Type = ItemType;
            Parent = ItemParent;
        }

        public Item(string ItemName, string ItemData, BranchType ItemType, bool IsInitial)
        {
            Name = ItemName;
            Data = ItemData;
            Type = ItemType;
            IsInitialComponent = IsInitial;
        }

        public Item(string ItemName, string ItemData, BranchType ItemType, string ItemParent, Side ItemCableSide)
        {
            Name = ItemName;
            Data = ItemData;
            Type = ItemType;
            Parent = ItemParent;
            CableSide = ItemCableSide;
        }
    }
}
