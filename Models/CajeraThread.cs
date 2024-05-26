using System;
using System.Collections.Generic;
using System.Threading;
using Supermercado.Models;

namespace Supermercado
{
    public class CajeraThread
    {
        private Cajera cajera;
        private Cliente cliente;
        private Action<string, string, string, int, decimal> logCallback;
        private CancellationToken cancellationToken;
        private static Random random = new Random();

        public CajeraThread(Cajera cajera, Cliente cliente, Action<string, string, string, int, decimal> logCallback, CancellationToken cancellationToken)
        {
            this.cajera = cajera;
            this.cliente = cliente;
            this.logCallback = logCallback;
            this.cancellationToken = cancellationToken;
        }

        public void Run()
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                // Simular la compra de un producto aleatorio
                string producto = $"Producto {random.Next(1, 101)}";
                int cantidad = random.Next(1, 5);
                decimal costo = random.Next(1, 100);

                // Simular el tiempo de procesamiento
                int tiempo = random.Next(1, 10);
                Thread.Sleep(tiempo * 1000);

                // Loguear la información
                logCallback(cajera.Nombre, cliente.Nombre, producto, tiempo, costo);
            }
        }
    }
}
