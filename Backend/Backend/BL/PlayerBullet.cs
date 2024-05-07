using Backend.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.BL
{
    public class PlayerBullet : IMotion
    {
        int speed;
        Point Boundry;
        public PlayerBullet(int speed,Point Boundary)
        {
            this.speed = speed;
            this.Boundry = Boundary;
        }
        public Point Move(Point Location)
        {
            if(Location.Y<=Boundry.Y) 
            { 
                Location.Y -= speed;
            }
            return Location;
        }
    }
}
