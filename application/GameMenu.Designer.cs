namespace Algebros.Application
{
    partial class GameMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameMenu));
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tbDifficulty = new System.Windows.Forms.TrackBar();
            this.tbTimeper = new System.Windows.Forms.TrackBar();
            this.tbNumq = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbDifficulty = new System.Windows.Forms.Label();
            this.lbTimeper = new System.Windows.Forms.Label();
            this.lbNumq = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbDifficulty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTimeper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbNumq)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Maroon;
            this.button1.Location = new System.Drawing.Point(718, 672);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(254, 34);
            this.button1.TabIndex = 0;
            this.button1.Text = "Launch";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel1.Location = new System.Drawing.Point(30, 525);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(943, 128);
            this.panel1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33444F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33445F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.tbDifficulty, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbTimeper, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbNumq, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbDifficulty, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbTimeper, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbNumq, 2, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(24);
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(943, 128);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tbDifficulty
            // 
            this.tbDifficulty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDifficulty.LargeChange = 1;
            this.tbDifficulty.Location = new System.Drawing.Point(27, 53);
            this.tbDifficulty.Maximum = 3;
            this.tbDifficulty.Minimum = 1;
            this.tbDifficulty.Name = "tbDifficulty";
            this.tbDifficulty.Size = new System.Drawing.Size(292, 20);
            this.tbDifficulty.TabIndex = 0;
            this.tbDifficulty.Value = 2;
            this.tbDifficulty.Scroll += new System.EventHandler(this.tbDifficulty_Scroll);
            // 
            // tbTimeper
            // 
            this.tbTimeper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbTimeper.LargeChange = 10;
            this.tbTimeper.Location = new System.Drawing.Point(325, 53);
            this.tbTimeper.Maximum = 60;
            this.tbTimeper.Minimum = 1;
            this.tbTimeper.Name = "tbTimeper";
            this.tbTimeper.Size = new System.Drawing.Size(292, 20);
            this.tbTimeper.SmallChange = 5;
            this.tbTimeper.TabIndex = 1;
            this.tbTimeper.TickFrequency = 5;
            this.tbTimeper.Value = 20;
            this.tbTimeper.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // tbNumq
            // 
            this.tbNumq.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbNumq.Location = new System.Drawing.Point(623, 53);
            this.tbNumq.Maximum = 100;
            this.tbNumq.Minimum = 1;
            this.tbNumq.Name = "tbNumq";
            this.tbNumq.Size = new System.Drawing.Size(293, 20);
            this.tbNumq.TabIndex = 2;
            this.tbNumq.TickFrequency = 10;
            this.tbNumq.Value = 30;
            this.tbNumq.Scroll += new System.EventHandler(this.trackBar3_Scroll);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "question difficulty";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(325, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(292, 26);
            this.label2.TabIndex = 4;
            this.label2.Text = "time  per problem";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(623, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(293, 26);
            this.label3.TabIndex = 5;
            this.label3.Text = "number of questions";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbDifficulty
            // 
            this.lbDifficulty.AutoSize = true;
            this.lbDifficulty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbDifficulty.Location = new System.Drawing.Point(27, 76);
            this.lbDifficulty.Name = "lbDifficulty";
            this.lbDifficulty.Size = new System.Drawing.Size(292, 28);
            this.lbDifficulty.TabIndex = 6;
            this.lbDifficulty.Text = "??";
            this.lbDifficulty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTimeper
            // 
            this.lbTimeper.AutoSize = true;
            this.lbTimeper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTimeper.Location = new System.Drawing.Point(325, 76);
            this.lbTimeper.Name = "lbTimeper";
            this.lbTimeper.Size = new System.Drawing.Size(292, 28);
            this.lbTimeper.TabIndex = 7;
            this.lbTimeper.Text = "??";
            this.lbTimeper.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbNumq
            // 
            this.lbNumq.AutoSize = true;
            this.lbNumq.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbNumq.Location = new System.Drawing.Point(623, 76);
            this.lbNumq.Name = "lbNumq";
            this.lbNumq.Size = new System.Drawing.Size(293, 28);
            this.lbNumq.TabIndex = 8;
            this.lbNumq.Text = "??";
            this.lbNumq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GameMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = Algebros.Application.Properties.Resources.gamebg;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GameMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Algebros";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameMenu_FormClosing);
            this.Load += new System.EventHandler(this.GameMenu_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbDifficulty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTimeper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbNumq)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TrackBar tbDifficulty;
        private System.Windows.Forms.TrackBar tbTimeper;
        private System.Windows.Forms.TrackBar tbNumq;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbDifficulty;
        private System.Windows.Forms.Label lbTimeper;
        private System.Windows.Forms.Label lbNumq;
    }
}