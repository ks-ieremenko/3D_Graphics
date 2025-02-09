﻿using System;
using System.Drawing;

namespace Project_Lab5
{
    public class Matrix3D : ICloneable
    {
        private float[] matrixXYZ;
        private float[] res;

        public float X
        {
            get => matrixXYZ[0];
            set => matrixXYZ[0] = value;
        }
        public float Y
        {
            get => matrixXYZ[1];
            set => matrixXYZ[1] = value;
        }
        public float Z
        {
            get => matrixXYZ[2];
            set => matrixXYZ[2] = value;
        }

        public Matrix3D(float x, float y, float z)
        {
            matrixXYZ = new[] { x, y, z, 1 };
        }

        public static float[,] Mul(float[,] matrix1, float[,] matrix2)
        {
            float sum;
            float[,] result = new float[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    sum = 0;
                    for (int k = 0; k < 4; k++)
                        sum += matrix1[i, k] * matrix2[k, j];
                    result[i, j] = sum;
                }
            }
            return result;
        }
        public Matrix3D Mul(float[,] matrix)
        {
            float sum;
            res = new float[4];
            for (int j = 0; j < 4; j++)
            {
                sum = 0;
                for (int k = 0; k < 4; k++)
                    sum += matrixXYZ[k] * matrix[k, j];
                res[j] = sum;
            }

            Matrix3D ans = new Matrix3D(res[0], res[1], res[2]);
            return ans;
        }

        public float[,] RotationOX(float angle)
        {
            float[,] matrixRotateX = new float[4, 4];
            Array.Clear(matrixRotateX, 0, 4);
            float sin = (float)Math.Sin(DegreeToRad(angle));
            float cos = (float)Math.Cos(DegreeToRad(angle));

            matrixRotateX[0, 0] = matrixRotateX[3, 3] = 1;
            matrixRotateX[1, 1] = matrixRotateX[2, 2] = cos;
            matrixRotateX[1, 2] = sin;
            matrixRotateX[2, 1] = -sin;
            return matrixRotateX;
        }

        public float[,] RotationOY(float angle)
        {
            float[,] matrixRotateY = new float[4, 4];
            Array.Clear(matrixRotateY, 0, 4);
            float sin = (float)Math.Sin(DegreeToRad(angle));
            float cos = (float)Math.Cos(DegreeToRad(angle));
            matrixRotateY[0, 0] = matrixRotateY[2, 2] = cos;
            matrixRotateY[1, 1] = matrixRotateY[3, 3] = 1;
            matrixRotateY[0, 2] = -sin;
            matrixRotateY[2, 0] = sin;
            return matrixRotateY;
        }

        public float[,] RotationOZ(float angle)
        {
            float[,] matrixRotateZ = new float[4, 4];
            Array.Clear(matrixRotateZ, 0, 4);
            float sin = (float)Math.Sin(DegreeToRad(angle));
            float cos = (float)Math.Cos(DegreeToRad(angle));
            matrixRotateZ[0, 0] = matrixRotateZ[1, 1] = cos;
            matrixRotateZ[2, 2] = matrixRotateZ[3, 3] = 1;
            matrixRotateZ[1, 0] = -sin;
            matrixRotateZ[0, 1] = sin;
            return matrixRotateZ;
        }

        public static float DegreeToRad(float angle)
        {
            return (float)(angle * Math.PI / 180); // перевод в радианы
        }

        public static Matrix3D operator -(Matrix3D a, Matrix3D b)
        {
            return new Matrix3D(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }
        public static Matrix3D operator +(Matrix3D a, Matrix3D b)
        {
            return new Matrix3D(b.X + a.X, b.Y + a.Y, b.Z + a.Z);
        }
        public static Matrix3D operator +(Matrix3D a, float number)
        {
            return new Matrix3D(a.X + number, a.Y, a.Z);
        }
        public static Matrix3D operator *(Matrix3D a, float length)
        {
            return new Matrix3D(a.X * length, a.Y * length, a.Z * length);
        }

        public static implicit operator PointF(Matrix3D a)
        {
            return new PointF((a.X - a.Z / 2), -(a.Y - a.Z / 2));
        }

        public object Clone()
        {
            return new Matrix3D(X, Y, Z);
        }
    }
}