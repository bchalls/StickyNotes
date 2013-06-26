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
    public partial class Note : Form
    {
        private bool drag;
        private Point startPos;
        private bool hidden;
        private Size oldSize;
        private bool onTop;
        private ThemeSettings tSettings;
        private HSLColor borderColor, titleColor;
        private Color bgColor, fontColor;
        private Font nFont;
        private int mOpacity;
        private Point startMouse, endMouse;
        private bool resize;

        public event addNoteHandler newNote;
        public event removeNoteHandler removeNote;

        public Note(Color gBGColor, Color gFontColor, Font f, int opaq, String[] tbText)
        {
            InitializeComponent();
            this.tSettings = new ThemeSettings(false);
            this.tSettings.Hide();
            this.tSettings.setColor += new setColorHandler(setColor);
            this.tSettings.setOpacity += new setOpaqHandler(setOpaque);
            this.tSettings.setFont += new setFontHandler(setFont);
            this.close.MouseEnter += new EventHandler(close_MouseEnter);
            this.close.MouseLeave += new EventHandler(close_MouseLeave);
            this.close.MouseClick += new MouseEventHandler(onMouseClick);            
            this.textBox.MouseClick += new MouseEventHandler(onMouseClick);
            this.titleLabel.MouseDoubleClick += new MouseEventHandler(title_MouseDoubleClick);
            this.titleLabel.MouseUp += new MouseEventHandler(title_MouseUp);
            this.titleLabel.MouseDown += new MouseEventHandler(title_MouseDown);
            this.titleLabel.MouseMove += new MouseEventHandler(title_MouseMove);
            drag = false;
            hidden = false;
            startPos = new Point(0, 0);
            oldSize = this.Size;
            titleLabel.Size = new Size(this.Size.Width - 15, 15);
            titleLabel.BringToFront();
            titleLabel.ContextMenuStrip = titleMenu;
            this.close.BringToFront();
            onTop = false;
            bgColor = gBGColor;
            titleColor = new HSLColor(bgColor);
            borderColor = new HSLColor(bgColor);
            fontColor = gFontColor;
            mOpacity = opaq; 
            setColor((int)bgColor.R, (int)bgColor.G, (int)bgColor.B, 1);
            setOpaque(mOpacity);
            nFont = f;
            this.textBox.Font = nFont;
            this.textBox.Lines = tbText;
            startMouse = new Point(0,0);
            endMouse = new Point(0,0);
            resize = false;
        }

        public String[] getText()
        {
            return textBox.Lines;
        }


        public int getOpacity()
        {
            return mOpacity;
        }

        public Font getFont()
        {
            return nFont;
        }

        public String colorToText(int choice)
        {
            if (choice == 1)
                return ("" + bgColor.R + "," + bgColor.G + "," + bgColor.B);
            else if (choice == 2)
                return ("" + fontColor.R + "," + fontColor.G + "," + fontColor.B);
            return ("" + bgColor.R + "," + bgColor.G + "," + bgColor.B);
        }

        void setFont(Font f)
        {
            nFont = f;
            this.textBox.Font = nFont;
            this.titleLabel.Font = nFont;
            this.textBox.ForeColor = fontColor;
            this.titleLabel.ForeColor = fontColor;
        }

        void setOpaque(int opaq)
        {
            if (opaq < 25)
                mOpacity = 25;
            else
                mOpacity = opaq;
            this.Opacity = (double) mOpacity / 100; //(255 * (opaq / 100));
        }

        void Note_Resize(object sender, EventArgs e)
        {
        }

        void setColor(int r, int g, int b, int caller)
        {
            if (caller == 1)
            {
                bgColor = Color.FromArgb(r, g, b);
                titleColor = new HSLColor(bgColor);
                titleColor.Saturation = titleColor.Saturation * 1.80;
                titleColor.Luminosity = titleColor.Luminosity * 0.90;
                borderColor = new HSLColor(bgColor);
                borderColor.Saturation = borderColor.Saturation * 0.80;
                borderColor.Luminosity = borderColor.Luminosity * 0.80;
                this.titleLabel.BackColor = (Color) titleColor;
                this.close.BackColor = (Color) titleColor;
                this.textBox.BackColor = bgColor;
                this.noteBackGround.BackColor = bgColor;
                this.LeftBorder.BackColor = (Color) borderColor;
                this.RightBorder.BackColor = (Color) borderColor;
                this.BottomBorder.BackColor = (Color) borderColor;
                this.TopBorder.BackColor = (Color) borderColor;
                this.TopBorder2.BackColor = (Color) borderColor;
            }
            if (caller == 2)
            {
                fontColor = Color.FromArgb(r, g, b);
                this.textBox.ForeColor = fontColor;
                this.titleLabel.ForeColor = fontColor;
            }
        }

        void  title_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Left))
                this.drag = false;
        }

        void  title_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Left))
            {
                this.drag = true;
                this.startPos = e.Location;
            }
            else if (e.Button.Equals(MouseButtons.Right))
            {
            }
        }

        void title_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.drag)
            {
                this.Location = new Point(this.PointToScreen(e.Location).X - this.startPos.X,
                    this.PointToScreen(e.Location).Y - this.startPos.Y);
            }
        }

        void close_MouseLeave(object sender, EventArgs e)
        {
            this.close.ForeColor = Color.Black;
        }
        void close_MouseEnter(object sender, EventArgs e)
        {
            this.close.ForeColor = Color.Orange;
        }

        void onMouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Right))
            {                    
            }
            else
            {
                if (sender.Equals(this.close))
                {
                    removeNote(this);
                    this.Close();
                }
            }
        }

        void title_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(e.Button.Equals(MouseButtons.Left))
            {
                if (this.hidden)
                {
                    this.textBox.Show();
                    this.Size = this.oldSize;
                    this.titleLabel.Text = "";
                }
                else
                {
                    if (this.textBox.Lines.Length == 0)
                        this.titleLabel.Text = "";
                    else
                        this.titleLabel.Text = this.textBox.Lines[0];
                    this.oldSize = this.Size;
                    this.textBox.Hide();
                    this.Size = new Size(this.Size.Width, 19);                   
                    
                }
                hidden = !hidden;
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            removeNote(this) ;
            this.Close();
        }

        private void setOnTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.onTop = !this.onTop;
            this.TopMost = this.onTop;
            
        }

        private void setThemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tSettings.setColorPreview((int) bgColor.R, (int)bgColor.G, (int)bgColor.B, 1);
            this.tSettings.setColorPreview((int)fontColor.R, (int)fontColor.G, (int)fontColor.B, 2);
            this.tSettings.setOpacitySlider(mOpacity);
            this.tSettings.setFontInfo(nFont);
            this.tSettings.Show();
        }

        private void copyThemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newNote(bgColor, fontColor, nFont, mOpacity, false, new String[0]);
        }

        private void globalThemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newNote(bgColor, fontColor, nFont, mOpacity, true, new String[0]);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                resize = true;
                startMouse = e.Location;
            }
            if (startMouse != e.Location)
            {
                
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                resize = false;
                endMouse = e.Location;
                this.Width += endMouse.X - startMouse.X;
                this.Height += endMouse.Y - startMouse.Y;
            }

        }

    }
}
