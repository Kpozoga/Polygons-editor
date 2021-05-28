using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace grafika_wielokaty
{
    public class MyPoint 
    {
        public double X { set; get; }
        public double Y { set; get; }
        public Edge Next { set; get; }
        public Edge Previous { set; get; }
        public double Limit = double.NaN;
        public MyPoint(double x, double y)
        {
            X = x; Y = y;
        }
        public static implicit operator MyPoint(Point p)
        {
            return new MyPoint(p.X, p.Y);
        }
        public bool IsEmpty
        {
            get
            {
                if (X == 0 && Y == 0) return true;
                return false;
            }
        }
        static public MyPoint Empty
        {
            get { return new MyPoint(0, 0); }
        }
        public void Move(double dx, double dy,int l=1,int d=1)
        {
            
            if(l==1)
            {
                if (Previous.Limit >= 0)
                {
                    Previous.Move(dx, dy,1, 1, 0);
                }
                if (Next.Limit >= 0)
                {
                    Next.Move(dx, dy,1, 0, 1);
                }

                this.X += dx;
                this.Y += dy;
                if (!double.IsNaN(Limit))
                {
                    if (Next.Limit>=0||d==0)
                    {
                        double a = Math.Tan(Next.Degree - Limit);
                        Edge.FindIntersection(this, new MyPoint(this.X + 1, this.Y + a), Previous.Previous.From, Previous.Previous.To, out MyPoint point);
                        if (double.IsNaN(point.X)) return;
                        point.Limit = Previous.From.Limit;
                        Previous.From = point;

                    }
                    else
                    {
                        double a = Math.Tan(Previous.Degree + Limit);
                        Edge.FindIntersection(this, new MyPoint(this.X + 1, this.Y + a), Next.Next.From, Next.Next.To, out MyPoint point);
                        if (double.IsNaN(point.X)) return;
                        point.Limit = Next.To.Limit;
                        Next.To = point;
                    }
                }
                if ((d==1||d==2)&&!(Next.Limit >= 0) && !double.IsNaN(Next.To.Limit))
                    Next.To.Move(0, 0);
                if ((d == 0||d==2) && !(Previous.Limit >= 0) &&!double.IsNaN(Previous.From.Limit))
                    Previous.From.Move(0, 0, 1, 0);
            }

            else
            {
                this.X += dx;
                this.Y += dy;
            }
        }
        public bool IsInsidePoint(MyPoint point)
        {
            double w = 4;
            if (point.X > this.X + w) return false;
            if (point.X < this.X - w) return false;
            if (point.Y > this.Y + w) return false;
            if (point.Y < this.Y - w) return false;
            return true;
        }
    }
}
