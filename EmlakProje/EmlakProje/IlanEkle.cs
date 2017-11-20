using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using Bunifu;
using BunifuAnimatorNS;
using MetroFramework;
using System.Data.SqlClient;

namespace EmlakProje
{
    public partial class IlanEkle : Form
    {
        public IlanEkle()
        {
            InitializeComponent();
        }

        private void ilanEklePanel_Paint(object sender, PaintEventArgs e)
        {

        }
        List<PictureBox> pictureboxlar = new List<PictureBox>();
        private FilterInfoCollection webcam;
        private VideoCaptureDevice cam;
        public int fotograf = 1;
        private void fotografButton_Click(object sender, EventArgs e)
        {
            

            if (fotograf == 1)
            {
                pictureBox1.Image = pictureBox1.Image;
            }
            if (fotograf == 2)
            {
                pictureBox2.Image = pictureBox2.Image;
            }
            if (fotograf == 3)
            {
                pictureBox3.Image = pictureBox3.Image;
            }
            if (fotograf == 4)
            {
                pictureBox4.Image = pictureBox4.Image;

            }
            fotograf++;

        }

        private void cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bit = (Bitmap)eventArgs.Frame.Clone();
            if (fotograf == 1)
                pictureBox1.Image = bit;
            if (fotograf == 2)
                pictureBox2.Image = bit;
            if (fotograf == 3)
                pictureBox3.Image = bit;
            if (fotograf == 4)
                pictureBox4.Image = bit;


        }

        public void fotografCek(PictureBox picturebox)
        {
            if (cam.IsRunning == true)
            {
                cam.Stop();
                picturebox.Image = picturebox.Image;

            }

        }
        public void GoruntuYakala()
        {
            cam = new VideoCaptureDevice(webcam[0].MonikerString);
            cam.NewFrame += new NewFrameEventHandler(cam_NewFrame);
            cam.Start();
        }
        private void Ilanlar_Load(object sender, EventArgs e)
        {
            tekrarfotoBtn.ButtonText = "YENİDEN ÇEK";
            fotografBtn.ButtonText = "FOTOGRAF CEK";
            comboBox1.Visible = false;
            onaylaBtn.ButtonText = "İLANI ONAYLIYORUM ";
            pictureboxlar.Add(pictureBox1);// pictureboxları listeye atıyoruz.
            pictureboxlar.Add(pictureBox2);
            pictureboxlar.Add(pictureBox3);
            pictureboxlar.Add(pictureBox4);

            webcam = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo videocapturedevice in webcam)
                comboBox1.Items.Add(videocapturedevice.Name);

            //comboBox1.SelectedIndex = 0;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            GoruntuYakala();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            GoruntuYakala();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            GoruntuYakala();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            GoruntuYakala();
        }

        private void kapatButton_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
           
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            cam.Start();
            
            if (fotograf == 1)
            {
                pictureBox1.Image = pictureBox1.Image;
            }
            if (fotograf == 2)
            {
                pictureBox2.Image = pictureBox2.Image;
            }
            if (fotograf == 3)
            {
                pictureBox3.Image = pictureBox3.Image;
            }
            if (fotograf == 4)
            {
                pictureBox4.Image = pictureBox4.Image;

            }
            fotograf++;
        }

        private void bunifuThinButton21_Click_1(object sender, EventArgs e)
        {
                          
            foreach(PictureBox pic in pictureboxlar)
            {
                pic.Image = null;
                cam.Stop();
            }
        }
        public enum harfler //rasgele resim isimi oluşturmak için oluşturuyoruz.
        {
            a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, r, s, t, u, v, y, z
        }
        Giris giris = new Giris();
        static string baglantiTxt = "Data Source=TUGRUL\\SQLEXPRESS;Initial Catalog=Emlak;Integrated Security=True";
        SqlConnection baglanti = new SqlConnection(baglantiTxt);
        List<string> resimKonum = new List<string>();
        private void onaylaBtn_Click(object sender, EventArgs e)
        {
            if(baglanti.State==ConnectionState.Closed)
            {
                baglanti.Open();
                try
                {
                    foreach(PictureBox resimler in pictureboxlar)
                    {
                        Random rnd = new Random();
                        int harf = rnd.Next(0, 24);
                        int sayi = rnd.Next(0, 100);
                        string resimlerKonum = Application.StartupPath + "\\Resim" + ((harfler)(harf)).ToString().ToUpper() + sayi.ToString() + ".png";
                        resimler.Image.Save(resimlerKonum);
                        resimKonum.Add(resimlerKonum);
                        
                    }
                    string Ilankomut = "INSERT INTO Ilanlar (IlanBaslik,EvTuru,EvAdres1,EvAdres2,EvAdres3,IsitmaTuru,EvKati,EvFiyat,EvTarih,MetreKare,KullaniciID_FK) VALUES (@IlanBaslik,@EvTuru,@EvAdres1,@EvAdres2,@EvAdres3,@IsitmaTuru,@EvKati,@EvFiyat,@EvTarih,@MetreKare,@KullaniciID_FK) " +
                        "GO " +
                        "INSERT INTO IlanFoto(IlanID, Foto1, Foto2, Foto3, Foto4) (SELECT TOP 1 IlanID FROM Ilanlar ORDER BY IlanID DESC,@foto1,@foto2,@foto3,@foto4) ";
                    SqlCommand komut = new SqlCommand(Ilankomut, baglanti);
                    komut.Parameters.AddWithValue("@IlanBaslik", baslikTxt.Text);
                    komut.Parameters.AddWithValue("@EvTuru", turBox.Text);
                    komut.Parameters.AddWithValue("@EvAdres1", ilBox.Text);
                    komut.Parameters.AddWithValue("@EvAdres2", ilceBox.Text);
                    komut.Parameters.AddWithValue("@EvAdres3", mahalleTxt.Text);
                    komut.Parameters.AddWithValue("@IsitmaTuru", isitmaBox.Text);
                    komut.Parameters.AddWithValue("@EvKati", katNumeric.Value);
                    komut.Parameters.AddWithValue("@EvFiyat", fiyatNumeric.Text);
                    komut.Parameters.AddWithValue("@MetreKare", metrekareTxt.Text);
                    komut.Parameters.AddWithValue("@KullaniciID_FK", giris.aktifKullanciID);
                    komut.Parameters.AddWithValue("@EvTarih", yasTxt.Text);
                    komut.Parameters.AddWithValue("@foto1", resimKonum[0].ToString());
                    komut.Parameters.AddWithValue("@foto2", resimKonum[1].ToString());
                    komut.Parameters.AddWithValue("@foto3", resimKonum[2].ToString());
                    komut.Parameters.AddWithValue("@foto4", resimKonum[3].ToString());
                    komut.ExecuteNonQuery();
                    MessageBox.Show("ilan Başarıyla Eklendi");
                    resimKonum.Clear();
                    baglanti.Close();
                }
                catch (Exception hata)
                {
                    baglanti.Close();
                    MessageBox.Show("HATA OLUŞTU"+hata);
                }
            }
        }
    }
}
