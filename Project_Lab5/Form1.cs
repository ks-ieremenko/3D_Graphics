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
    public partial class Form1 : Form
    {
        List<Matrix3D> cubePoints;
        int h, w;
        int currentSize = 50; //масштаб
        Color edgeClr, cubeClr; // цвет ребер и куба
        bool cubeColorChanged = false, edgesColorChanged = false;
        public Form1()
        {
            InitializeComponent();
            tbSize.Value = currentSize;
            cubePoints = new List<Matrix3D>
            {
                new Matrix3D(0, 0, 0), // A-0
                new Matrix3D(1, 0, 0), // B-1
                new Matrix3D(1, 0, 1), // C-2
                new Matrix3D(0, 0, 1), // D-3
                new Matrix3D(0, 1, 0), // E-4
                new Matrix3D(1, 1, 0), // F-5
                new Matrix3D(1, 1, 1), // G-6
                new Matrix3D(0, 1, 1)  // H-7
               
            };
            h = pictureBox1.Height / 2;
            w = pictureBox1.Width / 2;
        }
        private void DrawCube(Graphics gr, List<Matrix3D> cubePoints, Pen pen, Brush brush, string proection = "0")
        {
            PointF start, end;
            for (int i = 0; i < 8; i++) // прорисовка куба по точкам, получаем 2 квадрата
            {
                start = cubePoints[i].To3DPoints(proection, currentSize); // начальная точка
                gr.FillEllipse(brush, start.X - currentSize / 40 - 1, start.Y - currentSize / 40, currentSize / 20, currentSize / 20); // точки на кубе
                //конечная точка
                end = (i == 3 || i == 7) ? cubePoints[i - 3].To3DPoints(proection, currentSize) : cubePoints[i + 1].To3DPoints(proection, currentSize);
                gr.DrawLine(pen, start, end);
                if (i < 4) // для 4 линий, которые соединяют вершины квадратов
                {
                    end = cubePoints[i + 4].To3DPoints(proection, currentSize);
                    gr.DrawLine(pen, start, end);
                }
            }
        }
        private void FillCube(Graphics gr, List<Matrix3D> cubePoints, Brush brush)
        {
            PointF[] Square = new PointF[4]; // квадрат ABCD
            PointF[] Square2 = new PointF[4]; // квадрат EFGH
            for (int i = 0; i < 4; i++)
            {
                Square[i] = cubePoints[i].To3DPoints(size: currentSize);
                Square2[i] = cubePoints[i + 4].To3DPoints(size: currentSize);
            }
            gr.FillPolygon(brush, Square);
            gr.FillPolygon(brush, Square2);

            for (int i = 1, j = 0; i >= 0; i--, j++)
                Square[j] = cubePoints[i].To3DPoints(size: currentSize);
            for (int i = 4, j = 2; i <= 5; i++, j++)
                Square[j] = cubePoints[i].To3DPoints(size: currentSize);
            gr.FillPolygon(brush, Square); //квадрат BAEF 1045

            for (int i = 2, j = 0; i <= 3; i++, j++)
                Square[j] = cubePoints[i].To3DPoints(size: currentSize);
            for (int i = 7, j = 2; i >= 6; i--, j++)
                Square[j] = cubePoints[i].To3DPoints(size: currentSize);
            gr.FillPolygon(brush, Square);//квадрат CDHG 2376

            for (int i = 1, j = 0; i <= 2; i++, j++)
                Square[j] = cubePoints[i].To3DPoints(size: currentSize);
            for (int i = 6, j = 2; i >= 5; i--, j++)
                Square[j] = cubePoints[i].To3DPoints(size: currentSize);
            gr.FillPolygon(brush, Square); //квадрат BCGF 1265

            for (int i = 0, j = 0; i <= 3; i += 3, j++)
                Square[j] = cubePoints[i].To3DPoints(size: currentSize);
            for (int i = 7, j = 2; i >= 4; i -= 3, j++)
                Square[j] = cubePoints[i].To3DPoints(size: currentSize);
            gr.FillPolygon(brush, Square);// квадрат ADHE 0374
        }
        private void DrawNumbers(Graphics gr, List<Matrix3D> cubePoints, Font fnt, Brush blackBrush)
        {
            char number = (char)65; // буква А
            for (int i = 0; i < 8; i++)
            {
                gr.DrawString(number.ToString(), fnt, blackBrush, cubePoints[i].To3DPoints(size: currentSize));
                number++;
            }
        }
        private List<Matrix3D> Translation(List<Matrix3D> cubePoints, float dx = 0, float dy = 0, float dz = 0)
        {
            float[,] matrix_translation = new float[4, 4];
            Array.Clear(matrix_translation, 0, 4);
            matrix_translation[0, 0] = 1; matrix_translation[1, 1] = 1;
            matrix_translation[2, 2] = 1; matrix_translation[3, 3] = 1;
            matrix_translation[3, 0] = dx; matrix_translation[3, 1] = dy;
            matrix_translation[3, 2] = dz;
            List<Matrix3D> newCubePoints = new List<Matrix3D>();// список для новых координат куба после перемещений
            for (int i = 0; i < 8; i++)
            {
                Matrix3D translation = cubePoints[i].Mul(matrix_translation);
                newCubePoints.Add(translation);
            }
            return newCubePoints;
        }
        private List<Matrix3D> Rotation(List<Matrix3D> cubePoints, float angleX = 0, float angleY = 0, float angleZ = 0)
        {
            List<Matrix3D> newCubePoints = new List<Matrix3D>(); // список для новых координат куба после поворота
            for (int i = 0; i < 8; i++)
            {
                Matrix3D rotation = cubePoints[i].Mul(cubePoints[i].RotationOX(angleX)); //поворот по Х
                rotation = rotation.Mul(cubePoints[i].RotationOY(angleY));//поворот по Y
                rotation = rotation.Mul(cubePoints[i].RotationOZ(angleZ)); //поворот по Z
                newCubePoints.Add(rotation);
            }
            return newCubePoints;
        }
        private List<Matrix3D> RotationVector(Graphics gr, List<Matrix3D> cubePoints, float angle = 0)
        {
            int endX = 0, endY = 0, endZ = 0;
            
            int startX = 0, startY = 0, startZ = 0;
            string pattern = "-?[0-9]+;-?[0-9]+;-?[0-9]+"; //шаблон формата 1;1;1
            try
            {
                if (StartVecTxt.Text == EndVecTxt.Text)
                    throw new Exception("Заданная прямая не может быть точкой");
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
            string[] start = StartVecTxt.Text.Split(';'); // координаты начала вектора
            try
            {
                if (!Regex.IsMatch(StartVecTxt.Text, pattern))
                    throw new Exception();
                startX = int.Parse(start[0]);
                startY = int.Parse(start[1]);
                startZ = int.Parse(start[2]);
            }
            catch { }
            string[] end = EndVecTxt.Text.Split(';'); // координаты конца вектора
            try
            {
                if (!Regex.IsMatch(EndVecTxt.Text, pattern))
                    throw new Exception();
                endX = int.Parse(end[0]);
                endY = int.Parse(end[1]);
                endZ = int.Parse(end[2]);
            }
            catch { }
            // координаты вектора
            float vecX = endX - startX;
            float vecY = endY - startY;
            float vecZ = endZ - startZ;
            float length = (float)Math.Pow(Math.Sqrt(Math.Pow(vecX, 2) + Math.Pow(vecY, 2) + Math.Pow(vecZ, 2)), currentSize / 15);
            Pen greenPen = new Pen(Color.Green,2);
            greenPen.CustomEndCap = new AdjustableArrowCap(4, 4);
            Pen greenPen_dashed = new Pen(Color.Green, 1);
            greenPen_dashed.DashStyle = DashStyle.Dash;
            Matrix3D mStart = new Matrix3D(startX, startY, startZ);
            Matrix3D mEnd = new Matrix3D(endX, endY, endZ);
            Matrix3D mStartL = new Matrix3D(startX - vecX * length, startY - vecY * length, startZ - vecZ * length);
            Matrix3D mEndL = new Matrix3D(endX + vecX * length, endY + vecY * length, endZ + vecZ * length);
            if (DrawLine.Checked) //нарисовать вектор
            {
                gr.DrawLine(greenPen, mStart.To3DPoints(size: currentSize), mEnd.To3DPoints(size: currentSize));
                if (LongChB.Checked)
                    gr.DrawLine(greenPen_dashed, mStartL.To3DPoints(size: currentSize), mEndL.To3DPoints(size: currentSize));
            }
            float sum = (float)Math.Sqrt(Math.Pow(vecX, 2) + Math.Pow(vecY, 2) + Math.Pow(vecZ, 2));
            float cX = vecX / sum, cY = vecY / sum, cZ = vecZ / sum;
            float d = (float)Math.Sqrt(cY * cY + cZ * cZ);
            
            float[,] Translation_Inverse = new float[4, 4]; // обратная матрица переноса(перенос вектора в начало координат)
            Array.Clear(Translation_Inverse, 0, 4);
            Translation_Inverse[0, 0] = 1; Translation_Inverse[1, 1] = 1;
            Translation_Inverse[2, 2] = 1; Translation_Inverse[3, 3] = 1;
            Translation_Inverse[3, 0] = -endX; Translation_Inverse[3, 1] = -endY;
            Translation_Inverse[3, 2] = -endZ;

            float[,] Translation = new float[4, 4]; // матрица переноса(перенос обратно)
            Array.Clear(Translation, 0, 4);
            Translation[0, 0] = 1; Translation[1, 1] = 1;
            Translation[2, 2] = 1; Translation[3, 3] = 1;
            Translation[3, 0] = endX; Translation[3, 1] = endY;
            Translation[3, 2] = endZ;

            float[,] RotationVec;// матрица результата 

            if (cY != 0 || cZ != 0)
            {
                float[,] RotationX_Inverse = new float[4, 4]; // обратная матрица поворота по Х(поворот системы координат вокруг оси X)
                Array.Clear(RotationX_Inverse, 0, 4);
                RotationX_Inverse[0, 0] = 1; RotationX_Inverse[1, 1] = cZ / d;
                RotationX_Inverse[2, 2] = cZ / d; RotationX_Inverse[3, 3] = 1;
                RotationX_Inverse[2, 1] = -cY / d; RotationX_Inverse[1, 2] = cY / d;

                float[,] RotationY_Inverse = new float[4, 4]; // обратная матрица поворота по Y(поворот системы координат вокруг оси Y)
                Array.Clear(RotationY_Inverse, 0, 4);
                RotationY_Inverse[0, 0] = d; RotationY_Inverse[1, 1] = 1;
                RotationY_Inverse[2, 2] = d; RotationY_Inverse[3, 3] = 1;
                RotationY_Inverse[2, 0] = -cX; RotationY_Inverse[0, 2] = cX;
                RotationVec = Mul(Translation_Inverse, RotationX_Inverse); // умножение обратной матрицы переноса на обратную матрицу поворота по Х
                RotationVec = Mul(RotationVec, RotationY_Inverse);// умножение результата на обратную матрицу поворота по Y

                float[,] RotationZ = new float[4, 4]; // матрица поворота по Z
                Array.Clear(RotationZ, 0, 4);
                float sinZ = (float)Math.Sin(DegreeToRad(angle));
                float cosZ = (float)Math.Cos(DegreeToRad(angle));
                RotationZ[0, 0] = cosZ; RotationZ[1, 1] = cosZ;
                RotationZ[2, 2] = 1; RotationZ[3, 3] = 1;
                RotationZ[0, 1] = -sinZ; RotationZ[1, 0] = sinZ;

                RotationVec = Mul(RotationVec, RotationZ); // умножение результата на матрицу поворота по Z

                float[,] RotationY = new float[4, 4]; // матрица поворота по Y
                Array.Clear(RotationY, 0, 4);
                RotationY[0, 0] = d; RotationY[1, 1] = 1;
                RotationY[2, 2] = d; RotationY[3, 3] = 1;
                RotationY[2, 0] = cX; RotationY[0, 2] = -cX;

                RotationVec = Mul(RotationVec, RotationY); // умножение результата на матрицу поворота по Y

                float[,] RotationX = new float[4, 4];// матрица поворота по X
                Array.Clear(RotationX, 0, 4);
                RotationX[0, 0] = 1; RotationX[1, 1] = cZ / d;
                RotationX[2, 2] = cZ / d; RotationX[3, 3] = 1;
                RotationX[2, 1] = cY / d; RotationX[1, 2] = -cY / d;

                RotationVec = Mul(RotationVec, RotationX); // умножение результата на матрицу поворота по X
                RotationVec = Mul(RotationVec, Translation); // умножение результата на матрицу переноса(возврат вектора с начала координат)
            }
            else // случай в котором d=0
            {
                float[,] RotationX = new float[4, 4]; 
                Array.Clear(RotationX, 0, 4);
                float sinX = (float)Math.Sin(DegreeToRad(angle));
                float cosX = (float)Math.Cos(DegreeToRad(angle));
                RotationX[0, 0] = 1; RotationX[1, 1] = cosX;
                RotationX[2, 2] = cosX; RotationX[3, 3] = 1;
                RotationX[1, 2] = sinX; RotationX[2, 1] = -sinX;
                RotationVec = Mul(Translation_Inverse, RotationX);
                RotationVec = Mul(RotationVec, Translation);
            }
            List<Matrix3D> newCubePoints = new List<Matrix3D>();// список для новых координат куба после перемещений
            for (int i = 0; i < 8; i++)
            {
                Matrix3D points = cubePoints[i].Mul(RotationVec); // умножение результата на координаты куба
                newCubePoints.Add(points);
            }
            return newCubePoints;
        }
        public float DegreeToRad(float angle)
        {
            return (float)(angle * Math.PI / 180); // перевод в радианы
        }
        public static float[,] Mul(float[,] matrix1, float[,] matrix2)
        {
            float sum;
            float[,] result = new float[4, 4];
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    sum = 0;
                    for (int k = 0; k < 4; k++)
                        sum += matrix1[i, k] * matrix2[k, j];
                    result[i, j] = sum;
                }
            return result;
        }
        void DrawAxes(Graphics gr, Matrix3D start, Matrix3D end, Pen pen)
        {
            gr.DrawLine(pen, start.To3DPoints(), end.To3DPoints());
        }      
        private void Proection(Graphics gr, List<Matrix3D> cubePoints, string proectionXY, string proectionXZ, string proectionYZ)
        {
            Pen pinkPen_dashed = new Pen(Color.LightPink, 1);
            pinkPen_dashed.DashStyle = DashStyle.Dash;
            Pen pinkPen = new Pen(Color.LightPink, 1);
            SolidBrush brush = new SolidBrush(Color.LightPink);

            for (int i = 0; i < 8; i++)
            {
                if (proectionXY != "0")
                    gr.DrawLine(pinkPen_dashed, cubePoints[i].To3DPoints(proectionXY, currentSize), cubePoints[i].To3DPoints(size: currentSize));
                if (proectionXZ != "0")
                    gr.DrawLine(pinkPen_dashed, cubePoints[i].To3DPoints(proectionXZ, currentSize), cubePoints[i].To3DPoints(size: currentSize));
                if (proectionYZ != "0")
                    gr.DrawLine(pinkPen_dashed, cubePoints[i].To3DPoints(proectionYZ, currentSize), cubePoints[i].To3DPoints(size: currentSize));
            }
            if (proectionXY != "0")
                DrawCube(gr, cubePoints, pinkPen, brush, proectionXY);
            if (proectionXZ != "0")
                DrawCube(gr, cubePoints, pinkPen, brush, proectionXZ);
            if (proectionYZ != "0")
                DrawCube(gr, cubePoints, pinkPen, brush, proectionYZ);
        }     
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            h = pictureBox1.Height / 2;
            w = pictureBox1.Width / 2;
            List <Matrix3D> Coordinates = new List<Matrix3D>() {
                new Matrix3D(0, 0, 0), // center [0]
                new Matrix3D(- w + 20, 0, 0), // x start [1]
                new Matrix3D(w - 20, 0, 0), // x end [2]
                new Matrix3D(0, -h + 20, 0), // y start [3]
                new Matrix3D(0, h - 20, 0), // y end [4]
                new Matrix3D(0, 0, -h - 50), // z start [5]
                new Matrix3D(0, 0, w), // z end [6]
            };
            Graphics gr = e.Graphics;
            gr.SmoothingMode = SmoothingMode.HighQuality;
            gr.TranslateTransform(w, h); // новый центр
            Pen blackPen = new Pen(Color.Black, 1);
            blackPen.CustomEndCap = new AdjustableArrowCap(4, 4);
            for (int i = 1; i <= 5; i += 2)
                DrawAxes(gr, Coordinates[i], Coordinates[i + 1], blackPen);
            Font AxisFont = new Font("Times New Roman", 8);
            Pen violetPen = new Pen(Color.DarkViolet);
            SolidBrush violetBrush = new SolidBrush(Color.DarkViolet);
            if (edgesColorChanged)
            {
                violetPen = new Pen(edgeClr);
                violetBrush = new SolidBrush(edgeClr);
            }
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            gr.DrawString("X", AxisFont, blackBrush, new PointF(w - 20, 0)); // подпись осей 
            gr.DrawString("Y", AxisFont, blackBrush, new PointF(0, -h + 10));
            gr.DrawString("Z", AxisFont, blackBrush, Coordinates[6].To3DPoints());
            List<Matrix3D> newCubePoints;
            newCubePoints = Rotation(RotationVector(gr, Translation(cubePoints, tbPerX.Value, tbPerY.Value, tbPerZ.Value), tbRotateVector.Value),
               tbRotateX.Value, tbRotateY.Value, tbRotateZ.Value); // новые координаты после поворота и перемещений
            string proection1 = ProectionXY.Checked ? "z" : "0";// какая выбрана проекция
            string proection2 = ProectionXZ.Checked ? "y" : "0";
            string proection3 = ProectionYZ.Checked ? "x" : "0";
            SolidBrush Brush;
            if (cubeColorChanged)
            {
                Brush = new SolidBrush(cubeClr);
                FillCube(gr, newCubePoints, Brush);
            }
            if (proection1 != "0" || proection2 != "0" || proection3 != "0")
                Proection(gr, newCubePoints, proection1, proection2, proection3); // рисование проекций
            DrawCube(gr, newCubePoints, violetPen, violetBrush); // рисование заданого куба
            int fontSize = tbSize.Value / 7; // размер шрифта в зависимости от масштаба
            fontSize = (fontSize < 1) ? 1 : tbSize.Value / 7; // не может быть меньше 1
            Font numbersFont = new Font("Times New Roman", fontSize); // шрифт
            if(NumbersChB.Checked)
                DrawNumbers(gr, newCubePoints, numbersFont, blackBrush);
        }
        private void AnimStartButton_Click(object sender, EventArgs e)
        {
            AnimTimer.Start();
            AnimTimer.Enabled = true;
        }
        private void AnimTimer_Tick(object sender, EventArgs e)
        {
            AnimTimer.Interval = 1;
            // анимация от -360 до 360 градусов, пока не нажать стоп
            if (XRdButton.Checked) // X
            {
                if (tbRotateX.Value != 360)
                    tbRotateX.Value += 1;
                else
                    tbRotateX.Value = -360;
                txtRotX.Text = tbRotateX.Value.ToString();
                pictureBox1.Invalidate();
            }
            else if (vecRdButton.Checked) // по вектору
            {
                if (tbRotateVector.Value != 360)
                    tbRotateVector.Value += 1;
                else
                    tbRotateVector.Value = -360;
                vectorTxt.Text = tbRotateVector.Value.ToString();
            }
            else if (YRdButton.Checked) // Y
            {
                if (tbRotateY.Value != 360)
                    tbRotateY.Value += 1;
                else
                    tbRotateY.Value = -360;
                txtRotY.Text = tbRotateY.Value.ToString();
                
            }
            else if (ZRdButton.Checked) // Z
            {
                if (tbRotateZ.Value != 360)
                    tbRotateZ.Value += 1;
                else
                    tbRotateZ.Value = -360;
                txtRotZ.Text = tbRotateZ.Value.ToString();
            }
            pictureBox1.Invalidate();
        }
        private void AnimStopButton_Click(object sender, EventArgs e)
        {
            AnimTimer.Stop();
            AnimTimer.Enabled = false;
        }        
        private void InvalidateEvent(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }
        private void tbRotate_Scroll(object sender, EventArgs e)
        {
            txtRotX.Text = tbRotateX.Value.ToString();
            txtRotY.Text = tbRotateY.Value.ToString();
            txtRotZ.Text = tbRotateZ.Value.ToString();
            pictureBox1.Invalidate();
        }
        private void tbXYZ_Scroll(object sender, EventArgs e)
        {
            txtX.Text = tbPerX.Value.ToString();
            txtY.Text = tbPerY.Value.ToString();
            txtZ.Text = tbPerZ.Value.ToString();
            pictureBox1.Invalidate();
        }
        private void tbSize_Scroll(object sender, EventArgs e)
        {
            currentSize = tbSize.Value;
            txtSize.Text = currentSize.ToString();
            pictureBox1.Invalidate();
        }
        private void ClearButton_Click(object sender, EventArgs e)
        {
            tbPerX.Value = 0; tbPerY.Value = 0; tbPerZ.Value = 0;
            tbRotateX.Value = 0; tbRotateY.Value = 0; tbRotateZ.Value = 0;
            currentSize = 50; tbSize.Value = currentSize;
            tbRotateVector.Value = 0;
            txtRotX.Text = txtRotY.Text  = txtRotZ.Text = 0.ToString();
            txtX.Text = txtY.Text = txtZ.Text = 0.ToString();
            txtSize.Text = 50.ToString(); vectorTxt.Text = 0.ToString();
            ProectionYZ.Checked = ProectionXY.Checked = ProectionXZ.Checked = vecRdButton.Checked = false;
            XRdButton.Checked = YRdButton.Checked = ZRdButton.Checked = false;
            cubeClr = Color.Empty;
            edgeClr = Color.DarkViolet;
            pictureBox1.Invalidate();
        }
        private void txtSize_TextChanged(object sender, EventArgs e)
        {
            txtSize.Invalidate();
            if (txtSize.Text == "" || txtSize.Text == "-") tbSize.Value = 0;
            else
            {
                try
                {
                    if (int.Parse(txtSize.Text) > 100)
                    {
                        tbSize.Value = 100;
                        tbSize.Value = 100;
                        txtSize.Text = "100";
                        currentSize = 100;
                        throw new Exception("Размер не может быть больше 100");
                    }
                    if(int.Parse(txtSize.Text) < 0 )
                    {
                        tbSize.Value = 0;
                        txtSize.Text = "0";
                        currentSize = 0;
                        throw new Exception("Размер не может быть меньше 0");
                    }
                    tbSize.Value = int.Parse(txtSize.Text);
                }
                catch (Exception ex){ MessageBox.Show(ex.Message); }
            }
            currentSize = tbSize.Value;
            pictureBox1.Invalidate();
        }
        private void txtTrXYZ(object sender, EventArgs e)
        {
            txtX.Invalidate();
            if (txtX.Text == "" || txtX.Text == "-") tbPerX.Value = 0;
            else
            {
                try
                {
                    if (int.Parse(txtX.Text) > 20 || int.Parse(txtX.Text) < -20)
                    {
                        tbPerX.Value = 0;
                        txtX.Text = "0";
                        throw new Exception("Перенос не может быть больше чем 20 и меньше чем -20");
                    }
                    tbPerX.Value = int.Parse(txtX.Text);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            txtY.Invalidate();
            if (txtY.Text == "" || txtY.Text == "-") tbPerY.Value = 0;
            else
            {
                try
                {
                    if (int.Parse(txtY.Text) > 20 || int.Parse(txtY.Text) < -20)
                    {
                        tbPerY.Value = 0;
                        txtY.Text = "0";
                        throw new Exception("Перенос не может быть больше чем 20 и меньше чем -20");
                    }
                    tbPerY.Value = int.Parse(txtY.Text);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            txtZ.Invalidate();
            if (txtZ.Text == "" || txtZ.Text == "-") tbPerZ.Value = 0;
            else
            {
                try
                {
                    if (int.Parse(txtZ.Text) > 20 || int.Parse(txtZ.Text) < -20)
                    {
                        tbPerZ.Value = 0;
                        txtZ.Text = "0";
                        throw new Exception("Перенос не может быть больше чем 20 и меньше чем -20");
                    }
                    tbPerZ.Value = int.Parse(txtZ.Text);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            pictureBox1.Invalidate();
        }

        private void txtRotXYZ(object sender, EventArgs e)
        {
            txtRotX.Invalidate();
            if (txtRotX.Text == "" || txtRotX.Text == "-") tbRotateX.Value = 0;
            else
            {
                try
                {
                    if (int.Parse(txtRotX.Text) > 360 || int.Parse(txtRotX.Text) < -360)
                    {
                        tbRotateX.Value = 0;
                        txtRotX.Text = "0";
                        throw new Exception("Угол не может быть больше чем 360 и меньше чем -360");
                    }
                    tbRotateX.Value = int.Parse(txtRotX.Text);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            txtRotY.Invalidate();
            if (txtRotY.Text == "" || txtRotY.Text == "-") tbRotateY.Value = 0;
            else
            {
                try
                {
                    if (int.Parse(txtRotY.Text) > 360 || int.Parse(txtRotY.Text) < -360)
                    {
                        tbRotateY.Value = 0;
                        txtRotY.Text = "0";
                        throw new Exception("Угол не может быть больше чем 360 и меньше чем -360");
                    }
                    tbRotateY.Value = int.Parse(txtRotY.Text);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            txtRotZ.Invalidate();
            if (txtRotZ.Text == "" || txtRotZ.Text == "-") tbRotateZ.Value = 0;
            else
            {
                try
                {
                    if (int.Parse(txtRotZ.Text) > 360 || int.Parse(txtRotY.Text) < -360)
                    {
                        tbRotateZ.Value = 0;
                        txtRotZ.Text = "0";
                        throw new Exception("Угол не может быть больше чем 360 и меньше чем -360");
                    }
                    tbRotateZ.Value = int.Parse(txtRotZ.Text);
                    if (int.Parse(txtRotY.Text) > 360 || int.Parse(txtRotY.Text) < -360)
                    {
                        tbRotateY.Value = 0;
                        txtRotY.Text = "0";
                        throw new Exception("Угол не может быть больше чем 360 и меньше чем -360");
                    }
                    tbRotateY.Value = int.Parse(txtRotY.Text);
                    if (int.Parse(txtRotX.Text) > 360 || int.Parse(txtRotX.Text) < -360)
                    {
                        tbRotateX.Value = 0;
                        txtRotX.Text = "0";
                        throw new Exception("Угол не может быть больше чем 360 и меньше чем -360");
                    }
                    tbRotateX.Value = int.Parse(txtRotX.Text);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            pictureBox1.Invalidate();
        }

        private void tbRotateVector_Scroll(object sender, EventArgs e)
        {
            vectorTxt.Text = tbRotateVector.Value.ToString();
            pictureBox1.Invalidate();
        }
        private void colorPicker_Click(object sender, EventArgs e)
        {
            cubeColor.ShowDialog();
            cubeClr = cubeColor.Color;
            cubeColorChanged = true;
            pictureBox1.Invalidate();
        }
        private void colorPickerEdges_Click(object sender, EventArgs e)
        {
            edgesColor.ShowDialog();
            edgeClr = edgesColor.Color;
            edgesColorChanged = true;
            pictureBox1.Invalidate();
        }
    }
}
