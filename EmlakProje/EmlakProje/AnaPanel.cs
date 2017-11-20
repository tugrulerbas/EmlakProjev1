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
using System.Data.Sql;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace EmlakProje
{
    public partial class AnaPanel : Form
    {   
        
        
        public AnaPanel()
        {
            InitializeComponent();
        }
        KullaniciBilgileri kb = new KullaniciBilgileri();

        

        bool PanelDurum = true;
        public void PanelKaydir(Panel panel, int boyut)
        {
            if (PanelDurum == false)
            {
                panel.Width -= boyut;
                PanelDurum = true;

            }
            else if (PanelDurum == true)
            {
                panel.Width += boyut;
                PanelDurum = false;
            }
        }

        Giris girisForm = new Giris();
        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.MaximumSize = new Size(label1.Location.X, 40);
            yanPanel.Width -= 200;
            

        }
        static string baglantiTxt = "Data Source=TUGRUL\\SQLEXPRESS;Initial Catalog=Emlak;Integrated Security=True";
        static SqlConnection baglanti = new SqlConnection(baglantiTxt);
        public int aktifkullaniciID;
        public int kullaniciIlan()
        {
            int kayitSayi = 0;
             if(baglanti.State==ConnectionState.Closed)
            {
                baglanti.Open();
                string komut = "SELECT COUNT(*) as KayitSayi FROM Ilanlar WHERE KullaniciID_FK=@aktifID ";
                SqlCommand SayiKomut = new SqlCommand(komut, baglanti);
                SayiKomut.Parameters.AddWithValue("@aktifID",aktifkullaniciID);
                SqlDataReader dr = SayiKomut.ExecuteReader();
                SayiKomut.ExecuteNonQuery();
                
                kayitSayi += Convert.ToInt16(dr[0]);
                baglanti.Close();

            }
            return kayitSayi;
         
        }
        public int IlanSayi()
        {
            int kayitSayi = 0;
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
                string komut = "SELECT COUNT(*) as KayitSayi FROM Ilanlar";
                SqlCommand SayiKomut = new SqlCommand(komut, baglanti);
                SayiKomut.ExecuteNonQuery();
                SqlDataReader dr = SayiKomut.ExecuteReader();
                kayitSayi += 10;
                baglanti.Close();
            }
            
            return kayitSayi;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PanelKaydir(yanPanel, 200);
        }
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
            
        }

        private void KullaniciAyarButton_MouseMove(object sender, MouseEventArgs e)
        {
            KullaniciAyarButton.Size = new Size(160, 50);
        }

        private void KullaniciAyarButton_MouseLeave(object sender, EventArgs e)
        {
            KullaniciAyarButton.Size = new Size(149, 37);
        }
        public string renk;
        private void KullaniciAyarButton_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            yanPanel.BackColor = colorDialog1.Color;
            renk = colorDialog1.Color.Name;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            KullaniciBilgileri kb = new KullaniciBilgileri();
            kb.ShowDialog();
        }
        Panel ilanlarPanel = new Panel();

        private void IlanlarımButton_Click(object sender, EventArgs e)
        {          
               
                ilanlarPanel.Visible = true;
        }

        private void IlanVerBtn_Click(object sender, EventArgs e)
        {
            AnaPanel anaPanel = new AnaPanel();
            anaPanel.Close();
            IlanEkle ilanEkle = new IlanEkle();
            ilanEkle.Show();
        }
        static TextBox txt = new TextBox();

        static void Dinle()
        {
            var UdpServer = new UdpClient(8888);
            //UdpServer.Client.Bind(new IPEndPoint(IPAddress.Any, 8888)); // Herhangi bir IP den gelen 8888. porttan gelen mesazı dinliyor
            UdpServer.EnableBroadcast = true;
            var ClientIP = new IPEndPoint(IPAddress.Any, 8888);
            while (true)
            {
                var b = UdpServer.Receive(ref ClientIP);
                string s = Encoding.UTF8.GetString(b, 0, b.Length);//gelen mesajı s adlı değişkene atıyor.
                txt.Text = s.ToString();

            }
        }
        private void IlanAraBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("TELEFONUN KONUMU İLE Mİ ARAMAK İSTİYORSUNUZ ? ", "ARAMA SEÇENEKLERİ", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                panel1.Height += 40;
                txt.Location = new Point(panel1.Location.X + 100, panel1.Location.Y + 10);
                panel1.Controls.Add(txt);
                string deger = txt.Text;
                var tr = new Thread(new ThreadStart(Dinle));
                tr.Start();
                
                
            }
        }

        private void IlanlarımBtn_Click(object sender, EventArgs e)//GİRİLEN KULLANICININ OLUŞTURDUĞU İLANLARI GETİRECEK.
        {
           
        }
    }

    }

