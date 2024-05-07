using Backend.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EZInput;

namespace Backend.BL
{
    public  class KeyBoardHandler : IMotion
    {
        int speed;
        System.Drawing.Point Boundary;
        public KeyBoardHandler(int speed, System.Drawing.Point Boundary)  // Modify this line
        {
            this.speed = speed;
            this.Boundary = Boundary;
        }
        public System.Drawing.Point Move(System.Drawing.Point location)
        {
            if ((location.Y) <= Boundary.Y && Keyboard.IsKeyPressed(Key.DownArrow))
            {
                location.Y += speed;
            }
            else if (location.Y >= 0 && Keyboard.IsKeyPressed(Key.UpArrow))
            {
                location.Y -= speed;
            }
            else if (location.X  >= 0 && Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                location.X -= speed;
            }
            if ((location.X) <= Boundary.X && Keyboard.IsKeyPressed(Key.RightArrow))
            {
                location.X += speed;
            }
            return location;
        }

    }
}
