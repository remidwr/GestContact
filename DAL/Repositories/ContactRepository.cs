using DAL.Entities;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class ContactRepository : IContactRepository<Contact>
    {
        private string _connectionString;

        private SqlConnection _connection;

        public ContactRepository()
        {
            _connectionString = @"Data Source=PC-DE-REMS;Initial Catalog=DBContact;Integrated Security=True;";
            _connection = new SqlConnection(_connectionString);
        }

        public int Delete(int id)
        {
            using(SqlCommand command = _connection.CreateCommand())
            {
                _connection.Open();
                string sql = "DELETE FROM Contact WHERE Id = @id";
                command.CommandText = sql;
                command.Parameters.AddWithValue("id", id);
                return command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Contact> FindByName(string name)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                string sql = "SELECT * FROM Contact WHERE UPPER(Nom) LIKE UPPER(@param)";
                command.CommandText = sql;
                command.Parameters.AddWithValue("param", "%"+name+"%");
                _connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new Contact
                        {
                            Id = (int)reader["Id"],
                            Prenom = reader["Prenom"].ToString(),
                            Nom = reader["Nom"].ToString(),
                            Email = reader["Email"].ToString(),
                            Telephone = reader["Telephone"].ToString()
                        };
                    }
                }
            }
        }

        public IEnumerable<Contact> GetAll()
        {
            using(SqlCommand command = _connection.CreateCommand() )
            {
                string sql = "SELECT * FROM Contact";
                command.CommandText = sql;
                _connection.Open();
                using(SqlDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        yield return new Contact
                        {
                            Id = (int)reader["Id"],
                            Prenom = reader["Prenom"].ToString(),
                            Nom = reader["Nom"].ToString(),
                            Email = reader["Email"].ToString(),
                            Telephone = reader["Telephone"].ToString()
                        };
                    }
                }
            }
        }

        public Contact GetById(int id)
        {
            //return GetAll().Where(x => x.Id == id).FirstOrDefault();

            Contact c = new Contact();
            using(SqlCommand command = _connection.CreateCommand())
            {
                string sql = "SELECT * FROM Contact WHERE Id = @id";
                command.CommandText = sql;
                command.Parameters.AddWithValue("id", id);
                _connection.Open();
                using (SqlDataReader reader = command.ExecuteReader()) 
                {
                    while (reader.Read()) {
                        c.Id = (int)reader["Id"];
                        c.Prenom = reader["Prenom"].ToString();
                        c.Nom = reader["Nom"].ToString();
                        c.Email = reader["Email"].ToString();
                        c.Telephone = reader["Telephone"].ToString();
                    }
                } 
            }
            return c;
        }

        public int Save(Contact entity)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                string sql = "INSERT INTO Contact VALUES (@nom, @prenom, @email, @tel)";
                command.CommandText = sql;
                command.Parameters.AddWithValue("nom", entity.Nom);
                command.Parameters.AddWithValue("prenom", entity.Prenom);
                command.Parameters.AddWithValue("email", entity.Email);
                command.Parameters.AddWithValue("tel", entity.Telephone);
                _connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        public int Update(Contact entity)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                string sql = "UPDATE Contact SET Nom = @nom, Prenom = @prenom, Email = @email, Telephone = @tel WHERE Id = @id";
                command.CommandText = sql;
                command.Parameters.AddWithValue("id", entity.Id);
                command.Parameters.AddWithValue("nom", entity.Nom);
                command.Parameters.AddWithValue("prenom", entity.Prenom);
                command.Parameters.AddWithValue("email", entity.Email);
                command.Parameters.AddWithValue("tel", entity.Telephone);
                _connection.Open();
                return command.ExecuteNonQuery();
            }
        }
    }
}
