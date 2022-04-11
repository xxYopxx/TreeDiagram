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
        int BlackPenWith = 5;
        int RedPenWith = 5;
        int CableSeparation = 50;
        public int CableLength = 100;
        public int BoxLength = 50;
        public int BoxHeight = 20;
        int StartPointX = 500;
        int StartPointY = 500;
        int CanvasWidth = 1000;
        int CanvasHeight = 1000;
        public Point Start;
        public HorizontalTree(object BaseCanvas)
        {
            penRed = new Pen(Color.Red, RedPenWith);
            penBlack = new Pen(Color.Black, BlackPenWith);
            Start = new Point(StartPointX, StartPointY);
            BaseBox = (BaseCanvas as System.Windows.Forms.PictureBox);
            bmp = new Bitmap(CanvasWidth, CanvasHeight);
            Diagram = Graphics.FromImage(bmp);
        }

        public Point CalulateCableEnd(Point Beginning, int Index, int TotalCables, Side CableSide)
        {
            Point Result = new Point(0, 0);
            if (TotalCables == 1 && CableSide == Side.Right)
                Result = new Point(Beginning.X + CableLength, Beginning.Y);
            if (TotalCables == 1 && CableSide == Side.Left)
                Result = new Point(Beginning.X - CableLength, Beginning.Y);
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
                    Division = (TotalCables * CableSeparation) / 2;
                else
                {
                    MiddleCable = (TotalCables / 2) + 1;
                    Division = ((TotalCables - 1) * CableSeparation) / 2;
                    IsMiddle = Index == MiddleCable;
                }
                IndexValue = Index == 1 ? Division : Division - ((Index - 1) * CableSeparation);
                IsAboveZero = Division - (Index * CableSeparation) >= 0;

                if (IsMiddle)
                    NewY = 0;
                else
                {
                    NewY = IndexValue;
                }
                if (CableSide == Side.Right)
                    Result = new Point(Beginning.X + CableLength, Beginning.Y + NewY);
                else
                    Result = new Point(Beginning.X - CableLength, Beginning.Y + NewY);
            }
            return Result;
        }

        public void FillDataTree(DataTree Source)
        {
            Tree = Source;
            DataItem root = Tree.RootComponent;
            // Draw main component
            DrawComponentBlock(Start, root, "");
            bmp.Save("C:\\Test\\Test.bmp");
        }

        private void DrawComponentBlock(Point Starting, DataItem Source, string ConnectionName)
        {
            DrawBox(Starting, new Size(BoxLength, BoxHeight));

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
                            CableStartPoint = new Point(Starting.X, Starting.Y + (BoxHeight / 2));
                            CableEndPoint = CalulateCableEnd(CableStartPoint, LeftIndex, LeftCableCount, Side.Left);
                            DrawCable(CableStartPoint, CableEndPoint);
                        }
                        if (child.CableSide == Side.Right)
                        {
                            RightIndex += 1;
                            CableStartPoint = new Point(Starting.X + BoxLength, Starting.Y + (BoxHeight / 2));
                            CableEndPoint = CalulateCableEnd(CableStartPoint, RightIndex, RightCableCount, Side.Right);
                            DrawCable(CableStartPoint, CableEndPoint);
                        }
                        if (child.HasChildren())
                        {
                            foreach (DataItem grandChild in child.Children)
                            {
                                CableEndPoint.Y = CableEndPoint.Y - (BoxHeight / 2);
                                DrawComponentBlock(CableEndPoint, grandChild, child.Name);
                            }

                        }
                    }
                }
            }
        }

        private void DrawCable(Point Begin, Point End)
        {
            Diagram.DrawLine(penRed, Begin, End);
            //bmp.Save("C:\\Test\\Test.bmp");
        }

        private void DrawBox(Point Begin, Size Markup)
        {
            Rectangle box = new Rectangle(Begin, Markup);
            Diagram.DrawRectangle(penBlack, box);
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
}
