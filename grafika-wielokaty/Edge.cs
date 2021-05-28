using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace grafika_wielokaty
{
    public class Edge
    {
        private MyPoint from;
        private MyPoint to;
        public MyPoint From { set
            {
                from = value;
                value.Next = this;
                if (previous != null)
                {
                    previous.to = value;
                    value.Previous = previous;
                }
            } get {  return from;  } }
        public MyPoint To{ set {
                to = value;
                value.Previous = this;
                if (next != null)
                {
                    next.from = value;
                    value.Next = next;
                }
            } get {  return to; } }
        private Edge next;
        private Edge previous;
        public Edge Next { set { next = value; value.previous = this; } get { return next; } }
        public Edge Previous { set { previous = value; value.next = this; } get { return previous; } }
        public double Degree { get {return Math.Atan((to.Y - from.Y) / (to.X - from.X)); }  }
        public double Limit=-1;

        public Edge(MyPoint a,MyPoint b)
        {
            From = a;
            To = b;

        }

        public void Move(double dx, double dy, int l = 1, int f=1,int t=1)
        {
            if (To.X + dx == Next.To.X) dx += 0.0001;
            if (To.Y + dy == Next.To.Y) dy += 0.0001;
            if (From.X + dx == Previous.From.X) dx += 0.0001;
            if (From.Y + dy == Previous.From.Y) dy += 0.0001;

            MyPoint fpoint=MyPoint.Empty,tpoint=MyPoint.Empty;
            if(f==1)
            FindIntersection(new MyPoint(this.From.X + dx, this.From.Y + dy), new MyPoint(this.To.X + dx, this.To.Y + dy),
                       this.Previous.From, this.Previous.To, out fpoint);
            if(t==1)
            FindIntersection(new MyPoint(this.From.X + dx, this.From.Y + dy), new MyPoint(this.To.X + dx, this.To.Y + dy),
                this.Next.From, this.Next.To, out tpoint);

            if (f==1&&double.IsNaN(fpoint.X)) return;
            if (t == 1 && double.IsNaN(tpoint.X)) return;
            if (f == 1)
            {
                fpoint.Limit = from.Limit;
                this.From = fpoint;
            }
            if (t == 1)
            {
                tpoint.Limit = to.Limit;
                this.To = tpoint;
            }


        }
        public bool IsOnEdge(MyPoint point)
        {
            double w = 4;
            if (minimum_distance(this.From, this.To, point) > w) return false;
            return true;
        }
        private double minimum_distance(MyPoint v, MyPoint w, MyPoint p)
        {
            //https://stackoverflow.com/questions/849211/shortest-distance-between-a-point-and-a-line-segment
            // Return minimum distance between line segment vw and MyPoint p
            double l2 = Math.Pow(v.X - w.X, 2) + Math.Pow(v.Y - w.Y, 2);  // i.e. |w-v|^2 -  avoid a sqrt
                                                                          // v == w case
                                                                          // Consider the line extending the segment, parameterized as v + t (w - v).
                                                                          // We find projection of MyPoint p onto the line. 
                                                                          // It falls where t = [(p-v) . (w-v)] / |w-v|^2
                                                                          // We clamp t from [0,1] to handle MyPoints outside the segment vw.
            double t = Math.Max(0, Math.Min(1, ((p.X - v.X) * (w.X - v.X) + (p.Y - v.Y) * (w.Y - v.Y)) / l2));
            double x = v.X + t * (w.X - v.X);
            double y = v.Y + t * (w.Y - v.Y); // Projection falls on the segment
            return Math.Sqrt(Math.Pow(p.X - x, 2) + Math.Pow(p.Y - y, 2));
        }
      
        // Find the point of intersection between
        // the lines p1 --> p2 and p3 --> p4.
        //http://csharphelper.com/blog/2014/08/determine-where-two-lines-intersect-in-c/
        static public void FindIntersection(MyPoint p1, MyPoint p2, MyPoint p3, MyPoint p4, out MyPoint intersection)
        {
            // Get the segments' parameters.
            double dx12 = p2.X - p1.X;
            double dy12 = p2.Y - p1.Y;
            double dx34 = p4.X - p3.X;
            double dy34 = p4.Y - p3.Y;
            
            // Solve for t1 and t2
            double denominator = (dy12 * dx34 - dx12 * dy34);
            double t1 = ((p1.X - p3.X) * dy34 + (p3.Y - p1.Y) * dx34)/ denominator;
            if (double.IsInfinity(t1))
            {
                // The lines are parallel (or close enough to it).
                intersection = new MyPoint(double.NaN, double.NaN);
                return;
            }
            double t2 =((p3.X - p1.X) * dy12 + (p1.Y - p3.Y) * dx12)/ -denominator;
            // Find the point of intersection.
            intersection = new MyPoint(p1.X + dx12 * t1, p1.Y + dy12 * t1);
        }
    }
}
