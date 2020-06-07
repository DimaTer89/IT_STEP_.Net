namespace LinqSQL
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
            this.youngMonkeys = new System.Windows.Forms.Button();
            this.monkeysOverTen = new System.Windows.Forms.Button();
            this.byBreed = new System.Windows.Forms.Button();
            this.saveChanges = new System.Windows.Forms.Button();
            this.showDataBase = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 13);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(407, 327);
            this.dataGridView1.TabIndex = 0;
            // 
            // youngMonkeys
            // 
            this.youngMonkeys.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.youngMonkeys.Location = new System.Drawing.Point(468, 13);
            this.youngMonkeys.Name = "youngMonkeys";
            this.youngMonkeys.Size = new System.Drawing.Size(144, 43);
            this.youngMonkeys.TabIndex = 1;
            this.youngMonkeys.Text = "Young Monkeys";
            this.youngMonkeys.UseVisualStyleBackColor = true;
            this.youngMonkeys.Click += new System.EventHandler(this.youngMonkeys_Click);
            // 
            // monkeysOverTen
            // 
            this.monkeysOverTen.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.monkeysOverTen.Location = new System.Drawing.Point(468, 77);
            this.monkeysOverTen.Name = "monkeysOverTen";
            this.monkeysOverTen.Size = new System.Drawing.Size(144, 43);
            this.monkeysOverTen.TabIndex = 2;
            this.monkeysOverTen.Text = "Monkeys Over 10";
            this.monkeysOverTen.UseVisualStyleBackColor = true;
            this.monkeysOverTen.Click += new System.EventHandler(this.monkeysOverTen_Click);
            // 
            // byBreed
            // 
            this.byBreed.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.byBreed.Location = new System.Drawing.Point(468, 146);
            this.byBreed.Name = "byBreed";
            this.byBreed.Size = new System.Drawing.Size(144, 43);
            this.byBreed.TabIndex = 3;
            this.byBreed.Text = "By Breed";
            this.byBreed.UseVisualStyleBackColor = true;
            this.byBreed.Click += new System.EventHandler(this.byBreed_Click);
            // 
            // saveChanges
            // 
            this.saveChanges.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveChanges.Location = new System.Drawing.Point(468, 218);
            this.saveChanges.Name = "saveChanges";
            this.saveChanges.Size = new System.Drawing.Size(144, 43);
            this.saveChanges.TabIndex = 4;
            this.saveChanges.Text = "Save Changes";
            this.saveChanges.UseVisualStyleBackColor = true;
            this.saveChanges.Click += new System.EventHandler(this.saveChanges_Click);
            // 
            // showDataBase
            // 
            this.showDataBase.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.showDataBase.Location = new System.Drawing.Point(468, 293);
            this.showDataBase.Name = "showDataBase";
            this.showDataBase.Size = new System.Drawing.Size(144, 43);
            this.showDataBase.TabIndex = 5;
            this.showDataBase.Text = "Show DataBase";
            this.showDataBase.UseVisualStyleBackColor = true;
            this.showDataBase.Click += new System.EventHandler(this.showDataBase_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 360);
            this.Controls.Add(this.showDataBase);
            this.Controls.Add(this.saveChanges);
            this.Controls.Add(this.byBreed);
            this.Controls.Add(this.monkeysOverTen);
            this.Controls.Add(this.youngMonkeys);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "LinqSQL";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button youngMonkeys;
        private System.Windows.Forms.Button monkeysOverTen;
        private System.Windows.Forms.Button byBreed;
        private System.Windows.Forms.Button saveChanges;
        private System.Windows.Forms.Button showDataBase;
    }
}

