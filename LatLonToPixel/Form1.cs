using System.Drawing;
using System.Windows.Forms;

namespace LatLonToPixel
{
    public partial class Form1 : Form
    {
        // Image sizes
        private const int ImgWidth = 640;
        private const int ImgHeight = 640;

        // Maximum and minimum value of latitude and longitude on the image
        private const double LatMin = 23.45;
        private const double LatMax = 46.56;
        private const double LonMin = 121.93;
        private const double LonMax = 149.75;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            var point = LatLonToPixel(35.7, 139.7);

            var bitmap = new Bitmap(Properties.Resources.MapImage, ImgWidth, ImgHeight);
            var graphics = Graphics.FromImage(bitmap);
            var pen = new Pen(Color.Red, 2);
            graphics.DrawLine(pen, point[0] - 10, point[1] - 10, point[0] + 10, point[1] + 10);
            graphics.DrawLine(pen, point[0] - 10, point[1] + 10, point[0] + 10, point[1] - 10);
            pen.Dispose();
            graphics.Dispose();
            pictureBox1.Image = bitmap;
        }

        /// <summary>
        /// Convert latitude and longitude coordinates to pixel coordinates.
        /// </summary>
        /// <param name="lat">Latitude</param>
        /// <param name="lon">Longitude</param>
        /// <returns></returns>
        private static float[] LatLonToPixel(double lat, double lon)
        {
            var x = (lon - LonMin) * ImgWidth / (LonMax - LonMin);
            var y = ImgHeight - (lat - LatMin) * ImgHeight / (LatMax - LatMin);

            return new[] { (float)x, (float)y };
        }
    }
}
