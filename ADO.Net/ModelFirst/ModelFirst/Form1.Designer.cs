namespace ModelFirst
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.поискToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редактированиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сортировкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поКличкеКотаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поВозрастуКотаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поИмениВладельцаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.всёToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.добавлениеКотаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавлениеВладельцаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалениеКотаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(373, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(415, 411);
            this.dataGridView1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.поискToolStripMenuItem,
            this.редактированиеToolStripMenuItem,
            this.сортировкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // поискToolStripMenuItem
            // 
            this.поискToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.поКличкеКотаToolStripMenuItem,
            this.поВозрастуКотаToolStripMenuItem,
            this.поИмениВладельцаToolStripMenuItem,
            this.всёToolStripMenuItem});
            this.поискToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.поискToolStripMenuItem.Name = "поискToolStripMenuItem";
            this.поискToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.поискToolStripMenuItem.Text = "Поиск";
            // 
            // редактированиеToolStripMenuItem
            // 
            this.редактированиеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавлениеКотаToolStripMenuItem,
            this.добавлениеВладельцаToolStripMenuItem,
            this.удалениеКотаToolStripMenuItem});
            this.редактированиеToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.редактированиеToolStripMenuItem.Name = "редактированиеToolStripMenuItem";
            this.редактированиеToolStripMenuItem.Size = new System.Drawing.Size(124, 21);
            this.редактированиеToolStripMenuItem.Text = "Редактирование";
            // 
            // сортировкаToolStripMenuItem
            // 
            this.сортировкаToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.сортировкаToolStripMenuItem.Name = "сортировкаToolStripMenuItem";
            this.сортировкаToolStripMenuItem.Size = new System.Drawing.Size(89, 21);
            this.сортировкаToolStripMenuItem.Text = "Статистика";
            this.сортировкаToolStripMenuItem.Click += new System.EventHandler(this.сортировкаToolStripMenuItem_Click);
            // 
            // поКличкеКотаToolStripMenuItem
            // 
            this.поКличкеКотаToolStripMenuItem.Name = "поКличкеКотаToolStripMenuItem";
            this.поКличкеКотаToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.поКличкеКотаToolStripMenuItem.Text = "По кличке кота";
            this.поКличкеКотаToolStripMenuItem.Click += new System.EventHandler(this.поКличкеКотаToolStripMenuItem_Click);
            // 
            // поВозрастуКотаToolStripMenuItem
            // 
            this.поВозрастуКотаToolStripMenuItem.Name = "поВозрастуКотаToolStripMenuItem";
            this.поВозрастуКотаToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.поВозрастуКотаToolStripMenuItem.Text = "По возрасту кота";
            this.поВозрастуКотаToolStripMenuItem.Click += new System.EventHandler(this.поВозрастуКотаToolStripMenuItem_Click);
            // 
            // поИмениВладельцаToolStripMenuItem
            // 
            this.поИмениВладельцаToolStripMenuItem.Name = "поИмениВладельцаToolStripMenuItem";
            this.поИмениВладельцаToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.поИмениВладельцаToolStripMenuItem.Text = "По имени владельца";
            this.поИмениВладельцаToolStripMenuItem.Click += new System.EventHandler(this.поИмениВладельцаToolStripMenuItem_Click);
            // 
            // всёToolStripMenuItem
            // 
            this.всёToolStripMenuItem.Name = "всёToolStripMenuItem";
            this.всёToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.всёToolStripMenuItem.Text = "Всё";
            this.всёToolStripMenuItem.Click += new System.EventHandler(this.всёToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(326, 222);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Поиск";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(16, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(19, 89);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(289, 25);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(89, 150);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 36);
            this.button1.TabIndex = 2;
            this.button1.Text = "Найти";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // добавлениеКотаToolStripMenuItem
            // 
            this.добавлениеКотаToolStripMenuItem.Name = "добавлениеКотаToolStripMenuItem";
            this.добавлениеКотаToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.добавлениеКотаToolStripMenuItem.Text = "Добавление кота";
            this.добавлениеКотаToolStripMenuItem.Click += new System.EventHandler(this.добавлениеКотаToolStripMenuItem_Click);
            // 
            // добавлениеВладельцаToolStripMenuItem
            // 
            this.добавлениеВладельцаToolStripMenuItem.Name = "добавлениеВладельцаToolStripMenuItem";
            this.добавлениеВладельцаToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.добавлениеВладельцаToolStripMenuItem.Text = "Добавление владельца";
            this.добавлениеВладельцаToolStripMenuItem.Click += new System.EventHandler(this.добавлениеВладельцаToolStripMenuItem_Click);
            // 
            // удалениеКотаToolStripMenuItem
            // 
            this.удалениеКотаToolStripMenuItem.Name = "удалениеКотаToolStripMenuItem";
            this.удалениеКотаToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.удалениеКотаToolStripMenuItem.Text = "Удаление кота";
            this.удалениеКотаToolStripMenuItem.Click += new System.EventHandler(this.удалениеКотаToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Cats";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem поискToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поКличкеКотаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поВозрастуКотаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поИмениВладельцаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem всёToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редактированиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сортировкаToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem добавлениеКотаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавлениеВладельцаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалениеКотаToolStripMenuItem;
    }
}

