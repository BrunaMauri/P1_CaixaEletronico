using Proj_CaixaEletronico.br.com.logatti.connection;
using Proj_CaixaEletronico.br.com.logatti.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proj_CaixaEletronico.br.com.logatti.view
{
    public partial class Form_Cliente : Form
    {
        public Form_Cliente()
        {
            InitializeComponent();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {

            Cliente c = new Cliente()

            {
                IdCliente = int.Parse(txtId.Text),
                Celular = int.Parse(txtCelular.Text),
                NumConta = int.Parse(txtConta.Text),
                Nome = txtNome.Text,
                Saldo = double.Parse(txtSaldo.Text),
                Telefone = int.Parse(txtTelefone.Text),
                Agencia = txtAgencia.Text,
                CPF = txtCPF.Text,
                Endereco = txtEndereco.Text,

                banco = new Banco()
                {
                    Id = int.Parse(cbBanco.SelectedValue.ToString()),
                    NomeAgencia = cbBanco.Text
                }
            };

            //Inserir dados 


            //Inserir dados
            CreateCliente(cliente);
            //Atualizar dados na grid
            LoadGridCliente();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadComboCidade();
            LoadGridCliente();
        }

        private void LoadComboCidade()
        {
            cboCidade.DataSource = ConnectionSQLite.GetCidadeAll();
            cboCidade.ValueMember = "id";
            cboCidade.DisplayMember = "nome";
        }

        private void LoadGridCliente()
        {
            dgvCliente.DataSource = ConnectionSQLite.GetClienteAll();
        }

        private void CreateCliente(Cliente cliente)
        {
            try
            {
                ConnectionSQLite.Add(cliente);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO: " + ex.Message);
            }
        }

        private void btnChamar_Click(object sender, EventArgs e)
        {
            TesteChamada t = new TesteChamada();
            t.Show();
        }
    }
}
