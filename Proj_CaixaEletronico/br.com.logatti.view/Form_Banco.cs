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
    public partial class Form_Banco : Form
    {
        public Form_Banco()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            ConnectionSqlite.createDataBaseSQLite("dbCaixa.sqlite");
            ConnectionSqlite.CreateTableSQLiteBanco("Banco");

            Add(GetBanco());
            //Teste Consulta:
            dgvBanco.DataSource = GetAll();

        }


        private void Add(Banco banco)
        {
            ConnectionSqlite.Add(banco);
        }

        private DataTable GetAll()
        {
            return ConnectionSqlite.GetAll();
        }

        private Banco GetBanco()
        {
            return NewMethod();
        }

        private Banco NewMethod()
        {
            Banco b = new Banco();

            b.Id = int.Parse(txtId.Text);
            b.NomeAgencia = txtDescricao.Text;

            return b;
        }

    }
}
