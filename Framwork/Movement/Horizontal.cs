using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace Framwork.Movement
{
    public class Horizontal : IMovement
    {

        private string direction;
        private Point boundary;
        private int speed;
        private int offSet;
        public Horizontal (int speed , Point boundary , string direction , int offSet)
        {
            this.speed = speed;
            this.boundary = boundary;
            this.direction = direction;
            this.offSet = offSet;
        }
        public Point move (Point location)
        {
            if (location.X <= 0)
            {
                direction = "Right";
            }
            else if (location.X + offSet >= boundary.X)
            {
                direction = "Left";
            }
            if (direction == "Left")
            {
                location.X -= speed;
            }
            else if (direction == "Right")
            {
                location.X += speed;
            }
            return location;
        }
    }
}
