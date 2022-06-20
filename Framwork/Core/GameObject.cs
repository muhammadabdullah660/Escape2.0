using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Framwork.Movement;
using Framwork.Enum;

namespace Framwork.Core
{
    public class GameObject
    {
        private PictureBox pb;
        private IMovement movement;
        private objectTypes type;

        public GameObject (Image img , int top , int left , IMovement movement , objectTypes type , PictureBoxSizeMode mode , int height , int width)
        {
            Pb = new PictureBox();
            Pb.Image = img;
            Pb.BackColor = Color.Transparent;
            Pb.Height = height;
            Pb.Width = width;
            Pb.Top = top;
            Pb.Left = left;
            Pb.SizeMode = mode;
            this.Movement = movement;
            this.type = type;
        }

        public IMovement Movement { get => movement; set => movement = value; }
        public PictureBox Pb { get => pb; set => pb = value; }
        public objectTypes Type { get => type; set => type = value; }

        public void move ()
        {
            Pb.Location = Movement.move(Pb.Location);
        }

    }
}
