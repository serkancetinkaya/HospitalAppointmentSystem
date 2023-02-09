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
    public partial class SecretaryGuncelle : Form
    {
        public SecretaryGuncelle()
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

        private void textBoxSecretaryID_TextChanged(object sender, EventArgs e)
        {
            if (textBoxSecretaryID.Text.Length > 0)
            {
                EntitySecretary ent = new EntitySecretary();
                ent.SecretaryID = Convert.ToInt32(textBoxSecretaryID.Text);
                EntitySecretary secretaryList = LogicSecretary.LLSecretaryGuncellePersonelListele(ent);
                textBoxFirstName.Text = secretaryList.FirstName;
                textBoxLastName.Text = secretaryList.LastName;
                textBoxPhoneNumber.Text = secretaryList.PhoneNumber;
                textBoxPassword.Text = secretaryList.Password;
            }
            else
            {
                textBoxFirstName.Clear();
                textBoxLastName.Clear();
                textBoxPhoneNumber.Clear();
                textBoxPassword.Clear();
            }
        }

        private void buttonGuncelle_Click(object sender, EventArgs e)
        {
            if (textBoxSecretaryID.Text == "")
            {
                MessageBox.Show("Lütfen ID numarası giriniz");
            }
            else if (textBoxFirstName.Text == "admin" || textBoxFirstName.Text == "Admin" || textBoxFirstName.Text == "ADMİN")
            {
                MessageBox.Show("Admin kullanıcısı güncellenemez");
            }
            else if (textBoxPhoneNumber.Text.Length != 10)
            {
                MessageBox.Show("Telefon numarası 10 haneli olmalıdır.");
            }
            else
            {
                EntitySecretary ent = new EntitySecretary();
                ent.SecretaryID = Convert.ToInt32(textBoxSecretaryID.Text);
                ent.FirstName = textBoxFirstName.Text;
                ent.LastName = textBoxLastName.Text;
                ent.PhoneNumber = textBoxPhoneNumber.Text;
                ent.Password = textBoxPassword.Text;

                if (LogicSecretary.LLSecretaryGuncelle(ent) == true)
                {
                    LogicSecretary.LLSecretaryGuncelle(ent);
                    MessageBox.Show("Sekreter başarıyla güncellenmiştir");
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
                else if (LogicSecretary.LLSecretaryGuncelle(ent) == false)
                {
                    MessageBox.Show("Girilen ID numarasına tanımlı sekreter bulunamadı");
                }

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

        private void textBoxLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        private void textBoxFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        private void textBoxSecretaryID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void SecretaryGuncelle_Load(object sender, EventArgs e)
        {
            textBoxSecretaryID.MaxLength = 5;
            textBoxPhoneNumber.MaxLength = 10;

            List<EntitySecretary> secretary = LogicSecretary.LLSecreterListesi();
            dataGridViewSecretary.DataSource = secretary;
        }
    }
}
