using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace WindowsFormsApplication3
{
    public partial class Elektro : Form
    {
        
        private bool mouseDown;
        private Point lastLocation;
        public Elektro()
        {
            InitializeComponent();
        }

      

        private void Form1_Load(object sender, EventArgs e)
        {
            Db Conn = new Db();
            DataTable Dt=Conn.DataRead("Select Rodzaj From Wylaczniki");
            foreach(DataRow row in Dt.Rows)
            {
                comboBox1.Items.Add(row[0]);
            }

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();


        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;

        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();

            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            double loop; 
            


            if ((double.TryParse(textBox2.Text, out loop))&&(loop>=0.01)&&(loop<=200))
            {
                double Petla= Obliczenia.Petla(textBox2.Text);
                textBox1.Text = Convert.ToString(Petla);


                if (comboBox1.SelectedIndex == -1)
                {
                    textBox4.Text = "Prosze wybrać zabezpieczenie";
                    textBox4.BackColor = Color.White;
                }
                else
                {
                    Db Conn = new Db();
                    DataTable Dt=Conn.DataReadPar(comboBox1.Text);

                    double Iprze = Obliczenia.Przec(Dt);
                    double Izw = Obliczenia.Zwarcie(Dt);
                    
                    
                    
                    textBox3.Text = Convert.ToString(Izw);
                    textBox5.Text = Convert.ToString(Iprze);

                    if (Izw > Petla)
                    {
                        textBox4.Text = "Zabezpiecznie nie spełnia wymagań ochrony przeciwporażeniowej!";
                        textBox4.BackColor = Color.Red;
                    }
                    else
                    {
                        textBox4.Text = "Zabezpiecznie spełnia wymagania ochrony przeciwporażeniowej!";
                        textBox4.BackColor = Color.Green;
                    }
                }
                
            } 
            else
            {
                textBox4.Text="Podano złą wartość Panie Grzegorzu";
                textBox4.BackColor = Color.White;

            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }
    }
}
