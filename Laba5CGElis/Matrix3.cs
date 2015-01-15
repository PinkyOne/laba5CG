using System;
using System.Collections.Generic;
using System.Text;

namespace Laba5
{
    public class Matrix3
    {
        public float[,] M = new float[4, 4];

        public Matrix3()
        {
            Identity3();
        }

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
        public void Identity3()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
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
        public static Matrix3 operator *(Matrix3 m1, Matrix3 m2)
        {
            Matrix3 result = new Matrix3();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    float element = 0;
                    for (int k = 0; k < 4; k++)
                    {
                        element += m1.M[i, k] * m2.M[k, j];
                    }
                    result.M[i, j] = element;
                }
            }
            return result;
        }

        // Умножение матрицы на вектор:
        public float[] VectorMultiply(float[] vector)
        {
            float[] result = new float[4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    result[i] += M[i, j] * vector[j];
                }
            }
            return result;
        }    

        // Матрица преобразования:
        public static Matrix3 Translate3(float dx, float dy, float dz)
        {
            Matrix3 result = new Matrix3();
            result.M[0, 3] = dx;
            result.M[1, 3] = dy;
            result.M[2, 3] = dz;
            return result;
        } 

        // Аксонометрическая проекция:
        public static Matrix3 Axonometric(float alpha, float beta)
        {
            Matrix3 result = new Matrix3();
            float sna = (float)Math.Sin(alpha * Math.PI / 180);
            float cna = (float)Math.Cos(alpha * Math.PI / 180);
            float snb = (float)Math.Sin(beta * Math.PI / 180);
            float cnb = (float)Math.Cos(beta * Math.PI / 180);
            result.M[0, 0] = cnb;
            result.M[0, 2] = snb;
            result.M[1, 0] = sna * snb;
            result.M[1, 1] = cna;
            result.M[1, 2] = -sna * cnb;
            result.M[2, 2] = 0;
            return result;
        }

        //Функция фигуры (капли) в прострвнстве по циллиндричиским координатам
        public Point3 Obj(float r, float theta, float phi)
        {
            Point3 pt = new Point3();
            float sinT = (float)Math.Sin(theta * Math.PI / 180);
            float sin2T = (float)Math.Sin(phi * Math.PI / 90);
            float cosT = (float)Math.Cos(theta * Math.PI / 180);
            float sinP = (float)Math.Sin(phi * Math.PI / 180);
            float cosP = (float)Math.Cos(phi * Math.PI / 180);
            pt.X = (float)(r * sinT * cosP * (1 + 0.5 * Math.Abs(sin2T)));
            pt.Y = (float)(r * sinT * sinP * (1 + 0.5 * Math.Abs(sin2T)));
            pt.Z = r * cosT;
            /*if (theta > 0) pt.Z = r * cosT - r * (float)Math.Pow(theta / 141, 4); else pt.Z = r * cosT; */
            return pt;
        }
    }
}
