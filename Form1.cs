using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Supermercado.Models;
using System.Threading;
using System;

namespace Supermercado
{
    public partial class Form1 : Form
    {
        private List<Thread> cajeraThreads = new List<Thread>();
        private List<Cajera> cajeras = new List<Cajera>();
        private List<Cliente> clientes = new List<Cliente>();
        private List<LogEntry> logEntries = new List<LogEntry>();
        private int totalTime = 0;
        private Dictionary<string, List<LogEntry>> cajeraLogEntries = new Dictionary<string, List<LogEntry>>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnIniciarSimulacion_Click(object sender, EventArgs e)
        {
            foreach (var cliente in clientes)
            {
                foreach (var cajera in cajeras)
                {
                    var cajeraThread = new Thread(() =>
                    {
                        var cajeraObj = new CajeraThread(cajera, cliente, LogMessage);
                        cajeraObj.Run();
                        CajeraFinalizada(cajera.Nombre);
                    });
                    cajeraThreads.Add(cajeraThread);
                    cajeraThread.Start();
                }
            }
        }

        private void btnDetenerSimulacion_Click(object sender, EventArgs e)
        {
            foreach (var thread in cajeraThreads)
            {
                thread.Abort();
            }
        }

        private void btnAgregarCajera_Click(object sender, EventArgs e)
        {
            var cajera = new Cajera("Cajera " + (cajeras.Count + 1));
            cajeras.Add(cajera);
            listBoxCajeras.Items.Add(cajera.Nombre);
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            var cliente = new Cliente("Cliente " + (clientes.Count + 1));
            clientes.Add(cliente);
            listBoxClientes.Items.Add(cliente.Nombre);
        }

        private void btnDetenerCajera_Click(object sender, EventArgs e)
        {
            if (listBoxCajeras.SelectedItem != null)
            {
                var selectedCajera = listBoxCajeras.SelectedItem.ToString();
                var threadToAbort = cajeraThreads.FirstOrDefault(t => t.Name == selectedCajera);
                if (threadToAbort != null)
                {
                    threadToAbort.Abort();
                }
            }
        }

        private void LogMessage(string cajera, string cliente, string producto, int tiempo, decimal costo)
        {
            Invoke(new Action(() =>
            {
                logEntries.Add(new LogEntry
                {
                    Cajera = cajera,
                    Cliente = cliente,
                    Producto = producto,
                    Tiempo = tiempo,
                    Costo = costo
                });

                if (!cajeraLogEntries.ContainsKey(cajera))
                {
                    cajeraLogEntries[cajera] = new List<LogEntry>();
                }
                cajeraLogEntries[cajera].Add(new LogEntry
                {
                    Cajera = cajera,
                    Cliente = cliente,
                    Producto = producto,
                    Tiempo = tiempo,
                    Costo = costo
                });

                dataGridView.DataSource = null;
                dataGridView.DataSource = logEntries;
                totalTime += tiempo;
                lblTotalTime.Text = "Tiempo Total: " + totalTime + " segundos";
            }));
        }

        private void CajeraFinalizada(string cajera)
        {
            Invoke(new Action(() =>
            {
                listBoxResumen.Items.Add($"Resumen de {cajera}:");
                foreach (var entry in cajeraLogEntries[cajera])
                {
                    listBoxResumen.Items.Add($"{entry.Cliente} compró {entry.Producto} por {entry.Costo} en {entry.Tiempo} segundos.");
                }
                listBoxResumen.Items.Add("");
            }));
        }
    }

    public class LogEntry
    {
        public string Cajera { get; set; }
        public string Cliente { get; set; }
        public string Producto { get; set; }
        public int Tiempo { get; set; }
        public decimal Costo { get; set; }
    }
}
