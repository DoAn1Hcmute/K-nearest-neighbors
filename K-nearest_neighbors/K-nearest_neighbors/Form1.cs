using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace K_nearest_neighbors
{
    public partial class F1 : Form
    {
        Pen p0 = new Pen(Color.Black);
        SolidBrush fill0 = new SolidBrush(Color.Red);
        SolidBrush fill1 = new SolidBrush(Color.Blue);
        List<Diem> diem = new List<Diem>();

        public class Diem
        {
            public int toaDoX;
            public int toaDoY;
            public float chiSo;
            public int Loai;
            public Diem(int toaDoX,
            int toaDoY,
            float chiSo,
            int Loai)
            {
                this.toaDoX = toaDoX;
                this.toaDoY = toaDoY;
                this.chiSo = chiSo;
                this.Loai = Loai;
            }
            public Diem()
            {
                
            }
        }
        private void khoiTao()
        {

            diem.Add(new Diem(30, 30, 0, 0));
            diem.Add(new Diem(60, 70, 0, 0));
            diem.Add(new Diem(350, 400, 0, 0));
            diem.Add(new Diem(500, 400, 0, 0));
            diem.Add(new Diem(600, 450, 0, 0));
            diem.Add(new Diem(270, 250, 0, 0));

            diem.Add(new Diem(90, 150, 0, 1));
            diem.Add(new Diem(340, 360, 0, 1));
            diem.Add(new Diem(400, 460, 0, 1));
            diem.Add(new Diem(300, 400, 0, 0));
            diem.Add(new Diem(190, 150, 0, 1));
            diem.Add(new Diem(290, 150, 0, 1));
            diem.Add(new Diem(390, 150, 0, 1));
            diem.Add(new Diem(120, 170, 0, 1));
            diem.Add(new Diem(300, 280, 0, 1));

        }

        private int phanLoai(Diem diemMoi, int k)
        {
            foreach (Diem d in diem)
            {
                d.chiSo = (float)Math.Sqrt((float)Math.Pow(d.toaDoX - diemMoi.toaDoX, 2) + (float)Math.Pow(d.toaDoY - diemMoi.toaDoY, 2));
            }
            for (int i = 0; i < diem.Count - 1; i++)
            {
                for (int j = i + 1; j < diem.Count; j++)
                {
                    if (diem[i].chiSo > diem[j].chiSo)
                    {
                        Diem d = diem[i];
                        diem[i] = diem[j];
                        diem[j] = d;
                    }
                }
            }

            int x0 = 0, x1 = 0;
            for (int i = 0; i < k; i++)
                if (diem[i].Loai == 0)
                    x0++;
                else if (diem[i].Loai == 1)
                    x1++;

            if (x0 >= x1) return 0;
            return 1;
        }
        Diem diemMoi = new Diem();

        public F1()
        {
            InitializeComponent();
            khoiTao();
            diemMoi.toaDoX = 300;
            diemMoi.toaDoY = 300;
            diemMoi.Loai = phanLoai(diemMoi, 2);
        }

        private void F1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int i = 0; i < diem.Count; i++)
            {
                Rectangle rect = new Rectangle(diem[i].toaDoX, diem[i].toaDoY, 10, 10);
                if (diem[i].Loai == 0)
                {
                    g.DrawRectangle(p0, rect);
                    g.FillRectangle(fill0, rect);
                }
                else
                {
                    g.DrawRectangle(p0, rect);
                    g.FillRectangle(fill1, rect);
                }

            }
            Rectangle rec = new Rectangle(diemMoi.toaDoX, diemMoi.toaDoY, 15, 15);
            if (diemMoi.Loai == 0)
            {
                g.DrawRectangle(p0, rec);
                g.FillRectangle(fill0, rec);
            }
            else
            {
                g.DrawRectangle(p0, rec);
                g.FillRectangle(fill1, rec);
            }
        }
    }
}
