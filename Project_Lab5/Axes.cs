using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Lab5
{
    public class Axes
    {
        private readonly List<Matrix3D> _coordinates;
        SolidBrush brush = new SolidBrush(Color.Black);
        public Axes(int height, int width)
        {
            _coordinates = new List<Matrix3D>
            {
                new Matrix3D(0, 0, 0), // center [0]
                new Matrix3D(-width + 20, 0, 0), // x start [1]
                new Matrix3D(width - 20, 0, 0), // x end [2]
                new Matrix3D(0, -height + 20, 0), // y start [3]
                new Matrix3D(0, height - 20, 0), // y end [4]
                new Matrix3D(0, 0, -height - 50), // z start [5]
                new Matrix3D(0, 0, width), // z end [6]
            };
        }

        public void DrawLetters(ref Graphics gr, Cube cube, Font fnt)
        {
            char number = (char)65; // буква А
            for (int i = 0; i < 8; i++)
                gr.DrawString(number++.ToString(), fnt, brush, cube.Points[i] * cube.CurrentSize);
        }

        public void DrawAxes(ref Graphics gr)
        {
            Font axisFont = new Font("Times New Roman", 8);
            Pen pen = new Pen(Color.Black, 1) { CustomEndCap = new AdjustableArrowCap(4, 4) };
            for (int i = 1; i <= 5; i += 2)
                gr.DrawLine(pen, _coordinates[i], _coordinates[i + 1]);

            gr.DrawString("X", axisFont, brush, _coordinates[2]); // подпись осей 
            gr.DrawString("Y", axisFont, brush, (_coordinates[4] + 5));
            gr.DrawString("Z", axisFont, brush, _coordinates[6]);
        }
    }
}