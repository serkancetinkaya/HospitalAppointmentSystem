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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace HospitalSystem
{
    public partial class Appointment : Form
    {
        public Appointment()
        {
            InitializeComponent();
        }

        public int secretaryID;
        public string numberID, firstName, lastName, password, phoneNumber; //Giriş yapan sekreterin bütün bilgilerini saklar

        public string branchID;

        private void Appointment_Load(object sender, EventArgs e)
        {
            labelSecretaryAd.Text = firstName + " " + lastName; //labellere giriş yapan sekreterin bilgilerini yazar
            labelSecretaryNumberID.Text = numberID;
            labelSecretaryPhoneNumber.Text = phoneNumber;
            dataGridViewDoctor.Visible = false; //doktor tablosunu form ilk açıldığında görünmez yapar
            label3.Visible = false;

            List<EntityDiseased> diseased = LogicDiseased.LLDiseasedListesi(); //Hastalar tablosunu getirir
            dataGridViewDiseased.DataSource = diseased;

            List<EntityAppointment> appointmentListesi = LogicAppointment.LLAppointmentListesi(); //Randevu tablosunu getirir
            dataGridViewAppointment.DataSource = appointmentListesi;

            List<EntityBranch> branch = LogicBranch.LLBranchListesi(); //Branş tablosunu comboBox içerisine listeler
            comboBoxBranch.DataSource = null;
            int i = 0;
            while (i < branch.Count)
            {
                comboBoxBranch.Items.Add(branch[i].BranchName);
                i++;
            }
        }

        private void dataGridViewDiseased_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Hasta tablosundan hasta seçildiğinde seçilen hastanın ilgili bilgilerini ilgili labellara yazar
            if (e.RowIndex != -1)
            {
                DataGridViewRow datagridvievDiseased = dataGridViewDiseased.Rows[e.RowIndex];
                labelDiseasedID.Text = datagridvievDiseased.Cells[0].Value.ToString();
                labelDiseasedAd.Text = datagridvievDiseased.Cells[2].Value.ToString() + " " + datagridvievDiseased.Cells[3].Value.ToString();
                labelDiseasedNumberID.Text = datagridvievDiseased.Cells[1].Value.ToString();
                labelDiseasedPhoneNumber.Text = datagridvievDiseased.Cells[4].Value.ToString();
                labelDiseasedMail.Text = datagridvievDiseased.Cells[5].Value.ToString();
            }
        }

        private void dataGridViewDoctor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Doktor tablosundan doktor seçildiğinde seçilen doktorun ilgili bilgilerini ilgili labellara yazar
            if (e.RowIndex != -1)
            {
                DataGridViewRow datagridviewDoctor = dataGridViewDoctor.Rows[e.RowIndex];

                EntityBranch branch = LogicBranch.LLIlgiliBranchAdiGetir(Convert.ToInt32(datagridviewDoctor.Cells[6].Value.ToString()));

                labelDoctorID.Text = datagridviewDoctor.Cells[0].Value.ToString();
                labelDoctorAd.Text = datagridviewDoctor.Cells[2].Value.ToString() + " " + datagridviewDoctor.Cells[3].Value.ToString();
                labelDoctorNumberID.Text = datagridviewDoctor.Cells[1].Value.ToString();
                labelDoctorPhoneNumber.Text = datagridviewDoctor.Cells[5].Value.ToString();
                labelDoctorBranch.Text = branch.BranchName;

                this.branchID = datagridviewDoctor.Cells[6].Value.ToString();
            }
        }

        private void dataGridViewAppointment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow datagridviewAppointment = dataGridViewAppointment.Rows[e.RowIndex];

                EntityAppointment appointment = new EntityAppointment();

                EntitySecretary secretary = new EntitySecretary();
                appointment.SecretaryID = Convert.ToInt32(datagridviewAppointment.Cells[1].Value);
                secretary = LogicAppointment.LLAppointmentSecretaryGetir(appointment);

                EntityDoctor doctor = new EntityDoctor();
                appointment.DoctorID = Convert.ToInt32(datagridviewAppointment.Cells[2].Value);
                doctor = LogicAppointment.LLAppointmentDoctorGetir(appointment);

                EntityDiseased diseased = new EntityDiseased();
                appointment.DiseasedID = Convert.ToInt32(datagridviewAppointment.Cells[3].Value);
                diseased = LogicAppointment.LLAppointmentDiseasedGetir(appointment);

                EntityBranch branch = new EntityBranch();
                appointment.BranchID = Convert.ToInt32(datagridviewAppointment.Cells[4].Value);
                branch = LogicAppointment.LLAppointmentBranchGetir(appointment);

                labelAppointmentID.Text = datagridviewAppointment.Cells[0].Value.ToString();
                labelAppointmentSecretaryAd.Text = secretary.FirstName + " " + secretary.LastName;
                labelAppointmentDoctorAd.Text = doctor.FirstName + " " + doctor.LastName;
                labelAppointmentDiseasedAd.Text = diseased.FirstName + " " + diseased.LastName;
                labelAppointmentBranch.Text = branch.BranchName;
                labelAppointmentDate.Text = datagridviewAppointment.Cells[5].Value.ToString();

                textBoxAppointmentID.Text = datagridviewAppointment.Cells[0].Value.ToString();
            }
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBoxBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            EntityBranch branch = new EntityBranch();
            branch.BranchName = comboBoxBranch.Text;
            List<EntityDoctor> doctorListele = LogicBranch.LLIlgiliBranchDoctorListele(branch);
            dataGridViewDoctor.DataSource = doctorListele;
            if (comboBoxBranch.Text.Length > 0)
            {
                dataGridViewDoctor.Visible = true;
                label3.Visible = true;
            }
        }

        private void buttonAppointment_Click(object sender, EventArgs e)
        {
            try
            {
                EntityAppointment appointment = new EntityAppointment();

                appointment.SecretaryID = secretaryID;
                appointment.DoctorID = Convert.ToInt32(labelDoctorID.Text);
                appointment.DiseasedID = Convert.ToInt32(labelDiseasedID.Text);
                appointment.BranchID = Convert.ToInt32(branchID);
                appointment.Date = dateTimePickerAppointment.Value;

                LogicAppointment.LLAppointmentOlustur(appointment);

                List<EntityAppointment> appointmentListesi = LogicAppointment.LLAppointmentListesi();
                dataGridViewAppointment.DataSource = appointmentListesi;

                labelAppointmentID.Text = appointment.AppointmentID.ToString();
                labelAppointmentSecretaryAd.Text = labelSecretaryAd.Text;
                labelAppointmentDoctorAd.Text = labelDoctorAd.Text;
                labelAppointmentDiseasedAd.Text = labelDiseasedAd.Text;
                labelAppointmentBranch.Text = labelDoctorBranch.Text;
                labelAppointmentDate.Text = dateTimePickerAppointment.Value.ToString();

                MessageBox.Show("Yeni Randevu başarıyla kayıt edilmiştir");
            }
            catch
            {
                MessageBox.Show("Lütfen Doktor ve Hasta seçiniz");
            }
        }

        private void buttonRandevuSil_Click(object sender, EventArgs e)
        {
            if (textBoxAppointmentID.Text.Length == 0)
            {
                MessageBox.Show("Silmek için bir randevu seçiniz");
            }
            else
            {
                EntityAppointment appointment = new EntityAppointment();
                appointment.AppointmentID = Convert.ToInt32(textBoxAppointmentID.Text);

                if (LogicAppointment.LLAppointmentSil(appointment.AppointmentID) == true)
                {
                    LogicAppointment.LLAppointmentSil(appointment.AppointmentID);
                    MessageBox.Show("Randevu başarıyla silinmiştir");
                    textBoxAppointmentID.Clear();

                    List<EntityAppointment> appointmentList = LogicAppointment.LLAppointmentListesi();
                    dataGridViewAppointment.DataSource = appointmentList;
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
    }
}
