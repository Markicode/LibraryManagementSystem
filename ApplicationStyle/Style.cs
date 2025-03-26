using System.Drawing;
using System.Runtime.Versioning;

namespace GlobalApplicationVariables
{
    [SupportedOSPlatform("windows")]
    public static class Style
    {
        public static FontFamily fontFamily = new FontFamily("Lato"); 
        public static Color orangeColor = Color.FromArgb(255, 76, 0);
        public static Color purpleColor = Color.FromArgb(33, 0, 127);
        public static Font textFont = new(Style.fontFamily, 10, FontStyle.Regular);
        public static Font menuFont = new(Style.fontFamily, 16, FontStyle.Regular);
        public static Font hoverMenuFont = new(Style.fontFamily, 16, FontStyle.Bold);
        public static Font closeButtonFont = new(Style.fontFamily, 24, FontStyle.Regular);
        public static Font hoverCloseButtonFont = new(Style.fontFamily, 24, FontStyle.Bold);
        public static int menuSpacing = 15;
    }
}
