using System.Drawing;

namespace FlatUI.Helpers
{
    public class FlatColors
    {
        private FlatColors() { }

        private static FlatColors instance = null;
        public static FlatColors Instance()
        {
            if (instance == null) instance = new FlatColors();

            return instance;
        }

        public Color Flat { get; set; } = Color.FromArgb(35, 168, 109);
    }
}