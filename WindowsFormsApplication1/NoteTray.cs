using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace StickyNotes
{
    public delegate void setColorHandler(int r, int g, int b, int caller);
    public delegate Color getColorHandler(int caller);
    public delegate void addNoteHandler(Color bColor, Color fColor, Font f, int opaq, bool defaultTheme, String[] text);
    public delegate void removeNoteHandler(Note sender);
    public delegate void setOpaqHandler(int opaq);
    public delegate void setFontHandler(Font fStyle);

    public partial class NoteTray : Form
    {
        private List<Note> noteList;
        private ThemeSettings tSettings;
        private Color fontColor, bgColor;
        private int mOpacity;
        private Font nFont;
        private FileInfo fileName;
        private FileStream notesFile;

        public NoteTray()
        {
            InitializeComponent();
            noteList = new List<Note>();
            this.bgColor = Color.LightGoldenrodYellow;
            this.fontColor = Color.Black;
            this.nFont = new Font("Perpetua", 9.75F);
            mOpacity = 100;
            fileName = new FileInfo("notes.sav");
            notesFile = fileName.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite);
            parseFile();
            notesFile.Close();
            fileName.Delete();
            if(noteList.Count == 0)
                newNote(bgColor, fontColor, nFont, mOpacity, true, new String[0]);
            this.tSettings = new ThemeSettings(true);
            this.tSettings.Hide();
            this.tSettings.setGlobalColor += new setColorHandler(setColor);
            this.tSettings.setGlobalOpacity += new setOpaqHandler(setOpacity);
            this.tSettings.setGlobalFont += new setFontHandler(setFont);
        }

        private void parseFile()
        {
            Color bg, fc;
            Font f;
            int opaq;
            FontStyle fStyle = FontStyle.Regular;
            StreamReader sr = new StreamReader(notesFile);
            int lines;
            String[] rgb;
            String curLine = sr.ReadLine(); //1st line declares global settings
            if (curLine != null)
            {
                curLine = sr.ReadLine(); // reads bgcolor line
                rgb = curLine.Split(',');
                bgColor = Color.FromArgb(Int32.Parse(rgb[0]), Int32.Parse(rgb[1]), Int32.Parse(rgb[2]));
                nFont = new Font(sr.ReadLine(), float.Parse(sr.ReadLine()));
                curLine = sr.ReadLine();
                if (!curLine.Contains("Regular"))
                {
                    if (curLine.Contains("Bold"))
                        fStyle |= FontStyle.Bold;
                    if (curLine.Contains("Italic"))
                        fStyle |= FontStyle.Italic;
                    if (curLine.Contains("Strikeout"))
                        fStyle |= FontStyle.Strikeout;
                    if (curLine.Contains("Underline"))
                        fStyle |= FontStyle.Underline;
                    nFont = new Font(nFont, fStyle);
                }
                curLine = sr.ReadLine();
                rgb = curLine.Split(',');
                fontColor = Color.FromArgb(Int32.Parse(rgb[0]), Int32.Parse(rgb[1]), Int32.Parse(rgb[2]));
                mOpacity = Int32.Parse(sr.ReadLine());
                curLine = sr.ReadLine();
                while (curLine != null)
                {
                    fStyle = FontStyle.Regular;
                    if (curLine.StartsWith("["))
                        curLine = sr.ReadLine();
                    rgb = curLine.Split(',');
                    bg = Color.FromArgb(Int32.Parse(rgb[0]), Int32.Parse(rgb[1]), Int32.Parse(rgb[2]));
                    f = new Font(sr.ReadLine(), float.Parse(sr.ReadLine()));
                    curLine = sr.ReadLine();
                    if (!curLine.Contains("Regular"))
                    {
                        if (curLine.Contains("Bold"))
                            fStyle |= FontStyle.Bold;
                        if (curLine.Contains("Italic"))
                            fStyle |= FontStyle.Italic;
                        if (curLine.Contains("Strikeout"))
                            fStyle |= FontStyle.Strikeout;
                        if (curLine.Contains("Underline"))
                            fStyle |= FontStyle.Underline;
                        f = new Font(nFont, fStyle);
                    }
                    else
                        fStyle = FontStyle.Regular;
                    curLine = sr.ReadLine();
                    rgb = curLine.Split(',');
                    fc = Color.FromArgb(Int32.Parse(rgb[0]), Int32.Parse(rgb[1]), Int32.Parse(rgb[2]));
                    opaq = Int32.Parse(sr.ReadLine());
                    lines = Int32.Parse(sr.ReadLine());
                    String[] t = new String[lines];
                    for (int i = 0; i < lines; i++)
                    {
                        t[i] = sr.ReadLine();
                    }
                    newNote(bg, fc, f, opaq, false, t);
                    curLine = sr.ReadLine();
                }

                //nFont.Style =
            }
        }

        void setOpacity(int opaq)
        {
            if (opaq < 25)
                mOpacity = 25;
            else
                mOpacity = opaq;
        }

        void setFont(Font f)
        {
            nFont = f;
        }

        private void newNote(Color bColor, Color fColor, Font f, int opaq, bool defaultTheme, String[] text)
        {
            Note temp;
            if(defaultTheme)
                temp = new Note(bgColor, fontColor, nFont, mOpacity, new String[0]);
            else
                temp = new Note(bColor, fColor, f, opaq, text);
            temp.Show();
            temp.newNote += new addNoteHandler(newNote);
            temp.removeNote += new removeNoteHandler(removeNote);
            noteList.Add(temp);
            this.trayIcon.Text = "# of Notes: " + noteList.Count +
                                 "\nSticky Notes!";
        }

        private void removeNote(Note sender)
        {
            noteList.Remove(sender);
            this.trayIcon.Text = "# of Notes: " + noteList.Count +
                                 "\nSticky Notes!";
        }

        private void setColor(int r, int g, int b, int caller)
        {
            if (caller == 1)
                bgColor = Color.FromArgb(r, g, b);
            if (caller == 2)
                fontColor = Color.FromArgb(r, g, b);
        }

        protected override void OnLoad(EventArgs e)
        {
            this.Visible = false;
            this.ShowInTaskbar = false;
            base.OnLoad(e);
        }

        private void newNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newNote(bgColor, fontColor, nFont, mOpacity, true, new String[0]);            
        }

        private void closeProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileName = new FileInfo("notes.sav");
            notesFile = fileName.Open(FileMode.Create, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(notesFile);
            sw.WriteLine("[Global Settings]");
            sw.WriteLine("" + bgColor.R + "," + bgColor.G + "," + bgColor.B); //bgColor
            sw.WriteLine("" + nFont.Name); //Font name
            sw.WriteLine("" + nFont.Size.ToString()); //Font size
            sw.WriteLine("" + nFont.Style.ToString()); //Font styles
            sw.WriteLine("" + fontColor.R + ", " + fontColor.G + ", " + fontColor.B); //fontColor
            sw.WriteLine("" + mOpacity); //mOpacity
            int num = 1;
            while(noteList.Count != 0)
            {
                sw.WriteLine("[Note #: " + num + "]");
                sw.WriteLine("" + noteList[0].colorToText(1));
                sw.WriteLine("" + noteList[0].getFont().Name);
                sw.WriteLine("" + noteList[0].getFont().Size.ToString());
                sw.WriteLine("" + noteList[0].getFont().Style.ToString());
                sw.WriteLine("" + noteList[0].colorToText(2));
                sw.WriteLine("" + noteList[0].getOpacity());
                sw.WriteLine(noteList[0].getText().Length.ToString());
                for( int i = 0; i < noteList[0].getText().Length; i++ )
                    sw.WriteLine(noteList[0].getText()[i]);
                noteList[0].Close();
                noteList.RemoveAt(0);
                num++;
            }
            sw.Close();
            notesFile.Close();
            Application.Exit();
        }

        private void globalSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tSettings.setColorPreview((int)bgColor.R, (int)bgColor.G, (int)bgColor.B, 1);
            this.tSettings.setColorPreview((int)fontColor.R, (int)fontColor.G, (int)fontColor.B, 2);
            this.tSettings.setOpacitySlider(mOpacity);
            this.tSettings.setFontInfo(nFont);
            this.tSettings.Show();
        }            
    }
}
