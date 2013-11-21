namespace Parking
{
    partial class ParkingForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
            scene.Dispose();
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.start = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.status = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.fpsLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.stop = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.mapSizeBox = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizeSceneControl1 = new Parking.VisualizeSceneControl();
            this.оСистемеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оРазработчикахToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.status.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(321, 27);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(75, 23);
            this.start.TabIndex = 0;
            this.start.Text = "Старт";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(622, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Денег в кассе:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(712, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.fpsLabel});
            this.status.Location = new System.Drawing.Point(0, 749);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(824, 22);
            this.status.TabIndex = 6;
            this.status.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(26, 17);
            this.toolStripStatusLabel1.Text = "fps:";
            // 
            // fpsLabel
            // 
            this.fpsLabel.Name = "fpsLabel";
            this.fpsLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(402, 27);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(75, 23);
            this.stop.TabIndex = 7;
            this.stop.Text = "Стоп";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Карта:";
            // 
            // mapSizeBox
            // 
            this.mapSizeBox.FormattingEnabled = true;
            this.mapSizeBox.Location = new System.Drawing.Point(71, 29);
            this.mapSizeBox.Name = "mapSizeBox";
            this.mapSizeBox.Size = new System.Drawing.Size(121, 21);
            this.mapSizeBox.TabIndex = 9;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(824, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.файлToolStripMenuItem.Text = "Настройка";
            this.файлToolStripMenuItem.Click += new System.EventHandler(this.файлToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оСистемеToolStripMenuItem,
            this.оРазработчикахToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // visualizeSceneControl1
            // 
            this.visualizeSceneControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.visualizeSceneControl1.Location = new System.Drawing.Point(12, 57);
            this.visualizeSceneControl1.Name = "visualizeSceneControl1";
            this.visualizeSceneControl1.Scene = null;
            this.visualizeSceneControl1.Size = new System.Drawing.Size(800, 700);
            this.visualizeSceneControl1.State = Parking.VisualizeSceneControl.VisualizeState.Stopped;
            this.visualizeSceneControl1.TabIndex = 3;
            // 
            // оСистемеToolStripMenuItem
            // 
            this.оСистемеToolStripMenuItem.Name = "оСистемеToolStripMenuItem";
            this.оСистемеToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.оСистемеToolStripMenuItem.Text = "О системе";
            // 
            // оРазработчикахToolStripMenuItem
            // 
            this.оРазработчикахToolStripMenuItem.Name = "оРазработчикахToolStripMenuItem";
            this.оРазработчикахToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.оРазработчикахToolStripMenuItem.Text = "О разработчиках";
            // 
            // ParkingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 771);
            this.Controls.Add(this.mapSizeBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.status);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.visualizeSceneControl1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.start);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ParkingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Парковка";
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private VisualizeSceneControl visualizeSceneControl1;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel fpsLabel;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox mapSizeBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оСистемеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оРазработчикахToolStripMenuItem;
    }
}

