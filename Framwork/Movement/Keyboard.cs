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
        private int offSet;
        private System.Drawing.Point boundary;
        private string arrowAction;
        public Keyboard (int speed , System.Drawing.Point boundary , int offSet)
        {
            this.speed = speed;
            this.boundary = boundary;
            this.offSet = offSet;
            arrowAction = null;
        }
        public System.Drawing.Point move (System.Drawing.Point location)
        {
            if (EZInput.Keyboard.IsKeyPressed(Key.RightArrow) || EZInput.Keyboard.IsKeyPressed(Key.D))
            {
                if (location.X + offSet < boundary.X)
                {
                    location.X += speed;
                }
            }
            if (EZInput.Keyboard.IsKeyPressed(Key.LeftArrow) || EZInput.Keyboard.IsKeyPressed(Key.A))
            {
                if (location.X + offSet > offSet)
                {
                    location.X -= speed;
                }
            }
            if (EZInput.Keyboard.IsKeyPressed(Key.UpArrow) || EZInput.Keyboard.IsKeyPressed(Key.W))
            {
                if (location.Y + offSet > offSet)
                {
                    location.Y -= speed;
                }
            }
            if (EZInput.Keyboard.IsKeyPressed(Key.DownArrow) || EZInput.Keyboard.IsKeyPressed(Key.S))
            {
                if (location.Y + offSet < boundary.Y)
                {
                    location.Y += speed;
                }

            }
            return location;
        }
    }
}
