using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Supermercado.Models;

namespace Supermercado
{
    public partial class Form1 : Form
    {
        private List<Task> cajeraTasks = new List<Task>();
        private List<CancellationTokenSource> cancellationTokens = new List<CancellationTokenSource>();
        private List<Cajera> cajeras = new List<Cajera>();
        private List<Cliente> clientes = new List<Cliente>();
        private List<LogEntry> logEntries = new List<LogEntry>();
        private int totalTime = 0;
        private Dictionary<string, List<LogEntry>> cajeraLogEntries = new Dictionary<string, List<LogEntry>>();
        private Dictionary<string, Dictionary<string, (int totalProductos, decimal totalCosto)>> clienteCajeraTotals = new Dictionary<string, Dictionary<string, (int, decimal)>>();

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
                    var cancellationTokenSource = new CancellationTokenSource();
                    cancellationTokens.Add(cancellationTokenSource);

                    var cajeraTask = Task.Run(() =>
                    {
                        var cajeraObj = new CajeraThread(cajera, cliente, LogMessage, cancellationTokenSource.Token);
                        cajeraObj.Run();
                        CajeraFinalizada(cajera.Nombre);
                    }, cancellationTokenSource.Token);
                    cajeraTasks.Add(cajeraTask);
                }
            }
        }

        private void btnDetenerSimulacion_Click(object sender, EventArgs e)
        {
            foreach (var token in cancellationTokens)
            {
                token.Cancel();
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
                var index = cajeras.FindIndex(c => c.Nombre == selectedCajera);
                if (index >= 0 && index < cancellationTokens.Count)
                {
                    cancellationTokens[index].Cancel();
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

                // Actualizar los totales de productos y costos
                if (!clienteCajeraTotals.ContainsKey(cliente))
                {
                    clienteCajeraTotals[cliente] = new Dictionary<string, (int, decimal)>();
                }
                if (!clienteCajeraTotals[cliente].ContainsKey(cajera))
                {
                    clienteCajeraTotals[cliente][cajera] = (0, 0m);
                }
                clienteCajeraTotals[cliente][cajera] = (
                    clienteCajeraTotals[cliente][cajera].totalProductos + 1,
                    clienteCajeraTotals[cliente][cajera].totalCosto + costo
                );

                // Actualizar DataGridView
                dataGridView.DataSource = null;
                dataGridView.DataSource = logEntries;

                // Actualizar lblTotalTime
                totalTime += tiempo;
                lblTotalTime.Text = "Tiempo Total: " + totalTime + " segundos";

                // Actualizar listBoxTotalClienteCajera
                UpdateTotalClienteCajeraListBox();
            }));
        }

        private void UpdateTotalClienteCajeraListBox()
        {
            listBoxTotalClienteCajera.Items.Clear();
            foreach (var cliente in clienteCajeraTotals)
            {
                foreach (var cajera in cliente.Value)
                {
                    listBoxTotalClienteCajera.Items.Add($"{cliente.Key} con {cajera.Key} - Total Productos: {cajera.Value.totalProductos}, Total Costo: {cajera.Value.totalCosto:C}");
                }
            }
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
