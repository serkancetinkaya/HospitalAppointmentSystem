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
    public partial class SecretaryEkran : Form
    {
        public SecretaryEkran()
        {
            InitializeComponent();
        }

        public int secretaryID;
        public string numberID, firstName, lastName, password, phoneNumber; //Giriş yapan sekreterin bütün bilgilerini saklar

        private void buttonSecretaryEkle_Click(object sender, EventArgs e)
        {
            SecretaryEkle sekreterEkle = new SecretaryEkle(); //sekreter ekranı kapar sekreter ekleyi açar.ss

            sekreterEkle.secretaryID = this.secretaryID;
            sekreterEkle.numberID = this.numberID;
            sekreterEkle.firstName = this.firstName;
            sekreterEkle.lastName = this.lastName;
            sekreterEkle.password = this.password;
            sekreterEkle.phoneNumber = this.phoneNumber;

            sekreterEkle.Show();
            this.Close();//Hide saklar formu kapatmaz o yüzden tekrar açınca form yeniden açılmış gibi davranmaz.
                         //Close tamamen kapatır tekrar açılınca tekrar yüklenmiş gibi gösterir.
        }
        private void buttonDoctorEkle_Click(object sender, EventArgs e)
        {
            DoctorEkle doctorEkle = new DoctorEkle();

            doctorEkle.secretaryID = this.secretaryID;
            doctorEkle.numberID = this.numberID;
            doctorEkle.firstName = this.firstName;
            doctorEkle.lastName = this.lastName;
            doctorEkle.password = this.password;
            doctorEkle.phoneNumber = this.phoneNumber;

            doctorEkle.Show();
            this.Close();
        }
        private void buttonDiseasedEkle_Click(object sender, EventArgs e)
        {
            DiseasedEkle diseasedEkle = new DiseasedEkle();

            diseasedEkle.secretaryID = this.secretaryID;
            diseasedEkle.numberID = this.numberID;
            diseasedEkle.firstName = this.firstName;
            diseasedEkle.lastName = this.lastName;
            diseasedEkle.password = this.password;
            diseasedEkle.phoneNumber = this.phoneNumber;

            diseasedEkle.Show();
            this.Close();
        }

        private void buttonSecretarySil_Click(object sender, EventArgs e)
        {
            if (textBoxSecretarySil.Text == "1")
            {
                MessageBox.Show("Admin kullanıcısı silinemez");
                textBoxSecretarySil.Clear();
            }
            else if (textBoxSecretarySil.Text == "")
            {
                MessageBox.Show("Sekreter numarası giriniz");
            }
            else
            {
                EntitySecretary ent = new EntitySecretary();
                ent.SecretaryID = Convert.ToInt32(textBoxSecretarySil.Text);

                if (LogicSecretary.LLSecretarySil(ent.SecretaryID) == true)
                {
                    LogicSecretary.LLSecretarySil(ent.SecretaryID);
                    MessageBox.Show("Sekreter başarıyla silinmiştir");
                    textBoxSecretarySil.Clear();

                    List<EntitySecretary> secretary = LogicSecretary.LLSecreterListesi();
                    dataGridViewSecretary.DataSource = secretary;
                }
                else if (LogicSecretary.LLSecretarySil(ent.SecretaryID) == false)
                {
                    MessageBox.Show("İlgili sekreter bulunamadı");
                    textBoxSecretarySil.Clear();
                }
            }
        }
        private void buttonDoctorSil_Click(object sender, EventArgs e)
        {
            if (textBoxDoctorSil.Text == "")
            {
                MessageBox.Show("Doktor numarası giriniz");
            }
            else
            {
                EntityDoctor ent = new EntityDoctor();
                ent.DoctorID = Convert.ToInt32(textBoxDoctorSil.Text);

                if (LogicDoctor.LLDoctorSil(ent.DoctorID) == true)
                {
                    LogicDoctor.LLDoctorSil(ent.DoctorID);
                    MessageBox.Show("Doktor başarıyla silinmiştir");
                    textBoxDoctorSil.Clear();

                    List<EntityDoctor> doctor = LogicDoctor.LLDoctorListesi();
                    dataGridViewDoctor.DataSource = doctor;
                }
                else if (LogicDoctor.LLDoctorSil(ent.DoctorID) == false)
                {
                    MessageBox.Show("İlgili doktor bulunamadı");
                    textBoxDoctorSil.Clear();
                }
            }
        }
        private void buttonDiseasedSil_Click(object sender, EventArgs e)
        {
            if (textBoxDiseasedSil.Text == "")
            {
                MessageBox.Show("Hasta numarası giriniz");
            }
            else
            {
                EntityDiseased ent = new EntityDiseased();
                ent.DiseasedID = Convert.ToInt32(textBoxDiseasedSil.Text);

                if (LogicDiseased.LLDiseasedSil(ent.DiseasedID) == true)
                {
                    LogicDiseased.LLDiseasedSil(ent.DiseasedID);
                    MessageBox.Show("Hasta başarıyla silinmiştir");
                    textBoxDiseasedSil.Clear();

                    List<EntityDiseased> diseased = LogicDiseased.LLDiseasedListesi();
                    dataGridViewDiseased.DataSource = diseased;
                }
                else if (LogicDiseased.LLDiseasedSil(ent.DiseasedID) == false)
                {
                    MessageBox.Show("İlgili hasta bulunamadı");
                    textBoxDiseasedSil.Clear();
                }
            }
        }

        private void buttonSecretaryGuncelle_Click(object sender, EventArgs e)
        {
            SecretaryGuncelle secretaryGuncelle = new SecretaryGuncelle();

            secretaryGuncelle.secretaryID = this.secretaryID;
            secretaryGuncelle.numberID = this.numberID;
            secretaryGuncelle.firstName = this.firstName;
            secretaryGuncelle.lastName = this.lastName;
            secretaryGuncelle.password = this.password;
            secretaryGuncelle.phoneNumber = this.phoneNumber;

            secretaryGuncelle.Show();
            this.Close();
        }
        private void buttonDoctorGuncelle_Click(object sender, EventArgs e)
        {
            DoctorGuncelle doctorGuncelle = new DoctorGuncelle();

            doctorGuncelle.secretaryID = this.secretaryID;
            doctorGuncelle.numberID = this.numberID;
            doctorGuncelle.firstName = this.firstName;
            doctorGuncelle.lastName = this.lastName;
            doctorGuncelle.password = this.password;
            doctorGuncelle.phoneNumber = this.phoneNumber;

            doctorGuncelle.Show();
            this.Close();
        }
        private void buttonDiseasedGuncelle_Click(object sender, EventArgs e)
        {
            DiseasedGuncelle diseasedGuncelle = new DiseasedGuncelle();

            diseasedGuncelle.secretaryID = this.secretaryID;
            diseasedGuncelle.numberID = this.numberID;
            diseasedGuncelle.firstName = this.firstName;
            diseasedGuncelle.lastName = this.lastName;
            diseasedGuncelle.password = this.password;
            diseasedGuncelle.phoneNumber = this.phoneNumber;

            diseasedGuncelle.Show();
            this.Close();
        }

        private void buttonRandevuOlustur_Click(object sender, EventArgs e)
        {
            Appointment appointment = new Appointment();

            appointment.secretaryID = this.secretaryID;
            appointment.numberID = this.numberID;
            appointment.firstName = this.firstName;
            appointment.lastName = this.lastName;
            appointment.password = this.password;
            appointment.phoneNumber = this.phoneNumber;

            appointment.Show();
            this.Close();
        }
        private void buttonGeriDon_Click(object sender, EventArgs e)
        {
            SecretaryGiris secretaryGiris = new SecretaryGiris();
            MessageBox.Show("Güvenli çıkış yapıldı");
            secretaryGiris.Show();
            this.Close();
        }
        private void buttonGrafik_Click(object sender, EventArgs e)
        {
            Grafik grafik = new Grafik();

            grafik.secretaryID = this.secretaryID;
            grafik.numberID = this.numberID;
            grafik.firstName = this.firstName;
            grafik.lastName = this.lastName;
            grafik.password = this.password;
            grafik.phoneNumber = this.phoneNumber;

            grafik.Show();
            this.Close();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBoxDiseasedSil_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void textBoxDoctorSil_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void textBoxSecretarySil_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void SecretaryEkran_Load(object sender, EventArgs e)
        {
            label1.Text = "Hoşgeldin " + firstName + " " + lastName;
            label2.Text = "Kullanıcı ID: " + secretaryID.ToString();
            label3.Text = "Kimlik Numarası: " + numberID;
            label4.Text = "Telefon Numarası: " + phoneNumber;

            textBoxSecretarySil.MaxLength = 5;
            textBoxDoctorSil.MaxLength = 5;
            textBoxDiseasedSil.MaxLength = 5;

            List<EntitySecretary> secretary = LogicSecretary.LLSecreterListesi();
            dataGridViewSecretary.DataSource = secretary;

            List<EntityDoctor> doctor = LogicDoctor.LLDoctorListesi();
            dataGridViewDoctor.DataSource = doctor;

            List<EntityDiseased> diseased = LogicDiseased.LLDiseasedListesi();
            dataGridViewDiseased.DataSource = diseased;
        }
    }
}
