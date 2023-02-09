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
    public partial class DoctorGuncelle : Form
    {
        public DoctorGuncelle()
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

        private void textBoxBranchID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBoxDoctorID_TextChanged(object sender, EventArgs e)
        {
            if (textBoxDoctorID.Text.Length > 0)
            {
                EntityDoctor ent = new EntityDoctor();
                ent.DoctorID = Convert.ToInt32(textBoxDoctorID.Text);
                EntityDoctor doctorList = LogicDoctor.LLDoctorGuncellePersonelListele(ent);
                textBoxFirstName.Text = doctorList.FirstName;
                textBoxLastName.Text = doctorList.LastName;
                textBoxPhoneNumber.Text = doctorList.PhoneNumber;
                textBoxPassword.Text = doctorList.Password;
                textBoxBranchID.Text = Convert.ToString(doctorList.BranchID);
            }
            else
            {
                textBoxFirstName.Clear();
                textBoxLastName.Clear();
                textBoxPhoneNumber.Clear();
                textBoxPassword.Clear();
                textBoxBranchID.Clear();
            }
        }

        private void dataGridViewBranch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow datagridwievBranch = dataGridViewBranch.Rows[e.RowIndex];
                textBoxBranchID.Text = datagridwievBranch.Cells[0].Value.ToString();
            }
        }

        private void buttonGuncelle_Click(object sender, EventArgs e)
        {
            if (textBoxDoctorID.Text == "")
            {
                MessageBox.Show("Lütfen ID numarası giriniz");
            }
            else if (textBoxPhoneNumber.Text.Length != 10)
            {
                MessageBox.Show("Telefon numarası 10 haneli olmalıdır.");
            }
            else
            {
                EntityDoctor ent = new EntityDoctor();
                ent.DoctorID = Convert.ToInt32(textBoxDoctorID.Text);
                ent.FirstName = textBoxFirstName.Text;
                ent.LastName = textBoxLastName.Text;
                ent.PhoneNumber = textBoxPhoneNumber.Text;
                ent.Password = textBoxPassword.Text;
                ent.BranchID = Convert.ToInt32(textBoxBranchID.Text);

                if (LogicDoctor.LLDoctorGuncelle(ent) == true)
                {
                    LogicDoctor.LLDoctorGuncelle(ent);
                    MessageBox.Show("Doktor başarıyla güncellenmiştir");

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
                else if (LogicDoctor.LLDoctorGuncelle(ent) == false)
                {
                    MessageBox.Show("Girilen ID numarasına tanımlı doktor bulunamadı");
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

        private void textBoxDoctorID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBoxFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        private void DoctorGuncelle_Load(object sender, EventArgs e)
        {
            textBoxDoctorID.MaxLength = 5;
            textBoxPhoneNumber.MaxLength = 10;
            textBoxBranchID.MaxLength = 2;

            List<EntityBranch> branch = LogicBranch.LLBranchListesi();
            dataGridViewBranch.DataSource = branch;

            List<EntityDoctor> doctor = LogicDoctor.LLDoctorListesi();
            dataGridViewDoctor.DataSource = doctor;
        }
    }
}
