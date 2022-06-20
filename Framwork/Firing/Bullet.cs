using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framwork.Core;
using Framwork.Movement;
using Framwork.Enum;
using System.Windows.Forms;
using System.Drawing;
namespace Framwork.Firing
{
    public class Bullet : GameObject
    {
        public Bullet (Image img , int top , int left , IMovement movement , objectTypes type , PictureBoxSizeMode mode , int height , int width) : base(img , top , left , movement , type , mode , height , width)
        {
        }

    }
}
