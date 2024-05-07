using Backend.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Backend.BL
{
    public class HorizontalMotion : IMotion
    {
        int speed ;
        string direction;
        Point Boundary;
        int Offset = 20;
        public HorizontalMotion(int speed,Point boundary,string direction) 
        {
            this.speed = speed;
            this.direction = direction;
            this.Boundary = boundary;
        }
        public Point Move(Point location)
        {
            if ((location.X + Offset) >= Boundary.X)
            {
                direction = "left";
            }
            else if (location.X - Offset <= 0)
            {
                direction = "right";
            }
            if (direction == "left")
            {
                location.X -= speed;
            }
            else if (direction == "right")
            {
                location.X += speed;
            }
            return location;
        }
    }
}
