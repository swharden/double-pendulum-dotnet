
namespace DPend.WinForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nudMassP1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.nudLengthP1 = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.nudMassP2 = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.nudLengthP2 = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nudSpeed = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMassP1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLengthP1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMassP2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLengthP2)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Navy;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 88);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(515, 333);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.SizeChanged += new System.EventHandler(this.pictureBox1_SizeChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nudMassP1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.nudLengthP1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(199, 70);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pendulum 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(101, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mass (kg)";
            // 
            // nudMassP1
            // 
            this.nudMassP1.DecimalPlaces = 1;
            this.nudMassP1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudMassP1.Location = new System.Drawing.Point(101, 37);
            this.nudMassP1.Name = "nudMassP1";
            this.nudMassP1.Size = new System.Drawing.Size(89, 23);
            this.nudMassP1.TabIndex = 2;
            this.nudMassP1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMassP1.ValueChanged += new System.EventHandler(this.nudMassP1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Length (m)";
            // 
            // nudLengthP1
            // 
            this.nudLengthP1.DecimalPlaces = 1;
            this.nudLengthP1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudLengthP1.Location = new System.Drawing.Point(6, 37);
            this.nudLengthP1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudLengthP1.Name = "nudLengthP1";
            this.nudLengthP1.Size = new System.Drawing.Size(89, 23);
            this.nudLengthP1.TabIndex = 0;
            this.nudLengthP1.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudLengthP1.ValueChanged += new System.EventHandler(this.nudLengthP1_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.nudMassP2);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.nudLengthP2);
            this.groupBox2.Location = new System.Drawing.Point(217, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(199, 70);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pendulum 2";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(101, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 15);
            this.label7.TabIndex = 3;
            this.label7.Text = "Mass (kg)";
            // 
            // nudMassP2
            // 
            this.nudMassP2.DecimalPlaces = 1;
            this.nudMassP2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudMassP2.Location = new System.Drawing.Point(101, 37);
            this.nudMassP2.Name = "nudMassP2";
            this.nudMassP2.Size = new System.Drawing.Size(89, 23);
            this.nudMassP2.TabIndex = 2;
            this.nudMassP2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMassP2.ValueChanged += new System.EventHandler(this.nudMassP2_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 15);
            this.label8.TabIndex = 1;
            this.label8.Text = "Length (m)";
            // 
            // nudLengthP2
            // 
            this.nudLengthP2.DecimalPlaces = 1;
            this.nudLengthP2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudLengthP2.Location = new System.Drawing.Point(6, 37);
            this.nudLengthP2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudLengthP2.Name = "nudLengthP2";
            this.nudLengthP2.Size = new System.Drawing.Size(89, 23);
            this.nudLengthP2.TabIndex = 0;
            this.nudLengthP2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLengthP2.ValueChanged += new System.EventHandler(this.nudLengthP2_ValueChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.nudSpeed);
            this.groupBox3.Location = new System.Drawing.Point(422, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(105, 70);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Speed";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Steps per frame";
            // 
            // nudSpeed
            // 
            this.nudSpeed.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudSpeed.Location = new System.Drawing.Point(6, 37);
            this.nudSpeed.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudSpeed.Name = "nudSpeed";
            this.nudSpeed.Size = new System.Drawing.Size(89, 23);
            this.nudSpeed.TabIndex = 3;
            this.nudSpeed.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 433);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Double Pendulum";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMassP1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLengthP1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMassP2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLengthP2)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudMassP1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudLengthP1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudMassP2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudLengthP2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudSpeed;
    }
}

