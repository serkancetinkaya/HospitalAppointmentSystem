using EntityLayer;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace HospitalSystem
{
    public partial class DoctorEkran : Form
    {
        public DoctorEkran()
        {
            InitializeComponent();
        }

        public string numberID, firstName, lastName, password, phoneNumber;
        public int doctorID, branchID;

        private void buttonKaydet_Click(object sender, EventArgs e)
        {
            if (textBoxDiseasedID.Text == "" || textBoxFirstName.Text == "" || textBoxPhoneNumber.Text == "" ||
                textBoxMail.Text == "" || textBoxDoctorResult.Text == "" || textBoxTahlilResult.Text == "")
            {
                MessageBox.Show("Eksik alanları doldurmak zorunludur");
            }
            else
            {
                EntityResult ent = new EntityResult();

                ent.AppointmentID = Convert.ToInt32(textBoxAppointmentID.Text);
                ent.DoctorID = this.doctorID;
                ent.DiseasedID = Convert.ToInt32(textBoxDiseasedID.Text);
                ent.DoctorResult = textBoxDoctorResult.Text;
                ent.TestResult = textBoxTahlilResult.Text;
                ent.Date = dateTimePicker1.Value;

                LogicResult.LLResultEkle(ent);
                MessageBox.Show("Yeni doktor sonucu başarılı şekilde kayıt edilmiştir. Randevu listesinden kaldırılıyor.");

                List<EntityResult> result = LogicResult.LLIlgiliDoctorResultListesi(doctorID);
                dataGridViewResult.DataSource = result;

                LogicResult.LLResultAppointmentSil(ent.AppointmentID);

                List<EntityAppointment> appointment = LogicResult.LLIlgiliDoctorAppointmentListesi(doctorID);
                dataGridViewAppointment.DataSource = appointment;

                textBoxDiseasedID.Clear();
                textBoxFirstName.Clear();
                textBoxPhoneNumber.Clear();
                textBoxMail.Clear();
                textBoxDoctorResult.Clear();
                textBoxTahlilResult.Clear();
            }
        }

        private void buttonMailGonder_Click(object sender, EventArgs e)
        {
            if (textBoxDoctorResult2.Text == "" || textBoxTahlilResult2.Text == "")
            {
                MessageBox.Show("Lütfen mail göndermek istediğiniz randevu sonucunu seçiniz");
            }
            else
            {
                try
                {
                    EntityBranch branch = LogicBranch.LLIlgiliBranchAdiGetir(branchID);

                    MailMessage mail = new MailMessage();
                    SmtpClient istemci = new SmtpClient();
                    istemci.Credentials = new System.Net.NetworkCredential("gorselprogramlamaduzce@outlook.com", "Duzce_81");
                    istemci.Port = 587;
                    istemci.Host = "smtp-mail.outlook.com";
                    istemci.EnableSsl = true;
                    mail.To.Add(labelMail.Text);
                    mail.From = new MailAddress("gorselprogramlamaduzce@outlook.com");
                    mail.Subject = "Hasta Randevu Sonuçları, Randevu Tarihi: " + dateTimePicker2.Value.ToString();
                    mail.Body = "Doktor Adı: " + firstName + " " + lastName + "\n\nBölüm: " + branch.BranchName + "\n\nDoktor Görüşleri: " + textBoxDoctorResult2.Text + "\n\nTahlil Sonuçları: " + textBoxTahlilResult2.Text;
                    istemci.Send(mail);

                    MessageBox.Show("Mail hastaya başarı ile gönderilmiştir");
                }
                catch
                {
                    MessageBox.Show("Mail Gönderilemedi. Lütfen internet bağlantınızı kontrol ediniz");
                }
            }
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonPDFIndir_Click(object sender, EventArgs e)
        {
            if (textBoxDoctorResult3.Text != "" && textBoxTahlilResult3.Text != "")
            {
                string pdfstring = "Hastanın Adı Soyadı: " + labelDiseasedName2.Text + Environment.NewLine + "Doktor Adı Soyadı:  " + labelDoctorName.Text + Environment.NewLine + Environment.NewLine + label5.Text
                    + Environment.NewLine + Environment.NewLine + "Doktor Sonucu: " + textBoxDoctorResult3.Text + Environment.NewLine + Environment.NewLine + "Tahlil Sonucu: "
                    + textBoxTahlilResult3.Text + Environment.NewLine + Environment.NewLine + "Tarih: " + dateTimePicker3.Value.ToString();


                SaveFileDialog file = new SaveFileDialog();
                file.Filter = "PDF DOSYALARI(*.pdf) | *.pdf";
                file.Title = "PDF DOSYASI OLUŞTURMA";
                file.FileName = labelDiseasedName2.Text + " Hastane Raporu " + DateTime.Now.ToString("MM/dd/yyyy");
                if (file.ShowDialog() == DialogResult.OK)
                {
                    FileStream dosya = File.Open(file.FileName, FileMode.Create);
                    Document pdf = new Document();
                    PdfWriter.GetInstance(pdf, dosya);
                    pdf.Open();
                    pdf.AddAuthor(labelDoctorName.Text);
                    pdf.AddCreator(labelDoctorName.Text);
                    pdf.AddTitle(labelDoctorName.Text);
                    pdf.AddSubject(labelDoctorName.Text + "_Rapor");
                    pdf.AddKeywords(labelDoctorName.Text + "_Rapor");
                    pdf.AddCreationDate();
                    BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, "CP1254", BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 15, iTextSharp.text.Font.NORMAL);
                    Paragraph paragraph = new Paragraph(pdfstring, font);
                    pdf.Add(paragraph);
                    pdf.Close();
                    MessageBox.Show("Pdf başarıyla kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir hasta seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonGeriDon_Click(object sender, EventArgs e)
        {
            DoctorGiris doctorGiris = new DoctorGiris();
            MessageBox.Show("Güvenli çıkış yapıldı");
            doctorGiris.Show();
            this.Close();
        }

        private void dataGridViewResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow datagridwievResult = dataGridViewResult.Rows[e.RowIndex];

                EntityDiseased diseased = LogicResult.LLResultDiseasedGetir(Convert.ToInt32(datagridwievResult.Cells[3].Value));

                labelDiseasedName.Text = diseased.FirstName + " " + diseased.LastName;
                labelPhoneNumber.Text = diseased.PhoneNumber;
                labelMail.Text = diseased.Mail;
                textBoxDoctorResult2.Text = datagridwievResult.Cells[4].Value.ToString();
                textBoxTahlilResult2.Text = datagridwievResult.Cells[5].Value.ToString();
                dateTimePicker2.Text = datagridwievResult.Cells[6].Value.ToString();

                labelAppointmentID.Text = datagridwievResult.Cells[1].Value.ToString();
                labelDiseasedName2.Text = labelDiseasedName.Text;
                labelDoctorName.Text = firstName + " " + lastName;
                textBoxDoctorResult3.Text = datagridwievResult.Cells[4].Value.ToString();
                textBoxTahlilResult3.Text = datagridwievResult.Cells[5].Value.ToString();
                dateTimePicker3.Text = datagridwievResult.Cells[6].Value.ToString();
            }
        }

        private void dataGridViewAppointment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow datagridwievAppointment = dataGridViewAppointment.Rows[e.RowIndex];

                EntityDiseased diseased = LogicResult.LLResultDiseasedGetir(Convert.ToInt32(datagridwievAppointment.Cells[3].Value));

                textBoxDiseasedID.Text = datagridwievAppointment.Cells[3].Value.ToString();
                textBoxFirstName.Text = diseased.FirstName + " " + diseased.LastName;
                textBoxPhoneNumber.Text = diseased.PhoneNumber;
                textBoxMail.Text = diseased.Mail;
                dateTimePicker1.Text = datagridwievAppointment.Cells[5].Value.ToString();
                textBoxAppointmentID.Text = datagridwievAppointment.Cells[0].Value.ToString();

                textBoxDoctorResult.Enabled = true;
                textBoxTahlilResult.Enabled = true;
            }
        }

        private void DoctorEkran_Load(object sender, EventArgs e)
        {
            EntityBranch branch = LogicBranch.LLIlgiliBranchAdiGetir(branchID);

            label1.Text = "Hoşgeldin " + firstName + " " + lastName;
            label2.Text = "Kullanıcı ID: " + doctorID.ToString();
            label3.Text = "Kimlik Numarası: " + numberID;
            label4.Text = "Telefon Numarası: " + phoneNumber;
            label5.Text = "Branşı: " + branch.BranchName;

            textBoxPhoneNumber.MaxLength = 10;

            List<EntityAppointment> appointment = LogicResult.LLIlgiliDoctorAppointmentListesi(doctorID);
            dataGridViewAppointment.DataSource = appointment;

            List<EntityResult> result = LogicResult.LLIlgiliDoctorResultListesi(doctorID);
            dataGridViewResult.DataSource = result;

            textBoxDoctorResult.Enabled = false;
            textBoxTahlilResult.Enabled = false;
        }


    }
}
