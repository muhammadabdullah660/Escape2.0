using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framwork.Collisions;
using Framwork.Core;
using Framwork.Movement;
using Framwork.Firing;
using Framwork.Enum;
using System.Drawing;
using System.Windows.Forms;
namespace Framwork.HealthSystem
{
    public class ProgBar : GameObject
    {
        private ProgressBar healthBar;

        public ProgBar (Image img , int top , int left , IMovement movement , objectTypes type , PictureBoxSizeMode mode , int height , int width) : base(img , top , left , movement , type , mode , height , width)
        {
            healthBar = new ProgressBar();
            healthBar.Value = 100;
            healthBar.Top = top;
            healthBar.Left = left;
            healthBar.Height /= 2;

        }

        public ProgressBar HealthBar { get => healthBar; set => healthBar = value; }
       

    }
}
