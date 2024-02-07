using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_CalcularSueldo_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txt_SueldoBruto.Text, out double sueldo))
            {
                MessageBox.Show("Por favor, ingrese un sueldo válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            double afp = 0.0287;
            double sfs = 0.0304;

            double AFP = sueldo * afp;
            double SFS = sueldo * sfs;

            double SueldoNeto = sueldo - AFP - SFS;

            bool ISRaplica = SueldoNeto > 416220.05;

            double ISR = 0.0;

            if (ISRaplica)
            {
                ISR = (SueldoNeto - 416220.05) * 0.25;
            }

            txt_SueldoBruto.Text = SueldoNeto.ToString();
            txt_AFP.Text = AFP.ToString();
            txt_SFS.Text = SFS.ToString();
            txt_ISR.Text = (ISRaplica ? ISR.ToString() : "0.0");
            txt_SueldoNeto.Text = SueldoNeto.ToString();
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            txt_SueldoBruto.Clear();
            txt_AFP.Clear();
            txt_SFS.Clear();
            txt_SueldoNeto.Clear();
            txt_ISR.Clear();
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
