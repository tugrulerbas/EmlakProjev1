using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu;
using BunifuAnimatorNS;
using MetroFramework;
using System.Data.SqlClient;

namespace EmlakProje
{
    public partial class Giris : Form
    {



        public Giris()
        {
            InitializeComponent();
        }
        public string aktifKullanici;
        public int aktifKullanciID;
        private void bunifuMetroTextbox1_OnValueChanged(object sender, EventArgs e)
        {
            kadiText.Click += KadiText_Click;
        }
        
        List<object> objeler = new List<object>();
        void GirisKaldır()
        {
            for (int i = 0; i != giris.Controls.Count; i++)
            {
                objeler.Add(giris.Controls[i]);
            }

                try
            {
                foreach(Control item in objeler)
                {
                    if (item is Panel)
                    {
                        panel1.Visible = true;
                        giris.Size = new Size(550, 310);
                    }
                    if(item is Button && item is Label && item is TextBox)
                    {
                        giris.Controls.Remove(item);
                    }
                   
                        
                }
                /*int c = giris.Controls.Count;
                for (int i = 0; i != c; i++)
                {
                    objeler.Add(giris.Controls[i]);
                    if (giris.panel1.Visible==false && giris.Controls[i].GetType == Type.GetType(giris.panel1))
                    {
                        giris.Controls.RemoveAt(i);
                        panel1.Visible = true;
                        giris.Size = new Size(550, 310);
                    }
                }
                */
            }
            catch
            {


            }
        }
        static string baglantiTxt = "Data Source=TUGRUL\\SQLEXPRESS;Initial Catalog=Emlak;Integrated Security=True";
        SqlConnection baglanti = new SqlConnection(baglantiTxt);
        Giris giris = null;
        List<object> ekleObje = new List<object>();
        List<string> txtler = new List<string>();
        ns1.BunifuDatepicker dt = new ns1.BunifuDatepicker();
        public void EkleForm()
        {
            
            int lblkonum = 26;
            int txtkonum = 17;
            giris = new Giris();
            giris.Size = new Size(550, 700);
            giris.Show();
            giris.panel1.Visible = false;
            for (int i = 1; i <= 8; i++)
            {

                Label lbl = new Label();
                ns1.BunifuTileButton button = new ns1.BunifuTileButton();
                ns1.BunifuMetroTextbox txt = new ns1.BunifuMetroTextbox();
                lbl.Font = new Font("Arial", 10, FontStyle.Bold);
                lbl.Location = new Point(18, lblkonum);
                giris.Controls.Add(lbl);
                txt.SetBounds(200, txtkonum, 100, 40);

                if (i == 1)
                {
                    lbl.Text = "AD";
                    txt.Name = "adTxt";
                    txtler.Add(txt.Text);
                    lblkonum += 80;
                    txtkonum += 80;
                    button.Location = new Point(txt.Location.X + 200, txt.Location.Y - 50);
                    button.LabelText = "geri git";
                    button.Click += Button_Click1;
                    giris.Controls.Add(button);
                }
                if (i == 2)
                {
                    lbl.Text = "SOYAD";
                    txt.Name = "soyadTxt";
                    txtler.Add(txt.Text);
                    lblkonum += 80;
                    txtkonum += 80;

                }
                if (i == 3)
                {
                    lbl.Text = "Kullanıcı Adı";
                    txt.Name = "KullaniciTxt";
                    txtler.Add(txt.Text);
                    lblkonum += 80;
                    txtkonum += 80;

                }
                if (i == 4)
                {
                    lbl.Text = "Telefon";
                    txt.Name = "telefonTxt";
                    txtler.Add(txt.Text);
                    lblkonum += 80;
                    txtkonum += 80;

                }
                if (i == 5)
                {
                    lbl.Text = "Dogum Tarihi";
                    lblkonum += 80;
                    txtkonum += 80;
                    txtler.Add(txt.Text);
                    dt.Location = new Point(200, 337);
                    giris.Controls.Add(dt);
                    continue;

                }
                if (i == 6)
                {
                    lbl.Text = "Mail Adresi";
                    txt.Name = "mailTxt";
                    txtler.Add(txt.Text);
                    lblkonum += 80;
                    txtkonum += 80;

                }
                if (i == 7)
                {
                    lbl.Text = "Sifre";
                    txt.Name = "sifreTxt";
                    txtler.Add(txt.Text);
                    lblkonum += 80;
                    txtkonum += 80;
                    txt.isPassword = true;

                }
                if (i == 8)
                {
                    lbl.Text = "Sifre Tekrar";
                    txt.Name = "txtTekrar";
                    txtler.Add(txt.Text);
                    lblkonum += 80;
                    txtkonum += 80;
                    txt.isPassword = true;
                    button.Location = new Point(txt.Location.X + 200, txt.Location.Y - 50);
                    button.LabelText = "EKLE";
                    button.Click += Button_Click; 
                    giris.Controls.Add(button);
                } giris.Controls.Add(txt);
            }
        }

