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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
           
            KhoiTao();
        }
        public int diemPhanTu(TextBox t)
        {
            int k = 0;
            for (int i = 0; i < t.Text.Count(); i++)
                if (t.Text[i] == ' ')
                    k++;
            return k;
        }
        public void chuyenDoi(List<Diem> d,TextBox x,TextBox y)
        {
            int k1 = 1;
            int k2 = 1;
            int d1 = 1;
            List<string> s1 = new List<string>();
            for (int i = 0; i < x.Text.Count(); i++)
            {
                if (x.Text[i] == ' ')
                {
                    k1 = i;
                    string s = x.Text[0].ToString();
                    for (int j = 1; j < i; j++)
                        s += x.Text[j];
                    d[0].x = float.Parse(s);
                    break;
                }
            }
            for (int i = 0; i < y.Text.Count(); i++)
            {
                if (y.Text[i] == ' ')
                {
                    k2 = i;
                    string s = y.Text[0].ToString();
                    for (int j = 1; j < i; j++)
                        s += y.Text[j];
                    d[0].y = float.Parse(s);
                    break;
                }
            }
            for (int i = k1+1; i < x.Text.Count(); i++)
            {
             
                if (x.Text[i] == ' ')
                {
                    int k = 0;
                    string s = "";
                    for(int j=i-1;j>0;j--)
                        if (x.Text[j] == ' ')
                        { k = j + 1; break; }
                    for (int j = k; j < i; j++)
                        s += x.Text[j];
                    d[d1++].x = float.Parse(s);
                }
            }
            d1 = 1;
            for (int i = k2 + 1; i < y.Text.Count(); i++)
            {
                if (y.Text[i] == ' ')
                {
                    int k = 0;
                    string s = "";
                    for (int j = i - 1; j > 0; j--)
                        if (y.Text[j] == ' ')
                        { k = j + 1; break; }
                    for (int j = k; j < i; j++)
                        s += y.Text[j];
                    d[d1++].y = float.Parse(s);
                }
            }
        }
        public void tinhKhoangCach(List<float> kc, List<Diem> d, Diem k)
        {
            for (int i = 0; i < d.Count; i++)
            {
                kc[i] = (float)Math.Sqrt(Math.Pow(d[i].x - k.x, 2) + Math.Pow(d[i].y - k.y, 2));
            }
        }
        public bool thuoc(float x, List<float> T)
        {
            for (int i = 0; i < T.Count; i++)
                if (x == T[i])
                    return true;
            return false;
        }
        public void sapXep(List<float> kc)
        {
            for (int i = 0; i < kc.Count - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < kc.Count; j++)
                    if (kc[min] > kc[j])
                        min = j;
                float tmp = kc[i];
                kc[i] = kc[min];
                kc[min] = tmp;
          
            }
        }
        public int timMienGiaTri(List<float> kc1, List<float> kc2,int k)
        {
            int dem1=0;
            int dem2=0;
            List<float> kc = new List<float>();
            for (int i = 0; i < kc1.Count; i++) kc.Add(kc1[i]);
            int co = 0;
            for (int i = kc1.Count; i < (kc1.Count + kc2.Count); i++) kc.Add(kc2[co++]);
            sapXep(kc);
            for (int i = 0; i < k; i++)
            {
                if (thuoc(kc[i], kc1))
                    dem1++;
                else dem2++;
            }
            if (dem1 > dem2)
                return 1;
            else if (dem1 == dem2)
                return 1;
            else return 2;

        }

        public void KhoiTao()
        {
            int k = int.Parse( txtK.Text.ToString());
            List<Diem> diem1 = new List<Diem>();
            List<Diem> diem2 = new List<Diem>();
            List<float> kcDiem1 = new List<float>();
            List<float> kcDiem2 = new List<float>();
            Diem diemMoi=new Diem(float.Parse(txtX.Text.ToString()),float.Parse(txtY.Text.ToString()));
              for (int i = 0; i < diemPhanTu(txtX1); i++)
            { diem1.Add(new Diem(0, 0)); kcDiem1.Add(0); }
            for (int i = 0; i < diemPhanTu(txtX2); i++)
            { diem2.Add(new Diem(0, 0)); kcDiem2.Add(0); }
            chuyenDoi(diem1, txtX1, txtY1);
            chuyenDoi(diem2, txtX2, txtY2);
            tinhKhoangCach(kcDiem1, diem1, diemMoi);
            tinhKhoangCach(kcDiem2, diem2, diemMoi);           
            int thuoc = timMienGiaTri(kcDiem1, kcDiem2, k);
        }
    }
}
