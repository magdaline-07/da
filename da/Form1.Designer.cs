namespace da
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
        /// 

        private void InitializeComponent()
        {
            button1 = new Button();
            folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog2 = new FolderBrowserDialog();
            folderBrowserDialog3 = new FolderBrowserDialog();
            browseControl1 = new BrowseControl();
            checkBox1 = new CheckBox();
            button2 = new Button();
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(617, 29);
            button1.Name = "button1";
            button1.Size = new Size(148, 39);
            button1.TabIndex = 1;
            button1.Text = "Соединение";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // browseControl1
            // 
            browseControl1.Location = new Point(13, 29);
            browseControl1.Margin = new Padding(4, 5, 4, 5);
            browseControl1.Name = "browseControl1";
            browseControl1.RebrowseOnNodeExpande = false;
            browseControl1.Session = null;
            browseControl1.Size = new Size(296, 383);
            browseControl1.TabIndex = 2;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(617, 163);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(87, 24);
            checkBox1.TabIndex = 3;
            checkBox1.Text = "ЗАПУСК";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // button2
            // 
            button2.Location = new Point(617, 95);
            button2.Name = "button2";
            button2.Size = new Size(148, 39);
            button2.TabIndex = 4;
            button2.Text = "Мониторинг";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(343, 36);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(260, 28);
            comboBox1.TabIndex = 5;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // textBox1
            // 
            textBox1.AllowDrop = true;
            textBox1.Location = new Point(352, 91);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(92, 27);
            textBox1.TabIndex = 6;
            textBox1.DragDrop += textBox1_DragDrop;
            textBox1.DragOver += textBox1_DragOver;
            // 
            // textBox2
            // 
            textBox2.AllowDrop = true;
            textBox2.Location = new Point(352, 148);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(92, 27);
            textBox2.TabIndex = 7;
            textBox2.DragDrop += textBox2_DragDrop;
            textBox2.DragOver += textBox2_DragOver;
            // 
            // textBox3
            // 
            textBox3.AllowDrop = true;
            textBox3.Location = new Point(352, 208);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(92, 27);
            textBox3.TabIndex = 8;
            textBox3.DragDrop += textBox3_DragDrop;
            textBox3.DragOver += textBox3_DragOver;
            // 
            // textBox4
            // 
            textBox4.AllowDrop = true;
            textBox4.Location = new Point(352, 267);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(92, 27);
            textBox4.TabIndex = 9;
            textBox4.DragDrop += textBox4_DragDrop;
            textBox4.DragOver += textBox4_DragOver;
            // 
            // textBox5
            // 
            textBox5.AllowDrop = true;
            textBox5.Location = new Point(352, 325);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(92, 27);
            textBox5.TabIndex = 10;
            textBox5.DragDrop += textBox5_DragDrop;
            textBox5.DragOver += textBox5_DragOver;
            // 
            // textBox6
            // 
            textBox6.AllowDrop = true;
            textBox6.Location = new Point(352, 385);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(92, 27);
            textBox6.TabIndex = 11;
            textBox6.DragDrop += textBox6_DragDrop;
            textBox6.DragOver += textBox6_DragOver;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(458, 94);
            label1.Name = "label1";
            label1.Size = new Size(43, 20);
            label1.TabIndex = 12;
            label1.Text = "Вода";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(458, 148);
            label2.Name = "label2";
            label2.Size = new Size(45, 20);
            label2.TabIndex = 13;
            label2.Text = "Кофе";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(458, 208);
            label3.Name = "label3";
            label3.Size = new Size(50, 20);
            label3.TabIndex = 14;
            label3.Text = "Сахар";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(458, 270);
            label4.Name = "label4";
            label4.Size = new Size(64, 20);
            label4.TabIndex = 15;
            label4.Text = "Молоко";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(458, 325);
            label5.Name = "label5";
            label5.Size = new Size(91, 20);
            label5.TabIndex = 16;
            label5.Text = "Вес в миске";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(458, 385);
            label6.Name = "label6";
            label6.Size = new Size(160, 20);
            label6.TabIndex = 17;
            label6.Text = "Температура нагрева";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox6);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(comboBox1);
            Controls.Add(button2);
            Controls.Add(checkBox1);
            Controls.Add(browseControl1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }
        public Form1()
        {
            InitializeComponent();

            // Создание BrowseControl вручную
            browseControl1 = new BrowseControl();
            browseControl1.Location = new Point(13, 14);
            browseControl1.Size = new Size(250, 289);
            browseControl1.RebrowseOnNodeExpande = false;
            browseControl1.Session = null;

            this.Controls.Add(browseControl1);
        }


        #endregion

        private Button ConnectDisconnectBTN_Click;
        
        private FolderBrowserDialog folderBrowserDialog1;
        private FolderBrowserDialog folderBrowserDialog2;
        private FolderBrowserDialog folderBrowserDialog3;
        private BrowseControl browseControl1;
        private CheckBox checkBox1;
        private Button button2;
    
        private ComboBox comboBox1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button button1;
    }
}
