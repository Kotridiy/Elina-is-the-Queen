using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Elina_is_the_Queen
{
    class Button : GraphicObject
    {
        int             answer;
        GraphicsPath    gpath;
        Pen             pen;
        Brush           mainBrush;
        string          text;
        RectangleF      textRect;
        Brush           textBrush;
        Font            font;
        string          extraText;
        Point           mousePoint;
        bool            visible;

        Button(Colors colors)
        {
            mainBrush = new SolidBrush(colors.buttonColor);
            textBrush = new SolidBrush(colors.textColor);
            font = Palitra.font;
            pen = new Pen(colors.buttonLines, 4);
        }

        public Button(Colors colors, int type, bool visible = true) : this(colors)
        {
            this.visible = visible;
            switch (type)
            {
                case 1:
                    {
                        font = new Font(font.FontFamily, 30);
                        answer = 1;
                        gpath = new GraphicsPath();
                        Point start = new Point(100, 200);
                        gpath.AddClosedCurve(new Point[] {
                                                    new Point(start.X, start.Y),
                                                    new Point(start.X+50, start.Y),
                                                    new Point(start.X+100, start.Y),
                                                    new Point(start.X+150, start.Y),
                                                    new Point(start.X+200, start.Y),
                                                    new Point(start.X+200, start.Y+50),
                                                    new Point(start.X+200, start.Y+100),
                                                    new Point(start.X+150, start.Y+100),
                                                    new Point(start.X+100, start.Y+100),
                                                    new Point(start.X+100, start.Y+150),
                                                    new Point(start.X+100, start.Y+200),
                                                    new Point(start.X+50, start.Y+200),
                                                    new Point(start.X, start.Y+200),
                                                    new Point(start.X, start.Y+150),
                                                    new Point(start.X, start.Y+100),
                                                    new Point(start.X, start.Y+50)
                        });
                        text = "Да";
                        textRect = new Rectangle(start.X + 10, start.Y + 15, 90, 70);
                        break;
                    }
                case 2:
                    {
                        font = new Font(font.FontFamily, 30);
                        answer = 2;
                        gpath = new GraphicsPath();
                        Point start = new Point(350, 200);
                        gpath.AddClosedCurve(new Point[] {
                                                    new Point(start.X, start.Y),
                                                    new Point(start.X+50, start.Y),
                                                    new Point(start.X+100, start.Y),
                                                    new Point(start.X+150, start.Y),
                                                    new Point(start.X+200, start.Y),
                                                    new Point(start.X+200, start.Y+50),
                                                    new Point(start.X+200, start.Y+100),
                                                    new Point(start.X+200, start.Y+150),
                                                    new Point(start.X+200, start.Y+200),
                                                    new Point(start.X+150, start.Y+200),
                                                    new Point(start.X+100, start.Y+200),
                                                    new Point(start.X+100, start.Y+150),
                                                    new Point(start.X+100, start.Y+100),
                                                    new Point(start.X+50, start.Y+100),
                                                    new Point(start.X, start.Y+100),
                                                    new Point(start.X, start.Y+50)
                        });
                        text = "Нет";
                        textRect = new Rectangle(start.X + 110, start.Y + 15, 90, 70);
                        break;
                    }
                case 3:
                    {
                        answer = 3;
                        gpath = new GraphicsPath();
                        Point start = new Point(225, 325);
                        gpath.AddRectangle(new Rectangle(start.X, start.Y, 200, 100));
                        text = "Пошёл в попу урод этакий";
                        textRect = new Rectangle(start.X + 20, start.Y + 25, 160, 50);
                        break;
                    }
                default:
                    throw(new System.Exception());
            }
        }

        public void Hide(bool setHide = true)
        {
            visible = !setHide;
        }

        public void Draw(Graphics e)
        {
            if (!visible) return;

            e.DrawPath(pen, gpath);

            e.FillPath(mainBrush, gpath);

            StringFormat sformat = new StringFormat();
            sformat.Alignment = StringAlignment.Center;
            sformat.LineAlignment = StringAlignment.Center;
            e.DrawString(text, font, textBrush, textRect, sformat);
        }

        public void ChangeColor(Colors colors)
        {
            mainBrush = new SolidBrush(colors.buttonColor);
            textBrush = new SolidBrush(colors.textColor);
            pen = new Pen(colors.buttonLines, pen.Width);
        }

        public int Click(MouseEventArgs mouse)
        {
            if (!visible) return 0;

            if (gpath.IsVisible(mouse.X, mouse.Y))
            {
                return answer;
            }
            else return 0;
        }

        public void MouseDown(MouseEventArgs mouse)
        {
            if (!visible) return;

            if (gpath.IsVisible(mouse.X, mouse.Y))
            {
                extraText = text;
                text = "Эй!";
            }
            mousePoint = mouse.Location;
        }

        public void MouseUp(MouseEventArgs mouse)
        {
            if (!visible) return;

            if (gpath.IsVisible(mousePoint))
            {
                text = extraText;
            }
        }
    }
}