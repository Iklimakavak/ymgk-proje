using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
   
        public Form1()
        {
            InitializeComponent();
        }
        private Bitmap GriYap(Bitmap rsim)
        {
            for (int i = 0; i < rsim.Height - 1; i++) { 
                for (int j = 0; j < rsim.Width - 1; j++)

                {
                    int deger = (rsim.GetPixel(j, i).G + rsim.GetPixel(j, i).B * 0) / 3;
                    Color renk;
                    renk = Color.FromArgb(deger, deger, deger);
                    rsim.SetPixel(j, i, renk);
                }
        }
            return rsim;
             

                    }

        private void button1_Click(object sender, EventArgs e)
        {
             pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
             openFileDialog1.ShowDialog();
             pictureBox1.ImageLocation = openFileDialog1.FileName;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap resim = new Bitmap(pictureBox1.Image);
            Bitmap gri = GriYap(resim);
            pictureBox2.Image = gri;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int xset, yset;
            var boyut = 5;
            var goruntu = new Bitmap(pictureBox1.Image);
            var genislik = goruntu.Width;
            var yukseklik = goruntu.Height;

            var piksellestirme = new Bitmap(genislik, yukseklik);

            for (var i = 0; i < genislik; i += boyut)
            {
                for (var j = 0; j < yukseklik; j += boyut)
                {
                    xset = yset = boyut / 2;

                    if(i + xset>= genislik)
                    {
                        xset = genislik - i - 1;

                    }
                    if (j + yset >= genislik)
                    {
                        yset = genislik - j - 1;

                    }
                    var piksel = goruntu.GetPixel(i + xset, j + yset);

                    for (var x = i; x<i+boyut && x < genislik; x++)
                    {
                        for (var y= j; y < j + boyut && y < yukseklik; y++)
                        {
                            piksellestirme.SetPixel(x, y, piksel);
                        }

                    }
                }

            }
            pictureBox2.Image = piksellestirme;
        }

        private void button4_Click(object sender, EventArgs e)
        {
         
        }
    }

      

    
    }

