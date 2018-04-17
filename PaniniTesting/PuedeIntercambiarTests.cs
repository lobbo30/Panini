using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaniniEngine;

namespace PaniniTesting
{
    [TestClass]
    public class PuedeIntercambiarTests
    {
        [TestMethod]
        public void PuedeIntercambiar()
        {
            ICollection<Figurita> figuritas = new List<Figurita>();
            for (int i = 10; i <= 100; i += 10)
            {
                figuritas.Add(new Figurita() { Id = i });
            }

            Niño niño1 = new Niño()
            {
                Id = 1,
                Copias = new List<Copia>()
                {
                    new Copia() { Figurita = new Figurita() { Id = 10 }, Cantidad = 2 },
                    new Copia() { Figurita = new Figurita() { Id = 20 }, Cantidad = 1 },
                    new Copia() { Figurita = new Figurita() { Id = 30 }, Cantidad = 3 },
                    new Copia() { Figurita = new Figurita() { Id = 40 }, Cantidad = 1 },
                    new Copia() { Figurita = new Figurita() { Id = 50 }, Cantidad = 2 }
                }
            };

            Niño niño2 = new Niño()
            {
                Id = 2,
                Copias = new List<Copia>()
                {
                    new Copia() { Figurita = new Figurita() { Id = 10 }, Cantidad = 1 },
                    new Copia() { Figurita = new Figurita() { Id = 60 }, Cantidad = 2 },
                    new Copia() { Figurita = new Figurita() { Id = 30 }, Cantidad = 1 },
                    new Copia() { Figurita = new Figurita() { Id = 90 }, Cantidad = 3 },
                    new Copia() { Figurita = new Figurita() { Id = 100 }, Cantidad = 4 }
                }
            };

            FiguritaManager figuritaManager = new FiguritaManager();
            bool resultado = figuritaManager.PuedeIntercambiar(niño1, niño2, figuritas);

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void PuedeIntercambiar_WithDifferentArguments()
        {
            ICollection<Figurita> figuritas = new List<Figurita>();
            for (int i = 10; i <= 100; i += 10)
            {
                figuritas.Add(new Figurita() { Id = i });
            }

            Niño niño1 = new Niño()
            {
                Id = 1,
                Copias = new List<Copia>()
                {
                    new Copia() { Figurita = new Figurita() { Id = 10 }, Cantidad = 2 },
                    new Copia() { Figurita = new Figurita() { Id = 20 }, Cantidad = 1 },
                    new Copia() { Figurita = new Figurita() { Id = 30 }, Cantidad = 3 },
                    new Copia() { Figurita = new Figurita() { Id = 40 }, Cantidad = 1 },
                    new Copia() { Figurita = new Figurita() { Id = 50 }, Cantidad = 1 }
                }
            };

            Niño niño2 = new Niño()
            {
                Id = 2,
                Copias = new List<Copia>()
                {
                    new Copia() { Figurita = new Figurita() { Id = 10 }, Cantidad = 1 },
                    new Copia() { Figurita = new Figurita() { Id = 60 }, Cantidad = 2 },
                    new Copia() { Figurita = new Figurita() { Id = 30 }, Cantidad = 1 },
                    new Copia() { Figurita = new Figurita() { Id = 90 }, Cantidad = 3 },
                    new Copia() { Figurita = new Figurita() { Id = 100 }, Cantidad = 4 }
                }
            };

            FiguritaManager figuritaManager = new FiguritaManager();
            bool resultado = figuritaManager.PuedeIntercambiar(niño1, niño2, figuritas);

            Assert.IsFalse(resultado);
        }
    }
}
