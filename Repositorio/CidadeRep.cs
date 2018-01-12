using System;
using System.Collections.Generic;
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

            string sqlQuery = "insert into Cidades(Nome,Estado,Habitantes) values('"+cidade.Nome+"','"+cidade.Estado+"','"+cidade.Habitantes+"')";

            SqlCommand command = new SqlCommand(sqlQuery,connection);

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
        }
    }
}