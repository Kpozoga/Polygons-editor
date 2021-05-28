using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace grafika_wielokaty
{

    public partial class MainForm : Form
    {
        enum State { Idle, Moving, Creating, CreateCircle }
        enum SelectedType {Empty, Edge, Vert, Polygon }
        State status = State.Idle;
        List<List<Edge>> edges = new List<List<Edge>>();
        List<Edge> currentPolygon = null;
        object selected;
        SelectedType selectedType = SelectedType.Empty;
        Point latestMouseLoc = Point.Empty;
        Graphics flagGraphics;
        Image beforeMove;
        List<Circle> circles = new List<Circle>();
        
        /// <summary>
        /// Determines if the given point is inside the polygon
        /// </summary>
        /// <param name="polygon">the vertices of polygon</param>
        /// <param name="testPoint">the given point</param>
        /// <returns>true if the point is inside the polygon; otherwise, false</returns>
        //https://stackoverflow.com/questions/4243042/c-sharp-point-in-polygon
        private static bool IsPointInPolygon4(List<Edge> poly, MyPoint testPoint)
        { 
            if (poly.Count == 0) return false;
            MyPoint[] polygon = new MyPoint[poly.Count];
            Edge edge = poly[0];
            for (int i = 0; i < poly.Count; i++,edge=edge.Next)
                polygon[i] = edge.From;
            bool result = false;
            int j = polygon.Count() - 1;
            for (int i = 0; i < polygon.Count(); i++)
            {
                if (polygon[i].Y < testPoint.Y && polygon[j].Y >= testPoint.Y || polygon[j].Y < testPoint.Y && polygon[i].Y >= testPoint.Y)
                {
                    if (polygon[i].X + (testPoint.Y - polygon[i].Y) / (polygon[j].Y - polygon[i].Y) * (polygon[j].X - polygon[i].X) < testPoint.X)
                    {
                        result = !result;
                    }
                }
                j = i;
            }
            return result;
        }
        
       
        private void PutPixel(int x,int y,Brush b)
        {
           // if (x < 0 || y < 0) return;
           // if (x > pictureBox1.Width || y > pictureBox1.Height) return;
           flagGraphics.FillRectangle(b, x, y, 1, 1);
        }
        private void MyDrawLine(MyPoint From, MyPoint To,Brush color)
        {
            int d, dx, dy, ai, bi, xi, yi;
            int x = (int)From.X, y = (int)From.Y;
            // determining the direction of drawing
            if (From.X < To.X)
            {
                xi = 1;
                dx = (int)To.X - (int)From.X;
            }
            else
            {
                xi = -1;
                dx = (int)From.X - (int)To.X;
            }
            // determining the direction of drawing
            if (From.Y < To.Y)
            {
                yi = 1;
                dy = (int)To.Y - (int)From.Y;
            }
            else
            {
                yi = -1;
                dy = (int)From.Y - (int)To.Y;
            }
            // first pixel
            PutPixel(x, y,color);

            // the leading axis OX
            if (dx > dy)
            {
                ai = (dy - dx) * 2;
                bi = dy * 2;
                d = bi - dx;
                // loop for x
                while (x != (int)To.X)
                {
                    // factor test
                    if (d >= 0)
                    {
                        x += xi;
                        y += yi;
                        d += ai;
                    }
                    else
                    {
                        d += bi;
                        x += xi;
                    }
                    PutPixel(x, y,color);
                }
            }
            // the leading axis OY
            else
            {
                ai = (dx - dy) * 2;
                bi = dx * 2;
                d = bi - dy;
                // loop for y
                while (y != (int)To.Y)
                {
                    // factor test
                    if (d >= 0)
                    {
                        x += xi;
                        y += yi;
                        d += ai;
                    }
                    else
                    {
                        d += bi;
                        y += yi;
                    }
                    PutPixel(x, y,color);
                }
            }

        }
        private void PrintAll()
        {
            Pen drawPen = new Pen(Color.Black, 1);
            foreach (List<Edge> edgs in edges)
                foreach (Edge e in edgs)
                    if (!e.To.IsEmpty)
                    {
                        MyDrawLine(e.From, e.To, Brushes.Black);
                        if(e.Limit==0)
                        {
                            double x =e.From.X+ (e.To.X - e.From.X)/2;
                            double y =e.From.Y+ (e.To.Y - e.From.Y)/2;
                            flagGraphics.FillRectangle(Brushes.Green, (float)x - 5, (float)y - 15, 10, 10);
                            MyDrawLine(new MyPoint(x - 4, y - 10), new MyPoint(x + 4, y - 10), Brushes.Red);
                        }
                        if (e.Limit == 90)
                        {
                            double x = e.From.X + (e.To.X - e.From.X) / 2;
                            double y = e.From.Y + (e.To.Y - e.From.Y) / 2;
                            flagGraphics.FillRectangle(Brushes.Green, (float)x - 15, (float)y - 5, 10, 10);
                            MyDrawLine(new MyPoint(x - 10, y - 4), new MyPoint(x - 10, y +4), Brushes.Red);
                        }
                    }

            if (selectedType == SelectedType.Edge)
            {
                Edge edge = (Edge)selected;
                MyDrawLine(edge.From, edge.To, Brushes.Blue);
            }
            foreach (List<Edge> edgs in edges)
                foreach (Edge e in edgs)
                {
                    flagGraphics.FillEllipse(Brushes.White, (float)e.From.X - 3, (float)e.From.Y - 3, 6, 6);
                    flagGraphics.DrawEllipse(drawPen, (float)e.From.X - 3, (float)e.From.Y - 3, 6, 6);
                    double deg = e.Degree+e.From.Limit/2;
                    //flagGraphics.FillRectangle(Brushes.Green, (float)(e.From.X+10*Math.Cos(deg)-5) , (float)(e.From.Y+10*Math.Sin(deg)-5) , 15, 15);
                    flagGraphics.DrawString("K", DefaultFont, Brushes.Black, (float)(e.From.X + 10 * Math.Cos(deg) - 5), (float)(e.From.Y + 10 * Math.Sin(deg) - 5));
                }
           
            if(selectedType==SelectedType.Vert)
            {
                MyPoint vert = (MyPoint)selected;
                flagGraphics.FillEllipse(Brushes.LightBlue, (float)vert.X - 3, (float)vert.Y - 3, 6, 6);
                flagGraphics.DrawEllipse(new Pen(Color.Blue,1), (float)vert.X - 3, (float)vert.Y - 3, 6, 6);
            }
            foreach (Circle c in circles)
            {//draw circle
            }
        }
        private void ReprintPicture(bool Clear=true)
        {
            if(Clear)
                flagGraphics.FillRectangle(Brushes.White, 0, 0, pictureBox1.Image.Width, pictureBox1.Image.Height);
            PrintAll();
            //flagGraphics.DrawImage(pictureBox1.Image, 0, 0);
            pictureBox1.Refresh();
        }
        private void CreateClearBitmap(int width, int height)
        {

            pictureBox1.Image = new Bitmap(width, height);
            Graphics flagGraphics = Graphics.FromImage(pictureBox1.Image);
            this.flagGraphics = flagGraphics;
            flagGraphics.FillRectangle(Brushes.White, 0, 0, width, height);
            flagGraphics.DrawImage(pictureBox1.Image, width, height);
            pictureBox1.Refresh();

        }
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CreateClearBitmap(1600, 1000);
            List<Edge> tmp = new List<Edge>();
            MyPoint A= new MyPoint(50, 50), B = new MyPoint(150, 50), C = new MyPoint(250, 200),D=new MyPoint(220,300), E = new MyPoint(100, 250);
            tmp.Add(new Edge(A,B));
            tmp.Add(new Edge(B,C));
            tmp.Add(new Edge(C,D));
            tmp.Add(new Edge(D, E));
            tmp.Add(new Edge(E, A));     
            tmp[0].Next = tmp[1];
            tmp[1].Next = tmp[2];
            tmp[2].Next = tmp[3];
            tmp[3].Next = tmp[4];
            tmp[4].Next = tmp[0];
            tmp[0].Limit = 0;
            D.Limit = D.Next.Degree - D.Previous.Degree;
            edges.Add(tmp);
            ReprintPicture();
        }

        private void NewPolygonButton_Click(object sender, EventArgs e)
        {
            status = State.Creating;
            currentPolygon= new List<Edge>();
            edges.Add(currentPolygon);
            NewPolygonButton.Enabled = false;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if(status==State.Creating)
            {

                if (currentPolygon.Count > 0)
                {
                    currentPolygon[currentPolygon.Count - 1].To = e.Location;
                    //if(currentPolygon[currentPolygon.Count-1].To==currentPolygon[0].From)
                    if (currentPolygon[0].From.IsInsidePoint(currentPolygon[currentPolygon.Count-1].To))
                    {
                        currentPolygon[currentPolygon.Count - 1].Next = currentPolygon[0];
                        currentPolygon[currentPolygon.Count - 1].To = currentPolygon[0].From;
                        status = State.Idle;
                        currentPolygon = null;
                        ReprintPicture();
                        NewPolygonButton.Enabled = true;
                        return;
                    }
                }
                
                currentPolygon.Add(new Edge(e.Location, MyPoint.Empty));
                if (currentPolygon.Count > 1)
                {
                    currentPolygon[currentPolygon.Count - 2].Next = currentPolygon[currentPolygon.Count - 1];
                    currentPolygon[currentPolygon.Count - 2].To = currentPolygon[currentPolygon.Count - 1].From;
                }
                ReprintPicture();
            }
            if(status==State.Idle)
            {
                latestMouseLoc = e.Location;
                foreach (List<Edge> edgs in edges)
                    foreach (Edge ed in edgs)
                    {
                        if (ed.From.IsInsidePoint(e.Location))
                        {
                            selected = ed.From;
                            selectedType = SelectedType.Vert;    
                            ReprintPicture();
                            if (e.Button == MouseButtons.Left)
                            {
                                beforeMove = (Image)pictureBox1.Image.Clone();

                                status = State.Moving;
                            }
                            if (e.Button == MouseButtons.Right)
                            {
                                if (double.IsNaN(ed.From.Limit))
                                    toolStripMenuItemDegree.Checked = false;
                                else
                                    toolStripMenuItemDegree.Checked = true;
                                contextMenuStripVert.Show(pictureBox1, e.Location);
                            }
                            return;
                        }
                    }
                foreach (List<Edge> edgs in edges)
                    foreach (Edge ed in edgs)
                    {
                        if (ed.IsOnEdge(e.Location))
                        {
                            selected = ed;
                            selectedType = SelectedType.Edge;           
                            ReprintPicture();
                            if (e.Button == MouseButtons.Left)
                            {
                                beforeMove = (Image)pictureBox1.Image.Clone();
                                status = State.Moving;
                            }
                            if (e.Button == MouseButtons.Right)
                            {
                                toolStripMenuItemVerticalEdge.Checked = false;
                                toolStripMenuItemHorizontalEdge.Checked = false;
                                if(ed.Limit==0)
                                    toolStripMenuItemHorizontalEdge.Checked = true;
                                if (ed.Limit == 90)
                                    toolStripMenuItemVerticalEdge.Checked = true;
                                contextMenuStripEdge.Show(pictureBox1, e.Location);
                            }
                            return;
                        }
                    }
                foreach (List<Edge> edgs in edges)
                {
                    if(IsPointInPolygon4(edgs,e.Location))
                    {
                        selected = edgs;
                        selectedType = SelectedType.Polygon;
                        status = State.Moving;
                        ReprintPicture();
                        beforeMove = (Image)pictureBox1.Image.Clone();
                        return;
                    }
                }
                selectedType = SelectedType.Empty;
                selected = null;
            }
            if(status==State.CreateCircle)
            {
                circles.Add(new Circle(e.X, e.Y,100));
                button1.Enabled = true;
                status = State.Idle;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (status == State.Creating)
                if (currentPolygon.Count > 0)
                {
                    currentPolygon[currentPolygon.Count - 1].To = e.Location;
                    ReprintPicture();
                    return;
                }
            if(status==State.Moving)
            {
                double dx= (e.X - latestMouseLoc.X);
                double dy = (e.Y - latestMouseLoc.Y);
                if (dx == 0 && dy == 0) return;
                latestMouseLoc = e.Location;
                flagGraphics.FillRectangle(Brushes.White, 0, 0, pictureBox1.Image.Width, pictureBox1.Image.Height);
                if (beforeMove != null)
                {
                    //https://stackoverflow.com/questions/4779027/changing-the-opacity-of-a-bitmap-image
                    ColorMatrix matrix = new ColorMatrix();
                    //set the opacity  
                    matrix.Matrix33 = (float)0.4;
                    //create image attributes  
                    ImageAttributes attributes = new ImageAttributes();
                    //set the color(opacity) of the image  
                    attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                    //now draw the image  
                    flagGraphics.DrawImage(beforeMove, new Rectangle(0, 0, beforeMove.Width, beforeMove.Height),
                        0, 0, pictureBox1.Image.Width, pictureBox1.Image.Height, GraphicsUnit.Pixel, attributes);
                }
                if (selectedType==SelectedType.Vert)
                {

                    ((MyPoint)selected).Move(dx, dy,1,2);  
                    
                    ReprintPicture(false);
                    return;
                }
                if (selectedType==SelectedType.Edge)
                {
                    Edge edge = (Edge)selected;
                    
                    edge.Move(dx, dy);
                    ReprintPicture(false);

                    return;
                }
                if (selectedType == SelectedType.Polygon)
                {
                    List <Edge> poly = (List<Edge>)selected;
                    foreach (Edge edge in poly)
                        edge.From.Move(dx, dy,0);
                    
                    ReprintPicture(false);

                    return;
                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if(status==State.Moving)
            {
                status = State.Idle;
                beforeMove = null;
                ReprintPicture();
            }
        }

        private void toolStripMenuItemDeleteVert_Click(object sender, EventArgs e)
        {
            MyPoint vert = (MyPoint)selected;
            Edge edgeToDelete = vert.Next;
            vert.Previous.Limit = -1;
            vert.Previous.Next = vert.Next.Next;
            vert.Previous.To = vert.Next.To;
            foreach (List<Edge> poly in edges)
                poly.Remove(edgeToDelete);
            selectedType = SelectedType.Empty;
            selected = null;
            ReprintPicture();
        }

        private void toolStripMenuItemAddVert_Click(object sender, EventArgs e)
        {
            Edge edge = (Edge)selected;
            edge.Limit = -1;
            MyPoint vert = new MyPoint(latestMouseLoc.X,latestMouseLoc.Y);
            Edge tmp = new Edge(vert, edge.To);
            tmp.Next = edge.Next;
            tmp.Previous = edge;
            tmp.Previous.To = vert;
            tmp.Next.From = tmp.To;
            foreach (List<Edge> poly in edges)           
                if(poly.Contains(edge))
                {
                    poly.Add(tmp);
                    break;
                }
            selectedType = SelectedType.Empty;
            selected = null;
            ReprintPicture();
        }

        private void toolStripMenuItemClearEdgeLimit_Click(object sender, EventArgs e)
        {
            ((Edge)selected).Limit = -1;
            selectedType = SelectedType.Empty;
            selected = null;
            ReprintPicture();
        }

        private void toolStripMenuItemVerticalEdge_Click(object sender, EventArgs e)
        {
            Edge edge = (Edge)selected;
            if (edge.Next.Limit == 90 || edge.Previous.Limit == 90)
            {
                MessageBox.Show("Dwie kolejne krawędzie nie mogą być pionowe.", "Błąd relacji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(!double.IsNaN(edge.To.Limit))
            {
                edge.From.Move(edge.To.X - edge.From.X, 0);
            }
            else
                edge.To.Move(edge.From.X-edge.To.X, 0);
            edge.Limit = 90;
            ReprintPicture();
        }

        private void toolStripMenuItemHorizontalEdge_Click(object sender, EventArgs e)
        {
            Edge edge = (Edge)selected;
            if (edge.Next.Limit == 0 || edge.Previous.Limit == 0)
            {
                MessageBox.Show("Dwie kolejne krawędzie nie mogą być poziome.", "Błąd relacji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!double.IsNaN(edge.To.Limit))
            {
                edge.From.Move(0,edge.To.Y - edge.From.Y);
            }
            else
                edge.To.Move(0,edge.From.Y - edge.To.Y);
            edge.Limit = 0;
            ReprintPicture();
        }

        private void toolStripMenuItemDeleteVertLimit_Click(object sender, EventArgs e)
        {
            ((MyPoint)selected).Limit = double.NaN;
            selectedType = SelectedType.Empty;
            selected = null;
            ReprintPicture();
        }

        private void toolStripMenuItemDegree_Click(object sender, EventArgs e)
        {
            MyPoint vert = (MyPoint)selected;
            double l = vert.Next.Degree - vert.Previous.Degree;
            Form2 dialog = new Form2();
            dialog.deg = l*180/Math.PI;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                vert.Limit = dialog.deg * Math.PI / 180;
                vert.Move(0, 0);
            }
            dialog.Dispose();
            selectedType = SelectedType.Empty;
            selected = null;
            ReprintPicture();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            status = State.CreateCircle;
            button1.Enabled = false;
        }
    }
}
