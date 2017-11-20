using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmlakProje
{
    public partial class KullaniciBilgileri : Form
    {
        public KullaniciBilgileri()
        {
            InitializeComponent();
        }
        
        static string baglantiTxt = "Data Source=TUGRUL\\SQLEXPRESS;Initial Catalog=Emlak;Integrated Security=True";
        SqlConnection baglanti = new SqlConnection(baglantiTxt);
        public void BilgiGetir(TextBox txtNick, TextBox txtTelefon, TextBox txtMail, TextBox txtSifre)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
                try
                {
                    string komutBilgi = "SELECT KullaniciNick,Telefon,KullaniciMail,KullaniciSifre FROM Kullanicilar";
                    SqlCommand komutKullanici = new SqlCommand(komutBilgi, baglanti);
                    komutKullanici.ExecuteNonQuery();
                    SqlDataReader rdKbilgi = komutKullanici.ExecuteReader();
                    if (rdKbilgi.Read())
                    {
                        txtNick.Text = rdKbilgi[0].ToString();
                        txtTelefon.Text = rdKbilgi[1].ToString();
                        txtMail.Text = rdKbilgi[2].ToString();
                        txtSifre.Text = rdKbilgi[3].ToString();
                        baglanti.Close();
                        rdKbilgi.Close();
                    }
                }
                catch (Exception hata)
                {

                    MessageBox.Show(hata.ToString());;
                }
            }
        }
        private void KullaniciBilgileri_Load(object sender, EventArgs e)
        {
            BilgiGetir(kadiTxt, telTxt, mailTxt, sifreTxt);
            
        }
        Giris giris = new Giris();
        private void onaylaBtn_Click(object sender, EventArgs e)
        {
            
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
                try
                {
                    string guncellekmt = "UPDATE Kullanicilar SET KullaniciNick=@kadi, Telefon=@telefon,KullaniciMail=@mail,KullaniciSifre=@sifre WHERE KullaniciID=@kID";
                    SqlCommand guncelleKomut = new SqlCommand(guncellekmt, baglanti);
                    guncelleKomut.Parameters.AddWithValue("@kadi", kadiTxt.Text);
                    guncelleKomut.Parameters.AddWithValue("@telefon", telTxt.Text);
                    guncelleKomut.Parameters.AddWithValue("@mail", mailTxt.Text);
                    guncelleKomut.Parameters.AddWithValue("@sifre", sifreTxt.Text);
                    guncelleKomut.Parameters.AddWithValue("@kID", label1.Text);
                    guncelleKomut.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("BİLGİLER GÜNCELLENDİ");
                    this.Close();
                }
                catch (Exception hata2)
                {

                    MessageBox.Show(hata2.ToString());
                }
            }
        }
    }
}
