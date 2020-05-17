using Microsoft.Data.Sqlite;
using Proj_CaixaEletronico.br.com.logatti.connection;
using Proj_CaixaEletronico.br.com.logatti.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proj_CaixaEletronico.br.com.logatti.view
{
    public partial class Form_Cliente : Form
    {

        public SQLiteConnection SQLiteConnection { get; private set; }



        public Form_Cliente()
        {
            InitializeComponent();

            cbBanco.DataSource = ConnectionSqlite.GetBancoAll();
            cbBanco.ValueMember = "idBanco";
            cbBanco.DisplayMember = "descricao";
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {


            Conta conta = new Conta()
            {
                NumConta = int.Parse(txtCon.Text),
                NumAgencia = txtAgencia.Text,
                Saldo = double.Parse(txtSaldo.Text),
                IdClient = int.Parse(txtId.Text),
                IdConta = int.Parse(txtIdConta.Text),
                banco = new Banco()
                {
                    IdBanco = int.Parse(cbBanco.SelectedValue.ToString()),
                    NomeBanco = cbBanco.Text
                }

            };

            Cliente c = new Cliente()

            {
                IdCliente = int.Parse(txtId.Text),
                Celular = txtCelular.Text,
                IdConta = int.Parse(txtIdConta.Text),

                Nome = txtNome.Text,

                Telefone = txtTelefone.Text,

                CPF = txtCPF.Text,
                Endereco = txtEndereco.Text,
                

            };






            //Inserir dados 


            //Inserir dados
            CreateCliente(c);
            CreateConta(conta);

            //Atualizar dados na grid
            LoadGridCliente();
        }

        private void Form_Cliente_Load(object sender, EventArgs e)
        {
            LoadGridCliente();
        }


        private void LoadGridCliente()
        {
            dgvClientes.DataSource = ConnectionSqlite.GetClienteAll();
        }

        private void CreateCliente(Cliente cliente)
        {
            try
            {
                ConnectionSqlite.Add(cliente);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO: " + ex.Message);
            }
        }


        private void CreateConta(Conta cont)
        {
            try
            {
                ConnectionSqlite.Add(cont);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO: " + ex.Message);
            }
        }
        private void CreateBanco(Banco banc)
        {
            try
            {
                ConnectionSqlite.Add(banc);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO: " + ex.Message);
            }
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtCPF_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }


}