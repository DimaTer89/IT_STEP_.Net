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
            this.поКличкеКотаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поВозрастуКотаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поИмениВладельцаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.всёToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редактированиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавлениеКотаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавлениеВладельцаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалениеКотаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалениеПоВведённымДаннымToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалениеПоОтмеченномуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сортировкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.количестовКотовУКаждогоВладельцадиаграммаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.среднийВосрастКотовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.количествоВладельцевУКоторыхБольше2КотовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.кличкиКотовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.averageAveCat = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(373, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(415, 364);
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
            this.удалениеКотаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.удалениеПоВведённымДаннымToolStripMenuItem,
            this.удалениеПоОтмеченномуToolStripMenuItem});
            this.удалениеКотаToolStripMenuItem.Name = "удалениеКотаToolStripMenuItem";
            this.удалениеКотаToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.удалениеКотаToolStripMenuItem.Text = "Удаление кота";
            // 
            // удалениеПоВведённымДаннымToolStripMenuItem
            // 
            this.удалениеПоВведённымДаннымToolStripMenuItem.Name = "удалениеПоВведённымДаннымToolStripMenuItem";
            this.удалениеПоВведённымДаннымToolStripMenuItem.Size = new System.Drawing.Size(286, 22);
            this.удалениеПоВведённымДаннымToolStripMenuItem.Text = "Удаление по введённым данным";
            this.удалениеПоВведённымДаннымToolStripMenuItem.Click += new System.EventHandler(this.удалениеПоВведённымДаннымToolStripMenuItem_Click);
            // 
            // удалениеПоОтмеченномуToolStripMenuItem
            // 
            this.удалениеПоОтмеченномуToolStripMenuItem.Name = "удалениеПоОтмеченномуToolStripMenuItem";
            this.удалениеПоОтмеченномуToolStripMenuItem.Size = new System.Drawing.Size(286, 22);
            this.удалениеПоОтмеченномуToolStripMenuItem.Text = "Удаление по отмеченной строке";
            this.удалениеПоОтмеченномуToolStripMenuItem.Click += new System.EventHandler(this.удалениеПоОтмеченномуToolStripMenuItem_Click);
            // 
            // сортировкаToolStripMenuItem
            // 
            this.сортировкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.количестовКотовУКаждогоВладельцадиаграммаToolStripMenuItem,
            this.среднийВосрастКотовToolStripMenuItem,
            this.количествоВладельцевУКоторыхБольше2КотовToolStripMenuItem,
            this.кличкиКотовToolStripMenuItem});
            this.сортировкаToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.сортировкаToolStripMenuItem.Name = "сортировкаToolStripMenuItem";
            this.сортировкаToolStripMenuItem.Size = new System.Drawing.Size(89, 21);
            this.сортировкаToolStripMenuItem.Text = "Статистика";
            // 
            // количестовКотовУКаждогоВладельцадиаграммаToolStripMenuItem
            // 
            this.количестовКотовУКаждогоВладельцадиаграммаToolStripMenuItem.Name = "количестовКотовУКаждогоВладельцадиаграммаToolStripMenuItem";
            this.количестовКотовУКаждогоВладельцадиаграммаToolStripMenuItem.Size = new System.Drawing.Size(404, 22);
            this.количестовКотовУКаждогоВладельцадиаграммаToolStripMenuItem.Text = "Количестов котов у каждого владельца(диаграмма)";
            this.количестовКотовУКаждогоВладельцадиаграммаToolStripMenuItem.Click += new System.EventHandler(this.количестовКотовУКаждогоВладельцадиаграммаToolStripMenuItem_Click);
            // 
            // среднийВосрастКотовToolStripMenuItem
            // 
            this.среднийВосрастКотовToolStripMenuItem.Name = "среднийВосрастКотовToolStripMenuItem";
            this.среднийВосрастКотовToolStripMenuItem.Size = new System.Drawing.Size(404, 22);
            this.среднийВосрастКотовToolStripMenuItem.Text = "Средний восраст котов";
            this.среднийВосрастКотовToolStripMenuItem.Click += new System.EventHandler(this.среднийВосрастКотовToolStripMenuItem_Click);
            // 
            // количествоВладельцевУКоторыхБольше2КотовToolStripMenuItem
            // 
            this.количествоВладельцевУКоторыхБольше2КотовToolStripMenuItem.Name = "количествоВладельцевУКоторыхБольше2КотовToolStripMenuItem";
            this.количествоВладельцевУКоторыхБольше2КотовToolStripMenuItem.Size = new System.Drawing.Size(404, 22);
            this.количествоВладельцевУКоторыхБольше2КотовToolStripMenuItem.Text = "Количество владельцев, у которых больше 2 котов";
            this.количествоВладельцевУКоторыхБольше2КотовToolStripMenuItem.Click += new System.EventHandler(this.количествоВладельцевУКоторыхБольше2КотовToolStripMenuItem_Click);
            // 
            // кличкиКотовToolStripMenuItem
            // 
            this.кличкиКотовToolStripMenuItem.Name = "кличкиКотовToolStripMenuItem";
            this.кличкиКотовToolStripMenuItem.Size = new System.Drawing.Size(404, 22);
            this.кличкиКотовToolStripMenuItem.Text = "Клички котов";
            this.кличкиКотовToolStripMenuItem.Click += new System.EventHandler(this.кличкиКотовToolStripMenuItem_Click);
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
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(19, 89);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(289, 25);
            this.textBox1.TabIndex = 1;
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
            // averageAveCat
            // 
            this.averageAveCat.AutoSize = true;
            this.averageAveCat.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.averageAveCat.Location = new System.Drawing.Point(13, 301);
            this.averageAveCat.Name = "averageAveCat";
            this.averageAveCat.Size = new System.Drawing.Size(166, 17);
            this.averageAveCat.TabIndex = 3;
            this.averageAveCat.Text = "Средний возраст котов : ";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(16, 346);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 45);
            this.label2.TabIndex = 4;
            this.label2.Text = "Количество владельцев, у которых больше 2 котов : ";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.Location = new System.Drawing.Point(205, 288);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(46, 29);
            this.textBox2.TabIndex = 5;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox3.Location = new System.Drawing.Point(205, 346);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(46, 29);
            this.textBox3.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 402);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.averageAveCat);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Cats";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
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
        private System.Windows.Forms.ToolStripMenuItem количестовКотовУКаждогоВладельцадиаграммаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem среднийВосрастКотовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem количествоВладельцевУКоторыхБольше2КотовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem кличкиКотовToolStripMenuItem;
        private System.Windows.Forms.Label averageAveCat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ToolStripMenuItem удалениеПоВведённымДаннымToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалениеПоОтмеченномуToolStripMenuItem;
    }
}

