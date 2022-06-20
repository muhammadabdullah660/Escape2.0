using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace Framwork.Movement
{
    public class Gravity : IMovement
    {
        private int speed;
        public Gravity (int speed)
        {
            this.speed = speed;
        }
        public Point move (Point location)
        {
            location.Y += speed;
            return location;
        }
    }
}
