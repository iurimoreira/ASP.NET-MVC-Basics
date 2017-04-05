﻿using Livraria.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Livraria.Repository
{
    public class EmprestimoRepository
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Livraria.mdf;Integrated Security=True";

        public IEnumerable<Emprestimo> GetAllEmprestimos()
        {

            using (var connection = new SqlConnection(connectionString))
            {
                var commandText = "SELECT * FROM Emprestimo";
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

        internal void CreateEmprestimo(Emprestimo emprestimo)
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

        internal void UpdateEmprestimo(Emprestimo emprestimo)
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
    }
}