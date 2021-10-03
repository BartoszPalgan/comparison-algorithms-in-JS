using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algorytmy_San
{
    public partial class Form1 : Form
    {

        int maxSize = 20;

        public Form1()
        {
            InitializeComponent();
            dataGridView1.ColumnCount = 10;
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[0].HeaderText = "Array size";
            dataGridView1.Columns[1].HeaderText = "Selection sort";
            dataGridView1.Columns[2].HeaderText = "Insertion sort";
            dataGridView1.Columns[3].HeaderText = "Quick sort";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            maxSize = Convert.ToInt32(numericUpDown1.Value);
        }

        private void btnCreateArrays_Click(object sender, EventArgs e)
        {
            int[] tab1, tab2, tab3, tab4, tab5;
            string[] row = new string[4];
            Random random = new Random();
            int min = Convert.ToInt32(txtBoxMin.Text);
            int max = Convert.ToInt32(txtBoxMax.Text);
            for (int i = 1; i <= maxSize; i++)
            {
                tab1 = new int[i];
                tab2 = new int[i];
                tab3 = new int[i];

                for (int j = 0; j < tab1.Length; j++)
                {
                    if (min <= max) tab1[j] = random.Next(min, max);
                    else tab1[j] = random.Next(max, min);
                    tab2[j] = tab1[j];
                    tab3[j] = tab1[j];
                }

                row[0] = i.ToString();
                row[1] = Sorting_algorithms.selectionSort(tab1).ToString();
                row[2] = Sorting_algorithms.insertionSort(tab2).ToString();
                row[3] = Sorting_algorithms.quickSort(tab3, 0, tab3.Length - 1).ToString();
                dataGridView1.Rows.Add(row);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChart_Click(object sender, EventArgs e)
        {
            if (chart1.Series.Count > 0) chart1.Series.Clear();
            chart1.Invalidate();
            chart1.Series.Add("SelectionSort");
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[0].Color = System.Drawing.Color.Red;
            chart1.Series[0].BorderWidth = 4;

            chart1.Series.Add("InsertionSort");
            chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[1].Color = System.Drawing.Color.Green;
            chart1.Series[1].BorderWidth = 3;

            chart1.Series.Add("QuickSort");
            chart1.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[2].Color = System.Drawing.Color.Blue;
            chart1.Series[2].BorderWidth = 2;

            for (int i = 0; i < maxSize; i++)
            {
                chart1.Series[0].Points.AddXY(dataGridView1.Rows[i].Cells[0].Value, dataGridView1.Rows[i].Cells[1].Value);
                chart1.Series[1].Points.AddXY(dataGridView1.Rows[i].Cells[0].Value, dataGridView1.Rows[i].Cells[2].Value);
                chart1.Series[2].Points.AddXY(dataGridView1.Rows[i].Cells[0].Value, dataGridView1.Rows[i].Cells[3].Value);
            }

            chart1.Invalidate();
        }
    }
}
