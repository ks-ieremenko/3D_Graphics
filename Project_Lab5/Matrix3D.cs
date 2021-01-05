using System;
using System.Drawing;

namespace Project_Lab5
{
    class Matrix3D
    {
        private float[] matrixXYZ;
        private float[] res;
        public Matrix3D(float x, float y, float z)
        {
            matrixXYZ = new float[] { x, y, z, 1 };
        }
        public float GetX()
        {
            return matrixXYZ[0];
        }
        public float GetY()
        {
            return matrixXYZ[1];
        }
        public float GetZ()
        {
            return matrixXYZ[2];
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
        
        public PointF To3DPoints(string ans = "0", int size = 1)
        {
            float x = (ans == "x") ? 0 : GetX(); // если проекция на YZ
            float y = (ans == "y") ? 0 : GetY(); // если проекция на XZ
            float z = (ans == "z") ? 0 : GetZ(); // если проекция на XY
            return new PointF((x - z / 2) * size, -(y - z / 2) * size);
        }
        public float [,] RotationOX(float angle)
        {
            float[,] matrix_rotateX = new float[4, 4];
            Array.Clear(matrix_rotateX, 0, 4);
            float sin = (float)Math.Sin(DegreeToRad(angle));
            float cos = (float)Math.Cos(DegreeToRad(angle));
            matrix_rotateX[0, 0] = 1; matrix_rotateX[1, 1] = cos;
            matrix_rotateX[2, 2] = cos; matrix_rotateX[3, 3] = 1;
            matrix_rotateX[1, 2] = sin; matrix_rotateX[2, 1] = -sin;
            return matrix_rotateX;
        }
        public float[,] RotationOY(float angle)
        {
            float[,] matrix_rotateY = new float[4, 4];
            Array.Clear(matrix_rotateY, 0, 4);
            float sin = (float)Math.Sin(DegreeToRad(angle));
            float cos = (float)Math.Cos(DegreeToRad(angle));
            matrix_rotateY[0, 0] = cos; matrix_rotateY[1, 1] = 1;
            matrix_rotateY[2, 2] = cos; matrix_rotateY[3, 3] = 1;
            matrix_rotateY[0, 2] = -sin; matrix_rotateY[2, 0] = sin;
            return matrix_rotateY;
        }
        public float[,] RotationOZ(float angle)
        {
            float[,] matrix_rotateZ = new float[4, 4];
            Array.Clear(matrix_rotateZ, 0, 4);
            float sin = (float)Math.Sin(DegreeToRad(angle));
            float cos = (float)Math.Cos(DegreeToRad(angle));
            matrix_rotateZ[0, 0] = cos; matrix_rotateZ[1, 1] = cos;
            matrix_rotateZ[2, 2] = 1; matrix_rotateZ[3, 3] = 1;
            matrix_rotateZ[1, 0] = -sin; matrix_rotateZ[0, 1] = sin;
            return matrix_rotateZ;
        }
        public float DegreeToRad(float angle)
        {
            return (float)((angle * Math.PI) / 180); // перевод в радианы
        }
    }
}
