using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaniniEngine
{
    public class Niño
    {
        public int Id { get; set; }
        public ICollection<Copia> Copias { get; set; }
    }

    public class Figurita
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public ICollection<Copia> Copias { get; set; }
    }

    public class Copia
    {
        //public int Id { get; set; }
        public Niño Niño { get; set; }
        public Figurita Figurita { get; set; }
        public int Cantidad { get; set; }
    }

    public class FiguritaManager
    {
        public List<int> GetFiguritasFaltantes(Niño niño, ICollection<Figurita> figuritas)
        {
            var query = (from f in figuritas
                         select f.Id).Except(from c in niño.Copias
                                             select c.Figurita.Id);
            return query.ToList();
        }

        public List<int> GetFiguritasRepetidas(Niño niño)
        {
            var query = from c in niño.Copias
                        where c.Cantidad >= 2
                        select c.Figurita.Id;
            return query.ToList();
        }

        public List<int> Intersectar(ICollection<int> faltantes, ICollection<int> repetidos)
        {
            var query = (from f in faltantes
                         select f).Intersect(from r in repetidos
                                             select r);
            return query.ToList();
        }

        public bool PuedeIntercambiar(Niño niño1, Niño niño2, ICollection<Figurita> figuritas)
        {
            var faltantes = GetFiguritasFaltantes(niño1, figuritas);
            var repetidas = GetFiguritasRepetidas(niño1);

            var faltantes2 = GetFiguritasFaltantes(niño2, figuritas);
            var repetidas2 = GetFiguritasRepetidas(niño2);

            if (Intersectar(faltantes, repetidas2).Count() > 0 && Intersectar(faltantes2, repetidas).Count() > 0)
            {
                return true;
            }
            return false;
        }
    }
}