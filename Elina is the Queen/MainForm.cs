using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Elina_is_the_Queen
{
    public partial class MainForm : Form
    {
        Button yesButton;
        Button noButton;
        Button alterButton;
        List<Button> buttonList = new List<Button>();
        Billboard table;
        Colors colors;
        MapPlayer Map { get; set; }

        public MainForm()
        {
            InitializeComponent();
            this.Show();

            /*colors = Palitra.Red();
            yesButton = new Button(colors, 1);
            noButton = new Button(colors, 2);
            alterButton = new Button(colors, 3);
            buttonList.Add(yesButton);
            buttonList.Add(noButton);
            buttonList.Add(alterButton);
            table = new Billboard(colors);
            table.ChangeText("Вахахахахахаха!", 30);*/

            InitializeForm();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            base.OnPaint(e);
            foreach (Button button in buttonList)
            {
                button.Draw(e.Graphics);
            }
            table.Draw(e.Graphics);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (e.Button != MouseButtons.Left) return;
            int answer = 0;
            foreach (Button button in buttonList)
            {
                answer = button.Click(e);
                if (answer != 0)
                {
                    UpdateMap(answer);
                    break;
                }
            }

            this.Refresh();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button != MouseButtons.Left) return;
            foreach (Button button in buttonList)
            {
                button.MouseDown(e);
            }
            table.MouseDown(e);

            this.Refresh();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button != MouseButtons.Left) return;
            foreach (Button button in buttonList)
            {
                button.MouseUp(e);
            }
            table.MouseUp(e);

            this.Refresh();
        }

        void InitializeForm()
        {
            Map = new MapPlayer("map.dat");

            colors = Palitra.Normal();
            yesButton = new Button(colors, 1, false);
            noButton = new Button(colors, 2, false);
            alterButton = new Button(colors, 3, text: Map.CurrentPoint.AlterText);
            buttonList.Add(yesButton);
            buttonList.Add(noButton);
            buttonList.Add(alterButton);
            table = new Billboard(colors);
            table.ChangeText(Map.CurrentPoint.TableText, Map.CurrentPoint.TextSize);
        }

        private void UpdateMap(int answer)
        {
            Map.MoveTo(answer);

            TextPoint point = Map.CurrentPoint;

            yesButton.Hide(point.NextTo(1) == 0 || point.IsFinal);
            noButton.Hide(point.NextTo(2) == 0 || point.IsFinal);
            alterButton.Hide(point.NextTo(3) == 0 && !point.IsFinal);
            alterButton.ChangeAlterText(point.AlterText);

            colors = Palitra.GetColors(point.ColorPack);
            foreach (var button in buttonList)
            {
                button.ChangeColor(colors);
            }

            table.ChangeText(point.TableText, point.TextSize);
            table.ChangeColor(colors);
        }
    }
}
