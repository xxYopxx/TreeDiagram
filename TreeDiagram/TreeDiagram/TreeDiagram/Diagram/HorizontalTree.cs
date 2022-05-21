using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeDiagram.Diagram
{
    public class HorizontalTree : IDisposable
    {
        System.Windows.Forms.PictureBox BaseBox;
        Bitmap bmp;
        public Graphics Diagram = null;
        public DataTree Tree = null;
        public Pen penRed;
        public Pen penBlack;
        public Point Start;
        public TreeConfiguration Settings;
        public HorizontalTree(object BaseCanvas)
        {
            Settings = new TreeConfiguration();
            penRed = new Pen(Color.Red, Settings.RedPenWith);
            penBlack = new Pen(Color.Black, Settings.BlackPenWith);
            Start = new Point(Settings.StartPointX, Settings.StartPointY);
            BaseBox = (BaseCanvas as System.Windows.Forms.PictureBox);
            bmp = new Bitmap(Settings.CanvasWidth, Settings.CanvasHeight);
            Diagram = Graphics.FromImage(bmp);
        }

        public Point CalulateCableEnd(Point Beginning, int Index, int TotalCables, Side CableSide)
        {
            Point Result = new Point(0, 0);
            if (TotalCables == 1 && CableSide == Side.Right)
                Result = new Point(Beginning.X + Settings.CableLength, Beginning.Y);
            if (TotalCables == 1 && CableSide == Side.Left)
                Result = new Point(Beginning.X - Settings.CableLength, Beginning.Y);
            else
            {
                int NewY = 0;
                int Division = 0;
                int MiddleCable = 0;
                bool IsEven = Index % 2 == 0;
                bool IsTotalEven = TotalCables % 2 == 0;
                bool IsAboveZero = false;
                bool IsMiddle = false;
                int IndexValue = 0;
                if (IsTotalEven)
                    Division = (TotalCables * Settings.CableSeparation) / 2;
                else
                {
                    MiddleCable = (TotalCables / 2) + 1;
                    Division = ((TotalCables - 1) * Settings.CableSeparation) / 2;
                    IsMiddle = Index == MiddleCable;
                }
                IndexValue = Index == 1 ? Division : Division - ((Index - 1) * Settings.CableSeparation);
                IsAboveZero = Division - (Index * Settings.CableSeparation) >= 0;

                if (IsMiddle)
                    NewY = 0;
                else
                {
                    NewY = IndexValue;
                }
                if (CableSide == Side.Right)
                    Result = new Point(Beginning.X + Settings.CableLength, Beginning.Y + NewY);
                else
                    Result = new Point(Beginning.X - Settings.CableLength, Beginning.Y + NewY);
            }
            return Result;
        }

        public void FillDataTree(DataTree Source)
        {
            Tree = Source;
            DataItem root = Tree.RootComponent;
            // Draw main component
            DrawComponentBlock(Start, root, "");
            bmp.Save(Settings.FileLocation);
        }

        private void DrawComponentBlock(Point Starting, DataItem Source, string ConnectionName)
        {
            DrawBox(Starting, new Size(Settings.BoxLength, Settings.BoxHeight), Source.Name);

            if (Source.HasChildren())
            {
                int LeftCableCount = Source.Children.Where(c => c.Type == BranchType.Cable && c.CableSide == Side.Left).Count();
                int RightCableCount = Source.Children.Where(c => c.Type == BranchType.Cable && c.CableSide == Side.Right).Count();
                // Draw Children
                int LeftIndex = 0;
                int RightIndex = 0;
                foreach (DataItem child in Source.Children)
                {
                    if (child.Type == BranchType.Cable && child.Name != ConnectionName)
                    {
                        Point CableStartPoint = new Point(0, 0);
                        Point CableEndPoint = new Point(0, 0);
                        if (child.CableSide == Side.Left)
                        {
                            LeftIndex += 1;
                            CableStartPoint = new Point(Starting.X, Starting.Y + (Settings.BoxHeight / 2));
                            CableEndPoint = CalulateCableEnd(CableStartPoint, LeftIndex, LeftCableCount, Side.Left);
                            DrawCable(CableStartPoint, CableEndPoint,Side.Left, child.Name,child.CarriesData, child.Data);
                        }
                        if (child.CableSide == Side.Right)
                        {
                            RightIndex += 1;
                            CableStartPoint = new Point(Starting.X + Settings.BoxLength, Starting.Y + (Settings.BoxHeight / 2));
                            CableEndPoint = CalulateCableEnd(CableStartPoint, RightIndex, RightCableCount, Side.Right);
                            DrawCable(CableStartPoint, CableEndPoint, Side.Right, child.Name, child.CarriesData, child.Data);
                        }
                        if (child.HasChildren())
                        {
                            foreach (DataItem grandChild in child.Children)
                            {
                                CableEndPoint.Y = CableEndPoint.Y - (Settings.BoxHeight / 2);
                                DrawComponentBlock(CableEndPoint, grandChild, child.Name);
                            }
                        }
                    }
                }
            }
        }

        private void DrawCable(Point Begin, Point End, Side side, string Name, bool CarriesData, string Data)
        {
            Diagram.DrawLine(penRed, Begin, End);
            Point CableNameBegin = new Point();
            if (side == Side.Left)
                CableNameBegin = new Point(End.X + (Settings.CableLength / 2) - 20, End.Y - 20);
            else
                CableNameBegin = new Point(Begin.X + (Settings.CableLength / 2) - 20, End.Y - 20);
            SolidBrush NameBrush = new SolidBrush(Color.Black);
            Font NameFont = new Font("Arial", 10);
            Diagram.DrawString(Name, NameFont, NameBrush, CableNameBegin);
            if (CarriesData)
            {
                // Draw Data box
                Point DataBoxBegin = new Point(End.X - Settings.DataBoxLength - 10, End.Y - Settings.DataBoxHeight - 10);
                Point DataBegin = new Point(DataBoxBegin.X + 5, DataBoxBegin.Y + 5);
                Rectangle DataBox = new Rectangle(DataBoxBegin, new Size(Settings.DataBoxLength, Settings.DataBoxHeight));
                SolidBrush DataBrush = new SolidBrush(Color.Black);
                Font DataFont = new Font("Arial", 10);
                Diagram.DrawRectangle(penBlack, DataBox);
                Diagram.DrawString(Data, DataFont, DataBrush, DataBegin);
                //Diagram.DrawString(Name, NameFont, NameBrush, CableNameBegin);
                //bmp.Save("C:\\Test\\Test.bmp");
            }
        }

        private void DrawBox(Point Begin, Size Markup, string Name)
        {
            Font NameFont = new Font("Arial", 10);
            Point NameBegin = new Point(Begin.X + 10, Begin.Y + 10);
            SolidBrush NameBrush = new SolidBrush(Color.Black);
            Rectangle box = new Rectangle(Begin, Markup);
            Diagram.DrawRectangle(penBlack, box);
            Diagram.DrawString(Name, NameFont, NameBrush, NameBegin);
            //bmp.Save("C:\\Test\\Test.bmp");
        }

        public void Dispose()
        {
            bmp.Dispose();
            Diagram.Dispose();
            penBlack.Dispose();
            penRed.Dispose();
        }
    }

    public class TreeConfiguration
    {
        public int BlackPenWith { get; set; } = 5;
        public int RedPenWith { get; set; } = 5;
        public int CableSeparation { get; set; } = 100;
        public int CableLength { get; set; } = 300;
        public int BoxLength { get; set; } = 100;
        public int BoxHeight { get; set; } = 50;
        public int DataBoxLength { get; set; } = 100;
        public int DataBoxHeight { get; set; } = 65;
        public int StartPointX { get; set; } = 500;
        public int StartPointY { get; set; } = 500;
        public int CanvasWidth { get; set; } = 1000;
        public int CanvasHeight { get; set; } = 1000;
        public string FileLocation { get; set; } = string.Empty;

        public TreeConfiguration()
        {

        }
    }
}
