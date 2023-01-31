using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CinemaBooking
{
    public sealed partial class MovieItem : UserControl
    {
        public Movie MovieObject { get; set; }
        public MovieSession[] MovieSessions { get; set; }
        public int MovieSessionTolerance { get; set; }

        public MovieItem()
        {
            InitializeComponent();
            //Font = new Font("Arial Narrow", Font.Size * 2);
            pictureBoxPoster.Click += delegate { RefreshFields(); };
        }
        protected override void InitLayout()
        {
            base.InitLayout();
            RefreshFields();
        }
        private void RefreshFields()
        {
            try
            {
                var time = DateTime.Now;
                try { using (var entities = new CinemaBookingEntities()) { time = entities.GetDate(); } } catch (Exception e) { Console.WriteLine(e); }
                labelTitle.Text = MovieObject.Title.CropIfItsLong(25);
                labelDescription.Text = MovieObject.Description.CropIfItsLong(40);
                labelFormat.Text = string.Join(",", MovieObject.Movie_MovieFormat.Select(o => o.MovieFormat.MovieFormatName));
                labelDuration.Text = string.Format("{0} dakika", MovieObject.Duration);
                labelType.Text = string.Join(",", MovieObject.Movie_MovieType.Select(o => o.MovieType.MovieTypeName));
                pictureBoxPoster.BackgroundImage = MovieObject.PosterPreview.ToImage();
                tabControl.TabPages.Clear();
                if (MovieSessions != null && MovieSessions.Length > 0)
                {
                    foreach (var place in MovieSessions.Select(item => item.MovieTheatrePlace).Distinct())
                    {
                        var tab = new TabPage(place.MovieTheatrePlaceName);
                        var layout = new FlowLayoutPanel
                        {
                            AutoScroll = true,
                            Dock = DockStyle.Fill,
                            Margin = new Padding(0)
                        };
                        foreach (var session in MovieSessions.Where(item => item.MovieTheatrePlaceId == place.MovieTheatrePlaceId))
                        {
                            var button = new SessionButton(session, session.MovieTheatrePlace.MovieTheatrePlaceTemplate)
                            {
                                Margin = new Padding(3, 3, 0, 0),
                                Size = new Size(112, 44),
                                //Font = new Font("Calibri", Font.Size),
                                Session = session,
                                Enabled = session.SessionTime > time.AddMinutes(-1 * MovieSessionTolerance)
                            };
                            layout.Controls.Add(button);
                        }
                        tab.Controls.Add(layout);
                        tabControl.TabPages.Add(tab);
                    }
                }

                flowLayoutPanel.Controls.Clear();
                foreach (var item in MovieObject.Movie_MovieCategory.Select(o => o.MovieCategory))
                {
                    var pic = new PictureBox();
                    //pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic.SizeMode = PictureBoxSizeMode.Zoom;
                    pic.Width = 26;
                    pic.Height = 26;
                    ////pic.AutoSize = true;
                    pic.Image = item.MovieCategoryImage.ToImage();
                    flowLayoutPanel.Controls.Add(pic);
                }

            }
            catch (Exception)
            {
            }
        }

    }
}
