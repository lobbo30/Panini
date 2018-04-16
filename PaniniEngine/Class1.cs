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
    }
}