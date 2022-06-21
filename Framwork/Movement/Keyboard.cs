using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using EZInput;
namespace Framwork.Movement
{
    public class Keyboard : IMovement
    {
        private int speed;
        private int offSetH;
        private int offSetV;
        private System.Drawing.Point boundary;
        public Keyboard (int speed , System.Drawing.Point boundary , int offSetH , int offSetV)
        {
            this.speed = speed;
            this.boundary = boundary;
            this.offSetH = offSetH;
            this.offSetV = offSetV;
        }
        public System.Drawing.Point move (System.Drawing.Point location)
        {
            if (EZInput.Keyboard.IsKeyPressed(Key.RightArrow) || EZInput.Keyboard.IsKeyPressed(Key.D))
            {
                if (location.X + offSetH < boundary.X)
                {
                    location.X += speed;
                }
            }
            if (EZInput.Keyboard.IsKeyPressed(Key.LeftArrow) || EZInput.Keyboard.IsKeyPressed(Key.A))
            {
                if (location.X - offSetH > 0)
                {
                    location.X -= speed;
                }
            }
            if (EZInput.Keyboard.IsKeyPressed(Key.UpArrow) || EZInput.Keyboard.IsKeyPressed(Key.W))
            {
                if (location.Y > 0)
                {
                    location.Y -= speed;
                }
            }
            if (EZInput.Keyboard.IsKeyPressed(Key.DownArrow) || EZInput.Keyboard.IsKeyPressed(Key.S))
            {
                if (location.Y + offSetV < boundary.Y)
                {
                    location.Y += speed;
                }

            }
            return location;
        }
    }
}
