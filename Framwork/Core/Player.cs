using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Framwork.Collisions;
using Framwork.Enum;
using Framwork.Movement;
using Framwork.Firing;
namespace Framwork.Core
{
    public class Player : GameObject
    {
        private ProgressBar healthBar;
        private List<Bullet> myBullets;
        private Image bulletImg;
        public Player (Image bulletImg , Image img , int top , int left , IMovement movement , objectTypes type , PictureBoxSizeMode mode , int height , int width) : base(img , top , left , movement , type , mode , height , width)
        {
            healthBar = new ProgressBar();
            this.MyBullets = new List<Bullet>();
            this.bulletImg = bulletImg;
        }

        public List<Bullet> MyBullets { get => myBullets; set => myBullets = value; }
        public Image BulletImg { get => bulletImg; set => bulletImg = value; }

        public void createBullet (Game g)
        {
            Bullet gO = new Bullet(BulletImg , 0 , 0 , new Gravity(10) , objectTypes.playerfire , PictureBoxSizeMode.StretchImage , bulletImg.Height / 2 , bulletImg.Width / 2);
            gO.Pb.Top = base.Pb.Top + base.Pb.Height;
            gO.Pb.Left = base.Pb.Left + (base.Pb.Width / 2);
            g.addGameObj(gO);
        }
        public void fireBullet ()
        {
            foreach (Bullet b in MyBullets)
            {
                b.move();
            }
        }
        public void rmvBullet (Game g)
        {
            foreach (Bullet b in MyBullets)
            {
                if (b.Pb.Location.Y > 200)
                {
                    g.rmvGameObj(b);
                    this.MyBullets.Remove(b);
                    break;
                }
            }
        }
    }
}
