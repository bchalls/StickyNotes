using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StickyNotes
{
    public partial class ColorPicker : Form
    {
        private char[] hexString;
        private String redString, blueString, greenString; 
        private int caller;

        public event setColorHandler setColorPreview;
        public event getColorHandler getColor;

        public ColorPicker()
        {
            InitializeComponent();
            hexString = "0123456789ABCDEF".ToCharArray();
            redString = "00";
            blueString = "00";
            greenString = "00";
            caller = 0;
        }

        public void setCaller(int call){ caller = call; }

        public void setRGB(int r, int g, int b)
        {
            this.redSlider.Value = r;
            this.redValue.Text = "Red: " + this.redSlider.Value;
            this.greenSlider.Value = g;
            this.greenValue.Text = "Green: " + this.greenSlider.Value;
            this.blueSlider.Value = b;
            this.blueValue.Text = "Blue: " + this.blueSlider.Value;
            this.colorPreview.BackColor = Color.FromArgb(this.redSlider.Value, this.greenSlider.Value, this.blueSlider.Value);
        }

        private void redSlider_Scroll(object sender, EventArgs e)
        {
            this.redValue.Text = "Red: " + this.redSlider.Value;
            this.redString = this.hexString[((this.redSlider.Value-this.redSlider.Value%16)/16)].ToString() 
                + this.hexString[(this.redSlider.Value%16)].ToString();
            this.hexValue.Text = "Hex: " + this.redString + this.greenString + this.blueString;
            this.colorPreview.BackColor = Color.FromArgb(this.redSlider.Value, this.greenSlider.Value, this.blueSlider.Value);
        }

        private void greenSlider_Scroll(object sender, EventArgs e)
        {
            this.greenValue.Text = "Green: " + this.greenSlider.Value;
            this.greenString = this.hexString[((this.greenSlider.Value - this.greenSlider.Value % 16) / 16)].ToString()
                + this.hexString[(this.greenSlider.Value % 16)].ToString();
            this.hexValue.Text = "Hex: " + this.redString + this.greenString + this.blueString;
            this.colorPreview.BackColor = Color.FromArgb(this.redSlider.Value, this.greenSlider.Value, this.blueSlider.Value);
        }

        private void blueSlider_Scroll(object sender, EventArgs e)
        {
            this.blueValue.Text = "Blue: " + this.blueSlider.Value;
            this.blueString = this.hexString[((this.blueSlider.Value - this.blueSlider.Value % 16) / 16)].ToString()
                + this.hexString[(this.blueSlider.Value % 16)].ToString();
            this.hexValue.Text = "Hex: " + this.redString + this.greenString + this.blueString;
            this.colorPreview.BackColor = Color.FromArgb(this.redSlider.Value, this.greenSlider.Value, this.blueSlider.Value);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            setColorPreview(this.redSlider.Value, this.greenSlider.Value, this.blueSlider.Value, caller );
            this.Hide();
        }

        private void invertColorButton_Click(object sender, EventArgs e)
        {
            if (caller == 1)
                setRGB(255 - getColor(2).R, 255 - getColor(2).G, 255 - getColor(2).B);
            if (caller == 2)
                setRGB(255 - getColor(1).R, 255 - getColor(1).G, 255 - getColor(1).B);
        }
            

    }
}
