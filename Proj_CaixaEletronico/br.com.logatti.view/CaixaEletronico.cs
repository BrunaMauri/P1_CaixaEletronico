using javax.swing;
using Proj_CaixaEletronico.br.com.logatti.connection;
using Proj_CaixaEletronico.br.com.logatti.model;
using Sprache;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proj_CaixaEletronico.br.com.logatti.view
{
    public partial class CaixaEletronico : Form
    {
        public CaixaEletronico()
        {
            InitializeComponent();
         
            cbCliente.DataSource = ConnectionSqlite.GetClienteAll();
        
            cbCliente.DisplayMember = "cliente";
            cbCliente.ValueMember = "id";
        }

        public void CaixaEletronico_Load()
        {
            DataTable table = new DataTable();

            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Nome", typeof(string));
            table.Columns.Add("Agencia:", typeof(string));
            table.Columns.Add("Saldo", typeof(double));

            table.Rows.Add(1, "First A", "Last A", 10);

            dgvCliente.DataSource = table;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnCarregar_Click(object sender, EventArgs e)
        {



            Cliente c = new Cliente()
            {
                IdCliente = int.Parse(cbCliente.SelectedValue.ToString()),
                Nome = cbCliente.Text
           
            };


            int stg;
            stg = c.IdCliente;

           
        LoadGridCliente(stg);

    }


        private void LoadGridCliente(int id)
        {
            dgvCliente.DataSource = ConnectionSqlite.GetClienteBAll(id);
        }


        private void LoadGridExtrato(int id)
        {
            dgvExtrato.DataSource = ConnectionSqlite.GetClienteBAll(id);
        }


        private void btnSacar_Click(object sender, EventArgs e)
        {
            //extrato
            int stg;
            stg = int.Parse(cbCliente.SelectedValue.ToString());

            double valor = double.Parse(txtValor.Text);

            ConnectionSqlite.GetAtualizaSaldo(valor, stg);

            LoadGridExtrato(stg);

            txtValor.Text = string.Empty;

            
        }




       

        private void btSaca_Click(object sender, EventArgs e)
        {
            int stg;
            stg = int.Parse(cbCliente.SelectedValue.ToString());

            double valor = double.Parse(txtValor.Text);

            ConnectionSqlite.GetSaque(valor, stg);

            LoadGridExtrato(stg);

            txtValor.Text = string.Empty;
        }

        private void btnDepositar_Click(object sender, EventArgs e)
        {
            int stg;
            stg = int.Parse(cbCliente.SelectedValue.ToString());

            double valor = double.Parse(txtValor.Text);

            ConnectionSqlite.GetDep(valor, stg);

            LoadGridExtrato(stg);
            txtValor.Text = string.Empty;
        }

        private void dgvCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            TextWriter writer = new StreamWriter("C:\\Users\\bmauri2\\Desktop\\ArqTexto.txt");

            //  writer.Write("Cliente:     |CPF:           |Conta  |Agen.|Banco|Saldo\n");
            //   for (int i = 0; i < dgvExtrato.Rows.Count-1; i++)
            //   {
            //       for(int j = 0;j < dgvExtrato.Columns.Count; j++)
            //      {

            writer.WriteLine("Cliente:");
            writer.Write(dgvExtrato.Rows[0].Cells[0].Value.ToString() + " " );
            writer.WriteLine("\nCPF:");
            writer.Write(dgvExtrato.Rows[0].Cells[1].Value.ToString() + " " );
            writer.WriteLine("\nConta:");
            writer.Write(dgvExtrato.Rows[0].Cells[2].Value.ToString() + " " );
            writer.WriteLine("\nAgencia:");
            writer.Write(dgvExtrato.Rows[0].Cells[3].Value.ToString() + " " );
            writer.WriteLine("\nBanco:");
            writer.Write(dgvExtrato.Rows[0].Cells[4].Value.ToString() + " " );
            writer.WriteLine("\nSaldo:");
            writer.Write(dgvExtrato.Rows[0].Cells[5].Value.ToString() + " " );


            //   }

            writer.WriteLine("");
                writer.WriteLine("-------------------------------------------------------------------------------------------------");


           // }
            writer.Close();
            MessageBox.Show("Data Exported!");
        }
    }
}
