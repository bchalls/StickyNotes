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
    public partial class ThemeSettings : Form
    {
        public event setColorHandler setColor;
        public event setColorHandler setGlobalColor;
        public event setOpaqHandler setOpacity;
        public event setOpaqHandler setGlobalOpacity;
        public event setFontHandler setFont;
        public event setFontHandler setGlobalFont;


        private ColorPicker cPicker;
        private bool global;
        private Font nFont;

        public ThemeSettings(bool isGlobal)
        {
            InitializeComponent();
            this.cPicker = new ColorPicker();
            this.cPicker.Hide();
            this.cPicker.setColorPreview += new setColorHandler(setColorPreview);
            this.cPicker.getColor += new getColorHandler(getColor);
            global = isGlobal;
        }

        public void setFontInfo(Font f)
        {
            nFont = f;
            this.fontInfo.Text = "Font: " + f.Name +
                                 "\nSize: " + f.Size.ToString() +
                                 "\nEffects: " + f.Style.ToString();
        }

        public Color getColor(int caller)
        {
            if (caller == 1)
                return this.noteColor.BackColor;
            else if(caller == 2)
                return this.fontColor.BackColor;
            return this.noteColor.BackColor;
        }

        /*
         * Function: setColorPreview
         * Params: int r,g,b - red, green, and blue values for color
         * int caller - tells it which preview to set
         * 1 = Note Color
         * 2 = Font Color
         */
        public void setColorPreview(int r, int g, int b, int caller)
        {
            if (caller == 1)
                this.noteColor.BackColor = Color.FromArgb(r, g, b);
            if (caller == 2)
                this.fontColor.BackColor = Color.FromArgb(r, g, b);
        }

        public void setOpacitySlider(int opaq)
        {
            this.OpacitySlider.Value = opaq;
            this.OpacityLabel.Text = "Opacity: " + this.OpacitySlider.Value.ToString() + "%";
        }

        private void noteColor_DoubleClick(object sender, EventArgs e)
        {
            this.cPicker.setRGB((int)this.noteColor.BackColor.R, (int)this.noteColor.BackColor.G,
                (int)this.noteColor.BackColor.B);
            this.cPicker.setCaller(1);
            this.cPicker.Show();
        }

        private void fontColor_DoubleClick(object sender, EventArgs e)
        {
            this.cPicker.setRGB((int)this.fontColor.BackColor.R, (int)this.fontColor.BackColor.G,
                (int)this.fontColor.BackColor.B);
            this.cPicker.setCaller(2);
            this.cPicker.Show();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (global)
            {
                setGlobalColor((int)this.noteColor.BackColor.R, (int)this.noteColor.BackColor.G,
                    (int)this.noteColor.BackColor.B, 1);
                setGlobalColor((int)this.fontColor.BackColor.R, (int)this.fontColor.BackColor.G,
                    (int)this.fontColor.BackColor.B, 2);
                setGlobalOpacity(this.OpacitySlider.Value);
                setGlobalFont(this.nFont);
            }
            else
            {
                setColor((int)this.noteColor.BackColor.R, (int)this.noteColor.BackColor.G,
                    (int)this.noteColor.BackColor.B, 1);
                setColor((int)this.fontColor.BackColor.R, (int)this.fontColor.BackColor.G,
                    (int)this.fontColor.BackColor.B, 2);
                setOpacity(this.OpacitySlider.Value);
                setFont(this.nFont);
            }
            this.Hide();
        }

        private void OpacitySlider_Scroll(object sender, EventArgs e)
        {
            this.OpacityLabel.Text = "Opacity: " + this.OpacitySlider.Value.ToString() + "%";
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void fontInfo_DoubleClick(object sender, EventArgs e)
        {
            this.fontPicker.Font = nFont;
            this.fontPicker.ShowDialog();
        }

        private void fontPick_ApplyClick(object sender, EventArgs e)
        {
            nFont = this.fontPicker.Font;
            setFontInfo(nFont);
        }
    }
}
