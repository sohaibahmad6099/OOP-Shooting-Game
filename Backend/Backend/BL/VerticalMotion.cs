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
    public class VerticalMotion : IMotion
    {
        int speed;
        string direction; 
        Point Boundary;
        int Offset = 20;
        public VerticalMotion(int speed,Point Boundary, string direction)
        {
            this.speed = speed;
            this.direction = direction;
            this.Boundary = Boundary;
        }
        public Point Move(Point location)
        {
            if ((location.Y + Offset) >= Boundary.Y)
            {
                direction = "up";
            }

            else if (location.Y - Offset <= 0)
            {
                direction = "down";
            }
            if (direction == "up")
            {
                location.Y -= speed;
            }
            else if (direction == "down")
            {
                location.Y += speed;
            }
            return location;
        }
    }
}
