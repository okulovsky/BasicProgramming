﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace S06
{
    public class TimerEventArgs : EventArgs
    {
        public int Time { get; set; }
    }

    public delegate void TimerEventHandler(object sender, TimerEventArgs args);


    class Timer
    {
        public int Interval { get; set; }

        public event TimerEventHandler Tick;

        protected virtual void OnTick(object sender, TimerEventArgs args)
        {
            if (Tick != null)
                Tick(sender, args);
        }

        public void Start()
        {
            for (int i = 0; ; i++)
            {
                if (Tick != null) OnTick(this, new TimerEventArgs { Time = i });
                Thread.Sleep(Interval);
            }
        }
    }
}