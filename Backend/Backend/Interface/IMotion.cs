﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Backend.Interface
{
    public interface IMotion
    {
        Point Move(Point location);
    }
}
