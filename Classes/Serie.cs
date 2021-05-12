using System;

namespace DIO.Series
{
    public class Serie : EntidadeBase
    {
        // Atributos
        private Genero genero { get; set; }
        private string titulo { get; set; }
        private string descricao { get; set; }        
        private int ano { get; set; }
        private bool excluido { get; set; }

        // Métodos
        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.id = id;
            this.genero = genero;
            this.titulo = titulo;
            this.descricao = descricao;
            this.ano = ano;
            this.excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: "
                    + this.genero
                    + Environment.NewLine;
            retorno += "Título: "
                    + this.titulo
                    + Environment.NewLine;
            retorno += "Descrição: "
                    + this.descricao
                    + Environment.NewLine;
            retorno += "Ano de Início: "
                    + this.ano
                    + Environment.NewLine;
            retorno += "Excluído: "
                    + this.excluido;
            return retorno;
        }

        public string RetornarTitulo()
        {
            return this.titulo;
        }

        public int RetornarId()
        {
            return this.id;
        }

        public bool RetornarExcluido()
        {
            return this.excluido;
        }

        public void Excluir()
        {
            this.excluido = true;
        }
    }
}