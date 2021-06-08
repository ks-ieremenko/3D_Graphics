using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Project_Lab5
{
    public partial class Form1 : Form
    {
        Cube cube = new Cube(50);
        List<Matrix3D> cubePoints;
        int h, w;

        Color _edgeClr, _cubeClr; // цвет ребер и куба
        bool _cubeColorChanged, _edgesColorChanged = false;

        public Form1()
        {
            InitializeComponent();
            cubePoints = new List<Matrix3D>
            {
                new Matrix3D(0, 0, 0), // A-0
                new Matrix3D(1, 0, 0), // B-1
                new Matrix3D(1, 0, 1), // C-2
                new Matrix3D(0, 0, 1), // D-3
                new Matrix3D(0, 1, 0), // E-4
                new Matrix3D(1, 1, 0), // F-5
                new Matrix3D(1, 1, 1), // G-6
                new Matrix3D(0, 1, 1) // H-7
            };
            cube.Points = cubePoints;
            tbSize.Value = cube.CurrentSize;

            h = pictureBox1.Height / 2;
            w = pictureBox1.Width / 2;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            h = pictureBox1.Height / 2;
            w = pictureBox1.Width / 2;
            Axes axes = new Axes(h, w);

            Graphics gr = e.Graphics;
            gr.SmoothingMode = SmoothingMode.HighQuality;
            gr.TranslateTransform(w, h); // новый центр

            Pen pen = new Pen(Color.DarkViolet);
            SolidBrush brush = new SolidBrush(Color.DarkViolet);

            axes.DrawAxes(ref gr);

            if (_edgesColorChanged)
            {
                pen = new Pen(_edgeClr);
                brush = new SolidBrush(_edgeClr);
            }

            if (_cubeColorChanged)
            {
                cube.ChangeCubeColor(ref gr, new SolidBrush(_cubeClr));
            }
            List<Matrix3D> newCubePoints;
            newCubePoints = cube.Rotation(
                cube.RotationVector(DrawLine, LongChB, StartVecTxt.Text, EndVecTxt.Text, ref gr,
                    cube.Translation(cubePoints, tbPerX.Value, tbPerY.Value, tbPerZ.Value),
                    tbRotateVector.Value),
                tbRotateX.Value, tbRotateY.Value, tbRotateZ.Value); // новые координаты после поворота и перемещений
            string projection1 = ProectionXY.Checked ? "z" : "0"; // какая выбрана проекция
            string projection2 = ProectionXZ.Checked ? "y" : "0";
            string projection3 = ProectionYZ.Checked ? "x" : "0";

            if (projection1 != "0" || projection2 != "0" || projection3 != "0")
                cube.Projection(ref gr, newCubePoints, new[] { projection1, projection2, projection3 }); // рисование проекций
            cube.DrawCube(ref gr, newCubePoints, pen, brush); // рисование заданого куба
            int fontSize = tbSize.Value / 7 < 1 ? 1 : tbSize.Value / 7; // размер шрифта в зависимости от масштаба
            if (NumbersChB.Checked)
                axes.DrawLetters(ref gr, cube, new Font("Times New Roman", fontSize));
        }

        private void AnimStartButton_Click(object sender, EventArgs e)
        {
            AnimTimer.Start();
            AnimTimer.Enabled = true;
        }

        public Dictionary<TrackBar, TextBox> GetDictionary()
        {
            return new Dictionary<TrackBar, TextBox>
            {
                {tbRotateVector, vectorTxt},
                {tbRotateX, txtRotX},
                {tbRotateY, txtRotY},
                {tbRotateZ, txtRotZ}
            };
        }

        private void AnimTimer_Tick(object sender, EventArgs e)
        {
            var trackBarsAndTextBoxes = GetDictionary();
            var trackBarsAndRadioButtons = new Dictionary<TrackBar, RadioButton>
            {
                {tbRotateVector, vecRdButton},
                {tbRotateX, XRdButton},
                {tbRotateY, YRdButton},
                {tbRotateZ, ZRdButton}
            };
            AnimTimer.Interval = 1;
            foreach (var elem in trackBarsAndRadioButtons.Where(elem => elem.Value.Checked))
            {
                if (elem.Key.Value != 360)
                    elem.Key.Value++;
                else
                    elem.Key.Value = -360;
                trackBarsAndTextBoxes[elem.Key].Text = elem.Key.Value.ToString();
                pictureBox1.Invalidate();
            }

            // анимация от -360 до 360 градусов, пока не нажать стоп
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
            cube.CurrentSize = tbSize.Value;
            txtSize.Text = cube.CurrentSize.ToString();
            pictureBox1.Invalidate();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            tbPerX.Value = tbPerY.Value = tbPerZ.Value = 0;
            tbRotateX.Value = tbRotateY.Value = tbRotateZ.Value = 0;
            cube.CurrentSize = tbSize.Value = 50;
            tbRotateVector.Value = 0;
            txtRotX.Text = txtRotY.Text = txtRotZ.Text = 0.ToString();
            txtX.Text = txtY.Text = txtZ.Text = 0.ToString();
            txtSize.Text = 50.ToString();
            vectorTxt.Text = 0.ToString();
            ProectionYZ.Checked = ProectionXY.Checked = ProectionXZ.Checked = vecRdButton.Checked = false;
            XRdButton.Checked = YRdButton.Checked = ZRdButton.Checked = false;
            _cubeClr = Color.Empty;
            _edgeClr = Color.DarkViolet;
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
                        txtSize.Text = "100";
                        cube.CurrentSize = 100;
                        throw new Exception("Размер не может быть больше 100");
                    }

                    else if (int.Parse(txtSize.Text) < 0)
                    {
                        tbSize.Value = 0;
                        txtSize.Text = "0";
                        cube.CurrentSize = 0;
                        throw new Exception("Размер не может быть меньше 0");
                    }

                    tbSize.Value = int.Parse(txtSize.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            cube.CurrentSize = tbSize.Value;
            pictureBox1.Invalidate();
        }

        private void txtTrXYZ(object sender, EventArgs e)
        {
            var trackBarsAndTextBoxes = new Dictionary<TrackBar, TextBox>
            {
                {tbPerX, txtX},
                {tbPerY, txtY},
                {tbPerZ, txtZ}
            };
            foreach (var elem in trackBarsAndTextBoxes)
            {
                elem.Value.Invalidate();
                if (elem.Value.Text == "" || elem.Value.Text == "-") elem.Key.Value = 0;
                else
                {
                    try
                    {
                        if (int.Parse(elem.Value.Text) > 20 || int.Parse(elem.Value.Text) < -20)
                        {
                            elem.Key.Value = 0;
                            elem.Value.Text = "0";
                            throw new Exception("Перенос не может быть больше чем 20 и меньше чем -20");
                        }

                        elem.Key.Value = int.Parse(elem.Value.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                pictureBox1.Invalidate();
            }

        }

        private void txtRotXYZ(object sender, EventArgs e)
        {
            var trackBarsAndTextBoxes = GetDictionary();
            foreach (var elem in trackBarsAndTextBoxes)
            {
                elem.Value.Invalidate();
                if (elem.Value.Text == "" || elem.Value.Text == "-") elem.Key.Value = 0;
                else
                {
                    try
                    {
                        if (int.Parse(elem.Value.Text) > 360 || int.Parse(elem.Value.Text) < -360)
                        {
                            elem.Key.Value = 0;
                            elem.Value.Text = "0";
                            throw new Exception("Угол не может быть больше чем 360 и меньше чем -360");
                        }

                        elem.Key.Value = int.Parse(elem.Value.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
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
            _cubeClr = cubeColor.Color;
            _cubeColorChanged = true;
            pictureBox1.Invalidate();
        }

        private void colorPickerEdges_Click(object sender, EventArgs e)
        {
            edgesColor.ShowDialog();
            _edgeClr = edgesColor.Color;
            _edgesColorChanged = true;
            pictureBox1.Invalidate();
        }
    }
}