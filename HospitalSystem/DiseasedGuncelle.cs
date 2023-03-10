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
    public partial class DiseasedGuncelle : Form
    {
        public DiseasedGuncelle()
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

        private void textBoxDiseasedID_TextChanged(object sender, EventArgs e)
        {
            if (textBoxDiseasedID.Text.Length > 0)
            {
                EntityDiseased ent = new EntityDiseased();
                ent.DiseasedID = Convert.ToInt32(textBoxDiseasedID.Text);
                EntityDiseased diseasedList = LogicDiseased.LLDiseasedGuncelleHastaListele(ent);
                textBoxFirstName.Text = diseasedList.FirstName;
                textBoxLastName.Text = diseasedList.LastName;
                textBoxPhoneNumber.Text = diseasedList.PhoneNumber;
                textBoxMail.Text = diseasedList.Mail;
            }
            else
            {
                textBoxFirstName.Clear();
                textBoxLastName.Clear();
                textBoxPhoneNumber.Clear();
                textBoxMail.Clear();
            }
        }

        private void buttonGuncelle_Click(object sender, EventArgs e)
        {
            if (textBoxDiseasedID.Text == "")
            {
                MessageBox.Show("Lütfen ID numarası giriniz");
            }
            else if (textBoxPhoneNumber.Text.Length != 10)
            {
                MessageBox.Show("Telefon numarası 10 haneli olmalıdır");
            }
            else
            {
                EntityDiseased ent = new EntityDiseased();
                ent.DiseasedID = Convert.ToInt32(textBoxDiseasedID.Text);
                ent.FirstName = textBoxFirstName.Text;
                ent.LastName = textBoxLastName.Text;
                ent.PhoneNumber = textBoxPhoneNumber.Text;
                ent.Mail = textBoxMail.Text;

                if (LogicDiseased.LLDiseasedGuncelle(ent) == true)
                {
                    LogicDiseased.LLDiseasedGuncelle(ent);
                    MessageBox.Show("Hasta başarıyla güncellenmiştir");
                    this.Close();

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
                else if (LogicDiseased.LLDiseasedGuncelle(ent) == false)
                {
                    MessageBox.Show("Girilen ID numarasına tanımlı hasta bulunamadı");
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

        private void textBoxDiseasedID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void DiseasedGuncelle_Load(object sender, EventArgs e)
        {
            textBoxDiseasedID.MaxLength = 5;
            textBoxPhoneNumber.MaxLength = 10;
            textBoxMail.MaxLength = 50;

            List<EntityDiseased> diseased = LogicDiseased.LLDiseasedListesi();
            dataGridViewDiseased.DataSource = diseased;
        }
    }
}
