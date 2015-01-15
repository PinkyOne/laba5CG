// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Matrix3.cs" company="">
//   
// </copyright>
// <summary>
//   The matrix 3.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;
using System.Collections.Generic;
using System.Text;

namespace Laba5
{
    /// <summary>
    /// The matrix 3.
    /// </summary>
    public class Matrix3
    {
        /// <summary>
        /// The m.
        /// </summary>
        public float[,] M = new float[4, 4];

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix3"/> class.
        /// </summary>
        public Matrix3()
        {
            Identity3();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix3"/> class.
        /// </summary>
        /// <param name="m00">
        /// The m 00.
        /// </param>
        /// <param name="m01">
        /// The m 01.
        /// </param>
        /// <param name="m02">
        /// The m 02.
        /// </param>
        /// <param name="m03">
        /// The m 03.
        /// </param>
        /// <param name="m10">
        /// The m 10.
        /// </param>
        /// <param name="m11">
        /// The m 11.
        /// </param>
        /// <param name="m12">
        /// The m 12.
        /// </param>
        /// <param name="m13">
        /// The m 13.
        /// </param>
        /// <param name="m20">
        /// The m 20.
        /// </param>
        /// <param name="m21">
        /// The m 21.
        /// </param>
        /// <param name="m22">
        /// The m 22.
        /// </param>
        /// <param name="m23">
        /// The m 23.
        /// </param>
        /// <param name="m30">
        /// The m 30.
        /// </param>
        /// <param name="m31">
        /// The m 31.
        /// </param>
        /// <param name="m32">
        /// The m 32.
        /// </param>
        /// <param name="m33">
        /// The m 33.
        /// </param>
        public Matrix3(float m00, float m01, float m02, float m03, 
                       float m10, float m11, float m12, float m13, 
                       float m20, float m21, float m22, float m23, 
                       float m30, float m31, float m32, float m33)
        {
            M[0, 0] = m00;
            M[0, 1] = m01;
            M[0, 2] = m02;
            M[0, 3] = m03;
            M[1, 0] = m10;
            M[1, 1] = m11;
            M[1, 2] = m12;
            M[1, 3] = m13;
            M[2, 0] = m20;
            M[2, 1] = m21;
            M[2, 2] = m22;
            M[2, 3] = m23;
            M[3, 0] = m30;
            M[3, 1] = m31;
            M[3, 2] = m32;
            M[3, 3] = m33;
        }

        // Единичной матрица, только на диагонали единицы:
        /// <summary>
        /// The identity 3.
        /// </summary>
        public void Identity3()
        {
            for (var i = 0; i < 4; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    if (i == j)
                    {
                        M[i, j] = 1;
                    }
                    else
                    {
                        M[i, j] = 0;
                    }
                }
            }
        }

        // Умножение двух матриц:
        /// <summary>
        /// The *.
        /// </summary>
        /// <param name="m1">
        /// The m 1.
        /// </param>
        /// <param name="m2">
        /// The m 2.
        /// </param>
        /// <returns>
        /// </returns>
        public static Matrix3 operator *(Matrix3 m1, Matrix3 m2)
        {
            var result = new Matrix3();
            for (var i = 0; i < 4; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    float element = 0;
                    for (var k = 0; k < 4; k++)
                    {
                        element += m1.M[i, k] * m2.M[k, j];
                    }

                    result.M[i, j] = element;
                }
            }

            return result;
        }

        // Умножение матрицы на вектор:
        /// <summary>
        /// The vector multiply.
        /// </summary>
        /// <param name="vector">
        /// The vector.
        /// </param>
        /// <returns>
        /// The <see cref="float[]"/>.
        /// </returns>
        public float[] VectorMultiply(float[] vector)
        {
            var result = new float[4];
            for (var i = 0; i < 4; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    result[i] += M[i, j] * vector[j];
                }
            }

            return result;
        }    

        // Матрица преобразования:
        /// <summary>
        /// The translate 3.
        /// </summary>
        /// <param name="dx">
        /// The dx.
        /// </param>
        /// <param name="dy">
        /// The dy.
        /// </param>
        /// <param name="dz">
        /// The dz.
        /// </param>
        /// <returns>
        /// The <see cref="Matrix3"/>.
        /// </returns>
        public static Matrix3 Translate3(float dx, float dy, float dz)
        {
            var result = new Matrix3();
            result.M[0, 3] = dx;
            result.M[1, 3] = dy;
            result.M[2, 3] = dz;
            return result;
        } 

        // Аксонометрическая проекция:
        /// <summary>
        /// The axonometric.
        /// </summary>
        /// <param name="alpha">
        /// The alpha.
        /// </param>
        /// <param name="beta">
        /// The beta.
        /// </param>
        /// <returns>
        /// The <see cref="Matrix3"/>.
        /// </returns>
        public static Matrix3 Axonometric(float alpha, float beta)
        {
            var result = new Matrix3();
            var sinAlpha = (float)Math.Sin(alpha * Math.PI / 180);
            var cosAlpha = (float)Math.Cos(alpha * Math.PI / 180);
            var sinBeta = (float)Math.Sin(beta * Math.PI / 180);
            var cosBeta = (float)Math.Cos(beta * Math.PI / 180);
            result.M[0, 0] = cosBeta;
            result.M[0, 2] = sinBeta;
            result.M[1, 0] = sinAlpha * sinBeta;
            result.M[1, 1] = cosAlpha;
            result.M[1, 2] = -sinAlpha * cosBeta;
            result.M[2, 2] = 0;
            return result;
        }

        // Функция фигуры (капли) в прострвнстве по циллиндричиским координатам
        /// <summary>
        /// The obj.
        /// </summary>
        /// <param name="r">
        /// The r.
        /// </param>
        /// <param name="theta">
        /// The theta.
        /// </param>
        /// <param name="phi">
        /// The phi.
        /// </param>
        /// <returns>
        /// The <see cref="Point3"/>.
        /// </returns>
        public Point3 Obj(float r, float theta, float phi)
        {
            var point3 = new Point3();
            var sinTheta = (float)Math.Sin(theta * Math.PI / 180);
            var sin2Theta = (float)Math.Sin(phi * Math.PI / 90);
            var cosTheta = (float)Math.Cos(theta * Math.PI / 180);
            var sinPhi = (float)Math.Sin(phi * Math.PI / 180);
            var cosPhi = (float)Math.Cos(phi * Math.PI / 180);
            point3.X = (float)(r * sinTheta * cosPhi * (1 + 0.5 * Math.Abs(sin2Theta)));
            point3.Y = (float)(r * sinTheta * sinPhi * (1 + 0.5 * Math.Abs(sin2Theta)));
            point3.Z = r * cosTheta;
            return point3;
        }
    }
}
