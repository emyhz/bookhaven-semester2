using LogicLayer.EntityClasses;
using LogicLayer.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BookHavenDesktop.Forms.MainPages
{
    public partial class Statistics : Form
    {
        private readonly BookManager _bookManager;

        public Statistics(BookManager bookManager)
        {
            InitializeComponent();
            _bookManager = bookManager;

            // Create the chart
            Chart salesChart = new Chart
            {
                Dock = DockStyle.Fill
            };

            // Add the chart to the form
            Controls.Add(salesChart);

            // Configure the chart area
            ChartArea chartArea = new ChartArea("SalesChartArea");
            salesChart.ChartAreas.Add(chartArea);

            // Configure the legend
            Legend legend = new Legend("SalesLegend");
            salesChart.Legends.Add(legend);

            // Load the data and configure the series
            LoadSalesData(salesChart);
        }

        private void LoadSalesData(Chart salesChart)
        {
            // Fetch data using BookManager
            var booksBySales = _bookManager.GetSalesByBookType();

            // Separate sales data for audiobooks and physical books
            int audioBookSales = 0;
            int physicalBookSales = 0;

            foreach (var book in booksBySales)
            {
                if (book is AudioBook)
                {
                    audioBookSales += book.Sales;
                }
                else if (book is PhysicalBook)
                {
                    physicalBookSales += book.Sales;
                }
            }

            // Clear any existing series to avoid overlaps
            salesChart.Series.Clear();
            salesChart.ChartAreas.Clear();
            salesChart.Titles.Clear();

            // Add a new chart area
            ChartArea chartArea = new ChartArea("MainChartArea")
            {
                AxisX =
        {
            Title = "Book Types",
            LabelStyle = { Font = new Font("Arial", 10, FontStyle.Bold) } // Bold labels for better visibility
        },
                AxisY =
        {
            Title = "Sales",
            LabelStyle = { Format = "0", Font = new Font("Arial", 10, FontStyle.Regular) },
            Minimum = 0 // Start Y-axis at zero to avoid negative values
        }
            };

            // Add the chart area to the chart
            salesChart.ChartAreas.Add(chartArea);

            // Add a title to the chart
            salesChart.Titles.Add(new Title
            {
                Text = "Book Sales by Type of Book",
                Font = new Font("Arial", 14, FontStyle.Bold),
                Alignment = ContentAlignment.TopCenter
            });

            // Configure the legend to display labels
            Legend legend = new Legend
            {
                Docking = Docking.Right,
                Font = new Font("Arial", 10, FontStyle.Regular)
            };
            salesChart.Legends.Clear();
            salesChart.Legends.Add(legend);

            // Create series for audiobooks
            Series audioBookSeries = new Series("Audiobooks")
            {
                ChartType = SeriesChartType.Bar,
                IsValueShownAsLabel = true, // Show values on the chart
                Color = Color.Blue
            };
            audioBookSeries.Points.AddY(audioBookSales);

            // Create series for physical books
            Series physicalBookSeries = new Series("Physical Books")
            {
                ChartType = SeriesChartType.Bar,
                IsValueShownAsLabel = true, // Show values on the chart
                Color = Color.Orange
            };
            physicalBookSeries.Points.AddY(physicalBookSales);

            // Add the series to the chart
            salesChart.Series.Add(audioBookSeries);
            salesChart.Series.Add(physicalBookSeries);

            // Adjust margins to prevent labels or numbers from being cut off
            salesChart.ChartAreas["MainChartArea"].InnerPlotPosition = new ElementPosition(10, 10, 80, 80);

            // Force redraw to ensure labels and values are updated properly
            salesChart.Invalidate();
        }

    }
}
