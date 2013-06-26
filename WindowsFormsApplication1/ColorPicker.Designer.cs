namespace StickyNotes
{
    partial class ColorPicker
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.redValue = new System.Windows.Forms.Label();
            this.greenValue = new System.Windows.Forms.Label();
            this.blueValue = new System.Windows.Forms.Label();
            this.colorPreview = new System.Windows.Forms.PictureBox();
            this.hexValue = new System.Windows.Forms.Label();
            this.blueSlider = new System.Windows.Forms.TrackBar();
            this.greenSlider = new System.Windows.Forms.TrackBar();
            this.redSlider = new System.Windows.Forms.TrackBar();
            this.invertColorButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.colorPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(271, 87);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(190, 87);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // redValue
            // 
            this.redValue.AutoSize = true;
            this.redValue.Location = new System.Drawing.Point(43, 9);
            this.redValue.Name = "redValue";
            this.redValue.Size = new System.Drawing.Size(39, 13);
            this.redValue.TabIndex = 5;
            this.redValue.Text = "Red: 0";
            // 
            // greenValue
            // 
            this.greenValue.AutoSize = true;
            this.greenValue.Location = new System.Drawing.Point(155, 9);
            this.greenValue.Name = "greenValue";
            this.greenValue.Size = new System.Drawing.Size(48, 13);
            this.greenValue.TabIndex = 6;
            this.greenValue.Text = "Green: 0";
            // 
            // blueValue
            // 
            this.blueValue.AutoSize = true;
            this.blueValue.Location = new System.Drawing.Point(268, 9);
            this.blueValue.Name = "blueValue";
            this.blueValue.Size = new System.Drawing.Size(40, 13);
            this.blueValue.TabIndex = 7;
            this.blueValue.Text = "Blue: 0";
            // 
            // colorPreview
            // 
            this.colorPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorPreview.Location = new System.Drawing.Point(12, 57);
            this.colorPreview.Name = "colorPreview";
            this.colorPreview.Size = new System.Drawing.Size(45, 45);
            this.colorPreview.TabIndex = 8;
            this.colorPreview.TabStop = false;
            // 
            // hexValue
            // 
            this.hexValue.AutoSize = true;
            this.hexValue.Location = new System.Drawing.Point(63, 87);
            this.hexValue.Name = "hexValue";
            this.hexValue.Size = new System.Drawing.Size(32, 13);
            this.hexValue.TabIndex = 9;
            this.hexValue.Text = "Hex: ";
            // 
            // blueSlider
            // 
            this.blueSlider.Location = new System.Drawing.Point(232, 25);
            this.blueSlider.Maximum = 255;
            this.blueSlider.Name = "blueSlider";
            this.blueSlider.Size = new System.Drawing.Size(104, 45);
            this.blueSlider.TabIndex = 3;
            this.blueSlider.Scroll += new System.EventHandler(this.blueSlider_Scroll);
            // 
            // greenSlider
            // 
            this.greenSlider.Location = new System.Drawing.Point(122, 25);
            this.greenSlider.Maximum = 255;
            this.greenSlider.Name = "greenSlider";
            this.greenSlider.Size = new System.Drawing.Size(104, 45);
            this.greenSlider.TabIndex = 2;
            this.greenSlider.Scroll += new System.EventHandler(this.greenSlider_Scroll);
            // 
            // redSlider
            // 
            this.redSlider.Location = new System.Drawing.Point(12, 25);
            this.redSlider.Maximum = 255;
            this.redSlider.Name = "redSlider";
            this.redSlider.Size = new System.Drawing.Size(104, 45);
            this.redSlider.TabIndex = 4;
            this.redSlider.Scroll += new System.EventHandler(this.redSlider_Scroll);
            // 
            // invertColorButton
            // 
            this.invertColorButton.Location = new System.Drawing.Point(271, 58);
            this.invertColorButton.Name = "invertColorButton";
            this.invertColorButton.Size = new System.Drawing.Size(75, 23);
            this.invertColorButton.TabIndex = 10;
            this.invertColorButton.Text = "Opposite";
            this.invertColorButton.UseVisualStyleBackColor = true;
            this.invertColorButton.Click += new System.EventHandler(this.invertColorButton_Click);
            // 
            // ColorPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 114);
            this.Controls.Add(this.invertColorButton);
            this.Controls.Add(this.hexValue);
            this.Controls.Add(this.colorPreview);
            this.Controls.Add(this.blueValue);
            this.Controls.Add(this.greenValue);
            this.Controls.Add(this.redValue);
            this.Controls.Add(this.redSlider);
            this.Controls.Add(this.blueSlider);
            this.Controls.Add(this.greenSlider);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ColorPicker";
            this.ShowInTaskbar = false;
            this.Text = "Color Picker";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.colorPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redSlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label redValue;
        private System.Windows.Forms.Label greenValue;
        private System.Windows.Forms.Label blueValue;
        private System.Windows.Forms.PictureBox colorPreview;
        private System.Windows.Forms.Label hexValue;
        private System.Windows.Forms.TrackBar blueSlider;
        private System.Windows.Forms.TrackBar greenSlider;
        private System.Windows.Forms.TrackBar redSlider;
        private System.Windows.Forms.Button invertColorButton;
    }
}