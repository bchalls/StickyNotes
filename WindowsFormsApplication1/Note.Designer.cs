namespace StickyNotes
{
    partial class Note
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Note));
            this.textBox = new System.Windows.Forms.TextBox();
            this.close = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.titleMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyThemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.globalThemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setThemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setOnTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TopBorder2 = new System.Windows.Forms.Label();
            this.TopBorder = new System.Windows.Forms.Label();
            this.LeftBorder = new System.Windows.Forms.Label();
            this.RightBorder = new System.Windows.Forms.Label();
            this.BottomBorder = new System.Windows.Forms.Label();
            this.noteBackGround = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.titleMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox.Location = new System.Drawing.Point(0, 22);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(241, 194);
            this.textBox.TabIndex = 0;
            // 
            // close
            // 
            this.close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.close.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close.ForeColor = System.Drawing.SystemColors.ControlText;
            this.close.Location = new System.Drawing.Point(226, 2);
            this.close.Margin = new System.Windows.Forms.Padding(0);
            this.close.MaximumSize = new System.Drawing.Size(15, 15);
            this.close.MinimumSize = new System.Drawing.Size(15, 15);
            this.close.Name = "close";
            this.close.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.close.Size = new System.Drawing.Size(15, 15);
            this.close.TabIndex = 2;
            this.close.Text = "X";
            this.close.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // titleLabel
            // 
            this.titleLabel.BackColor = System.Drawing.Color.Yellow;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.titleLabel.Location = new System.Drawing.Point(2, 2);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(0);
            this.titleLabel.MaximumSize = new System.Drawing.Size(500, 15);
            this.titleLabel.MinimumSize = new System.Drawing.Size(237, 15);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(237, 15);
            this.titleLabel.TabIndex = 3;
            // 
            // titleMenu
            // 
            this.titleMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNoteToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.titleMenu.Name = "titleMenu";
            this.titleMenu.Size = new System.Drawing.Size(126, 70);
            // 
            // addNoteToolStripMenuItem
            // 
            this.addNoteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyThemeToolStripMenuItem,
            this.globalThemeToolStripMenuItem});
            this.addNoteToolStripMenuItem.Name = "addNoteToolStripMenuItem";
            this.addNoteToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.addNoteToolStripMenuItem.Text = "Add Note";
            // 
            // copyThemeToolStripMenuItem
            // 
            this.copyThemeToolStripMenuItem.Name = "copyThemeToolStripMenuItem";
            this.copyThemeToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.copyThemeToolStripMenuItem.Text = "Copy Theme";
            this.copyThemeToolStripMenuItem.Click += new System.EventHandler(this.copyThemeToolStripMenuItem_Click);
            // 
            // globalThemeToolStripMenuItem
            // 
            this.globalThemeToolStripMenuItem.Name = "globalThemeToolStripMenuItem";
            this.globalThemeToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.globalThemeToolStripMenuItem.Text = "Global Theme";
            this.globalThemeToolStripMenuItem.Click += new System.EventHandler(this.globalThemeToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setThemeToolStripMenuItem,
            this.setOnTopToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // setThemeToolStripMenuItem
            // 
            this.setThemeToolStripMenuItem.Name = "setThemeToolStripMenuItem";
            this.setThemeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.setThemeToolStripMenuItem.Text = "Set Theme";
            this.setThemeToolStripMenuItem.Click += new System.EventHandler(this.setThemeToolStripMenuItem_Click);
            // 
            // setOnTopToolStripMenuItem
            // 
            this.setOnTopToolStripMenuItem.CheckOnClick = true;
            this.setOnTopToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.setOnTopToolStripMenuItem.Name = "setOnTopToolStripMenuItem";
            this.setOnTopToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.setOnTopToolStripMenuItem.Text = "Always on Top";
            this.setOnTopToolStripMenuItem.ToolTipText = "If turned on, the note will always be the top-most window";
            this.setOnTopToolStripMenuItem.Click += new System.EventHandler(this.setOnTopToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // TopBorder2
            // 
            this.TopBorder2.BackColor = System.Drawing.Color.Red;
            this.TopBorder2.Location = new System.Drawing.Point(0, 17);
            this.TopBorder2.Name = "TopBorder2";
            this.TopBorder2.Size = new System.Drawing.Size(241, 2);
            this.TopBorder2.TabIndex = 4;
            // 
            // TopBorder
            // 
            this.TopBorder.BackColor = System.Drawing.Color.Red;
            this.TopBorder.Location = new System.Drawing.Point(0, 0);
            this.TopBorder.Name = "TopBorder";
            this.TopBorder.Size = new System.Drawing.Size(241, 2);
            this.TopBorder.TabIndex = 5;
            // 
            // LeftBorder
            // 
            this.LeftBorder.BackColor = System.Drawing.Color.Red;
            this.LeftBorder.Location = new System.Drawing.Point(0, 0);
            this.LeftBorder.Name = "LeftBorder";
            this.LeftBorder.Size = new System.Drawing.Size(2, 216);
            this.LeftBorder.TabIndex = 6;
            // 
            // RightBorder
            // 
            this.RightBorder.BackColor = System.Drawing.Color.Red;
            this.RightBorder.Location = new System.Drawing.Point(239, 0);
            this.RightBorder.Name = "RightBorder";
            this.RightBorder.Size = new System.Drawing.Size(2, 216);
            this.RightBorder.TabIndex = 7;
            // 
            // BottomBorder
            // 
            this.BottomBorder.BackColor = System.Drawing.Color.Red;
            this.BottomBorder.Location = new System.Drawing.Point(0, 214);
            this.BottomBorder.Name = "BottomBorder";
            this.BottomBorder.Size = new System.Drawing.Size(241, 2);
            this.BottomBorder.TabIndex = 8;
            // 
            // noteBackGround
            // 
            this.noteBackGround.Location = new System.Drawing.Point(0, 0);
            this.noteBackGround.Name = "noteBackGround";
            this.noteBackGround.Size = new System.Drawing.Size(241, 216);
            this.noteBackGround.TabIndex = 9;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(226, 201);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(13, 13);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // Note
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(241, 216);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.BottomBorder);
            this.Controls.Add(this.RightBorder);
            this.Controls.Add(this.LeftBorder);
            this.Controls.Add(this.TopBorder);
            this.Controls.Add(this.TopBorder2);
            this.Controls.Add(this.close);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.noteBackGround);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Note";
            this.ShowInTaskbar = false;
            this.Text = "Note";
            this.TransparencyKey = System.Drawing.SystemColors.InactiveBorder;
            this.titleMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Label close;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.ContextMenuStrip titleMenu;
        private System.Windows.Forms.ToolStripMenuItem addNoteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setThemeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setOnTopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyThemeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem globalThemeToolStripMenuItem;
        private System.Windows.Forms.Label TopBorder2;
        private System.Windows.Forms.Label TopBorder;
        private System.Windows.Forms.Label LeftBorder;
        private System.Windows.Forms.Label RightBorder;
        private System.Windows.Forms.Label BottomBorder;
        private System.Windows.Forms.Label noteBackGround;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

