using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using javax.swing;
using Proj_CaixaEletronico.br.com.logatti.model;

namespace Proj_CaixaEletronico.br.com.logatti.connection
{
    class ConnectionSqlite
    {


        private static SQLiteConnection sqliteConnection;


        private static SQLiteConnection DbConnection()
        {
            sqliteConnection = new SQLiteConnection(@"Data Source=c:\tmp\dbCaixa.db");
            sqliteConnection.Open();
            return sqliteConnection;
        }

        //Criação do arquivo SQLite
        public static void createDataBaseSQLite(string dataBaseName)
        {
            try
            {
                if (!File.Exists(@"c:\tmp\" + dataBaseName))
                    SQLiteConnection.CreateFile(@"c:\tmp\" + dataBaseName);
            }
            catch (Exception)
            {
                throw;
            }
        }

      



        //funcionario

        public static void CreateTableSQLiteBanco(string tableName)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS " + tableName + " ( id int, descricao varchar(50))";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


              public static void CreateTableSQLiteCliente(string tableName)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS " + tableName + " (idCliente int, nome varchar(50), celular varchar(50), cpf varchar(50), telefone varchar(50), endereco varchar(50), agencia varchar(50), idConta int, saldo double, status boolean, idbanco int)";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

       


        //Inserindo os dados na tabela banco
        public static void Add(Banco banco)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Banco (idBanco, descricao) values (@IdBanco, @Descricao)";
                    cmd.Parameters.AddWithValue("@IdBanco", banco.IdBanco);
                    cmd.Parameters.AddWithValue("@Descricao", banco.NomeBanco);


                    cmd.ExecuteNonQuery();
                    JOptionPane.showMessageDialog(null, "Banco " + banco.NomeBanco + " inserido com o ÍD "+ banco.IdBanco);
                }

            }
            catch (Exception)
            {
                JOptionPane.showMessageDialog(null, "Informações inválidas, revise as informações!" +
                    "\n *O Id não pode ser igual a um ID existente.");

            }
        }

        //Inserindo os dados na tabela banco
        public static void Add(Conta conta)
        {

            using (var cmd = DbConnection().CreateCommand())
            {
                cmd.CommandText = "INSERT INTO Conta (idConta, idCliente, numConta, numAgencia, saldo, idBanco) values (@IdConta, @IdCliente, @NumConta, @NumAgencia, @Saldo, @IdBanco)";
                cmd.Parameters.AddWithValue("@IdConta", conta.IdConta);
                cmd.Parameters.AddWithValue("@NumConta", conta.NumConta);
                cmd.Parameters.AddWithValue("@IdCliente", conta.IdClient);
                cmd.Parameters.AddWithValue("@NumAgencia", conta.NumAgencia);

                cmd.Parameters.AddWithValue("@Saldo", conta.Saldo);

                cmd.Parameters.AddWithValue("@IdBanco", conta.banco.IdBanco);

                cmd.ExecuteNonQuery();
            }
        }



        //Inserindo os dados na tabela Cliente
        public static void Add(Cliente cliente)
        {

            using (var cmd = DbConnection().CreateCommand())
            {
                cmd.CommandText = "INSERT INTO Cliente (idCliente, nome, celular, cpf, telefone, endereco, idConta) values (@IdCliente, @Nome, @Celular, @Cpf, @Telefone, @Endereco, @IdConta)";

                cmd.Parameters.AddWithValue("@IdCliente", cliente.IdCliente);
                cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                cmd.Parameters.AddWithValue("@Celular", cliente.Celular);
                cmd.Parameters.AddWithValue("@Cpf", cliente.CPF);
                cmd.Parameters.AddWithValue("@Telefone", cliente.Telefone);

                cmd.Parameters.AddWithValue("@Endereco", cliente.Endereco);
                cmd.Parameters.AddWithValue("@IdConta", cliente.IdConta);
               
                

                cmd.ExecuteNonQuery();
            }
         
            }




        //Consultando os dados na tabela banco
        public static DataTable GetBancoAll()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();

            using (var cmd = DbConnection().CreateCommand())
            {
                cmd.CommandText = "select idBanco, descricao from Banco";
                da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                da.Fill(dt);
                return dt;
            }
        }


        //Consultando os dados na tabela cliente
        public static DataTable GetClienteCAll()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();

            using (var cmd = DbConnection().CreateCommand())
            {
                cmd.CommandText = "select idCliente ID, nome Nome from Banco";
                da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                da.Fill(dt);
                return dt;
            }
        }


        public static DataTable GetBancoAllGetBancoAll()
        {
            DataTable dt = new DataTable();
            SQLiteDataAdapter da = null;

            using (var cmd = DbConnection().CreateCommand())
            {
                cmd.CommandText = "select idBanco ID, descricao Banco from Banco";
                da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                da.Fill(dt);
            }
            return dt;
        }

        public static DataTable GetClienteAll()
        {
            DataTable dt = new DataTable();
            SQLiteDataAdapter da = null;

            using (var cmd = DbConnection().CreateCommand())
            {
                cmd.CommandText = "select a.idCliente ID, a.nome Cliente, a.celular Celular, a.cpf CPF, a.telefone Telefone, a.endereco Endereço, b.numConta Conta, b.numAgencia Agencia, b.saldo Saldo, b.idBanco Banco from Cliente as a left join conta as b on a.idConta = b.idConta";
                da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                da.Fill(dt);
            }
            return dt;
        }


        public static DataTable GetClienteBAll(int id)
        {
            DataTable dt = new DataTable();
            SQLiteDataAdapter da = null;

            using (var cmd = DbConnection().CreateCommand())
            {
                cmd.CommandText = "select a.nome Cliente, a.cpf CPF, b.numConta Conta, b.numAgencia Agencia, b.idBanco Banco, b.saldo Saldo from Cliente as a left join conta as b on a.idConta = b.idConta where b.idCliente =" +id+ ";";
                da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                da.Fill(dt);
            }
            return dt;
        }


        public static DataTable GetAtualizaSaldo(double valor, int id)
        {
            DataTable dt = new DataTable();
            SQLiteDataAdapter da = null;

            using (var cmd = DbConnection().CreateCommand())
            {
                cmd.CommandText = "UPDATE conta SET saldo = " + valor + " WHERE idConta in (select idConta from Cliente where idCliente =" +id+");";
                da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                da.Fill(dt);
            }
            return dt;
        }


        public static DataTable GetSaque(double valor, int id)
        {
            DataTable dt = new DataTable();
            SQLiteDataAdapter da = null;

            using (var cmd = DbConnection().CreateCommand())
            {
                cmd.CommandText = "UPDATE conta SET saldo = saldo - " + valor + " WHERE idConta in (select idConta from Cliente where idCliente =" + id + ");";
                da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                da.Fill(dt);
            }
            return dt;
        }

        public static DataTable GetDep(double valor, int id)
        {
            DataTable dt = new DataTable();
            SQLiteDataAdapter da = null;

            using (var cmd = DbConnection().CreateCommand())
            {
                cmd.CommandText = "UPDATE conta SET saldo = saldo + " + valor + " WHERE idConta in (select idConta from Cliente where idCliente =" + id + ");";
                da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                da.Fill(dt);
            }
            return dt;
        }

    }
}



