using System;

namespace CrudSimples.API.Models
{
    public class Colaborador
    {
        public Colaborador( string nome, string sexo, string dataDeNascimento, string cargo, bool ativo)
        {
            //Id = id;
            Nome = nome;
            Sexo = sexo;
            DataDeNascimento = dataDeNascimento;
            Cargo = cargo;
            Ativo = ativo;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public string DataDeNascimento { get; set; }
        public string Cargo { get; set; }
        public bool Ativo { get; set; }


        public override string ToString()
        {
            return $"Colaborador: { Id }, { Nome }, { Sexo }, { DataDeNascimento }, { Cargo }, { Ativo }";
        }
    }
    
}