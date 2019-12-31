using Npgsql;
using System.Collections.Generic;
using System;
using PessoaAPI.Models;

namespace PessoaAPI.DAL
{

   public class DAOPessoa{

       string connString = "Host=localhost;Username=postgres;Password=86554732;Database=DotNetCoreAPI";
       public List<Pessoa> RetornarPessoas(){

           List<Pessoa> lstPessoa = new List<Pessoa>();

           try{
               using (var conn = new NpgsqlConnection(connString))
               {
                   conn.Open();
                   using (var cmd = new NpgsqlCommand("SELECT * FROM pessoa", conn))
                   using (var reader = cmd.ExecuteReader())
                   while (reader.Read()){
                       Pessoa pessoa = new Pessoa();
                       pessoa.Id = (Int64)reader["id"];
                       pessoa.CPF = (Int64)reader["cpf"];
                       pessoa.Nome = reader.GetString(2);
                       lstPessoa.Add(pessoa);
                   }
                   conn.Close();
               }
           }catch(Exception ex){
               string teste = ex.Message;
               Console.WriteLine(teste);
           }      
       
           return lstPessoa;
       }

       public Pessoa RetornarPessoa(int id){
           Pessoa pessoa = new Pessoa();
           try{
               using (var conn = new NpgsqlConnection(connString))
               {
                   conn.Open();
                   using (var cmd = new NpgsqlCommand($"SELECT * FROM pessoa WHERE id = {id}", conn))
                   using (var reader = cmd.ExecuteReader())
                   while (reader.Read()){
                       pessoa.Id = (Int64)reader["id"];
                       pessoa.CPF = (Int64)reader["cpf"];
                       pessoa.Nome = reader.GetString(2);
                   }
                   conn.Close();
               }
           }catch(Exception ex){
               string teste = ex.Message;
               Console.WriteLine(teste);
           }      
       
           return pessoa;
       }
   }
}