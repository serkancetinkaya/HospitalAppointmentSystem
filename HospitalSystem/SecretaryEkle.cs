using EntityLayer;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalSystem
{
    public partial class SecretaryEkle : Form
    {
        public SecretaryEkle()
        {
            InitializeComponent();
        }

        public int secretaryID;
        public string numberID, firstName, lastName, password, phoneNumber; //Giriş yapan sekreterin bütün bilgilerini saklar

        private void textBoxPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            if (textBoxPhoneNumber.Text.Length == 1)
            {
                if (textBoxPhoneNumber.Text == "0")
                {
                    textBoxPhoneNumber.Text = textBoxPhoneNumber.Text.Substring(1);
                }
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void buttonEkle_Click(object sender, EventArgs e)
        {
            if (textBoxFirstName.Text == "" || textBoxLastName.Text == "" || textBoxNumberID.Text == "" ||
                textBoxPassword.Text == "" || textBoxPhoneNumber.Text == "")
            {
                MessageBox.Show("Eksik alanları doldurmak zorunludur");
            }
            else if (textBoxFirstName.Text == "admin" || textBoxFirstName.Text == "Admin" || textBoxFirstName.Text == "ADMİN" ||
                    textBoxLastName.Text == "admin" || textBoxLastName.Text == "Admin" || textBoxLastName.Text == "ADMİN")
            {
                MessageBox.Show("Admin kullanıcısı oluşturulamaz");
            }
            else if (textBoxNumberID.Text.Length != 11)
            {
                MessageBox.Show("Kimlik numarası 11 haneli olmalıdır.");
            }
            else if (textBoxPhoneNumber.Text.Length != 10)
            {
                MessageBox.Show("Telefon numarası 10 haneli olmalıdır.");
            }
            else if (LogicSecretary.LLSecretaryTCKontrol(textBoxNumberID.Text) == 1 ||
                    LogicDoctor.LLDoctorTCKontrol(textBoxNumberID.Text) == 1 ||
                    LogicDiseased.LLDiseasedTCKontrol(textBoxNumberID.Text) == 1)
            {
                MessageBox.Show("Aynı kimlik numarasına ait kayıt eklenemez");
            }
            else
            {
                EntitySecretary ent = new EntitySecretary();
                ent.FirstName = textBoxFirstName.Text;
                ent.LastName = textBoxLastName.Text;
                ent.NumberID = textBoxNumberID.Text;
                ent.Password = textBoxPassword.Text;
                ent.PhoneNumber = textBoxPhoneNumber.Text;
                LogicSecretary.LLSecretaryEkle(ent);
                MessageBox.Show("Yeni sekreter başarılı şekilde kayıt edilmiştir");

                SecretaryEkran secretaryEkran = new SecretaryEkran();//Sekreterekleyi kapar sekreter ekranı açar

                secretaryEkran.secretaryID = this.secretaryID;
                secretaryEkran.numberID = this.numberID;
                secretaryEkran.firstName = this.firstName;
                secretaryEkran.lastName = this.lastName;
                secretaryEkran.password = this.password;
                secretaryEkran.phoneNumber = this.phoneNumber;

                secretaryEkran.Show();
                this.Close();
            }
        }

        private void buttonGeriDon_Click(object sender, EventArgs e)
        {
            SecretaryEkran secretaryEkran = new SecretaryEkran();

            secretaryEkran.secretaryID = this.secretaryID;
            secretaryEkran.numberID = this.numberID;
            secretaryEkran.firstName = this.firstName;
            secretaryEkran.lastName = this.lastName;
            secretaryEkran.password = this.password;
            secretaryEkran.phoneNumber = this.phoneNumber;

            secretaryEkran.Show();
            this.Close();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBoxNumberID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBoxLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        private void textBoxFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        private void SecretaryEkle_Load(object sender, EventArgs e)
        {
            textBoxNumberID.MaxLength = 11;
            textBoxPhoneNumber.MaxLength = 10;
        }
    }
}
