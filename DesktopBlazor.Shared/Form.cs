using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace DesktopBlazor.Shared
{
    public class Form
    {
        public Boolean AllowTransparency { get; set; } = false;
        public Boolean AutoScale { get; set; } = false;
        public Size AutoScaleBaseSize { get; set; } = new Size { Width = 6, Height = 16 };
        public Boolean AutoScroll { get; set; } = false;
        public Boolean AutoSize { get; set; } = false;
        public Color BackColor { get; set; }
        public Size ClientSize { get; set; } = new Size { Width = 800, Height = 450 };
        public Boolean HelpButton { get; set; } = false;
        public Boolean IsMdiChild { get; set; } = false;
        public Boolean IsMdiContainer { get; set; } = false;
        public Boolean IsRestrictedWindow { get; set; } = false;
        public Boolean KeyPreview { get; set; } = false;
        public Point Location { get; set; } = new Point { X = 0, Y = 0 };
        public Size MaximumSize { get; set; } = new Size { Width = 0, Height = 0 };
        public Size MinimumSize { get; set; } = new Size { Width = 0, Height = 0 };
        public Boolean MaximizeBox { get; set; } = true;
        public Boolean MinimizeBox { get; set; } = true;
        public Boolean Modal { get; set; } = false;
        public Double Opacity { get; set; } = 1;
        public Boolean RightToLeftLayout { get; set; } = false;
        public Boolean ShowInTaskbar { get; set; } = true;
        public Boolean ShowIcon { get; set; } = true;
        public Size Size { get; set; } = new Size { Width = 816, Height = 489 };
        public Int32 TabIndex { get; set; } = 0;
        public Boolean TabStop { get; set; } = true;
        public String Text { get; set; }
        public Boolean TopLevel { get; set; } = true;
        public Boolean TopMost { get; set; } = false;
        public Boolean AllowDrop { get; set; } = false;
        public Boolean Enabled { get; set; } = true;
        public Boolean Focused { get; set; } = false;
        public Color ForeColor { get; set; }
        public Int32 Height { get; set; } = 489;
        public Boolean IsHandleCreated { get; set; } = true;
        public Boolean InvokeRequired { get; set; } = false;
        public Boolean IsAccessible { get; set; } = false;
        public Boolean IsMirrored { get; set; } = false;
        public Int32 Left { get; set; } = 234;
        public String Name { get; set; }
        public Boolean RecreatingHandle { get; set; } = false;
        public Int32 Right { get; set; } = 1050;
        public Int32 Top { get; set; } = 234;
        public Boolean UseWaitCursor { get; set; } = false;
        public Boolean Visible { get; set; } = false;
        public Int32 Width { get; set; } = 816;
        public Size PreferredSize { get; set; } = new Size { Width = 16, Height = 39 };
    }
}
