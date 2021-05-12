using System;
using System.Collections.Generic;

namespace DIO.Series
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();
        public void Atualizar(int id, Serie objeto)
        {
            listaSerie[id] = objeto;
        }

        public void Excluir(int id)
        {
            listaSerie[id].Excluir();
        }

        public void Inserir(Serie objeto)
        {
            listaSerie.Add(objeto);
        }

        public List<Serie> Listar()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public Serie RetornarPorId(int id)
        {
            try
            {
                return listaSerie[id];
            }catch(ArgumentOutOfRangeException e)
            {
                e.GetType();
                Console.WriteLine("> Série não encontrada! <\n");
                return null;
            }

        }
    }
}