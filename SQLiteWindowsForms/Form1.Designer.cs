namespace SQLiteWindowsForms
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
            loadButton = new Button();
            button2 = new Button();
            dataGridView1 = new DataGridView();
            Name = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // loadButton
            // 
            loadButton.Location = new Point(12, 12);
            loadButton.Name = "loadButton";
            loadButton.Size = new Size(159, 39);
            loadButton.TabIndex = 0;
            loadButton.Text = "load database file";
            loadButton.UseVisualStyleBackColor = true;
            loadButton.Click += loadButton_click;
            // 
            // button2
            // 
            button2.Location = new Point(12, 67);
            button2.Name = "button2";
            button2.Size = new Size(159, 39);
            button2.TabIndex = 2;
            button2.Text = "save database to file";
            button2.UseVisualStyleBackColor = true;
            button2.Click += saveButton_click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Name, Price });
            dataGridView1.Location = new Point(177, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(243, 426);
            dataGridView1.TabIndex = 3;
            // 
            // Name
            // 
            Name.HeaderText = "Name";
            Name.Name = "column1";
            // 
            // Price
            // 
            Price.HeaderText = "Price";
            Price.Name = "column2";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(430, 446);
            Controls.Add(dataGridView1);
            Controls.Add(button2);
            Controls.Add(loadButton);
            Text = "SQLite in Windows Forms Example";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button loadButton;
        private Button button2;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Name;
        private DataGridViewTextBoxColumn Price;
    }
}
