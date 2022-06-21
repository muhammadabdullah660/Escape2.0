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

        public void createBullet (Game g , IMovement movement , int top , int left)
        {
            Bullet gO = new Bullet(BulletImg , top , left , movement , objectTypes.playerfire , PictureBoxSizeMode.StretchImage , bulletImg.Height / 2 , bulletImg.Width / 2);
            MyBullets.Add(gO);
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

            for (int i = 0 ; i < myBullets.Count ; i++)
            {
                if (myBullets[i].Pb.Location.Y > g.Boundary.Y && myBullets[i].Movement.GetType() == typeof(Gravity))
                {
                    g.rmvGameObj(myBullets[i]);
                    this.myBullets.Remove(myBullets[i]);

                }
                else if (myBullets[i].Pb.Location.Y <= 0 && myBullets[i].Movement.GetType() == typeof(GravityInvert))
                {
                    g.rmvGameObj(myBullets[i]);
                    this.myBullets.Remove(myBullets[i]);
                }
            }
        }
    }
}
