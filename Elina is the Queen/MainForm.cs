using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public MainForm()
        {
            InitializeComponent();
            this.Show();

            colors = Palitra.Red();
            yesButton = new Button(colors, 1);
            noButton = new Button(colors, 2);
            alterButton = new Button(colors, 3);
            buttonList.Add(yesButton);
            buttonList.Add(noButton);
            buttonList.Add(alterButton);
            table = new Billboard(colors);
            table.ChangeText("Вахахахахахаха!", 30);
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
            foreach (Button button in buttonList)
            {
                button.Click(e);
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
    }
}
