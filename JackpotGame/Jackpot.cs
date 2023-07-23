using JackpotGame.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JackpotGame
{
    public partial class Jackpot : Form
    {
        int cevirmeSuresi = 3000;
        int resimDegisimSuresi = 100;
        int sayac = 0;
        List<Bitmap> resimler = new List<Bitmap>()
        {
            Resources.karpuz,
            Resources.kiraz,
            Resources.kivi,
            Resources.muz,
            Resources.armut,
            Resources.ananas,
            Resources.cilek,
            Resources.erik,
            Resources.seftali,

        };
        public Jackpot()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;
            Random rnd = new Random();
            int rndSayi = rnd.Next(0, resimler.Count);
            pictureBox1.Image = resimler[rndSayi];
            rndSayi = rnd.Next(0, resimler.Count);
            pictureBox2.Image = resimler[rndSayi];
            rndSayi = rnd.Next(0, resimler.Count);
            pictureBox3.Image = resimler[rndSayi];
            rndSayi = rnd.Next(0, resimler.Count);

            if (sayac == (cevirmeSuresi / resimDegisimSuresi))
            {
                timer1.Stop();
                sayac = 0;
                KontrolEt();
            }
        }
        private void KontrolEt()
        {
            if (pictureBox1.Image == pictureBox2.Image && pictureBox1.Image == pictureBox3.Image)
            {
                label1.Text = "Tebrikler! KAZANDINIZ";
                label1.ForeColor = Color.Green;
            }
            else if (pictureBox1.Image == pictureBox2.Image || pictureBox1.Image == pictureBox3.Image || pictureBox2.Image == pictureBox3.Image)
            {
                label1.Text = "Amorti Kazandınız,Yatırdığınız Miktar İade Edildi";
                label1.ForeColor = Color.Orange;
            }
            else
            {
                label1.Text = "Kaybettiniz! Tekrar Deneyiniz...";
                label1.ForeColor = Color.Red;
            }
        }
    }
}
