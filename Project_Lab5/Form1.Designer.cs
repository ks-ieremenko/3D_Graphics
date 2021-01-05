
namespace Project_Lab5
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ClearButton = new System.Windows.Forms.Button();
            this.colorPickerEdges = new System.Windows.Forms.Button();
            this.NumbersChB = new System.Windows.Forms.CheckBox();
            this.colorPickerCube = new System.Windows.Forms.Button();
            this.gbRotationO = new System.Windows.Forms.GroupBox();
            this.LongChB = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.vectorTxt = new System.Windows.Forms.TextBox();
            this.DrawLine = new System.Windows.Forms.CheckBox();
            this.txtRotY = new System.Windows.Forms.TextBox();
            this.tbRotateVector = new System.Windows.Forms.TrackBar();
            this.txtRotZ = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRotX = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.StartVecTxt = new System.Windows.Forms.TextBox();
            this.EndVecTxt = new System.Windows.Forms.TextBox();
            this.tbRotateZ = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbRotateY = new System.Windows.Forms.TrackBar();
            this.tbRotateX = new System.Windows.Forms.TrackBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ProectionXZ = new System.Windows.Forms.CheckBox();
            this.ProectionYZ = new System.Windows.Forms.CheckBox();
            this.ProectionXY = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.vecRdButton = new System.Windows.Forms.RadioButton();
            this.ZRdButton = new System.Windows.Forms.RadioButton();
            this.YRdButton = new System.Windows.Forms.RadioButton();
            this.XRdButton = new System.Windows.Forms.RadioButton();
            this.AnimStartButton = new System.Windows.Forms.Button();
            this.AnimStopButton = new System.Windows.Forms.Button();
            this.gbPer = new System.Windows.Forms.GroupBox();
            this.txtZ = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtY = new System.Windows.Forms.TextBox();
            this.tbPerZ = new System.Windows.Forms.TrackBar();
            this.txtX = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPerX = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPerY = new System.Windows.Forms.TrackBar();
            this.gbSize = new System.Windows.Forms.GroupBox();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.tbSize = new System.Windows.Forms.TrackBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.AnimTimer = new System.Windows.Forms.Timer(this.components);
            this.cubeColor = new System.Windows.Forms.ColorDialog();
            this.edgesColor = new System.Windows.Forms.ColorDialog();
            this.panel1.SuspendLayout();
            this.gbRotationO.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbRotateVector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRotateZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRotateY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRotateX)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbPer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbPerZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPerX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPerY)).BeginInit();
            this.gbSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ClearButton);
            this.panel1.Controls.Add(this.colorPickerEdges);
            this.panel1.Controls.Add(this.NumbersChB);
            this.panel1.Controls.Add(this.colorPickerCube);
            this.panel1.Controls.Add(this.gbRotationO);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.gbPer);
            this.panel1.Controls.Add(this.gbSize);
            this.panel1.Location = new System.Drawing.Point(808, -5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(324, 673);
            this.panel1.TabIndex = 0;
            // 
            // ClearButton
            // 
            this.ClearButton.AutoSize = true;
            this.ClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ClearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClearButton.Location = new System.Drawing.Point(184, 632);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(113, 30);
            this.ClearButton.TabIndex = 19;
            this.ClearButton.Text = "Сбросить";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // colorPickerEdges
            // 
            this.colorPickerEdges.AutoSize = true;
            this.colorPickerEdges.BackColor = System.Drawing.Color.MistyRose;
            this.colorPickerEdges.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.colorPickerEdges.Location = new System.Drawing.Point(184, 587);
            this.colorPickerEdges.Name = "colorPickerEdges";
            this.colorPickerEdges.Size = new System.Drawing.Size(103, 27);
            this.colorPickerEdges.TabIndex = 18;
            this.colorPickerEdges.Text = "Цвет ребер";
            this.colorPickerEdges.UseVisualStyleBackColor = false;
            this.colorPickerEdges.Click += new System.EventHandler(this.colorPickerEdges_Click);
            // 
            // NumbersChB
            // 
            this.NumbersChB.AutoSize = true;
            this.NumbersChB.Location = new System.Drawing.Point(13, 639);
            this.NumbersChB.Name = "NumbersChB";
            this.NumbersChB.Size = new System.Drawing.Size(129, 21);
            this.NumbersChB.TabIndex = 16;
            this.NumbersChB.Text = "Подписи точек";
            this.NumbersChB.UseVisualStyleBackColor = true;
            this.NumbersChB.CheckedChanged += new System.EventHandler(this.InvalidateEvent);
            // 
            // colorPickerCube
            // 
            this.colorPickerCube.AutoSize = true;
            this.colorPickerCube.BackColor = System.Drawing.Color.AntiqueWhite;
            this.colorPickerCube.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.colorPickerCube.Location = new System.Drawing.Point(28, 587);
            this.colorPickerCube.Name = "colorPickerCube";
            this.colorPickerCube.Size = new System.Drawing.Size(103, 27);
            this.colorPickerCube.TabIndex = 17;
            this.colorPickerCube.Text = "Цвет куба";
            this.colorPickerCube.UseVisualStyleBackColor = false;
            this.colorPickerCube.Click += new System.EventHandler(this.colorPicker_Click);
            // 
            // gbRotationO
            // 
            this.gbRotationO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbRotationO.Controls.Add(this.LongChB);
            this.gbRotationO.Controls.Add(this.label9);
            this.gbRotationO.Controls.Add(this.vectorTxt);
            this.gbRotationO.Controls.Add(this.DrawLine);
            this.gbRotationO.Controls.Add(this.txtRotY);
            this.gbRotationO.Controls.Add(this.tbRotateVector);
            this.gbRotationO.Controls.Add(this.txtRotZ);
            this.gbRotationO.Controls.Add(this.label8);
            this.gbRotationO.Controls.Add(this.txtRotX);
            this.gbRotationO.Controls.Add(this.label7);
            this.gbRotationO.Controls.Add(this.label6);
            this.gbRotationO.Controls.Add(this.StartVecTxt);
            this.gbRotationO.Controls.Add(this.EndVecTxt);
            this.gbRotationO.Controls.Add(this.tbRotateZ);
            this.gbRotationO.Controls.Add(this.label2);
            this.gbRotationO.Controls.Add(this.label1);
            this.gbRotationO.Controls.Add(this.tbRotateY);
            this.gbRotationO.Controls.Add(this.tbRotateX);
            this.gbRotationO.Location = new System.Drawing.Point(18, 189);
            this.gbRotationO.Name = "gbRotationO";
            this.gbRotationO.Size = new System.Drawing.Size(290, 254);
            this.gbRotationO.TabIndex = 14;
            this.gbRotationO.TabStop = false;
            this.gbRotationO.Text = "Вращение осей";
            // 
            // LongChB
            // 
            this.LongChB.AutoSize = true;
            this.LongChB.Location = new System.Drawing.Point(185, 179);
            this.LongChB.Name = "LongChB";
            this.LongChB.Size = new System.Drawing.Size(94, 21);
            this.LongChB.TabIndex = 14;
            this.LongChB.Text = "Продлить";
            this.LongChB.UseVisualStyleBackColor = true;
            this.LongChB.CheckedChanged += new System.EventHandler(this.InvalidateEvent);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Location = new System.Drawing.Point(85, 109);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 19);
            this.label9.TabIndex = 13;
            this.label9.Text = "Вокруг прямой";
            // 
            // vectorTxt
            // 
            this.vectorTxt.Location = new System.Drawing.Point(229, 215);
            this.vectorTxt.Name = "vectorTxt";
            this.vectorTxt.Size = new System.Drawing.Size(32, 22);
            this.vectorTxt.TabIndex = 12;
            this.vectorTxt.Text = "0";
            // 
            // DrawLine
            // 
            this.DrawLine.AutoSize = true;
            this.DrawLine.Location = new System.Drawing.Point(6, 179);
            this.DrawLine.Name = "DrawLine";
            this.DrawLine.Size = new System.Drawing.Size(158, 21);
            this.DrawLine.TabIndex = 6;
            this.DrawLine.Text = "Отобразить вектор";
            this.DrawLine.UseVisualStyleBackColor = true;
            this.DrawLine.CheckedChanged += new System.EventHandler(this.InvalidateEvent);
            // 
            // txtRotY
            // 
            this.txtRotY.Location = new System.Drawing.Point(242, 50);
            this.txtRotY.Name = "txtRotY";
            this.txtRotY.Size = new System.Drawing.Size(32, 22);
            this.txtRotY.TabIndex = 11;
            this.txtRotY.Text = "0";
            this.txtRotY.TextChanged += new System.EventHandler(this.txtRotXYZ);
            // 
            // tbRotateVector
            // 
            this.tbRotateVector.AutoSize = false;
            this.tbRotateVector.Location = new System.Drawing.Point(1, 217);
            this.tbRotateVector.Maximum = 360;
            this.tbRotateVector.Minimum = -360;
            this.tbRotateVector.Name = "tbRotateVector";
            this.tbRotateVector.Size = new System.Drawing.Size(214, 35);
            this.tbRotateVector.TabIndex = 5;
            this.tbRotateVector.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbRotateVector.Scroll += new System.EventHandler(this.tbRotateVector_Scroll);
            // 
            // txtRotZ
            // 
            this.txtRotZ.Location = new System.Drawing.Point(242, 78);
            this.txtRotZ.Name = "txtRotZ";
            this.txtRotZ.Size = new System.Drawing.Size(32, 22);
            this.txtRotZ.TabIndex = 10;
            this.txtRotZ.Text = "0";
            this.txtRotZ.TextChanged += new System.EventHandler(this.txtRotXYZ);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(212, 132);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 17);
            this.label8.TabIndex = 4;
            this.label8.Text = "Конец";
            // 
            // txtRotX
            // 
            this.txtRotX.Location = new System.Drawing.Point(243, 21);
            this.txtRotX.Name = "txtRotX";
            this.txtRotX.Size = new System.Drawing.Size(32, 22);
            this.txtRotX.TabIndex = 9;
            this.txtRotX.Text = "0";
            this.txtRotX.TextChanged += new System.EventHandler(this.txtRotXYZ);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 17);
            this.label7.TabIndex = 3;
            this.label7.Text = "Начало";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Oz";
            // 
            // StartVecTxt
            // 
            this.StartVecTxt.Location = new System.Drawing.Point(16, 147);
            this.StartVecTxt.Name = "StartVecTxt";
            this.StartVecTxt.Size = new System.Drawing.Size(76, 22);
            this.StartVecTxt.TabIndex = 2;
            this.StartVecTxt.Text = "0;0;0";
            this.StartVecTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.StartVecTxt.TextChanged += new System.EventHandler(this.InvalidateEvent);
            // 
            // EndVecTxt
            // 
            this.EndVecTxt.Location = new System.Drawing.Point(199, 150);
            this.EndVecTxt.Name = "EndVecTxt";
            this.EndVecTxt.Size = new System.Drawing.Size(76, 22);
            this.EndVecTxt.TabIndex = 0;
            this.EndVecTxt.Text = "0;0;1";
            this.EndVecTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.EndVecTxt.TextChanged += new System.EventHandler(this.InvalidateEvent);
            // 
            // tbRotateZ
            // 
            this.tbRotateZ.AutoSize = false;
            this.tbRotateZ.Location = new System.Drawing.Point(50, 76);
            this.tbRotateZ.Maximum = 360;
            this.tbRotateZ.Minimum = -360;
            this.tbRotateZ.Name = "tbRotateZ";
            this.tbRotateZ.Size = new System.Drawing.Size(186, 30);
            this.tbRotateZ.TabIndex = 4;
            this.tbRotateZ.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbRotateZ.Scroll += new System.EventHandler(this.tbRotate_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Oy";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ox";
            // 
            // tbRotateY
            // 
            this.tbRotateY.AutoSize = false;
            this.tbRotateY.Location = new System.Drawing.Point(50, 49);
            this.tbRotateY.Maximum = 360;
            this.tbRotateY.Minimum = -360;
            this.tbRotateY.Name = "tbRotateY";
            this.tbRotateY.Size = new System.Drawing.Size(186, 30);
            this.tbRotateY.TabIndex = 1;
            this.tbRotateY.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbRotateY.Scroll += new System.EventHandler(this.tbRotate_Scroll);
            // 
            // tbRotateX
            // 
            this.tbRotateX.AutoSize = false;
            this.tbRotateX.Location = new System.Drawing.Point(50, 21);
            this.tbRotateX.Maximum = 360;
            this.tbRotateX.Minimum = -360;
            this.tbRotateX.Name = "tbRotateX";
            this.tbRotateX.Size = new System.Drawing.Size(187, 30);
            this.tbRotateX.TabIndex = 0;
            this.tbRotateX.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbRotateX.Scroll += new System.EventHandler(this.tbRotate_Scroll);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ProectionXZ);
            this.groupBox2.Controls.Add(this.ProectionYZ);
            this.groupBox2.Controls.Add(this.ProectionXY);
            this.groupBox2.Location = new System.Drawing.Point(17, 529);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(276, 49);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Проекции";
            // 
            // ProectionXZ
            // 
            this.ProectionXZ.AutoSize = true;
            this.ProectionXZ.Location = new System.Drawing.Point(198, 21);
            this.ProectionXZ.Name = "ProectionXZ";
            this.ProectionXZ.Size = new System.Drawing.Size(70, 21);
            this.ProectionXZ.TabIndex = 4;
            this.ProectionXZ.Text = "На XZ";
            this.ProectionXZ.UseVisualStyleBackColor = true;
            this.ProectionXZ.CheckedChanged += new System.EventHandler(this.InvalidateEvent);
            // 
            // ProectionYZ
            // 
            this.ProectionYZ.AutoSize = true;
            this.ProectionYZ.Location = new System.Drawing.Point(107, 21);
            this.ProectionYZ.Name = "ProectionYZ";
            this.ProectionYZ.Size = new System.Drawing.Size(70, 21);
            this.ProectionYZ.TabIndex = 3;
            this.ProectionYZ.Text = "На YZ";
            this.ProectionYZ.UseVisualStyleBackColor = true;
            this.ProectionYZ.CheckedChanged += new System.EventHandler(this.InvalidateEvent);
            // 
            // ProectionXY
            // 
            this.ProectionXY.AutoSize = true;
            this.ProectionXY.Location = new System.Drawing.Point(9, 21);
            this.ProectionXY.Name = "ProectionXY";
            this.ProectionXY.Size = new System.Drawing.Size(70, 21);
            this.ProectionXY.TabIndex = 2;
            this.ProectionXY.Text = "На XY";
            this.ProectionXY.UseVisualStyleBackColor = true;
            this.ProectionXY.CheckedChanged += new System.EventHandler(this.InvalidateEvent);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.vecRdButton);
            this.groupBox1.Controls.Add(this.ZRdButton);
            this.groupBox1.Controls.Add(this.YRdButton);
            this.groupBox1.Controls.Add(this.XRdButton);
            this.groupBox1.Controls.Add(this.AnimStartButton);
            this.groupBox1.Controls.Add(this.AnimStopButton);
            this.groupBox1.Location = new System.Drawing.Point(11, 449);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(297, 80);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Анимация";
            // 
            // vecRdButton
            // 
            this.vecRdButton.AutoSize = true;
            this.vecRdButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.vecRdButton.Location = new System.Drawing.Point(72, 47);
            this.vecRdButton.Name = "vecRdButton";
            this.vecRdButton.Size = new System.Drawing.Size(100, 21);
            this.vecRdButton.TabIndex = 13;
            this.vecRdButton.TabStop = true;
            this.vecRdButton.Text = "По прямой";
            this.vecRdButton.UseVisualStyleBackColor = true;
            // 
            // ZRdButton
            // 
            this.ZRdButton.AutoSize = true;
            this.ZRdButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ZRdButton.Location = new System.Drawing.Point(8, 46);
            this.ZRdButton.Name = "ZRdButton";
            this.ZRdButton.Size = new System.Drawing.Size(60, 21);
            this.ZRdButton.TabIndex = 12;
            this.ZRdButton.TabStop = true;
            this.ZRdButton.Text = "По Z";
            this.ZRdButton.UseVisualStyleBackColor = true;
            // 
            // YRdButton
            // 
            this.YRdButton.AutoSize = true;
            this.YRdButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.YRdButton.Location = new System.Drawing.Point(72, 21);
            this.YRdButton.Name = "YRdButton";
            this.YRdButton.Size = new System.Drawing.Size(60, 21);
            this.YRdButton.TabIndex = 11;
            this.YRdButton.TabStop = true;
            this.YRdButton.Text = "По Y";
            this.YRdButton.UseVisualStyleBackColor = true;
            // 
            // XRdButton
            // 
            this.XRdButton.AutoSize = true;
            this.XRdButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.XRdButton.Location = new System.Drawing.Point(8, 21);
            this.XRdButton.Name = "XRdButton";
            this.XRdButton.Size = new System.Drawing.Size(60, 21);
            this.XRdButton.TabIndex = 10;
            this.XRdButton.TabStop = true;
            this.XRdButton.Text = "По Х";
            this.XRdButton.UseVisualStyleBackColor = true;
            // 
            // AnimStartButton
            // 
            this.AnimStartButton.BackColor = System.Drawing.Color.Plum;
            this.AnimStartButton.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.AnimStartButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AnimStartButton.Location = new System.Drawing.Point(198, 17);
            this.AnimStartButton.Name = "AnimStartButton";
            this.AnimStartButton.Size = new System.Drawing.Size(75, 23);
            this.AnimStartButton.TabIndex = 8;
            this.AnimStartButton.Text = "Старт";
            this.AnimStartButton.UseVisualStyleBackColor = false;
            this.AnimStartButton.Click += new System.EventHandler(this.AnimStartButton_Click);
            // 
            // AnimStopButton
            // 
            this.AnimStopButton.BackColor = System.Drawing.Color.Thistle;
            this.AnimStopButton.FlatAppearance.BorderColor = System.Drawing.Color.Thistle;
            this.AnimStopButton.FlatAppearance.BorderSize = 5;
            this.AnimStopButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AnimStopButton.Location = new System.Drawing.Point(198, 48);
            this.AnimStopButton.Name = "AnimStopButton";
            this.AnimStopButton.Size = new System.Drawing.Size(75, 23);
            this.AnimStopButton.TabIndex = 9;
            this.AnimStopButton.Text = "Стоп";
            this.AnimStopButton.UseVisualStyleBackColor = false;
            this.AnimStopButton.Click += new System.EventHandler(this.AnimStopButton_Click);
            // 
            // gbPer
            // 
            this.gbPer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPer.Controls.Add(this.txtZ);
            this.gbPer.Controls.Add(this.label5);
            this.gbPer.Controls.Add(this.txtY);
            this.gbPer.Controls.Add(this.tbPerZ);
            this.gbPer.Controls.Add(this.txtX);
            this.gbPer.Controls.Add(this.label3);
            this.gbPer.Controls.Add(this.tbPerX);
            this.gbPer.Controls.Add(this.label4);
            this.gbPer.Controls.Add(this.tbPerY);
            this.gbPer.Location = new System.Drawing.Point(11, 77);
            this.gbPer.Name = "gbPer";
            this.gbPer.Size = new System.Drawing.Size(302, 112);
            this.gbPer.TabIndex = 12;
            this.gbPer.TabStop = false;
            this.gbPer.Text = "Перенос фигуры";
            // 
            // txtZ
            // 
            this.txtZ.Location = new System.Drawing.Point(254, 80);
            this.txtZ.Name = "txtZ";
            this.txtZ.Size = new System.Drawing.Size(32, 22);
            this.txtZ.TabIndex = 10;
            this.txtZ.Text = "0";
            this.txtZ.TextChanged += new System.EventHandler(this.txtTrXYZ);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Oz";
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(254, 49);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(32, 22);
            this.txtY.TabIndex = 9;
            this.txtY.Text = "0";
            this.txtY.TextChanged += new System.EventHandler(this.txtTrXYZ);
            // 
            // tbPerZ
            // 
            this.tbPerZ.AutoSize = false;
            this.tbPerZ.Location = new System.Drawing.Point(54, 78);
            this.tbPerZ.Maximum = 20;
            this.tbPerZ.Minimum = -20;
            this.tbPerZ.Name = "tbPerZ";
            this.tbPerZ.Size = new System.Drawing.Size(186, 30);
            this.tbPerZ.TabIndex = 12;
            this.tbPerZ.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbPerZ.Scroll += new System.EventHandler(this.tbXYZ_Scroll);
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(254, 19);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(32, 22);
            this.txtX.TabIndex = 8;
            this.txtX.Text = "0";
            this.txtX.TextChanged += new System.EventHandler(this.txtTrXYZ);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Oy";
            // 
            // tbPerX
            // 
            this.tbPerX.AutoSize = false;
            this.tbPerX.Location = new System.Drawing.Point(54, 21);
            this.tbPerX.Maximum = 20;
            this.tbPerX.Minimum = -20;
            this.tbPerX.Name = "tbPerX";
            this.tbPerX.Size = new System.Drawing.Size(187, 30);
            this.tbPerX.TabIndex = 8;
            this.tbPerX.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbPerX.Scroll += new System.EventHandler(this.tbXYZ_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Ox";
            // 
            // tbPerY
            // 
            this.tbPerY.AutoSize = false;
            this.tbPerY.Location = new System.Drawing.Point(54, 50);
            this.tbPerY.Maximum = 20;
            this.tbPerY.Minimum = -20;
            this.tbPerY.Name = "tbPerY";
            this.tbPerY.Size = new System.Drawing.Size(186, 30);
            this.tbPerY.TabIndex = 9;
            this.tbPerY.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbPerY.Scroll += new System.EventHandler(this.tbXYZ_Scroll);
            // 
            // gbSize
            // 
            this.gbSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSize.Controls.Add(this.txtSize);
            this.gbSize.Controls.Add(this.tbSize);
            this.gbSize.Location = new System.Drawing.Point(34, 11);
            this.gbSize.Name = "gbSize";
            this.gbSize.Size = new System.Drawing.Size(245, 60);
            this.gbSize.TabIndex = 7;
            this.gbSize.TabStop = false;
            this.gbSize.Text = "Масштаб фигуры";
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(196, 21);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(36, 22);
            this.txtSize.TabIndex = 11;
            this.txtSize.Text = "50";
            this.txtSize.TextChanged += new System.EventHandler(this.txtSize_TextChanged);
            // 
            // tbSize
            // 
            this.tbSize.AutoSize = false;
            this.tbSize.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbSize.Location = new System.Drawing.Point(3, 21);
            this.tbSize.Maximum = 100;
            this.tbSize.Name = "tbSize";
            this.tbSize.Size = new System.Drawing.Size(187, 30);
            this.tbSize.TabIndex = 4;
            this.tbSize.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbSize.Value = 50;
            this.tbSize.Scroll += new System.EventHandler(this.tbSize_Scroll);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(2, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 609);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.Resize += new System.EventHandler(this.InvalidateEvent);
            // 
            // AnimTimer
            // 
            this.AnimTimer.Tick += new System.EventHandler(this.AnimTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 668);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbRotationO.ResumeLayout(false);
            this.gbRotationO.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbRotateVector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRotateZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRotateY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRotateX)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbPer.ResumeLayout(false);
            this.gbPer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbPerZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPerX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPerY)).EndInit();
            this.gbSize.ResumeLayout(false);
            this.gbSize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton ZRdButton;
        private System.Windows.Forms.RadioButton YRdButton;
        private System.Windows.Forms.RadioButton XRdButton;
        private System.Windows.Forms.Button AnimStopButton;
        private System.Windows.Forms.Button AnimStartButton;
        private System.Windows.Forms.GroupBox gbRotationO;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar tbRotateZ;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar tbRotateY;
        private System.Windows.Forms.TrackBar tbRotateX;
        private System.Windows.Forms.GroupBox gbPer;
        private System.Windows.Forms.TextBox txtZ;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.TrackBar tbPerZ;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar tbPerX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar tbPerY;
        private System.Windows.Forms.GroupBox gbSize;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.TrackBar tbSize;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer AnimTimer;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox NumbersChB;
        private System.Windows.Forms.TextBox txtRotY;
        private System.Windows.Forms.TextBox txtRotZ;
        private System.Windows.Forms.TextBox txtRotX;
        private System.Windows.Forms.ColorDialog cubeColor;
        private System.Windows.Forms.Button colorPickerCube;
        private System.Windows.Forms.Button colorPickerEdges;
        private System.Windows.Forms.ColorDialog edgesColor;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.TextBox EndVecTxt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox StartVecTxt;
        private System.Windows.Forms.TrackBar tbRotateVector;
        private System.Windows.Forms.CheckBox DrawLine;
        private System.Windows.Forms.TextBox vectorTxt;
        private System.Windows.Forms.RadioButton vecRdButton;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox LongChB;
        private System.Windows.Forms.CheckBox ProectionXY;
        private System.Windows.Forms.CheckBox ProectionYZ;
        private System.Windows.Forms.CheckBox ProectionXZ;
    }
}

