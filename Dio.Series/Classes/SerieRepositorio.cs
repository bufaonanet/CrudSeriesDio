using System.Collections.Generic;
using Dio.Series.Interfaces;

namespace Dio.Series.Classes
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        List<Serie> ListaSeries = new List<Serie>();

        public void Atualiza(int id, Serie serie)
        {
            ListaSeries[id] = serie;
        }

        public void Exclui(int id)
        {
            ListaSeries[id].Excluido = true;
        }

        public void Insere(Serie serie)
        {
            ListaSeries.Add(serie);
        }

        public List<Serie> Lista()
        {
            return ListaSeries;
        }

        public int ProximoId()
        {
            return ListaSeries.Count;
        }

        public Serie RetornaPorId(int id)
        {
            return ListaSeries[id];
        }
    }
}