﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AudioVisualizer
{
    class RenderWaveform : RenderBase
    {
        public RenderWaveform(Settings s, string n) : base(s, n) 
        {
            Settings.Colors.Add(new NamedColor("Color", Color.White));
        }

        public override void Render(Graphics g, float[] heights)
        {
            List<PointF> points = new List<PointF>();

            for (int i = 0; i < heights.Length; i++)
            {
                float height = Smooth(heights, i, Settings.Smoothing);

                points.Add(new PointF(i / (float)heights.Length * g.VisibleClipBounds.Width * Settings.XScale, (float)( g.VisibleClipBounds.Size.Height / 2 - height * Settings.YScale)));

                if (i / (float)heights.Length *  g.VisibleClipBounds.Width * Settings.XScale >  g.VisibleClipBounds.Width)
                {
                    break;
                }
            }

            Pen p = new Pen(Settings.GetColor("Color"), 2.0f);

            g.DrawLines(p, points.ToArray());
        }
    }
}
