using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Slide09
{
    public class Program
    {
        static void Main()
        {
            var experimentalData = new List<PointF>();

            var rnd = new Random();
            for (float x = 0; x < 1; x+=0.0001f)
            {
                experimentalData.Add(new PointF(x, (float)(x * x + rnd.NextDouble())));
            }

            var chart = new Chart();
            chart.ChartAreas.Add(new ChartArea());
            var raw = new Series();

            foreach (var point in experimentalData)
                raw.Points.Add(new DataPoint(point.X, point.Y));

            raw.ChartType = SeriesChartType.FastLine;
            raw.Color = Color.Red;
            chart.Series.Add(raw);

            var smooth=new Series();
            MakeSmooth(experimentalData, smooth,50);

            smooth.ChartType = SeriesChartType.FastLine;
            smooth.Color = Color.Green;
            smooth.BorderWidth = 5;
            chart.Series.Add(smooth);

            chart.Dock = System.Windows.Forms.DockStyle.Fill;
            var form = new Form();
            form.Controls.Add(chart);
            form.WindowState = FormWindowState.Maximized;
            Application.Run(form);
        }

        static void MakeSmooth(List<PointF> experimentalData, Series series, int windowWidth)
        {
            float Sum = 0;
            var queue = new Queue<float>();
            foreach (var e in experimentalData)
            {
                Sum += e.Y;
                queue.Enqueue(e.Y);
                if (queue.Count == windowWidth)
                    Sum-=queue.Dequeue();
                series.Points.Add(new DataPoint(e.X, Sum / queue.Count));
            }

        }
    }
}