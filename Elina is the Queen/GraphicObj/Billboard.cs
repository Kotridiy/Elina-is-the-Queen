using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Elina_is_the_Queen
{
    class Billboard : GraphicObject
    {
        private Rectangle rectangle;
        private Pen pen;
        private Brush mainBrush;
        private string text;
        private RectangleF textRect;
        private Brush textBrush;
        private Font font;
        private string extraText;
        private Point mousePoint;

        public Billboard(Colors colors)
        {
            Point startPoint = new Point(50, 20);
            rectangle = new Rectangle(startPoint.X, startPoint.Y, 550, 150);
            mainBrush = new SolidBrush(colors.tableColor);
            textBrush = new SolidBrush(colors.textColor);
            font = Palitra.font;
            pen = new Pen(colors.tableLines, 10);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            textRect = new RectangleF(startPoint.X + 10, startPoint.Y + 10, 530, 130);
            text = "";
        }

        public void Draw(Graphics e)
        {
            e.DrawRectangle(pen, rectangle);

            e.FillRectangle(mainBrush, rectangle);

            StringFormat sformat = new StringFormat();
            sformat.Alignment = StringAlignment.Center;
            sformat.LineAlignment = StringAlignment.Center;
            e.DrawString(text, font, textBrush, textRect, sformat);
        }

        public void ChangeColor(Colors colors)
        {
            mainBrush = new SolidBrush(colors.tableColor);
            textBrush = new SolidBrush(colors.textColor);
            pen = new Pen(colors.tableLines, 4);
        }

        public void MouseDown(MouseEventArgs mouse)
        {
            if (rectangle.Contains(mouse.Location))
            {
                extraText = text;
                text = "Эй!";
            }
            mousePoint = mouse.Location;
        }

        public void MouseUp(MouseEventArgs mouse)
        {
            if (rectangle.Contains(mousePoint))
            {
                text = extraText;
            }
        }

        public void ChangeText(string newText, float newSize = 0)
        {
            text = newText;
            if (newSize > 0)
            {
                font = new Font(Palitra.font.FontFamily, newSize, Palitra.font.Style);
            }
        }
    }
}
