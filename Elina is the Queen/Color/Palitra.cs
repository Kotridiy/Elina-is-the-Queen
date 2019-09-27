using System.Drawing;

namespace Elina_is_the_Queen
{
    static class Palitra
    {
        public static Font font = new Font("Comic Sans MS", 15, FontStyle.Bold | FontStyle.Italic);

        public static Colors Red()
        {
            Colors colors = new Colors();
            colors.buttonLines = Color.FromArgb(250,255,0,0);
            colors.buttonColor = Color.FromArgb(150, 193, 0, 0);
            colors.textColor = Color.FromArgb(255, 50, 0, 0);
            colors.tableLines = Color.FromArgb(150, 255, 0, 0);
            colors.tableColor = Color.FromArgb(150, 255, 0, 0);
            return colors;
        }

        public static Colors Green()
        {
            Colors colors = new Colors();
            colors.buttonLines = Color.FromArgb(250, 255, 0, 0);
            colors.buttonColor = Color.FromArgb(150, 193, 0, 0);
            colors.textColor = Color.FromArgb(255, 50, 0, 0);
            colors.tableLines = Color.FromArgb(150, 255, 0, 0);
            colors.tableColor = Color.FromArgb(150, 255, 0, 0);
            return colors;
        }

        public static Colors Yellow()
        {
            Colors colors = new Colors();
            colors.buttonLines = Color.FromArgb(250, 255, 0, 0);
            colors.buttonColor = Color.FromArgb(150, 193, 0, 0);
            colors.textColor = Color.FromArgb(255, 50, 0, 0);
            colors.tableLines = Color.FromArgb(150, 255, 0, 0);
            colors.tableColor = Color.FromArgb(150, 255, 0, 0);
            return colors;
        }

        public static Colors Dark()
        {
            Colors colors = new Colors();
            colors.buttonLines = Color.FromArgb(250, 255, 0, 0);
            colors.buttonColor = Color.FromArgb(150, 193, 0, 0);
            colors.textColor = Color.FromArgb(255, 50, 0, 0);
            colors.tableLines = Color.FromArgb(150, 255, 0, 0);
            colors.tableColor = Color.FromArgb(150, 255, 0, 0);
            return colors;
        }

        public static Colors Rainbow()
        {
            Colors colors = new Colors();
            colors.buttonLines = Color.FromArgb(250, 255, 0, 0);
            colors.buttonColor = Color.FromArgb(150, 193, 0, 0);
            colors.textColor = Color.FromArgb(255, 50, 0, 0);
            colors.tableLines = Color.FromArgb(150, 255, 0, 0);
            colors.tableColor = Color.FromArgb(150, 255, 0, 0);
            return colors;
        }
    }
}