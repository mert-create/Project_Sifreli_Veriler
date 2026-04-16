using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Project_Sıfrelı_Verıler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=DbTest;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");

        void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT*FROM TBLVERILER",baglantı);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource=dt;
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            string ad = txtAd.Text;
            byte[] addizi=ASCIIEncoding.ASCII.GetBytes(ad);
            string adsifre = Convert.ToBase64String(addizi);

            
            string soyad =txtSoyad.Text;
            byte[] soyaddizi = ASCIIEncoding.ASCII.GetBytes(ad);
            string soyadsıfre = Convert.ToBase64String(soyaddizi);


            string mail = txtMaıl.Text;
            byte[] maildizi = ASCIIEncoding.ASCII.GetBytes(mail);
            string mailsıfre = Convert.ToBase64String(maildizi);


            string sifre = txtSıfre.Text;
            byte[] sifredizi = ASCIIEncoding.ASCII.GetBytes(sifre);
            string sifresifre = Convert.ToBase64String(sifredizi);


            string hesapno = txtHesapNo.Text;
            byte[] hesapdizi = ASCIIEncoding.ASCII.GetBytes(hesapno);
            string hesapsifre = Convert.ToBase64String(hesapdizi);

            baglantı.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO TBLVERILER (AD,SOYAD,MAIL,SIFRE,HESAPNO) VALUES (@p1,@p2,@p3,@p4,@p5)", baglantı);
            komut.Parameters.AddWithValue("@p1", adsifre);
            komut.Parameters.AddWithValue("@p2", soyadsıfre);
            komut.Parameters.AddWithValue("@p3", mailsıfre);
            komut.Parameters.AddWithValue("@p4", sifresifre);
            komut.Parameters.AddWithValue("@p5", hesapsifre);
            komut.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Veriler Eklendi");

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Adcozum = txtAd.Text;
            byte[] Adcozumdizi =Convert.FromBase64String(Adcozum);
            string Adverısı =ASCIIEncoding.ASCII.GetString(Adcozumdizi);
            label6.Text=Adverısı;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }
    }
}
