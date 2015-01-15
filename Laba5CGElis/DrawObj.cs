using System;
using System.Drawing;
using System.Windows.Forms;

namespace Laba5
{
    public class DrawObj
    {
        private Form1 form1;
        private float r = 10;
        private float xc = 0;
        private float yc = 0;
        private float zc = 0;

        public DrawObj(Form1 fm1)
        {
            form1 = fm1;
        }

        public DrawObj(Form1 fm1, float r1, float xc1, float yc1, float zc1)
        {
            form1 = fm1;
            r = r1;
            xc = xc1;
            yc = yc1;
            zc = zc1;
        }

        public Point3[,] ObjCoordinates(int dis)
        {
            Point3[,] pts = new Point3[dis, dis];
            Matrix3 m = new Matrix3();
            Matrix3 mt = Matrix3.Translate3(xc, yc, zc);

            for (int i = 0; i < pts.GetLength(0); i++)
            {
                for (int j = 0; j < pts.GetLength(1); j++)
                {
                    pts[i, j] = m.Obj(r, i * 180 / (pts.GetLength(0) - 1),
                        j * 360 / (pts.GetLength(1) - 1));
                    pts[i, j].Transform(mt);
                }
            }
            return pts;
        }

        public void DrawIsometricView(Graphics g, float alpha, float beta, Color cl,int setk)
        {
            Matrix3 m = Matrix3.Axonometric(alpha, beta);
            Point3[,] pts = ObjCoordinates(setk);
            PointF[,] pta = new PointF[pts.GetLength(0), pts.GetLength(1)];
            for (int i = 0; i < pts.GetLength(0); i++)
            {
                for (int j = 0; j < pts.GetLength(1); j++)
                {
                    pts[i, j].Transform(m);
                    pta[i, j] = Point2D(new PointF(pts[i, j].X, pts[i, j].Y));
                }
            }

            PointF[] ptf = new PointF[4];
            Brush brush = new SolidBrush(cl);
            for (int i = 1; i < pts.GetLength(0); i++)
            {
                for (int j = 1; j < pts.GetLength(1); j++)
                {
                    ptf[0] = pta[i - 1, j - 1];
                    ptf[1] = pta[i, j - 1];
                    ptf[2] = pta[i, j];
                    ptf[3] = pta[i - 1, j];
                   // g.FillPolygon(brush, ptf);
                    g.DrawPolygon(Pens.Black, ptf);
                    g.FillPolygon(new SolidBrush(Color.Red),ptf );
                }
            }
        }

        private PointF Point2D(PointF pt)
        {
            PointF aPoint = new PointF();
            aPoint.X = form1.panel1.Width / 2 + pt.X;
            aPoint.Y = form1.panel1.Height / 2 - pt.Y;
            return aPoint;
        }
    }
}