        private void Button_Click1(object sender, EventArgs e)
        {
            GirisKaldır();
        }

        private void Button_Click(object sender, EventArgs e)//EKLE BUTON
        {
            
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();

                try
                {
                    if (txtler[6].ToString() != txtler[7].ToString())
                    {
                        MessageBox.Show("GİRİLEN ŞİFRELER AYNI DEĞİL");
                        baglanti.Close();
                    }
                    else
                    {
                        string komutTxt = "INSERT INTO Kullanicilar(KullaniciAd,KullaniciSoyad,KullaniciNick,DogumTarih,KayitTarihi,KullaniciMail,KullaniciSifre,Telefon) VALUES (@KullaniciAd,@KullaniciSoyad,@KullaniciNick,@DogumTarih,@KayitTarihi,@KullaniciMail,@KullaniciSifre,@Telefon )";              
                        SqlCommand komut = new SqlCommand(komutTxt, baglanti);
                        
                        komut.Parameters.AddWithValue("@KullaniciAd", txtler[0].ToString());
                        komut.Parameters.AddWithValue("@KullaniciSoyad", txtler[1].ToString());
                        komut.Parameters.AddWithValue("@KullaniciNick", txtler[2].ToString());
                        komut.Parameters.AddWithValue("@telefon", txtler[3].ToString());
                        komut.Parameters.AddWithValue("@DogumTarih", Convert.ToDateTime(dt.Value));
                        komut.Parameters.AddWithValue("@KullaniciMail", txtler[5].ToString());
                        komut.Parameters.AddWithValue("@KullaniciSifre", txtler[6].ToString());
                        komut.Parameters.AddWithValue("@KayitTarihi", DateTime.Today);
                        komut.ExecuteNonQuery();                      
                        txtler.Clear();
                        baglanti.Close();
                        MessageBox.Show("KULLANİCİ BAŞARIYLA EKLENDİ");
                    }
                    
                }
                catch (Exception hata)
                {
                    MessageBox.Show("HATA OLUŞTU" + hata);
                }
            }
            else
                MessageBox.Show("BAĞLANTI AÇIK");

        }

        private void KadiText_Click(object sender, EventArgs e)
        {
            kadiText.Text = " ";
            sifreText.Text = " ";
        }

        private void sifreText_OnValueChanged(object sender, EventArgs e)
        {

        }
        

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
                try
                {
                    string GirisKomut = "SELECT KullaniciAd,KullaniciID FROM Kullanicilar WHERE KullaniciNick=@kullaniciAdi AND KullaniciSifre=@sifre";//KULLANICI KONTROLU YAPILIYOR.
                    SqlCommand komut = new SqlCommand(GirisKomut, baglanti);
                    komut.Parameters.AddWithValue("@kullaniciAdi", kadiText.Text);
                    komut.Parameters.AddWithValue("@sifre", sifreText.Text);
                    komut.ExecuteNonQuery();
                    
                    SqlDataReader dr = komut.ExecuteReader();
                
                    if (dr.Read())
                    {

                        aktifKullanici = dr[0].ToString();
                        aktifKullanciID = Convert.ToInt16(dr[1]);
                        AnaPanel pnl = new AnaPanel();
                        KullaniciBilgileri kb = new KullaniciBilgileri();
                        kb.label1.Text = "şuanki ID"+aktifKullanciID.ToString();
                        pnl.linkLabel1.Text = "Hoşgeldin " + aktifKullanici.ToString()+" "+aktifKullanciID;
                        pnl.aktifkullaniciID = aktifKullanciID;
                        //kb.aktifKullaniciID = aktifKullanciID.ToString();
                        pnl.ShowDialog();
                        baglanti.Close();
                        dr.Close();

                    }
                    else
                    {

                        for (int i = 0; i < 1000; i++)
                        {
                            this.Top += 5;
                            this.Left += 5;
                            this.Top -= 5;
                            this.Left -= 5;
                            i++;
                        }
                        MessageBox.Show("ŞİFRE VEYA KULLANİCİ ADI YANLIŞ");
                    }
                }
                
                catch (Exception hata)
                {
                    MessageBox.Show("HATA VAR" + hata);
                }
            }
            

        }
        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            EkleForm();

        }

        private void bunifuThinButton22_MouseDown(object sender, EventArgs e)
        {

        }

        private void Giris_Load(object sender, EventArgs e)
        {

        }
        
            
    
    
    }
    }

