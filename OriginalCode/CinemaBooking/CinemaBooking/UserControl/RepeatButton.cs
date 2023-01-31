using System;
using System.Windows.Forms;

namespace CinemaBooking
{
    public class RepeatButton : Button
    {
        private readonly Timer _timer = new Timer();

        public event EventHandler Depressed;

        public virtual TimeSpan Interval
        {
            get { return TimeSpan.FromMilliseconds(_timer.Interval); }
            set { _timer.Interval = (int)value.TotalMilliseconds; }
        }

        public RepeatButton()
        {
            _timer.Interval = 100;
            _timer.Tick += delegate { OnDepressed(); };
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            _timer.Stop();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            _timer.Start();
        }
        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            if(!Enabled) _timer.Stop();
        }

        protected virtual void OnDepressed()
        {
            Depressed?.Invoke(this, EventArgs.Empty);
            PerformClick();
        }
    }
}
