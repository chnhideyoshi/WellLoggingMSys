using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GraphicsDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(timer_Tick);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            
        }
        Timer timer = new Timer();
        private void Form1_Load(object sender, EventArgs e)
        {
            viewport = new Viewport();
            viewport.Left = -20;
            viewport.Top = -20;
            viewport.Width = panel1.Width-20;
            viewport.Height = panel1.Height-20;
            grid.Height = 1000;
            grid.Width = panel1.Width;
            grid.VerticalGridCellsCount = 100;
            grid.HorizontalGridCellsCount = 20;
            grid.Left = 0; 
            grid.Top = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        Grid grid = new Grid();
        Viewport viewport;
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            grid.Draw(e.Graphics, viewport);
            //ShowMessage(e.ClipRectangle.X + " " + e.ClipRectangle.Y + " " + e.ClipRectangle.Width + " " + e.ClipRectangle.Height + " ||" );

            
        }
        void ShowMessage(string message)
        {
            richTextBox1.Text = message + Environment.NewLine + richTextBox1.Text;
        }
    }
}
