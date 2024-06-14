namespace _6demayo
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
            pictureBox1 = new PictureBox();
            button1 = new Button();
            button2 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button3 = new Button();
            textBox3 = new TextBox();
            openFileDialog1 = new OpenFileDialog();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            dataGridView1 = new DataGridView();
            textBox5 = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label6 = new Label();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.PaleTurquoise;
            pictureBox1.Location = new Point(265, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(385, 370);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.MouseClick += pictureBox1_MouseClick;
            // 
            // button1
            // 
            button1.BackColor = Color.Silver;
            button1.Location = new Point(78, 39);
            button1.Name = "button1";
            button1.Size = new Size(84, 29);
            button1.TabIndex = 1;
            button1.Text = "Importar";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Silver;
            button2.Location = new Point(78, 315);
            button2.Name = "button2";
            button2.Size = new Size(84, 29);
            button2.TabIndex = 2;
            button2.Text = "Texturizador";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(78, 158);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(84, 23);
            textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(78, 187);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(84, 23);
            textBox2.TabIndex = 4;
            // 
            // button3
            // 
            button3.BackColor = Color.Silver;
            button3.Location = new Point(78, 109);
            button3.Name = "button3";
            button3.Size = new Size(84, 29);
            button3.TabIndex = 5;
            button3.Text = "Texturizador";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(78, 216);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(84, 23);
            textBox3.TabIndex = 6;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(58, 161);
            label1.Name = "label1";
            label1.Size = new Size(14, 15);
            label1.TabIndex = 8;
            label1.Text = "R";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(58, 190);
            label2.Name = "label2";
            label2.Size = new Size(15, 15);
            label2.TabIndex = 9;
            label2.Text = "G";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(58, 219);
            label3.Name = "label3";
            label3.Size = new Size(14, 15);
            label3.TabIndex = 10;
            label3.Text = "B";
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.FromArgb(192, 255, 255);
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 429);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(827, 193);
            dataGridView1.TabIndex = 12;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(78, 257);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(84, 23);
            textBox5.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(43, 260);
            label5.Name = "label5";
            label5.Size = new Size(29, 15);
            label5.TabIndex = 15;
            label5.Text = "HEX";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(78, 297);
            label4.Name = "label4";
            label4.Size = new Size(90, 15);
            label4.TabIndex = 16;
            label4.Text = "TEXT POR PIXEL";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(78, 81);
            label6.Name = "label6";
            label6.Size = new Size(96, 15);
            label6.TabIndex = 17;
            label6.Text = "TEXT SECCIONES";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(373, 400);
            label8.Name = "label8";
            label8.Size = new Size(89, 15);
            label8.TabIndex = 20;
            label8.Text = "BASE DE DATOS";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(862, 628);
            Controls.Add(label8);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(textBox5);
            Controls.Add(dataGridView1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox3);
            Controls.Add(button3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private Button button2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button3;
        private TextBox textBox3;
        private OpenFileDialog openFileDialog1;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private DataGridView dataGridView1;
        private TextBox textBox5;
        private Label label5;
        private Label label4;
        private Label label6;
        private Label label8;
    }
}
