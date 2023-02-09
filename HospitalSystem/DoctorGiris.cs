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
    public partial class DoctorGiris : Form
    {
        public DoctorGiris()
        {
            InitializeComponent();
        }

        private void DoctorGiris_Load(object sender, EventArgs e)
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
            EntityDoctor ent = new EntityDoctor();
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
                if (LogicDoctor.LLDoctorGiris(ent) == 1)
                {
                    MessageBox.Show("Giriş Başarılı");
                    DoctorEkran doctorEkran = new DoctorEkran();
                    EntityDoctor doctor = LogicDoctor.LLDoctorBilgiTut(ent);

                    doctorEkran.doctorID = doctor.DoctorID;
                    doctorEkran.numberID = doctor.NumberID;
                    doctorEkran.firstName = doctor.FirstName;
                    doctorEkran.lastName = doctor.LastName;
                    doctorEkran.phoneNumber = doctor.PhoneNumber;
                    doctorEkran.branchID = doctor.BranchID;

                    doctorEkran.Show();
                    this.Hide();

                }
                else if (LogicDoctor.LLDoctorGiris(ent) == 2)
                {
                    MessageBox.Show("Kimlik Numaranız ya da şifreniz hatalıdır. Lütfen kimlik numaranızı ya da şifrenizi kontrol ediniz.");
                }
            }
        }

        private void buttonGeriDon_Click(object sender, EventArgs e)
        {
            SecretaryGiris secretaryGiris = new SecretaryGiris();
            secretaryGiris.Show();
            this.Close();
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
