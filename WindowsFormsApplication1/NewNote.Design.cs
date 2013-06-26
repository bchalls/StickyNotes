using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace StickyNotes
{
    public partial class NewNote
    {
        // Variables
        private SolidBrush backBrush, borderBrush, fontBrush;
        private int formOpacity;

        private void InitializeComponent()
        {
            formOpacity = 100;
            backBrush = new SolidBrush(Color.FromArgb(255, 255, 255, 192));
            borderBrush = new SolidBrush(Color.FromArgb(220, backBrush.Color));
            fontBrush = new SolidBrush(Color.Black);
            //this.HScroll = false;
            //this.VScroll = false;
            this.Size = new Size(241, 216);
            AddPaintHandlers(this);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                if (!this.DesignMode)
                    cp.ExStyle |= NativeMethods.WS_EX_LAYERED;
                return cp;
            }
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();
            //Disable VisualStyles as we're doing all painting ourselves.
            if (OSFeature.Feature.IsPresent(OSFeature.Themes))
                NativeMethods.SetWindowTheme(this.Handle, null, "");
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.Created)
                UpdateWindow();
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);
            if (this.Created)
                UpdateWindow();
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (this.Visible)
                UpdateWindow();
        }

        protected override void OnScroll(ScrollEventArgs se)
        {
            base.OnScroll(se);
            if (this.Created)
                this.UpdateWindow();
        }

        private void AddPaintHandlers(Control control)
        {
            foreach (Control ctl in control.Controls)
            {
                ctl.MouseEnter += new EventHandler(ctl_Paint);
                ctl.MouseLeave += new EventHandler(ctl_Paint);
                ctl.MouseDown += new MouseEventHandler(ctl_Paint);
                ctl.MouseUp += new MouseEventHandler(ctl_Paint);
                ctl.MouseMove += new MouseEventHandler(ctl_Paint);
                AddPaintHandlers(ctl);
            }
        }

        private void ctl_Paint(object sender, EventArgs e)
        {
            this.UpdateWindow();
        }
        public void UpdateWindow()
        {
            if (this.IsDisposed || this.Width <= 0 || this.Height <= 0)
                return;

            using (Bitmap backBuffer = new Bitmap(this.Width, this.Height, PixelFormat.Format32bppPArgb))
            {
                using (Graphics gr = Graphics.FromImage(backBuffer))
                {
                    gr.SmoothingMode = SmoothingMode.AntiAlias;

                    Point pt = this.PointToScreen(Point.Empty);
                    pt.Offset(-this.Left, -this.Top);
                    Rectangle rc = this.RectangleToScreen(this.ClientRectangle);
                    rc.Offset(-this.Left, -this.Top);

                    if (this.ClientSize.Width > 0 && this.ClientSize.Height > 0)
                    {
                        //Paint the ClientArea
                        gr.FillRectangle(backBrush, rc);

                        //Allow for AutoScroll behaviour
                        using (Bitmap clientBuffer = new Bitmap(this.DisplayRectangle.Width, this.DisplayRectangle.Height, PixelFormat.Format32bppPArgb))
                        {
                            Point pos = this.AutoScrollPosition;
                            //Paint the Controls
                            foreach (Control ctl in this.Controls)
                            {
                                Rectangle rcCtl = ctl.Bounds;
                                rcCtl.Offset(-pos.X, -pos.Y);
                                ctl.DrawToBitmap(clientBuffer, rcCtl);
                            }
                            gr.DrawImage(clientBuffer, new Rectangle(rc.Location, this.ClientSize), new Rectangle(new Point(-pos.X, -pos.Y), this.ClientSize), GraphicsUnit.Pixel);
                        }
                    }

                    //Paint the NonClientArea
                    gr.SetClip(rc, CombineMode.Exclude);

                    gr.FillPath(backBrush, this.CreateFormShape());

                    if (this.WindowState != FormWindowState.Minimized)
                    {
                        using (Font scrollFont = new Font("Marlett", SystemInformation.VerticalScrollBarArrowHeight, FontStyle.Regular, GraphicsUnit.Pixel))
                        {
                            using (StringFormat sf = new StringFormat())
                            {
                                sf.Alignment = StringAlignment.Center;
                                sf.LineAlignment = StringAlignment.Center;

                                //Paint any scrollbars
                                if (this.HScroll)
                                {
                                    Rectangle hScrollRect = this.RectangleToScreen(new Rectangle(0, this.ClientSize.Height, this.ClientSize.Width, SystemInformation.HorizontalScrollBarHeight));
                                    hScrollRect.Offset(-this.Left, -this.Top);
                                    gr.FillRectangle(Brushes.Aqua, hScrollRect);

                                    Rectangle thumbRect = new Rectangle(hScrollRect.X, hScrollRect.Y, hScrollRect.Height, hScrollRect.Height);
                                    gr.FillRectangle(Brushes.Green, thumbRect);
                                    gr.DrawString("3", scrollFont, Brushes.White, thumbRect);

                                    NativeMethods.SCROLLBARINFO sbi = new NativeMethods.SCROLLBARINFO();
                                    sbi.cbSize = Marshal.SizeOf(sbi);
                                    bool rslt = NativeMethods.GetScrollBarInfo(this.Handle, NativeMethods.OBJID_HSCROLL, ref sbi);

                                    thumbRect = this.RectangleToScreen(Rectangle.FromLTRB(sbi.xyThumbTop, this.ClientRectangle.Bottom + 1, sbi.xyThumbBottom, this.ClientRectangle.Bottom + hScrollRect.Height + 1));
                                    thumbRect.Offset(-this.Left, -this.Top);
                                    gr.FillRectangle(Brushes.Red, thumbRect);

                                    thumbRect = new Rectangle(hScrollRect.Right - hScrollRect.Height, hScrollRect.Y, hScrollRect.Height, hScrollRect.Height);
                                    gr.FillRectangle(Brushes.Green, thumbRect);
                                    gr.DrawString("4", scrollFont, Brushes.White, thumbRect);
                                }

                                if (this.VScroll)
                                {
                                    Rectangle vScrollRect = this.RectangleToScreen(new Rectangle(this.ClientSize.Width, 0, SystemInformation.VerticalScrollBarWidth, this.ClientSize.Height));
                                    vScrollRect.Offset(-this.Left, -this.Top);
                                    gr.FillRectangle(Brushes.Aqua, vScrollRect);
                                    Rectangle thumbRect = new Rectangle(vScrollRect.X, vScrollRect.Y, vScrollRect.Width, vScrollRect.Width);
                                    gr.FillRectangle(Brushes.Green, thumbRect);
                                    gr.DrawString("5", scrollFont, Brushes.White, thumbRect);

                                    NativeMethods.SCROLLBARINFO sbi = new NativeMethods.SCROLLBARINFO();
                                    sbi.cbSize = Marshal.SizeOf(sbi);
                                    bool rslt = NativeMethods.GetScrollBarInfo(this.Handle, NativeMethods.OBJID_VSCROLL, ref sbi);

                                    thumbRect = this.RectangleToScreen(Rectangle.FromLTRB(this.ClientRectangle.Right + 1, sbi.xyThumbTop, this.ClientRectangle.Right + vScrollRect.Width + 1, sbi.xyThumbBottom));
                                    thumbRect.Offset(-this.Left, -this.Top);
                                    gr.FillRectangle(Brushes.Red, thumbRect);

                                    thumbRect = new Rectangle(vScrollRect.X, vScrollRect.Bottom - vScrollRect.Width, vScrollRect.Width, vScrollRect.Width);
                                    gr.FillRectangle(Brushes.Green, thumbRect);
                                    gr.DrawString("6", scrollFont, Brushes.White, thumbRect);
                                }

                                //Paint the borders
                                Size hBorderSize = new Size(this.Width, 2);
                                Size vBorderSize = new Size(2, this.Height);
                                Rectangle borderRect = new Rectangle(new Point(0, 0), hBorderSize);
                                gr.FillRectangle(borderBrush, borderRect);
                                borderRect = new Rectangle(new Point(0, 17), hBorderSize);
                                gr.FillRectangle(Brushes.Aqua, borderRect);
                                borderRect = new Rectangle(new Point(0, this.Height - 2), hBorderSize);
                                gr.FillRectangle(Brushes.Aqua, borderRect);
                                borderRect = new Rectangle(new Point(0, 0), vBorderSize);
                                gr.FillRectangle(Brushes.Aqua, borderRect);
                                borderRect = new Rectangle(new Point(this.Width - 2, 0), vBorderSize);
                                gr.FillRectangle(Brushes.Aqua, borderRect);

                                //Paint title bar
                                Size titleSize = new Size(this.Width-4, 15);
                                Rectangle titleRect = new Rectangle(new Point(2, 2), titleSize);

                                //Paint the Caption String
                                sf.Alignment = StringAlignment.Near;
                                sf.Trimming = StringTrimming.EllipsisCharacter;
                                gr.DrawString(this.Text, this.Font, Brushes.White, 4, 4, sf);
                            }
                        }
                        gr.ResetClip();
                    }

                }

                //Use Interop to transfer the bitmap to the screen.
                IntPtr screenDC = NativeMethods.GetDC(IntPtr.Zero);
                IntPtr memDC = NativeMethods.CreateCompatibleDC(screenDC);
                IntPtr hBitmap = backBuffer.GetHbitmap(Color.FromArgb(0));
                IntPtr oldBitmap = NativeMethods.SelectObject(memDC, hBitmap);

                NativeMethods.BLENDFUNCTION blend = new NativeMethods.BLENDFUNCTION(255);
                Point ptDst = this.Location;
                Size szDst = backBuffer.Size;
                Point ptSrc = Point.Empty;
                NativeMethods.UpdateLayeredWindow(this.Handle, screenDC, ref ptDst, ref szDst, memDC, ref ptSrc, 0, ref blend, NativeMethods.ULW_ALPHA);

                NativeMethods.SelectObject(memDC, oldBitmap);
                NativeMethods.DeleteObject(hBitmap);
                NativeMethods.DeleteDC(memDC);
                NativeMethods.DeleteDC(screenDC);
            }
        }

        private GraphicsPath CreateFormShape()
        {
            GraphicsPath formShape = new GraphicsPath();

            formShape.AddLine(0, 19, this.Width, 19);
            formShape.AddLine(0, this.Height, this.Width, this.Height);
            formShape.AddLine(0, 19, 0, this.Height);
            formShape.AddLine(this.Width, 19, this.Width, this.Height);
            formShape.CloseFigure();

            return formShape;
        }

    }

    public class NativeMethods
    {
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref Point pptDst, ref Size psize, IntPtr hdcSrc, ref Point pptSrc, int crKey, ref BLENDFUNCTION pblend, int dwFlags);

        [DllImport("uxtheme.dll")]
        internal static extern IntPtr SetWindowTheme(IntPtr hwnd, String pszSubAppName, String pszSubIdList);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("gdi32.dll")]
        internal static extern IntPtr CreateCompatibleDC(IntPtr dc);

        [DllImport("gdi32.dll")]
        internal static extern IntPtr SelectObject(IntPtr hdc, IntPtr hObj);

        [DllImport("gdi32.dll")]
        internal static extern IntPtr DeleteDC(IntPtr dc);

        [DllImport("gdi32.dll")]
        internal static extern IntPtr DeleteObject(IntPtr hObj);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool GetScrollBarInfo(IntPtr hwnd, int idObject, ref SCROLLBARINFO psbi);

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct BLENDFUNCTION
        {
            public byte BlendOp, BlendFlags, SourceConstantAlpha, AlphaFormat;

            public BLENDFUNCTION(Byte alpha)
            {
                this.BlendOp = AC_SRC_OVER;
                this.BlendFlags = 0;
                this.SourceConstantAlpha = alpha;
                this.AlphaFormat = AC_SRC_ALPHA;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct SCROLLBARINFO
        {
            public int cbSize;
            public RECT rcScrollBar;
            public int dxyLineButton;
            public int xyThumbTop;
            public int xyThumbBottom;
            public int reserved;
            public int scrollbar, incbtn, pgup, thumb, pgdn, decbtn;
        }


        [StructLayout(LayoutKind.Sequential)]
        internal struct RECT
        {
            public int Left, Top, Right, Bottom;
        }

        internal const int AC_SRC_OVER = 0x0;
        internal const int AC_SRC_ALPHA = 0x1;

        internal const int ULW_ALPHA = 0x2;

        internal const int WS_EX_LAYERED = 0x80000;

        internal const int OBJID_HSCROLL = unchecked((int)0xFFFFFFFA);//-6;
        internal const int OBJID_VSCROLL = unchecked((int)0xFFFFFFFB);//-5;

    }
}