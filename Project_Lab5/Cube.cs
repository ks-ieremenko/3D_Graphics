using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Project_Lab5
{
    public class Cube
    {
        public int CurrentSize { get; set; }
        public List<Matrix3D> Points { get; set; }
        public Cube(int currentSize)
        {
            CurrentSize = currentSize;
        }

        public Matrix3D Check(Matrix3D matrix, string projection)
        {
            Matrix3D m = (Matrix3D)matrix.Clone();
            switch (projection)
            {
                case "0":
                    break;
                case "x":
                    m.X = 0;
                    break;
                case "y":
                    m.Y = 0;
                    break;
                case "z":
                    m.Z = 0;
                    break;
            }

            return m * CurrentSize;
        }
        public void DrawCube(ref Graphics gr, List<Matrix3D> cubePoints, Pen pen, Brush brush, string projection = "0")
        {
            PointF start, end;
            for (int i = 0; i < 8; i++) // прорисовка куба по точкам, получаем 2 квадрата
            {
                start = Check(cubePoints[i], projection); // начальная точка
                gr.FillEllipse(brush, start.X - CurrentSize / 40 - 1, start.Y - CurrentSize / 40, CurrentSize / 20,
                    CurrentSize / 20); // точки на кубе
                //конечная точка
                end = i == 3 || i == 7
                     ? Check(cubePoints[i - 3], projection)
                     : Check(cubePoints[i + 1], projection);
                gr.DrawLine(pen, start, end);
                if (i < 4) // для 4 линий, которые соединяют вершины квадратов
                {
                    end = Check(cubePoints[i + 4], projection);
                    gr.DrawLine(pen, start, end);
                }
            }
        }

        public void FillCube(ref Graphics gr, Brush brush)
        {
            PointF[] square = new PointF[4]; // квадрат ABCD
            PointF[] square2 = new PointF[4]; // квадрат EFGH
            for (int i = 0; i < 4; i++)
            {
                square[i] = Points[i] * CurrentSize;
                square2[i] = Points[i + 4] * CurrentSize;
            }

            gr.FillPolygon(brush, square);
            gr.FillPolygon(brush, square2);

            for (int i = 1, j = 0; i >= 0; i--, j++)
                square[j] = Points[i] * CurrentSize;
            for (int i = 4, j = 2; i <= 5; i++, j++)
                square[j] = Points[i] * CurrentSize;
            gr.FillPolygon(brush, square); //квадрат BAEF 1045

            for (int i = 2, j = 0; i <= 3; i++, j++)
                square[j] = Points[i] * CurrentSize;
            for (int i = 7, j = 2; i >= 6; i--, j++)
                square[j] = Points[i] * CurrentSize;
            gr.FillPolygon(brush, square); //квадрат CDHG 2376

            for (int i = 1, j = 0; i <= 2; i++, j++)
                square[j] = Points[i] * CurrentSize;
            for (int i = 6, j = 2; i >= 5; i--, j++)
                square[j] = Points[i] * CurrentSize;
            gr.FillPolygon(brush, square); //квадрат BCGF 1265

            for (int i = 0, j = 0; i <= 3; i += 3, j++)
                square[j] = Points[i] * CurrentSize;
            for (int i = 7, j = 2; i >= 4; i -= 3, j++)
                square[j] = Points[i] * CurrentSize;
            gr.FillPolygon(brush, square); // квадрат ADHE 0374
        }

        public void Projection(ref Graphics gr, List<Matrix3D> cubePoints, string[] projections)
        {
            Color color = Color.LightPink;
            Pen pen = new Pen(color, 1) { DashStyle = DashStyle.Dash };
            foreach (var projection in projections)
            {
                for (int i = 0; i < 8; i++)
                {
                    gr.DrawLine(pen, Check(cubePoints[i], projection),
                        cubePoints[i] * CurrentSize);
                }
                if (projection != "0")
                    DrawCube(ref gr, cubePoints, new Pen(color, 1), new SolidBrush(color), projection);
            }
        }

        public void ChangeCubeColor(ref Graphics gr, Brush brush)
        {
            FillCube(ref gr, brush);
        }

        public List<Matrix3D> Translation(List<Matrix3D> cubePoints, float dx = 0, float dy = 0, float dz = 0)
        {
            var matrixTranslation = new float[4, 4];
            Array.Clear(matrixTranslation, 0, 4);
            for (int i = 0; i < 4; i++)
                matrixTranslation[i, i] = 1;

            matrixTranslation[3, 0] = dx;
            matrixTranslation[3, 1] = dy;
            matrixTranslation[3, 2] = dz;
            List<Matrix3D> newCubePoints = new List<Matrix3D>(); // список для новых координат куба после перемещений
            for (int i = 0; i < 8; i++)
            {
                Matrix3D translation = cubePoints[i].Mul(matrixTranslation);
                newCubePoints.Add(translation);
            }

            return newCubePoints;
        }

        public List<Matrix3D> Rotation(List<Matrix3D> cubePoints, float angleX = 0, float angleY = 0, float angleZ = 0)
        {
            List<Matrix3D> newCubePoints = new List<Matrix3D>(); // список для новых координат куба после поворота

            for (int i = 0; i < 8; i++)
            {
                Matrix3D rotation = cubePoints[i]
                    .Mul(cubePoints[i].RotationOX(angleX)) //поворот по Х
                    .Mul(cubePoints[i].RotationOY(angleY)) //поворот по Y
                    .Mul(cubePoints[i].RotationOZ(angleZ)); //поворот по Z
                newCubePoints.Add(rotation);
            }

            return newCubePoints;
        }

        public List<Matrix3D> RotationVector(CheckBox drawLine, CheckBox extendLine, string startVector,
            string endVector, ref Graphics gr, List<Matrix3D> cubePoints, float angle = 0)
        {
            Matrix3D startVec = new Matrix3D(0, 0, 0), endVec = new Matrix3D(0, 0, 0);
            const string pattern = "-?[0-9]+;-?[0-9]+;-?[0-9]+"; //шаблон формата 1;1;1
            string[] start = startVector.Split(';'); // координаты начала вектора
            string[] end = endVector.Split(';'); // координаты конца вектора
            try
            {
                if (startVector == endVector)
                    throw new Exception("Заданная прямая не может быть точкой");
                if (!Regex.IsMatch(startVector, pattern))
                    throw new Exception("Неверно введенные координаты начала вектора");
                startVec = new Matrix3D(int.Parse(start[0]), int.Parse(start[1]), int.Parse(start[2]));
                if (!Regex.IsMatch(endVector, pattern))
                    throw new Exception("Неверно введенные координаты конца вектора");
                endVec = new Matrix3D(int.Parse(end[0]), int.Parse(end[1]), int.Parse(end[2]));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // координаты вектора
            Matrix3D vector = endVec - startVec;
            float length = (float)Math.Pow(
                Math.Sqrt(Math.Pow(vector.X, 2) + Math.Pow(vector.Y, 2) + Math.Pow(vector.Z, 2)),
                CurrentSize / 15);

            Color color = Color.Green;

            Pen pen = new Pen(color, 2) { CustomEndCap = new AdjustableArrowCap(4, 4) };
            Pen dashedPen = new Pen(color, 1) { DashStyle = DashStyle.Dash };
            Matrix3D extendedStart = startVec - vector * length;
            Matrix3D extendedEnd = endVec + vector * length;
            if (drawLine.Checked) //нарисовать вектор
            {
                gr.DrawLine(pen, startVec * CurrentSize, endVec * CurrentSize);
                if (extendLine.Checked)
                    gr.DrawLine(dashedPen, extendedStart * CurrentSize,
                        extendedEnd * CurrentSize);
            }

            float sum = (float)Math.Sqrt(Math.Pow(vector.X, 2) + Math.Pow(vector.Y, 2) + Math.Pow(vector.Z, 2));
            float cX = vector.X / sum, cY = vector.Y / sum, cZ = vector.Z / sum;
            float d = (float)Math.Sqrt(cY * cY + cZ * cZ);

            var translationInverse = new float[4, 4]; // обратная матрица переноса(перенос вектора в начало координат)
            Array.Clear(translationInverse, 0, 4);
            for (int i = 0; i < 4; i++)
                translationInverse[i, i] = 1;
            translationInverse[3, 0] = -endVec.X;
            translationInverse[3, 1] = -endVec.Y;
            translationInverse[3, 2] = -endVec.Z;

            float[,] Translation = new float[4, 4]; // матрица переноса(перенос обратно)
            Array.Clear(Translation, 0, 4);
            for (int i = 0; i < 4; i++)
                Translation[i, i] = 1;
            Translation[3, 0] = endVec.X;
            Translation[3, 1] = endVec.Y;
            Translation[3, 2] = endVec.Z;

            float[,] RotationVec; // матрица результата 

            if (cY != 0 || cZ != 0)
            {
                float[,]
                    rotationXInverse =
                        new float[4, 4]; // обратная матрица поворота по Х(поворот системы координат вокруг оси X)
                Array.Clear(rotationXInverse, 0, 4);
                //for (int i = 0; i < 4; i += 2)
                //{
                //    RotationX_Inverse[i, i] = 1;
                //    RotationX_Inverse[i + 1, i + 1] = cZ / d;
                //}

                rotationXInverse[0, 0] = 1;
                rotationXInverse[1, 1] = cZ / d;
                rotationXInverse[2, 2] = cZ / d;
                rotationXInverse[3, 3] = 1;
                rotationXInverse[2, 1] = -cY / d;
                rotationXInverse[1, 2] = cY / d;

                float[,]
                    rotationYInverse =
                        new float[4, 4]; // обратная матрица поворота по Y(поворот системы координат вокруг оси Y)
                Array.Clear(rotationYInverse, 0, 4);
                for (int i = 0; i < 4; i += 2)
                {
                    rotationYInverse[i, i] = d;
                    rotationYInverse[i + 1, i + 1] = 1;
                }
                rotationYInverse[2, 0] = -cX;
                rotationYInverse[0, 2] = cX;
                RotationVec =
                    Matrix3D.Mul(translationInverse,
                        rotationXInverse); // умножение обратной матрицы переноса на обратную матрицу поворота по Х
                RotationVec =
                    Matrix3D.Mul(RotationVec, rotationYInverse); // умножение результата на обратную матрицу поворота по Y

                float[,] rotationZ = new float[4, 4]; // матрица поворота по Z
                Array.Clear(rotationZ, 0, 4);
                float sinZ = (float)Math.Sin(Matrix3D.DegreeToRad(angle));
                float cosZ = (float)Math.Cos(Matrix3D.DegreeToRad(angle));
                for (int i = 0; i < 2; i++)
                {
                    rotationZ[i, i] = cosZ;
                    rotationZ[i + 2, i + 2] = 1;
                }
                rotationZ[0, 1] = -sinZ;
                rotationZ[1, 0] = sinZ;

                RotationVec = Matrix3D.Mul(RotationVec, rotationZ); // умножение результата на матрицу поворота по Z

                float[,] rotationY = new float[4, 4]; // матрица поворота по Y
                Array.Clear(rotationY, 0, 4);
                for (int i = 0; i < 4; i += 2)
                {
                    rotationY[i, i] = d;
                    rotationY[i + 1, i + 1] = 1;
                }
                rotationY[2, 0] = cX;
                rotationY[0, 2] = -cX;

                RotationVec = Matrix3D.Mul(RotationVec, rotationY); // умножение результата на матрицу поворота по Y

                float[,] rotationX = new float[4, 4]; // матрица поворота по X
                Array.Clear(rotationX, 0, 4);
                //for (int i = 0; i < 4; i += 3)
                //{
                //    RotationX[i, i] = 1;
                //    RotationX[i + 1, i + 1] = cZ / d;
                //}

                rotationX[0, 0] = 1;
                rotationX[1, 1] = cZ / d;
                rotationX[2, 2] = cZ / d;
                rotationX[3, 3] = 1;
                rotationX[2, 1] = cY / d;
                rotationX[1, 2] = -cY / d;

                RotationVec = Matrix3D.Mul(RotationVec, rotationX); // умножение результата на матрицу поворота по X
                RotationVec = Matrix3D.Mul(RotationVec, Translation); // умножение результата на матрицу переноса(возврат вектора с начала координат)
            }
            else // случай в котором d=0
            {
                float[,] RotationX = new float[4, 4];
                Array.Clear(RotationX, 0, 4);
                float sinX = (float)Math.Sin(Matrix3D.DegreeToRad(angle));
                float cosX = (float)Math.Cos(Matrix3D.DegreeToRad(angle));
                RotationX[0, 0] = 1;
                RotationX[1, 1] = cosX;
                RotationX[2, 2] = cosX;
                RotationX[3, 3] = 1;
                RotationX[1, 2] = sinX;
                RotationX[2, 1] = -sinX;
                RotationVec = Matrix3D.Mul(translationInverse, RotationX);
                RotationVec = Matrix3D.Mul(RotationVec, Translation);
            }

            List<Matrix3D> newCubePoints = new List<Matrix3D>(); // список для новых координат куба после перемещений
            for (int i = 0; i < 8; i++)
            {
                Matrix3D points = cubePoints[i].Mul(RotationVec); // умножение результата на координаты куба
                newCubePoints.Add(points);
            }

            return newCubePoints;
        }

    }
}