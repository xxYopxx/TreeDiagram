using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TreeDiagram.Diagram;

namespace TreeDiagram
{
    public partial class frmTreeDiagram : Form
    {
        const string _TYPE_CABLE = "Cable";
        const string _TYPE_SLEEVE = "Sleeve";
        public frmTreeDiagram()
        {
            InitializeComponent();
        }

        private void btnPJS4_Click(object sender, EventArgs e)
        {
            // Cable
            DataTree BOM = new DataTree("107419");
            for (int CableCount = 1; CableCount<=5; CableCount++)
            {
                DataItem Cable = new DataItem();
                Cable.Name = CableCount==1? "197-PJ65" : CableCount == 2 ? "197-PJ11" : CableCount == 3 ? "197-PJ14" : CableCount == 4 ? "197-PJ15" : "197-PJ19";
                Cable.Type = BranchType.Cable;
                Cable.CableSide = CableCount == 1 ? Side.Left : Side.Right;
                BOM.AddRootChild(Cable);
            }
            HorizontalTree Diagram = new HorizontalTree(pbDiagram);
            Diagram.FillDataTree(BOM);
            //pbDiagram.Image = Image.FromFile("C:\\Test\\Test.bmp");
            Diagram.Dispose();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(pbDiagram.Width, pbDiagram.Height);
            Graphics g = Graphics.FromImage(bm);
            Pen blue = new Pen(Color.Blue, 5);
            g.DrawLine(blue, 0, 0, 100, 100);
            bm.Save("C:\\Test\\Test.bmp");

        }

        private void btnGen_PJS_S1_Click(object sender, EventArgs e)
        {
            List<Item> Source = new List<Item>();
            Source.Add(new Item("176-PJ68", "Long: 11.75\" \nCalibre: 16\nTipo: GXL\nTerm: 140001", BranchType.Cable, "PJ-S1", Side.Left));
            Source.Add(new Item("PJ-S1", "PJ-S1\nManga: 106318", BranchType.Box, true));
            Source.Add(new Item("176-PJ70", "Long: 14.75\"\nCalibre: 16\nTipo: GXL", BranchType.Cable, "PJ-S1", Side.Right));
            Source.Add(new Item("176-PJ71", "Long: 13.25\"\nCalibre: 16\nTipo: GXL\nTerm: 140001", BranchType.Cable, "PJ-S1", Side.Right));
            Source.Add(new Item("176-PJ72", "Long: 14.00\"\nCalibre: 16\nTipo: GXL\nTerm: 140001", BranchType.Cable, "PJ-S1", Side.Right));
            Source.Add(new Item("PJ-S6", "PJ-S6\nManga: 106318", BranchType.Box, "176-PJ70"));
            Source.Add(new Item("176-PJ69", "Long: 9.75\"\nCalibre: 16\nTipo: GXL\nTerm: 140001", BranchType.Cable, "PJ-S6", Side.Left));
            Source.Add(new Item("176-PJ67", "Long: 11.00\"\nCalibre: 16\nTipo: GXL\nTerm: 140001", BranchType.Cable, "PJ-S6", Side.Left));
            Source.Add(new Item("176-PJ33", "Long: 99.00\"\nCalibre: 16\nTipo: GXL\nTerm: 140002", BranchType.Cable, "PJ-S6", Side.Right));
            DataTree Tree = new DataTree();
            Tree.FillDataTree(Source);
            /*
            DataTree BOM = new DataTree("US-");
            for(int CableCount = 1; CableCount < 5; CableCount++)
            {
                DataItem Cable = new DataItem();
                Cable.Name = CableCount == 1 ? "PJ68" : CableCount == 2 ? "PJ70" : CableCount == 3 ? "PJ71" : "PJ72";
                Cable.CarriesData = true;
                Cable.Data = Cable.Name;
                Cable.Type = BranchType.Cable;
                Cable.CableSide = CableCount == 1 ? Side.Left : Side.Right;
                if (CableCount == 2)
                {
                    DataItem Component = new DataItem();
                    Component.Name = "US-";
                    Component.Type = BranchType.Box;
                    for(int Cable2Count = 1; Cable2Count<4; Cable2Count++)
                    {
                        DataItem Cable2 = new DataItem();
                        Cable2.Name = Cable2Count == 1 ? "PJ67" : Cable2Count == 2 ? "PJ69" : "PJ33";
                        Cable2.CarriesData = true;
                        Cable2.Data = Cable2.Name;
                        Cable2.Type = BranchType.Cable;
                        Cable2.CableSide = Cable2Count == 3 ? Side.Right : Side.Left;
                        Component.Children.Add(Cable2);
                    }
                    Cable.Children.Add(Component);
                }
                BOM.AddRootChild(Cable);
            }*/
            HorizontalTree Diagram = new HorizontalTree(pbDiagram);
            Diagram.Settings.FileLocation = "C:\\Test\\Test.bmp";
            Diagram.FillDataTree(Tree);
            //pbDiagram.Image = Image.FromFile("C:\\Test\\Test.bmp");
            Diagram.Dispose();
        }
    }
}
