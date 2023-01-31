using System.ComponentModel;
using System.Windows.Forms;

namespace CinemaBooking.Class
{
    public sealed class CustomTableLayoutPanel : TableLayoutPanel
    {
        public CustomTableLayoutPanel()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
        }

        public CustomTableLayoutPanel(IContainer container)
        {
            DoubleBuffered = true;
            container.Add(this);
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.UserPaint, true);
        }
    }
}
