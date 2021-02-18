using System;

namespace Dio.Series.Classes
{
    public class Serie : EntidadeBase
    {
        public Serie(
            int id,
            Genero genero,
            string titulo,
            string descricao,
            int ano,
            bool excluido)
        {
            Id = id;
            Genero = genero;
            Titulo = titulo;
            Descricao = descricao;
            Ano = ano;
            Excluido = excluido;
        }

        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        public bool Excluido { get; set; }

        public override string ToString()
        {
            var retorno = "";
            retorno += $"Genero: {Genero}" + Environment.NewLine;
            retorno += $"Título: {Titulo}" + Environment.NewLine;
            retorno += $"Descrição: {Descricao}" + Environment.NewLine;
            retorno += $"Ano: {Ano}" + Environment.NewLine;
            retorno += $"Excluido: {Excluido}" + Environment.NewLine;
            return retorno;
        }

        public string GetTitulo()
        {
            return Titulo;
        }
        public int GetId()
        {
            return Id;
        }
    }
}