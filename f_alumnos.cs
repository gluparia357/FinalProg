using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArchivosInicio
{
    public partial class Form1 : Form
    {
        gestionaralumnos MiGestor = new gestionaralumnos();

        public Form1()
        {
            InitializeComponent();
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            MostrarGrilla();
        }

        

        private void Btncrear_Click(object sender, EventArgs e)
        {
            Alumno nuevoalumno = new Alumno(
                this.txtnombre.Text,
                Int64.Parse(this.txtdocumento.Text),
                Int32.Parse(this.txtedad.Text)
            );
            
            MiGestor.alta(nuevoalumno);
            MostrarGrilla();
        }

        private void MostrarGrilla()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = MiGestor.Leer();
            
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
