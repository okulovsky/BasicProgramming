﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Slide09
{
    public class Sensor
    {
        double x;
        Random rnd = new Random();
        public double Measure()
        {
            x += 0.02;
            return Math.Sin(x) + (rnd.NextDouble() - 0.5);
        }
    }

    public class Averager
    {
        Sensor sensor;
        Queue<double> queue;
        int bufferLength;
        double sum;
        public Averager(Sensor sensor, int bufferLength)
        {
            this.bufferLength = bufferLength;
            this.sensor = sensor;
            queue = new Queue<double>();
        }

        public double Measure()
        {
            var value = sensor.Measure();
            queue.Enqueue(value);
            sum += value;
            if (queue.Count > bufferLength)
            {
                sum -= queue.Dequeue();
            }
            return sum / queue.Count;
        }
    }

    public class Program
    {
        public static void MainX()
        {
            var sensor = new Sensor();
            var averager = new Averager(sensor, 1000);

            var chart = new Chart();
            chart.ChartAreas.Add(new ChartArea());
            var raw = new Series();

            for (int i = 0; i < 1000; i++)
                //raw.Points.Add(new DataPoint(i, sensor.Measure()));
                raw.Points.Add(new DataPoint(i, averager.Measure()));




            raw.ChartType = SeriesChartType.FastLine;
            raw.Color = Color.Red;
            chart.Series.Add(raw);

            chart.Dock = System.Windows.Forms.DockStyle.Fill;
            var form = new Form();
            form.Controls.Add(chart);
            form.WindowState = FormWindowState.Maximized;
            Application.Run(form);

        }
    }
}