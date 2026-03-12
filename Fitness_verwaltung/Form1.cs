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

namespace Fitness_verwaltung
{
    public partial class Form1 : Form
    {
        FitnessEntities daten = new FitnessEntities();
        public Form1()
        {
           
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            tbl_mitgliedschaftBindingSource.DataSource = daten.tbl_mitgliedschaft.ToList();
            tbl_kurseBindingSource.DataSource = daten.tbl_kurse.ToList();
            tbl_zahlungBindingSource.DataSource = daten.tbl_zahlung.ToList();
            tbl_mitgliederBindingSource.DataSource = daten.tbl_mitglieder.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Test2
            // 1. Bei einem gesuchten Mitglied können die Mitgliedschaftsarten verwaltet werden - Phil
            List<tbl_mitgliedschaft> gefunden = new List<tbl_mitgliedschaft>();

            string search = textBox1.Text;

            foreach (var item in daten.tbl_mitglieder)
            {
                if (item.Vorname.ToLower().Contains(search.ToLower()))
                {
                    gefunden.Add(item.tbl_mitgliedschaft);
                }
            }
            tbl_mitgliedschaftBindingSource.DataSource = gefunden;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            daten.SaveChanges();
        }
    }
}
