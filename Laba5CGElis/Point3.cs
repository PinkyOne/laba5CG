// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Point3.cs" company="">
//   
// </copyright>
// <summary>
//   The point 3.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;
using System.Collections.Generic;
using System.Text;

namespace Laba5
{
    /// <summary>
    /// The point 3.
    /// </summary>
    public class Point3
    {
        /// <summary>
        /// The x.
        /// </summary>
        public float X;

        /// <summary>
        /// The y.
        /// </summary>
        public float Y;

        /// <summary>
        /// The z.
        /// </summary>
        public float Z;

        /// <summary>
        /// The w.
        /// </summary>
        public float W = 1f;

        /// <summary>
        /// Initializes a new instance of the <see cref="Point3"/> class.
        /// </summary>
        public Point3()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Point3"/> class.
        /// </summary>
        /// <param name="x">
        /// The x.
        /// </param>
        /// <param name="y">
        /// The y.
        /// </param>
        /// <param name="z">
        /// The z.
        /// </param>
        /// <param name="w">
        /// The w.
        /// </param>
        public Point3(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        /// <summary>
        /// The transform.
        /// </summary>
        /// <param name="m">
        /// The m.
        /// </param>
        public void Transform(Matrix3 m)
        {
            var result = m.VectorMultiply(new[] { X, Y, Z, W });
            X = result[0];
            Y = result[1];
            Z = result[2];
            W = result[3];
        }

        /// <summary>
        /// The transform normalize.
        /// </summary>
        /// <param name="m">
        /// The m.
        /// </param>
        public void TransformNormalize(Matrix3 m)
        {
            var result = m.VectorMultiply(new[] { X, Y, Z, W });
            X = result[0] / result[3];
            Y = result[1] / result[3];
            Z = result[2];
            W = 1;
        }
    }
}
