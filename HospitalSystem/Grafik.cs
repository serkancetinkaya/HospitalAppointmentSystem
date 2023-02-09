using EntityLayer;
using LogicLayer;
using System;
using System.Collections;
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
    public partial class Grafik : Form
    {
        public Grafik()
        {
            InitializeComponent();
        }

        public int secretaryID;
        public string numberID, firstName, lastName, password, phoneNumber; //Giriş yapan sekreterin bütün bilgilerini saklar

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Grafik_Load(object sender, EventArgs e)
        {
            List<EntityBranch> branch = LogicBranch.LLBranchListesi(); //Branş tablosunu comboBox içerisine listeler
            comboBoxBranch.DataSource = null;
            int i = 0;
            while (i < branch.Count)
            {
                comboBoxBranch.Items.Add(branch[i].BranchName);
                i++;
            }

            EntityBranch entityBranch = new EntityBranch();
            string[] bolumler = {"İç Hastalıkları","Kardiyoloji","Göğüs Hastalıkları","Nöroloji","Psikiyatri","Çocuk Hastalıkları"
                    ,"Genel Cerrahi","Üroloji","Kulak Burun Boğaz","Göz Hastalıkları"};
            for (int a=0; a < bolumler.Length; a++)
            {
                entityBranch.BranchName = bolumler[a];
                int sayi = LogicLayer.LogicDoctor.LLBransHastaSayisiCek(entityBranch);
                chart1.Series[bolumler[a]].Points.AddXY(2,sayi);
            }
            comboBoxBranch.SelectedIndex = 0;
            
            
        }

        private void comboBoxBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            chart2.Series.Clear();
            if (comboBoxBranch.Text=="İç Hastalıkları")
            {
                EntityBranch branch = new EntityBranch();
                branch.BranchName = "İç Hastalıkları";
                List<EntityDoctor> adlar = LogicBranch.LLIlgiliBranchDoctorListele(branch);
                int i = 0;
                while (i < adlar.Count)
                {
                    chart2.Series.Add(adlar[i].FirstName+" " + adlar[i].LastName);
                }

            }
            else if (comboBoxBranch.Text == "Kardiyoloji")
            {
                EntityBranch branch = new EntityBranch();
                branch.BranchName = "Kardiyoloji";
                List<EntityDoctor> adlar = LogicBranch.LLIlgiliBranchDoctorListele(branch);
                int i = 0;
                while (i < adlar.Count)
                {
                    chart2.Series.Add(adlar[i].FirstName + " " + adlar[i].LastName);
                    i++;
                }
            }
            else if (comboBoxBranch.Text == "Göğüs Hastalıkları")
            {
                EntityBranch branch = new EntityBranch();
                branch.BranchName = "Göğüs Hastalıkları";
                List<EntityDoctor> adlar = LogicBranch.LLIlgiliBranchDoctorListele(branch);
                int i = 0;
                while (i < adlar.Count)
                {
                    chart2.Series.Add(adlar[i].FirstName + " " + adlar[i].LastName);
                    i++;
                }
            }
            else if (comboBoxBranch.Text == "Nöroloji")
            {
                EntityBranch branch = new EntityBranch();
                branch.BranchName = "Nöroloji";
                List<EntityDoctor> adlar = LogicBranch.LLIlgiliBranchDoctorListele(branch);
                int i = 0;
                while (i < adlar.Count)
                {
                    chart2.Series.Add(adlar[i].FirstName + " " + adlar[i].LastName);
                    i++;
                }
            }
            else if (comboBoxBranch.Text == "Psikiyatri")
            {
                EntityBranch branch = new EntityBranch();
                branch.BranchName = "Psikiyatri";
                List<EntityDoctor> adlar = LogicBranch.LLIlgiliBranchDoctorListele(branch);
                int i = 0;
                while (i < adlar.Count)
                {
                    chart2.Series.Add(adlar[i].FirstName + " " + adlar[i].LastName);
                    i++;
                }
            }
            else if (comboBoxBranch.Text == "Çocuk Hastalıkları")
            {
                EntityBranch branch = new EntityBranch();
                branch.BranchName = "Çocuk Hastalıkları";
                List<EntityDoctor> adlar = LogicBranch.LLIlgiliBranchDoctorListele(branch);
                int i = 0;
                while (i < adlar.Count)
                {
                    chart2.Series.Add(adlar[i].FirstName + " " + adlar[i].LastName);
                    i++;
                }
            }
            else if (comboBoxBranch.Text == "Genel Cerrahi")
            {
                EntityBranch branch = new EntityBranch();
                branch.BranchName = "Genel Cerrahi";
                List<EntityDoctor> adlar = LogicBranch.LLIlgiliBranchDoctorListele(branch);
                int i = 0;
                while (i < adlar.Count)
                {
                    chart2.Series.Add(adlar[i].FirstName + " " + adlar[i].LastName);
                    i++;
                }
            }
            else if (comboBoxBranch.Text == "Üroloji")
            {
                EntityBranch branch = new EntityBranch();
                branch.BranchName = "Üroloji";
                List<EntityDoctor> adlar = LogicBranch.LLIlgiliBranchDoctorListele(branch);
                int i = 0;
                while (i < adlar.Count)
                {
                    chart2.Series.Add(adlar[i].FirstName + " " + adlar[i].LastName);
                    i++;
                }
            }
            else if (comboBoxBranch.Text == "Kulak Burun Boğaz")
            {
                EntityBranch branch = new EntityBranch();
                branch.BranchName = "Kulak Burun Boğaz";
                List<EntityDoctor> adlar = LogicBranch.LLIlgiliBranchDoctorListele(branch);
                int i = 0;
                while (i < adlar.Count)
                {
                    chart2.Series.Add(adlar[i].FirstName + " " + adlar[i].LastName);
                    i++;
                }
            }
            else if (comboBoxBranch.Text == "Göz Hastalıkları")
            {
                EntityBranch branch = new EntityBranch();
                branch.BranchName = "Göz Hastalıkları";
                List<EntityDoctor> adlar = LogicBranch.LLIlgiliBranchDoctorListele(branch);
                int i = 0;
                while (i < adlar.Count)
                {
                    chart2.Series.Add(adlar[i].FirstName + " " + adlar[i].LastName);
                    i++;
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
