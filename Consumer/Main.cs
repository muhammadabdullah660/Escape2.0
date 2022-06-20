using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Framwork.Core;
using Framwork.Firing;
using Framwork.Movement;
using Framwork.Enum;
using EZInput;

namespace Consumer
{
    public partial class Main : Form
    {
        private Game g;
        Image img;
        Image imgBullet;
        Player x;

        public Main ()
        {
            InitializeComponent();
        }

        private void Form1_Load (object sender , EventArgs e)
        {
            System.Drawing.Point boundary = new System.Drawing.Point(this.Width , this.Height);
            g = new Game();
            g.OnPlayerAdd += new EventHandler(onGameObjAdded);
            g.OnBulletDel += new EventHandler(onbulletDel);
            imgBullet = Properties.Resources.laserBlue16;
            img = Properties.Resources.tanks__3_;
            x = new Player(imgBullet , img , 100 , 0 , new Framwork.Movement.Keyboard(10 , boundary , 200) , objectTypes.tank , PictureBoxSizeMode.StretchImage , img.Height / 2 , img.Width / 2);
            g.addGameObj(x);

        }
        private void onGameObjAdded (object sender , EventArgs e)
        {
            this.Controls.Add((PictureBox)sender);
        }
        private void onbulletDel (object sender , EventArgs e)
        {
            this.Controls.Remove((PictureBox)sender);
        }

        private void gameLoop_Tick (object sender , EventArgs e)
        {
            if (EZInput.Keyboard.IsKeyPressed(Key.Space))
            {
                x.createBullet(g);
            }
            x.rmvBullet(g);
            g.update();

        }


        private void lblLives_Click (object sender , EventArgs e)
        {

        }
    }
}
