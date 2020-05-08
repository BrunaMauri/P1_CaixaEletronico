using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_CaixaEletronico.br.com.logatti.model
{
    class Cliente
    {
       
        public string Nome { get; set; }

        public int Celular { get; set; }

        public string CPF { get; set; }

        public int Telefone { get; set; }
     

        public string Endereco { get; set; }

        public string Agencia { get; set; }

        public int NumConta { get; set; }
        public double Saldo { get; set; }
        public Boolean status { get; set; }

        public int IdCliente { get; set; }

        public Banco banco { get; set; }

    }
}
