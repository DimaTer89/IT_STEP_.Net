namespace LinqEntity
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.humans = new System.Windows.Forms.Button();
            this.countPeople = new System.Windows.Forms.Button();
            this.addCanadaPeople = new System.Windows.Forms.Button();
            this.deletePeople = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 13);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(611, 316);
            this.dataGridView1.TabIndex = 0;
            // 
            // humans
            // 
            this.humans.Location = new System.Drawing.Point(13, 351);
            this.humans.Name = "humans";
            this.humans.Size = new System.Drawing.Size(179, 41);
            this.humans.TabIndex = 1;
            this.humans.Text = "Humans";
            this.humans.UseVisualStyleBackColor = true;
            this.humans.Click += new System.EventHandler(this.humans_Click);
            // 
            // countPeople
            // 
            this.countPeople.Location = new System.Drawing.Point(227, 351);
            this.countPeople.Name = "countPeople";
            this.countPeople.Size = new System.Drawing.Size(179, 41);
            this.countPeople.TabIndex = 2;
            this.countPeople.Text = "Count people";
            this.countPeople.UseVisualStyleBackColor = true;
            this.countPeople.Click += new System.EventHandler(this.countPeople_Click);
            // 
            // addCanadaPeople
            // 
            this.addCanadaPeople.Location = new System.Drawing.Point(13, 410);
            this.addCanadaPeople.Name = "addCanadaPeople";
            this.addCanadaPeople.Size = new System.Drawing.Size(179, 41);
            this.addCanadaPeople.TabIndex = 3;
            this.addCanadaPeople.Text = "Add Canada People";
            this.addCanadaPeople.UseVisualStyleBackColor = true;
            this.addCanadaPeople.Click += new System.EventHandler(this.addCanadaPeople_Click);
            // 
            // deletePeople
            // 
            this.deletePeople.Location = new System.Drawing.Point(445, 351);
            this.deletePeople.Name = "deletePeople";
            this.deletePeople.Size = new System.Drawing.Size(179, 41);
            this.deletePeople.TabIndex = 4;
            this.deletePeople.Text = "Delete People";
            this.deletePeople.UseVisualStyleBackColor = true;
            this.deletePeople.Click += new System.EventHandler(this.deletePeople_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(227, 422);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(158, 29);
            this.textBox1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 463);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.deletePeople);
            this.Controls.Add(this.addCanadaPeople);
            this.Controls.Add(this.countPeople);
            this.Controls.Add(this.humans);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "EntityIndependent";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button humans;
        private System.Windows.Forms.Button countPeople;
        private System.Windows.Forms.Button addCanadaPeople;
        private System.Windows.Forms.Button deletePeople;
        private System.Windows.Forms.TextBox textBox1;
    }
}

