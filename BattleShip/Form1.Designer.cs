namespace BattleShip
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
            //DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            //DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            //DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            //DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            //DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            //DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            //DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            //DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            //DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            //DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            button1 = new Button();
            textBox1 = new TextBox();
            button2 = new Button();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton3 = new RadioButton();
            radioButton4 = new RadioButton();
            button203 = new Button();
            button204 = new Button();
            dataGridView1 = new DataGridView();
            А = new DataGridViewTextBoxColumn();
            Б = new DataGridViewTextBoxColumn();
            В = new DataGridViewTextBoxColumn();
            Г = new DataGridViewTextBoxColumn();
            Д = new DataGridViewTextBoxColumn();
            Е = new DataGridViewTextBoxColumn();
            Ж = new DataGridViewTextBoxColumn();
            З = new DataGridViewTextBoxColumn();
            И = new DataGridViewTextBoxColumn();
            К = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(640, 39);
            button1.Name = "button1";
            button1.Size = new Size(126, 23);
            button1.TabIndex = 0;
            button1.Text = "Выстрел";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(640, 97);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(126, 23);
            textBox1.TabIndex = 1;
            // 
            // button2
            // 
            button2.Location = new Point(640, 68);
            button2.Name = "button2";
            button2.Size = new Size(126, 23);
            button2.TabIndex = 2;
            button2.Text = "Авто выстрел";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(640, 129);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(52, 19);
            checkBox1.TabIndex = 5;
            checkBox1.Text = "Вниз";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(640, 154);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(70, 19);
            checkBox2.TabIndex = 6;
            checkBox2.Text = "Удалить";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.Click += checkBox2_Click;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(640, 179);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(37, 19);
            radioButton1.TabIndex = 7;
            radioButton1.TabStop = true;
            radioButton1.Text = "х1";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(640, 204);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(37, 19);
            radioButton2.TabIndex = 8;
            radioButton2.TabStop = true;
            radioButton2.Text = "x2";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(640, 229);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(37, 19);
            radioButton3.TabIndex = 9;
            radioButton3.TabStop = true;
            radioButton3.Text = "x3";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Location = new Point(640, 254);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(37, 19);
            radioButton4.TabIndex = 10;
            radioButton4.TabStop = true;
            radioButton4.Text = "x4";
            radioButton4.UseVisualStyleBackColor = true;
            // 
            // button203
            // 
            button203.Location = new Point(640, 282);
            button203.Name = "button203";
            button203.Size = new Size(126, 23);
            button203.TabIndex = 11;
            button203.Text = "Поставить";
            button203.UseVisualStyleBackColor = true;
            button203.Click += button203_Click;
            // 
            // button204
            // 
            button204.Location = new Point(640, 311);
            button204.Name = "button204";
            button204.Size = new Size(126, 23);
            button204.TabIndex = 12;
            button204.Text = "Перерисовать";
            button204.UseVisualStyleBackColor = true;
            button204.Click += button204_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { А, Б, В, Г, Д, Е, Ж, З, И, К });
            dataGridView1.Location = new Point(24, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 25;
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.ScrollBars = ScrollBars.None;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView1.Size = new Size(255, 271);
            dataGridView1.TabIndex = 35;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // А
            // 
            А.HeaderText = "А";
            А.Name = "А";
            А.Resizable = DataGridViewTriState.False;
            А.Width = 25;
            // 
            // Б
            // 
            Б.HeaderText = "Б";
            Б.Name = "Б";
            Б.Resizable = DataGridViewTriState.False;
            Б.Width = 25;
            // 
            // В
            // 
            В.HeaderText = "В";
            В.Name = "В";
            В.Resizable = DataGridViewTriState.False;
            В.Width = 25;
            // 
            // Г
            // 
            Г.HeaderText = "Г";
            Г.Name = "Г";
            Г.Resizable = DataGridViewTriState.False;
            Г.Width = 25;
            // 
            // Д
            // 
            Д.HeaderText = "Д";
            Д.Name = "Д";
            Д.Resizable = DataGridViewTriState.False;
            Д.Width = 25;
            // 
            // Е
            // 
            Е.HeaderText = "Е";
            Е.Name = "Е";
            Е.Resizable = DataGridViewTriState.False;
            Е.Width = 25;
            // 
            // Ж
            // 
            Ж.HeaderText = "Ж";
            Ж.Name = "Ж";
            Ж.Resizable = DataGridViewTriState.False;
            Ж.Width = 25;
            // 
            // З
            // 
            З.HeaderText = "З";
            З.Name = "З";
            З.Resizable = DataGridViewTriState.False;
            З.Width = 25;
            // 
            // И
            //            
            И.HeaderText = "И";
            И.Name = "И";
            И.Resizable = DataGridViewTriState.False;
            И.Width = 25;
            // 
            // К
            //                        
            К.HeaderText = "К";
            К.Name = "К";
            К.Resizable = DataGridViewTriState.False;
            К.Width = 25;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(button204);
            Controls.Add(button203);
            Controls.Add(radioButton4);
            Controls.Add(radioButton3);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(button2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBox1;
        private Button button2;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RadioButton radioButton3;
        private RadioButton radioButton4;
        private Button button203;
        private Button button204;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn А;
        private DataGridViewTextBoxColumn Б;
        private DataGridViewTextBoxColumn В;
        private DataGridViewTextBoxColumn Г;
        private DataGridViewTextBoxColumn Д;
        private DataGridViewTextBoxColumn Е;
        private DataGridViewTextBoxColumn Ж;
        private DataGridViewTextBoxColumn З;
        private DataGridViewTextBoxColumn И;
        private DataGridViewTextBoxColumn К;
    }
}
