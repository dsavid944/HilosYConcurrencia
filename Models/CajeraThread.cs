using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Supermercado.Models;

namespace Supermercado.Models
{
    public class CajeraThread
    {
        private Cajera cajera;
        private Cliente cliente;
        private Action<string, string, string, int, decimal> logMessage;

        public CajeraThread(Cajera cajera, Cliente cliente, Action<string, string, string, int, decimal> logMessage)
        {
            this.cajera = cajera;
            this.cliente = cliente;
            this.logMessage = logMessage;
        }

        public void Run()
        {
            var productos = new[] { "Producto A", "Producto B", "Producto C" };
            var random = new Random();

            foreach (var producto in productos)
            {
                int tiempo = random.Next(1, 5);
                decimal costo = random.Next(1, 100);
                Thread.Sleep(tiempo * 1000);

                logMessage(cajera.Nombre, cliente.Nombre, producto, tiempo, costo);
            }
        }
    }
}