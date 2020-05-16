using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_CaixaEletronico.br.com.logatti.model
{
    class Conta
    {
        public int IdConta { get; set; }
        public int IdClient { get; set; }


        public int NumConta { get; set; }

        public string NumAgencia { get; set; }

        public double Saldo { get; set; }

        public Boolean Status { get; set; }

        public Banco banco { get; set; }

        public Cliente cliente { get; set; }


    }
}
