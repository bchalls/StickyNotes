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
    public partial class NewNote : Form
    {
        private ThemeSettings tSettings;

        public NewNote()
        {
            InitializeComponent();
            tSettings = new ThemeSettings(false);
        }
    }
}
