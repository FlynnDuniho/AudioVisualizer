﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AudioVisualizer
{
    class RenderEventArgs : EventArgs
    {
        public RenderBase Render { get; private set; }

        public RenderEventArgs(RenderBase r)
        {
            Render = r;
        }
    }
}
