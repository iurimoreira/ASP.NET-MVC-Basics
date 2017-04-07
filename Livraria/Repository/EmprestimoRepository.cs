using Livraria.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Livraria.Repository
{
    public interface IEmprestimoRepository
    {
        IEnumerable<Emprestimo> GetAllEmprestimos();

        Emprestimo GetEmprestimoById(int id);

        void CreateEmprestimo(Emprestimo emprestimo);

        void DeleteEmprestimo(int id);

        void UpdateEmprestimo(Emprestimo emprestimo);

    }

    public class EmprestimoRepository : IEmprestimoRepository
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Livraria.mdf;Integrated Security=True";

        public IEnumerable<Emprestimo> GetAllEmprestimos()
        {

            using (var connection = new SqlConnection(connectionString))
            {
                //var commandText = "SELECT * FROM Emprestimo";
                var commandText = "SELECT Emprestimo.Id, Emprestimo.dataEmprestimo, Emprestimo.dataDevolucao, Emprestimo.IdLivro, Livro.titulo FROM Emprestimo INNER JOIN Livro ON Emprestimo.IdLivro = Livro.Id";
                var selectCommand = new SqlCommand(commandText, connection);

                Emprestimo emprestimo = null;
                var emprestimos = new List<Emprestimo>();

                try
                {
                    connection.Open();

                    using (var reader = selectCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            emprestimo = new Emprestimo();
                            emprestimo.id = (int)reader["Id"];
                            emprestimo.dataEmprestimo = (DateTime)reader["dataEmprestimo"];
                            emprestimo.dataDevolucao = (DateTime)reader["dataDevolucao"];
                            emprestimo.idLivro = (int)reader["IdLivro"];
                            emprestimo.nomeDoLivro = reader["titulo"].ToString();
                            
                            emprestimos.Add(emprestimo);
                        }
                    }
                }
                finally
                {
                    connection.Close();
                }
                return emprestimos;
            }
        }

        public void CreateEmprestimo(Emprestimo emprestimo)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var commandText = "INSERT INTO Emprestimo (dataEmprestimo, dataDevolucao, IdLivro) VALUES (@DataEmprestimo, @DataDevolucao, @IdLivro)";
                var insertCommand = new SqlCommand(commandText, connection);
                insertCommand.Parameters.AddWithValue("@DataEmprestimo", emprestimo.dataEmprestimo);
                insertCommand.Parameters.AddWithValue("@DataDevolucao", emprestimo.dataDevolucao);
                insertCommand.Parameters.AddWithValue("IdLivro", emprestimo.idLivro);

                try
                {
                    connection.Open();
                    insertCommand.ExecuteNonQuery();
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public Emprestimo GetEmprestimoById(int id)
        {

            using (var connection = new SqlConnection(connectionString))
            {
                var commandText = "SELECT * FROM Emprestimo Where Id=@id";
                var selectCommand = new SqlCommand(commandText, connection);
                selectCommand.Parameters.AddWithValue("@id", id);

                Emprestimo emprestimo = null;


                try
                {
                    connection.Open();

                    using (var reader = selectCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            emprestimo = new Emprestimo();
                            emprestimo.id = (int)reader["Id"];
                            emprestimo.dataEmprestimo = (DateTime)reader["dataEmprestimo"];
                            emprestimo.dataDevolucao = (DateTime)reader["dataDevolucao"];
                            emprestimo.idLivro = (int)reader["IdLivro"];
                        }
                    }
                }
                finally
                {
                    connection.Close();
                }
                return emprestimo;
            }
        }

        public void UpdateEmprestimo(Emprestimo emprestimo)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "UPDATE Emprestimo SET dataEmprestimo=@dataEmprestimo, dataDevolucao=@dataDevolucao, IdLivro=@IdLivro Where Id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", emprestimo.id);
                cmd.Parameters.AddWithValue("@dataEmprestimo", emprestimo.dataEmprestimo);
                cmd.Parameters.AddWithValue("@dataDevolucao", emprestimo.dataDevolucao);
                cmd.Parameters.AddWithValue("@IdLivro", emprestimo.idLivro);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public void DeleteEmprestimo(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "DELETE FROM Emprestimo WHERE Id=@cod";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@cod", id);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}