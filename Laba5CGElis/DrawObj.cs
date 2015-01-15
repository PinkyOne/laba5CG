// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DrawObj.cs" company="">
//   
// </copyright>
// <summary>
//   The draw obj.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;
using System.Drawing;
using System.Windows.Forms;

namespace Laba5
{
    /// <summary>
    /// The draw obj.
    /// </summary>
    public class DrawObj
    {
        /// <summary>
        /// The form 1.
        /// </summary>
        private Form1 form1;

        /// <summary>
        /// The r.
        /// </summary>
        private float r = 10;

        /// <summary>
        /// The xc.
        /// </summary>
        private float xc = 0;

        /// <summary>
        /// The yc.
        /// </summary>
        private float yc = 0;

        /// <summary>
        /// The zc.
        /// </summary>
        private float zc = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="DrawObj"/> class.
        /// </summary>
        /// <param name="fm1">
        /// The fm 1.
        /// </param>
        /// <param name="r1">
        /// The r 1.
        /// </param>
        /// <param name="xc1">
        /// The xc 1.
        /// </param>
        /// <param name="yc1">
        /// The yc 1.
        /// </param>
        /// <param name="zc1">
        /// The zc 1.
        /// </param>
        public DrawObj(Form1 fm1, float r1, float xc1, float yc1, float zc1)
        {
            form1 = fm1;
            r = r1;
            xc = xc1;
            yc = yc1;
            zc = zc1;
        }

        /// <summary>
        /// The obj coordinates.
        /// </summary>
        /// <param name="dis">
        /// The dis.
        /// </param>
        /// <returns>
        /// The <see cref="Point3[,]"/>.
        /// </returns>
        public Point3[,] ObjCoordinates(int dis)
        {
            var pts = new Point3[dis, dis];
            var m = new Matrix3();
            var mt = Matrix3.Translate3(xc, yc, zc);

            for (var i = 0; i < pts.GetLength(0); i++)
            {
                for (var j = 0; j < pts.GetLength(1); j++)
                {
                    pts[i, j] = m.Obj(r, i * 180 / (pts.GetLength(0) - 1), j * 360 / (pts.GetLength(1) - 1));
                    pts[i, j].Transform(mt);
                }
            }

            return pts;
        }

        /// <summary>
        /// The draw isometric view.
        /// </summary>
        /// <param name="g">
        /// The g.
        /// </param>
        /// <param name="alpha">
        /// The alpha.
        /// </param>
        /// <param name="beta">
        /// The beta.
        /// </param>
        /// <param name="cl">
        /// The cl.
        /// </param>
        /// <param name="setka">
        /// The setka.
        /// </param>
        public void DrawIsometricView(Graphics g, float alpha, float beta, Color cl, int setka)
        {
            var m = Matrix3.Axonometric(alpha, beta);
            var pts = ObjCoordinates(setka);
            var pta = new PointF[pts.GetLength(0), pts.GetLength(1)];
            for (var i = 0; i < pts.GetLength(0); i++)
            {
                for (var j = 0; j < pts.GetLength(1); j++)
                {
                    pts[i, j].Transform(m);
                    pta[i, j] = Point2D(new PointF(pts[i, j].X, pts[i, j].Y));
                }
            }

            var ptf = new PointF[4];
            for (var i = 1; i < pta.GetLength(0); i++)
            {
                for (var j = 1; j < pta.GetLength(1); j++)
                {
                    ptf[0] = pta[i - 1, j - 1];
                    ptf[1] = pta[i, j - 1];
                    ptf[2] = pta[i, j];
                    ptf[3] = pta[i - 1, j];
                    g.DrawPolygon(Pens.Black, ptf);
                    g.FillPolygon(new SolidBrush(Color.DeepSkyBlue), ptf);
                }
            }
        }

        /// <summary>
        /// The point 2 d.
        /// </summary>
        /// <param name="pt">
        /// The pt.
        /// </param>
        /// <returns>
        /// The <see cref="PointF"/>.
        /// </returns>
        private PointF Point2D(PointF pt)
        {
            var aPoint = new PointF();
            aPoint.X = form1.panel1.Width / 2 + pt.X;
            aPoint.Y = form1.panel1.Height / 2 - pt.Y;
            return aPoint;
        }
    }
}