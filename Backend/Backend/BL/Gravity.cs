using Backend.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Backend.BL
{
    public class Gravity : IMotion
    {
        int gravity;
        Point Boundary;
        int Offset = 20;
        public Gravity(int gravity,Point Boundary)
        {
            this.gravity = gravity;
            this.Boundary = Boundary;
        }
        public Point Move(Point Location)
        {
            if (Location.Y +Offset < this.Boundary.Y)
            {
                Location.Y += gravity;
            }
            return Location;
        }


    }
}
