using com.sun.corba.se.spi.ior;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Proj_CaixaEletronico.br.com.logatti.model
{
    public class ClienteService
    {

        public void Add(int idCliente, string nome, double valor, string numAgencia, int celular, string cpf, int telefone, string endereco, int idconta)
        {
            Cliente cl = new Cliente()
            {
                IdCliente = idCliente,
                Nome = nome,
                Saldo = valor,
                Agencia = numAgencia,
                Celular = celular,
                CPF = cpf,
                Telefone = telefone, 
                Endereco = endereco,
               IdConta = idconta,



            };
            new Cliente().Add(cl);
        }

        public void Imprimir(int IdCliente, string Nome, string Agencia, double Saldo)
        {


            string CaminhoNome = "C:\\Users\\bmauri2\\Desktop\\ArqTexto.txt";

            using (StreamWriter x = File.CreateText(CaminhoNome))
            {
                       
                x.WriteLine("id: " + IdCliente +
                 "\nNome: " + Nome +
                 "\nAgencia: " + Agencia +
                 "\n\nSaldo: " + Saldo);
            }

       
        }
    }


    }
    

