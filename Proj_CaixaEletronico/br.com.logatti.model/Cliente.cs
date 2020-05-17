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
        public static List<Cliente> lstCli = new List<Cliente>();
     
        public string Nome { get; set; }

        public string Celular { get; set; }

        public string CPF { get; set; }

        public string Telefone { get; set; }


        public string Endereco { get; set; }

        public string Agencia { get; set; }

        public int IdConta { get; set; }
        public double Saldo { get; set; }
        public Boolean status { get; set; }

        public int IdCliente { get; set; }

        public Banco banco { get; set; }

        public Conta conta { get; set; }

    
        public void Add(Cliente c)
        {
            lstCli.Add(c);
        }

        public List<Cliente> ListAll()
        {
            return lstCli;
        }

        public override string ToString()
        {
            return "id: " + this.IdCliente +
                 "\nNome: " + this.Nome +
                 "\nAgencia: " + this.Agencia +
                 "\n\nSaldo: " + this.Saldo;
        }

    }
}

