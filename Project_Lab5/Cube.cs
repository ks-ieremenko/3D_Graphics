using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Lab5
{
    class Cube
    {
        public int CurrentSize { get; set; }
        List<Matrix3D> cubePoints;
        Graphics gr;
        public Cube(int currentSize, List<Matrix3D> cubePoints, Graphics gr)
        {
            CurrentSize = currentSize;
            this.cubePoints = cubePoints;
            this.gr = gr;
        }
        public void Draw(Pen pen, Brush brush, string proection = "0")
        {
            PointF start, end;
            for (int i = 0; i < 8; i++) // прорисовка куба по точкам, получаем 2 квадрата
            {
                start = cubePoints[i].To3DPoints(proection, CurrentSize); // начальная точка
                gr.FillEllipse(brush, start.X - CurrentSize / 40 - 1, start.Y - CurrentSize / 40, CurrentSize / 20, CurrentSize / 20); // точки на кубе
                //конечная точка
                end = (i == 3 || i == 7) ? cubePoints[i - 3].To3DPoints(proection, CurrentSize) : cubePoints[i + 1].To3DPoints(proection, CurrentSize);
                gr.DrawLine(pen, start, end);
                if (i < 4) // для 4 линий, которые соединяют вершины квадратов
                {
                    end = cubePoints[i + 4].To3DPoints(proection, CurrentSize);
                    gr.DrawLine(pen, start, end);
                }
            }
        }
        public void FillCube(Brush brush)
        {
            PointF[] Square = new PointF[4]; // квадрат ABCD
            PointF[] Square2 = new PointF[4]; // квадрат EFGH
            for (int i = 0; i < 4; i++)
            {
                Square[i] = cubePoints[i].To3DPoints(size: CurrentSize);
                Square2[i] = cubePoints[i + 4].To3DPoints(size: CurrentSize);
            }
            gr.FillPolygon(brush, Square);
            gr.FillPolygon(brush, Square2);

            for (int i = 1, j = 0; i >= 0; i--, j++)
                Square[j] = cubePoints[i].To3DPoints(size: CurrentSize);
            for (int i = 4, j = 2; i <= 5; i++, j++)
                Square[j] = cubePoints[i].To3DPoints(size: CurrentSize);
            gr.FillPolygon(brush, Square); //квадрат BAEF 1045

            for (int i = 2, j = 0; i <= 3; i++, j++)
                Square[j] = cubePoints[i].To3DPoints(size: CurrentSize);
            for (int i = 7, j = 2; i >= 6; i--, j++)
                Square[j] = cubePoints[i].To3DPoints(size: CurrentSize);
            gr.FillPolygon(brush, Square);//квадрат CDHG 2376

            for (int i = 1, j = 0; i <= 2; i++, j++)
                Square[j] = cubePoints[i].To3DPoints(size: CurrentSize);
            for (int i = 6, j = 2; i >= 5; i--, j++)
                Square[j] = cubePoints[i].To3DPoints(size: CurrentSize);
            gr.FillPolygon(brush, Square); //квадрат BCGF 1265

            for (int i = 0, j = 0; i <= 3; i += 3, j++)
                Square[j] = cubePoints[i].To3DPoints(size: CurrentSize);
            for (int i = 7, j = 2; i >= 4; i -= 3, j++)
                Square[j] = cubePoints[i].To3DPoints(size: CurrentSize);
            gr.FillPolygon(brush, Square);// квадрат ADHE 0374
        }
    }
}
