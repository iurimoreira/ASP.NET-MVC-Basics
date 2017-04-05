using Livraria.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Livraria.Repository
{
    public class LivroRepository
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Livraria.mdf;Integrated Security=True";

        public IEnumerable<Livro> GetAllLivros()
        {

            using (var connection = new SqlConnection(connectionString))
            {
                var commandText = "SELECT * FROM Livro";
                var selectCommand = new SqlCommand(commandText, connection);

                Livro livro = null;
                var livros = new List<Livro>();

                try
                {
                    connection.Open();

                    using (var reader = selectCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            livro = new Livro();
                            livro.id = (int)reader["Id"];
                            livro.titulo = reader["titulo"].ToString();
                            livro.autor = reader["autor"].ToString();
                            livro.editora = reader["editora"].ToString();
                            livro.ano = (int)reader["ano"];

                            livros.Add(livro);
                        }
                    }
                }
                finally
                {
                    connection.Close();
                }
                return livros;
            }
        }

        public Livro GetLivroById(int id)
        {

            using (var connection = new SqlConnection(connectionString))
            {
                var commandText = "SELECT * FROM Livro Where Id=@id";
                var selectCommand = new SqlCommand(commandText, connection);
                selectCommand.Parameters.AddWithValue("@id", id);

                Livro livro = null;
                

                try
                {
                    connection.Open();

                    using (var reader = selectCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            livro = new Livro();
                            livro.id = (int)reader["Id"];
                            livro.titulo = reader["titulo"].ToString();
                            livro.autor = reader["autor"].ToString();
                            livro.editora = reader["editora"].ToString();
                            livro.ano = (int)reader["ano"];

                            
                        }
                    }
                }
                finally
                {
                    connection.Close();
                }
                return livro;
            }
        }

        internal void CreateLivro(Livro livro)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var commandText = "INSERT INTO Livro (titulo, autor, editora, ano) VALUES (@Titulo, @Autor, @Editora, @Ano)";
                var insertCommand = new SqlCommand(commandText, connection);
                insertCommand.Parameters.AddWithValue("@Titulo", livro.titulo);
                insertCommand.Parameters.AddWithValue("@Autor", livro.autor);
                insertCommand.Parameters.AddWithValue("@Editora", livro.editora);
                insertCommand.Parameters.AddWithValue("@Ano", livro.ano);

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

        internal void DeleteLivro(int id)
        {

            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "DELETE FROM Livro WHERE Id=@cod";
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

        internal void UpdateLivro(Livro livro)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "UPDATE Livro SET titulo=@titulo, autor=@autor, editora=@editora, ano=@ano Where Id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id",livro.id);
                cmd.Parameters.AddWithValue("@titulo", livro.titulo);
                cmd.Parameters.AddWithValue("@autor", livro.autor);
                cmd.Parameters.AddWithValue("@editora", livro.editora);
                cmd.Parameters.AddWithValue("@ano", livro.ano);
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