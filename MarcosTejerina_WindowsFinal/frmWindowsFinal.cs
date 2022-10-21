using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.VisualBasic;

namespace MarcosTejerina_WindowsFinal
{
    public partial class frmWindowsFinal : Form
    {
        public frmWindowsFinal()
        {
            InitializeComponent();
        }

        private void btnValidaciones_Click(object sender, EventArgs e)
        {
            int Sueldo = Int32.Parse(txtSueldo.Text);
            string Puesto = txtPuesto.Text.ToUpper();
            string Nombre = txtNombre.Text;
            string Apellido = txtApellido.Text;

            //Validación de Sueldo y Puesto
            if (Sueldo<=0 || 
                Puesto !="SOPORTE TECNICO" && Puesto!="DBA" && Puesto!="DESARROLLADOR" ||
                Nombre.Length<=2 || 
                Nombre.Length>=50 ||
                Apellido.Length<=2 || 
                Apellido.Length>=50)
            {
                if (Sueldo <= 0)
                {
                    MessageBox.Show("El sueldo debe ser mayor a cero");
                }

                if (Puesto != "SOPORTE TECNICO" && Puesto != "DBA" && Puesto != "DESARROLLADOR")
                {
                    MessageBox.Show("El puesto debe ser Soporte Tecnico, DBA o Desarrollador");
                }

                if (Nombre.Length<= 2 || Nombre.Length >= 50)
                {
                    MessageBox.Show("El Nombre debe tener entre 3 y 49 caracteres");
                }

                if (Apellido.Length <= 2 || Apellido.Length >= 50)
                {
                    MessageBox.Show("El Apellido debe tener entre 3 y 49 caracteres");
                }
            }
            else
            {
                MessageBox.Show("Validacion completada!");
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            string Puesto = txtPuesto.Text.ToUpper();
            string Nombre = txtNombre.Text.ToUpper();
            string Apellido = txtApellido.Text.ToUpper();

            MessageBox.Show("NOMBRE COMPLETO: " + Nombre + " " + Apellido + "\n" +
                            "PUESTO: " + Puesto);
        }

        private void btnIngresarHoras_Click(object sender, EventArgs e)
        {
            Int16[] horas = { 1, 2, 3, 4, 5, 6 };
            string[] dias = { "Lunes", "Martes", "Miercoles", "Jueves", "Viernes"};
            bool[] dias4horas = { false, false, false, false, false };
            int suma = 0;
            decimal promedio = 0;
            decimal prom = 0;
            string mensaje4horas = "Se trabajo menos de 4 horas los siguientes dias: ";

            for (int i=0; i<5; i++)
            {
                horas[i] = Int16.Parse(Interaction.InputBox("Ingrese las horas del " + dias[i], "Datos requeridos"));
                suma = suma + horas[i];
                if (horas[i]<4)
                {
                    dias4horas[i] = true;
                    mensaje4horas = mensaje4horas + dias[i] + " ";
                }
            }

            prom = suma;
            promedio = Decimal.Round(prom/5,2);
            MessageBox.Show("Esta semana se trabajo un total de " + suma + " horas" + "\n" +
                            "El promedio de horas trabajadas es de " + promedio + "\n" + mensaje4horas);


        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtPuesto.Clear();
            txtSueldo.Clear();
        }
    }
}
