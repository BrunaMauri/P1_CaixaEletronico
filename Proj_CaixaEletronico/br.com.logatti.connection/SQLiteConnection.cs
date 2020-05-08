using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS " + tableName + " (idCliente int, nome varchar(50), celular int, cpf varchar(50), telefone int, endereco varchar(50), agencia varchar(50), conta int, saldo double, status boolean, idbanco int)";
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

            using (var cmd = DbConnection().CreateCommand())
            {
                cmd.CommandText = "INSERT INTO Banco (id, descricao) values (@Id, @Descricao)";
                cmd.Parameters.AddWithValue("@Id", banco.Id);
                cmd.Parameters.AddWithValue("@Descricao", banco.NomeAgencia);
          

                cmd.ExecuteNonQuery();
            }
        }

        //Inserindo os dados na tabela Conta
        public static void Add(Conta conta, Cliente cliente)
        {

            using (var cmd = DbConnection().CreateCommand())
            {
                cmd.CommandText = "INSERT INTO Cliente (idCliente, nome, celular, cpf, telefone, endereco, agencia, conta, saldo, status, idbanco) values (@IdCliente, @Nome, @Celular, @Cpf, @Telefone, @Endereco, @Agencia, @Conta, @Saldo, @Idbanco)";
                cmd.Parameters.AddWithValue("@IdBanco", conta.Id);
                cmd.Parameters.AddWithValue("@Agencia", conta.Agencia);
                cmd.Parameters.AddWithValue("@Saldo", conta.Saldo);
                cmd.Parameters.AddWithValue("@Conta", conta.NumConta);
                cmd.Parameters.AddWithValue("@Banco", conta.banco);
                cmd.Parameters.AddWithValue("@IdCliente", cliente.Id);
                cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                cmd.Parameters.AddWithValue("@Celular", cliente.Celular);
                cmd.Parameters.AddWithValue("@Cpf", cliente.CPF);
                cmd.Parameters.AddWithValue("@Telefone", cliente.Telefone);
                cmd.Parameters.AddWithValue("@Conta", cliente.conta);
                cmd.Parameters.AddWithValue("@Endereco", cliente.Endereco);

                cmd.ExecuteNonQuery();
            }
         
            }
        



        //Consultando os dados na tabela banco
        public static DataTable GetAll()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();

            using (var cmd = DbConnection().CreateCommand())
            {
                cmd.CommandText = "select id, descricao from Banco";
                da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                da.Fill(dt);
                return dt;
            }
        }


    }
}
