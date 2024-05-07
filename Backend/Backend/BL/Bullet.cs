using Backend.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.BL
{
    public class Bullet :IMotion
    {
        int speed ;
        Point Boundary;
        public Bullet(int speed, Point boundary)
        {
            this.speed = speed;
            Boundary = boundary;
        }
        public Point Move(Point location)
        {
            if(location.Y<Boundary.Y) 
            {
                location.Y += speed;
            }
            return location;
        }
    }
}
