using Backend.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Backend.BL
{
    public class ZigZagMotion : IMotion
    {
        int speed;
        string direction;
        Point Boundary;
        int Offset = 20;
        int count;
        public ZigZagMotion(int speed,Point Boundary,string direction)
        {
            this.speed = speed;
            this.direction = direction;
            this.Boundary = Boundary;
            count =0;
        }
        public Point Move(Point location)
        {
            if (direction == "right")
            {
                if (count < 5)
                {
                    location.X += speed;
                    location.Y -= speed;
                }
                else if (count >= 5 && count < 10)
                {
                    location.X += speed;
                    location.Y += speed;
                }
            }
            else if (direction == "left")
            {
                if (count < 5)
                {
                    location.X -= speed;
                    location.Y += speed;
                }
                else if (count >= 5 && count < 10)
                {
                    location.X -= speed;
                    location.Y -= speed;
                }
            }
            if ((location.X + Offset) >= Boundary.X)
            {
                direction = "left";

            }
            else if ((location.X + speed) <= 0)
            {
                direction = "right";

            }
            if (count == 10)
            {
                count = 0;
            }
            count++;
            return location;
        }

    }

}