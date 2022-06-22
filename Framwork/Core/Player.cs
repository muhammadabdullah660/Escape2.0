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
        private int barLeft;
        private int barTop;
        private List<Bullet> myBullets;
        private Image bulletImg;
        public Player (Image bulletImg , Image img , int top , int left , IMovement movement , objectTypes type , PictureBoxSizeMode mode , int height , int width) : base(img , top , left , movement , type , mode , height , width)
        {
            HealthBar = new ProgressBar();
            this.MyBullets = new List<Bullet>();
            this.bulletImg = bulletImg;
        }

        public List<Bullet> MyBullets { get => myBullets; set => myBullets = value; }
        public Image BulletImg { get => bulletImg; set => bulletImg = value; }
        public ProgressBar HealthBar { get => healthBar; set => healthBar = value; }

        public void createHealthBar (int left , int top)
        {
            barLeft = left;
            barTop = top;
            HealthBar.Value = 100;
            HealthBar.Top = top;
            HealthBar.Left = left;
            HealthBar.Height /= 2;
        }
        public void setPositionProgressBar ()
        {
            HealthBar.Left = base.Pb.Left - 10;
            HealthBar.Top = base.Pb.Top + base.Pb.Height;
        }
        public void createBullet (Game g , IMovement movement , int top , int left , objectTypes type)
        {
            Bullet gO = new Bullet(BulletImg , top , left , movement , type , PictureBoxSizeMode.StretchImage , bulletImg.Height / 2 , bulletImg.Width / 2);
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
                if ((myBullets[i].Pb.Location.Y > g.Boundary.Y && myBullets[i].Movement.GetType() == typeof(Gravity)) || (myBullets[i].Pb.Location.Y <= 0 && myBullets[i].Movement.GetType() == typeof(GravityInvert)))
                {
                    g.rmvGameObj(myBullets[i]);
                    this.myBullets.Remove(myBullets[i]);

                }
            }
        }
        public void tankReset (Point Boundary , int offSetH , int offSetV)
        {
            if (base.Pb.Location.Y >= Boundary.Y)
            {
                Random rand = new Random();
                this.Pb.Top = 0;
                this.Pb.Left = rand.Next(offSetH , Boundary.X - offSetH);
            }
        }
    }
}
