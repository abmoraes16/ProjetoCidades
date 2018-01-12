using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ProjetoCidades.Models;

namespace ProjetoCidades.Repositorio
{
    public class CidadeRep
    {
        string connectionString = @"Data source=.\SqlExpress;Initial Catalog=ProjetoCidades;uid=sa;pwd=senai@123";

        public List<Cidade> Listar(){
            List<Cidade> lstCidades = new List<Cidade>();

            SqlConnection connection = new SqlConnection(connectionString);

            string SqlQuery = "Select * from Cidades";

            SqlCommand command = new SqlCommand(SqlQuery,connection);

            connection.Open();

            SqlDataReader dataReader = command.ExecuteReader();

            //Cidade cidade;

            while(dataReader.Read()){
                Cidade cidade = new Cidade();
            
                cidade.Id = Convert.ToInt16(dataReader["Id"]);
                cidade.Nome = dataReader["Nome"].ToString();
                cidade.Estado = dataReader["Estado"].ToString();
                cidade.Habitantes = Convert.ToInt16(dataReader["Habitantes"]);

                lstCidades.Add(cidade);
            }

            connection.Close();

            return lstCidades;
        } 

        public void Cadastrar(Cidade cidade){
            SqlConnection connection = new SqlConnection(connectionString);

            string sqlQuery = "insert into Cidades(Nome,Estado,Habitantes) values(@cidadeNome,@cidadeEstado,@cidadeHabitantes)";

            SqlCommand command = new SqlCommand(sqlQuery,connection);

            connection.Open();

            command.CommandType = CommandType.Text;

            command.Parameters.AddWithValue("@cidadeNome",cidade.Nome);
            command.Parameters.AddWithValue("@cidadeEstado",cidade.Estado);
            command.Parameters.AddWithValue("@cidadeHabitantes",cidade.Habitantes);
            
            command.ExecuteNonQuery();

            connection.Close();
        }

        public void Editar(Cidade cidade){
            SqlConnection connection = new SqlConnection(connectionString);

            string sqlQuery = "update Cidades set Nome='"+cidade.Nome+"',Estado='"+cidade.Estado+"', Habitantes="+cidade.Habitantes+" where Id="+cidade.Id;

            SqlCommand command = new SqlCommand(sqlQuery,connection);

            connection.Open();

            //command.CommandType = CommandType.Text;

            //command.Parameters.AddWithValue("@cidadeId",cidade.Id);
            //command.Parameters.AddWithValue("@cidadeNome",cidade.Nome);
            //command.Parameters.AddWithValue("@cidadeEstado",cidade.Estado);
            //command.Parameters.AddWithValue("@cidadeHabitantes",cidade.Habitantes);
            
            command.ExecuteNonQuery();

            connection.Close();
        }

        public Cidade Consultar(int id){
            Cidade cidade = new Cidade();

            SqlConnection connection = new SqlConnection(connectionString);

            string SqlQuery = "Select * from Cidades where Id="+id;

            SqlCommand command = new SqlCommand(SqlQuery,connection);

            connection.Open();

            SqlDataReader dataReader = command.ExecuteReader();

            while(dataReader.Read()){
                cidade.Id = Convert.ToInt16(dataReader["Id"]);
                cidade.Nome = dataReader["Nome"].ToString();
                cidade.Estado = dataReader["Estado"].ToString();
                cidade.Habitantes = Convert.ToInt16(dataReader["Habitantes"]);
            }

            connection.Close();

            return cidade;
        }

        public void Excluir(int id){
            SqlConnection connection = new SqlConnection(connectionString);

            string sqlQuery = "delete from Cidades where id="+id;

            SqlCommand command = new SqlCommand(sqlQuery,connection);

            connection.Open();
            
            command.ExecuteNonQuery();

            connection.Close();
        }
    }
}