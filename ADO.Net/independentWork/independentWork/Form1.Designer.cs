namespace independentWork
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
            this.save = new System.Windows.Forms.Button();
            this.needAboveAverage = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataBase = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // save
            // 
            this.save.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.save.Location = new System.Drawing.Point(13, 370);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(179, 41);
            this.save.TabIndex = 0;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // needAboveAverage
            // 
            this.needAboveAverage.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.needAboveAverage.Location = new System.Drawing.Point(215, 370);
            this.needAboveAverage.Name = "needAboveAverage";
            this.needAboveAverage.Size = new System.Drawing.Size(179, 41);
            this.needAboveAverage.TabIndex = 1;
            this.needAboveAverage.Text = "Need Above Average";
            this.needAboveAverage.UseVisualStyleBackColor = true;
            this.needAboveAverage.Click += new System.EventHandler(this.needAboveAverage_Click);
            // 
            // cancel
            // 
            this.cancel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancel.Location = new System.Drawing.Point(419, 370);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(179, 41);
            this.cancel.TabIndex = 2;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 13);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(785, 351);
            this.dataGridView1.TabIndex = 3;
            // 
            // dataBase
            // 
            this.dataBase.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataBase.Location = new System.Drawing.Point(619, 370);
            this.dataBase.Name = "dataBase";
            this.dataBase.Size = new System.Drawing.Size(179, 41);
            this.dataBase.TabIndex = 4;
            this.dataBase.Text = "Show DataBase";
            this.dataBase.UseVisualStyleBackColor = true;
            this.dataBase.Click += new System.EventHandler(this.dataBase_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 421);
            this.Controls.Add(this.dataBase);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.needAboveAverage);
            this.Controls.Add(this.save);
            this.Name = "Form1";
            this.Text = "Cowshed";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button needAboveAverage;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button dataBase;
    }
}

