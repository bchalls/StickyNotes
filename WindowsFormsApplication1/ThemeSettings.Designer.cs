namespace StickyNotes
{
    partial class ThemeSettings
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
            this.noteTexture = new System.Windows.Forms.PictureBox();
            this.fontColor = new System.Windows.Forms.PictureBox();
            this.noteColor = new System.Windows.Forms.PictureBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.fontInfo = new System.Windows.Forms.Label();
            this.fontLabel = new System.Windows.Forms.Label();
            this.textureLabel = new System.Windows.Forms.Label();
            this.colorLabel = new System.Windows.Forms.Label();
            this.infoLabel = new System.Windows.Forms.Label();
            this.OpacitySlider = new System.Windows.Forms.TrackBar();
            this.OpacityLabel = new System.Windows.Forms.Label();
            this.fontPicker = new System.Windows.Forms.FontDialog();
            ((System.ComponentModel.ISupportInitialize)(this.noteTexture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.noteColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OpacitySlider)).BeginInit();
            this.SuspendLayout();
            // 
            // noteTexture
            // 
            this.noteTexture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.noteTexture.Location = new System.Drawing.Point(12, 69);
            this.noteTexture.Name = "noteTexture";
            this.noteTexture.Size = new System.Drawing.Size(156, 25);
            this.noteTexture.TabIndex = 0;
            this.noteTexture.TabStop = false;
            // 
            // fontColor
            // 
            this.fontColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fontColor.Location = new System.Drawing.Point(12, 113);
            this.fontColor.Name = "fontColor";
            this.fontColor.Size = new System.Drawing.Size(156, 25);
            this.fontColor.TabIndex = 1;
            this.fontColor.TabStop = false;
            this.fontColor.DoubleClick += new System.EventHandler(this.fontColor_DoubleClick);
            // 
            // noteColor
            // 
            this.noteColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.noteColor.Location = new System.Drawing.Point(12, 25);
            this.noteColor.Name = "noteColor";
            this.noteColor.Size = new System.Drawing.Size(156, 25);
            this.noteColor.TabIndex = 2;
            this.noteColor.TabStop = false;
            this.noteColor.DoubleClick += new System.EventHandler(this.noteColor_DoubleClick);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(12, 274);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(93, 274);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // fontInfo
            // 
            this.fontInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fontInfo.Location = new System.Drawing.Point(12, 141);
            this.fontInfo.Name = "fontInfo";
            this.fontInfo.Size = new System.Drawing.Size(156, 41);
            this.fontInfo.TabIndex = 5;
            this.fontInfo.Text = "Font:\r\nSize:\r\nEffects:";
            this.fontInfo.DoubleClick += new System.EventHandler(this.fontInfo_DoubleClick);
            // 
            // fontLabel
            // 
            this.fontLabel.AutoSize = true;
            this.fontLabel.Location = new System.Drawing.Point(64, 97);
            this.fontLabel.Name = "fontLabel";
            this.fontLabel.Size = new System.Drawing.Size(55, 13);
            this.fontLabel.TabIndex = 6;
            this.fontLabel.Text = "Font Color\r\n";
            // 
            // textureLabel
            // 
            this.textureLabel.AutoSize = true;
            this.textureLabel.Location = new System.Drawing.Point(56, 53);
            this.textureLabel.Name = "textureLabel";
            this.textureLabel.Size = new System.Drawing.Size(69, 13);
            this.textureLabel.TabIndex = 7;
            this.textureLabel.Text = "Note Texture";
            // 
            // colorLabel
            // 
            this.colorLabel.AutoSize = true;
            this.colorLabel.Location = new System.Drawing.Point(64, 9);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Size = new System.Drawing.Size(57, 13);
            this.colorLabel.TabIndex = 8;
            this.colorLabel.Text = "Note Color";
            // 
            // infoLabel
            // 
            this.infoLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.infoLabel.Location = new System.Drawing.Point(12, 249);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(156, 22);
            this.infoLabel.TabIndex = 9;
            this.infoLabel.Text = "Double click a box to change it";
            this.infoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OpacitySlider
            // 
            this.OpacitySlider.Location = new System.Drawing.Point(12, 201);
            this.OpacitySlider.Maximum = 100;
            this.OpacitySlider.Name = "OpacitySlider";
            this.OpacitySlider.Size = new System.Drawing.Size(156, 45);
            this.OpacitySlider.TabIndex = 10;
            this.OpacitySlider.Value = 100;
            this.OpacitySlider.Scroll += new System.EventHandler(this.OpacitySlider_Scroll);
            // 
            // OpacityLabel
            // 
            this.OpacityLabel.AutoSize = true;
            this.OpacityLabel.Location = new System.Drawing.Point(56, 185);
            this.OpacityLabel.Name = "OpacityLabel";
            this.OpacityLabel.Size = new System.Drawing.Size(75, 13);
            this.OpacityLabel.TabIndex = 11;
            this.OpacityLabel.Text = "Opacity: 100%";
            // 
            // fontPicker
            // 
            this.fontPicker.ShowApply = true;
            this.fontPicker.Apply += new System.EventHandler(this.fontPick_ApplyClick);
            // 
            // ThemeSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(180, 301);
            this.Controls.Add(this.OpacityLabel);
            this.Controls.Add(this.OpacitySlider);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.colorLabel);
            this.Controls.Add(this.textureLabel);
            this.Controls.Add(this.fontLabel);
            this.Controls.Add(this.fontInfo);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.noteColor);
            this.Controls.Add(this.fontColor);
            this.Controls.Add(this.noteTexture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ThemeSettings";
            this.ShowInTaskbar = false;
            this.Text = "Theme Settings";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.noteTexture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.noteColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OpacitySlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox noteTexture;
        private System.Windows.Forms.PictureBox fontColor;
        private System.Windows.Forms.PictureBox noteColor;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label fontInfo;
        private System.Windows.Forms.Label fontLabel;
        private System.Windows.Forms.Label textureLabel;
        private System.Windows.Forms.Label colorLabel;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.TrackBar OpacitySlider;
        private System.Windows.Forms.Label OpacityLabel;
        private System.Windows.Forms.FontDialog fontPicker;
    }
}