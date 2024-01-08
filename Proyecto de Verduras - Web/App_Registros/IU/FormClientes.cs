using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using App_Registros.DAO;

namespace App_Registros.IU
{
    public partial class FormClientes : Form
    {
        //PATRON SINGLETON
        private FormClientes()
        {
            InitializeComponent();
        }
        private static FormClientes Instancia = null;

        public static FormClientes ObtenerInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new FormClientes();
                Instancia.FormClosed += new FormClosedEventHandler(reset);//SOLO PARA FORMULARIOS
            }
            return Instancia;
        }

        public FormClientes()
        {
            InitializeComponent();
        }

        private void FormClientes_Load(object sender, EventArgs e)
        {
            //MOSTRAR TODO
            VerRegistros("");
        }

        //METODO VER REGISTROS
        private void VerRegistros(string condicion)
        {
            ClienteDao DAO = new ClienteDao();
            dataGridView1.DataSource = DAO.VerRegistros(condicion);

        }

        //METODO BUSCAR
        private void button1_Click(object sender, EventArgs e)
        {
            VerRegistros(txtbuscar.Text);
        }

        //FILTRAR
        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            VerRegistros(txtbuscar.Text);
        }
    }
}
