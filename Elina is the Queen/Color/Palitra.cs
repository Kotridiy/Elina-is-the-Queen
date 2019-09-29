using System.Drawing;

namespace Elina_is_the_Queen
{
    static class Palitra
    {
        public static Font font = new Font("Comic Sans MS", 15, FontStyle.Bold | FontStyle.Italic);

        public static Colors Normal()
        {
            Colors colors = new Colors();
            colors.buttonLines = Color.FromArgb(250, 245, 245, 220);
            colors.buttonColor = Color.FromArgb(220, 20, 20, 40);
            colors.textColor = Color.FromArgb(255, 245, 245, 220);
            colors.tableLines = Color.FromArgb(240, 245, 245, 220);
            colors.tableColor = Color.FromArgb(220, 20, 20, 40);
            return colors;
        }

        public static Colors Pessimist()
        {
            Colors colors = new Colors();
            colors.buttonLines = Color.FromArgb(250, 255, 255, 255);
            colors.buttonColor = Color.FromArgb(180, 135, 110, 110);
            colors.textColor = Color.FromArgb(255, 0, 0, 0);
            colors.tableLines = Color.FromArgb(150, 255, 255, 255);
            colors.tableColor = Color.FromArgb(180, 135, 110, 110);
            /*colors.buttonLines = Color.FromArgb(250, 50, 10, 50);
            colors.buttonColor = Color.FromArgb(180, 50, 10, 50);
            colors.textColor = Color.FromArgb(255, 88, 161, 208);
            colors.tableLines = Color.FromArgb(150, 50, 10, 50);
            colors.tableColor = Color.FromArgb(180, 50, 10, 50);*/
            return colors;
        }

        public static Colors Cheerfull()
        {
            Colors colors = new Colors();
            colors.buttonLines = Color.FromArgb(250, 60, 230, 80);
            colors.buttonColor = Color.FromArgb(200, 60, 230, 80);
            colors.textColor = Color.FromArgb(255, 255, 255, 80);
            colors.tableLines = Color.FromArgb(150, 60, 230, 80);
            colors.tableColor = Color.FromArgb(200, 60, 230, 80);
            return colors;
        }

        public static Colors Angry()
        {
            Colors colors = new Colors();
            colors.buttonLines = Color.FromArgb(250, 255, 0, 0);
            colors.buttonColor = Color.FromArgb(250, 80, 0, 0);
            colors.textColor = Color.FromArgb(255, 250, 0, 0);
            colors.tableLines = Color.FromArgb(220, 50, 0, 0);
            colors.tableColor = Color.FromArgb(220, 100, 0, 0);
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

        public static Colors GetColors(int index)
        {
            switch (index)
            {
                case 1:
                    return Normal();
                case 2:
                    return Pessimist();
                case 3:
                    return Cheerfull();
                case 4:
                    return Angry();
                case 5:
                    return Rainbow();
                default:
                    throw new System.ArgumentException();
            }
        }
    }
}