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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HospitalSystem
{
    public partial class SecretaryGiris : Form
    {
        public SecretaryGiris()
        {
            InitializeComponent();
        }

        private void SecretaryGiris_Load(object sender, EventArgs e)
        {
            textBoxNumberID.MaxLength = 11;
            pictureBoxEye.Visible = false;
            textBoxPassword.UseSystemPasswordChar = true;
        }

        private void textBoxNumberID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }   

        private void buttonGirisYap_Click(object sender, EventArgs e)
        {
            EntitySecretary ent = new EntitySecretary();
            ent.NumberID = textBoxNumberID.Text;
            ent.Password = textBoxPassword.Text;

            if (textBoxNumberID.Text == "" || textBoxPassword.Text == "")
            {
                MessageBox.Show("Kimlik numarası ya da şifre alanı boş bırakılamaz");
            }
            else if (textBoxNumberID.Text.Length < 11)
            {
                MessageBox.Show("Kimlik Numarası 11 Haneli Olmalıdır");
            }
            else
            {
                if (LogicSecretary.LLSecretaryGiris(ent) == 1)
                {
                    MessageBox.Show("Giriş Başarılı");
                    SecretaryEkran secretaryEkran = new SecretaryEkran();
                    EntitySecretary secretary = LogicSecretary.LLSecretaryBilgiTut(ent);

                    secretaryEkran.secretaryID = secretary.SecretaryID;
                    secretaryEkran.numberID = secretary.NumberID;
                    secretaryEkran.firstName = secretary.FirstName;
                    secretaryEkran.lastName = secretary.LastName;
                    secretaryEkran.phoneNumber = secretary.PhoneNumber;

                    secretaryEkran.Show();
                    this.Hide();
                }
                else if (LogicSecretary.LLSecretaryGiris(ent) == 2)
                {
                    MessageBox.Show("Kimlik Numaranız ya da şifreniz hatalıdır. Lütfen kimlik numaranızı ya da şifrenizi kontrol ediniz.");
                }
            }
        }

        private void linkLabelDoctorGiris_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DoctorGiris doctorGiris = new DoctorGiris();
            doctorGiris.Show();
            this.Hide();
        }

        private void pictureBoxEye_Click(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = true;
            pictureBoxEye.Hide();
            pictureBoxHide.Show();
        }

        private void pictureBoxHide_Click(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = false;
            pictureBoxHide.Hide();
            pictureBoxEye.Show();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
