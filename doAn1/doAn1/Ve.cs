using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Ve : Form
    {
        Pen penRed = new Pen(Color.Red);
        Pen penBlue = new Pen(Color.Blue);
        SolidBrush fillRed = new SolidBrush(Color.Red);
        SolidBrush fillBlue = new SolidBrush(Color.Blue);
        List<Rectangle> recDiem1 = new List<Rectangle>();
        List<Rectangle> recDiem2 = new List<Rectangle>();
        public Ve(List<Diem> diem1,List<Diem>diem2,Diem diemMoi,int k)
        {
            InitializeComponent();
            for (int i = 0; i < diem1.Count; i++)
            {
                Rectangle rect = new Rectangle((int)diem1[i].x, (int)diem1[i].y, 30, 30);
                recDiem1.Add(rect);
            }
            for (int i = 0; i < diem2.Count; i++)
            {
                Rectangle rect = new Rectangle((int)diem2[i].x, (int)diem2[i].y, 30, 30);
                recDiem2.Add(rect);
            }
            if (k == 1)
            {
                Rectangle rect = new Rectangle((int)diemMoi.x, (int)diemMoi.y, 50, 50);
                recDiem1.Add(rect);
            }
            else if(k==2)
            {
                Rectangle rect = new Rectangle((int)diemMoi.x, (int)diemMoi.y, 50, 50);
                recDiem2.Add(rect);
            }
        }

        private void Ve_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int i = 0; i < recDiem1.Count; i++)
            {
                g.DrawRectangle(penRed, recDiem1[i]);
                g.FillRectangle(fillRed,recDiem1[i]);
            }
            for (int i = 0; i < recDiem2.Count; i++)
            {
                g.DrawRectangle(penBlue, recDiem2[i]);
                g.FillRectangle(fillBlue, recDiem2[i]);
            }
        }
    }
}
