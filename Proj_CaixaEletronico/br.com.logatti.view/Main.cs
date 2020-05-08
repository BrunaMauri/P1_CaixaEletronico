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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void cadastrarBancoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Banco fb = new Form_Banco();
            fb.ShowDialog();
        }

        private void cadastrarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Cliente fc = new Form_Cliente();
            fc.ShowDialog();
        }
    }
}
