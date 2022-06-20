using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace Framwork.Movement
{
    public class Vertical : IMovement
    {
        private string direction;
        private Point boundary;
        private int speed;
        private int offSet;
        public Vertical (int speed , Point boundary , string direction , int offSet)
        {
            this.speed = speed;
            this.boundary = boundary;
            this.direction = direction;
            this.offSet = offSet;
        }
        public Point move (Point location)
        {
            if (location.Y + offSet <= 0)
            {
                direction = "Down";
            }
            else if (location.Y + offSet < boundary.Y)
            {
                direction = "Up";
            }
            if (direction == "Up")
            {
                location.Y -= speed;
            }
            else if (direction == "Down")
            {
                location.Y += speed;
            }
            return location;
        }
    }
}
