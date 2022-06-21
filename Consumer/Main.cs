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
using Framwork.Collisions;
using EZInput;

namespace Consumer
{
    public partial class Main : Form
    {
        Random rand = new Random();
        private int offsetH;
        private int offsetV;
        private Game g;
        private Image imgRoad;
        private Image imgHero;
        private Image scoringPillImg;
        private Image imgBulletHero;
        private Image imgBlueTank;
        private Image imgBulletBlueTank;
        private Player hero;
        private Player tankBlue;
        private GameObject road;
        private GameObject road1;
        private GameObject scoringPill;
        private int tankBlueTimeToBullet;
        private int tankBlueLastTimeToBullet;
        private int tankRedTimeToBullet;
        private int tankRedLastTimeToBullet;
        private int tankGreenTimeToBullet;
        private int tankGreenLastTimeToBullet;
        private int healthPillGenerationTime;
        private int healthPillLastGenerationTime;
        private int scoringPillGenerationTime;
        private int scoringPillLastGenerationTime;
        private int score = 0;


        public Game G { get => g; set => g = value; }
        public Image ImgHero { get => imgHero; set => imgHero = value; }
        public Image ImgBlueTank { get => imgBlueTank; set => imgBlueTank = value; }
        public Image ImgBulletBlueTank { get => imgBulletBlueTank; set => imgBulletBlueTank = value; }
        public Image ImgBulletHero { get => imgBulletHero; set => imgBulletHero = value; }
        public Player Hero { get => hero; set => hero = value; }
        public Player TankBlue { get => tankBlue; set => tankBlue = value; }

        public Main ()
        {
            InitializeComponent();
        }

        private void Form1_Load (object sender , EventArgs e)
        {

            tankBlueTimeToBullet = 40;
            tankBlueLastTimeToBullet = 0;
            scoringPillGenerationTime = 60;
            scoringPillLastGenerationTime = 0;
            offsetH = 250;
            offsetV = 0;
            System.Drawing.Point boundary = new System.Drawing.Point(this.Width , this.Height);
            G = new Game(boundary);
            G.OnPlayerAdd += new EventHandler(onGameObjAdded);
            G.OnBulletDel += new EventHandler(onbulletDel);
            G.OnPlayerCollideScore += new EventHandler(onPlayerCollideScore);
            Collision play = new Collision(objectTypes.player , objectTypes.scorePill , new PlayerCollision());
            g.addCollision(play);
            //Road Creation
            imgRoad = Properties.Resources.background_1_0;
            road = new GameObject(imgRoad , 0 , 0 , new Framwork.Movement.Gravity(2) , objectTypes.road , PictureBoxSizeMode.StretchImage , this.Height , this.Width);
            G.addGameObj(road);
            road1 = new GameObject(imgRoad , road.Pb.Top - this.Height , 0 , new Framwork.Movement.Gravity(2) , objectTypes.road , PictureBoxSizeMode.StretchImage , this.Height , this.Width);
            G.addGameObj(road1);
            //Tanks Creation
            ImgBulletBlueTank = Properties.Resources.laserBlue16;
            ImgBlueTank = Properties.Resources.tanks__3_;
            TankBlue = new Player(ImgBulletBlueTank , ImgBlueTank , 100 , 200 , new Framwork.Movement.Gravity(2) , objectTypes.tank , PictureBoxSizeMode.StretchImage , ImgBlueTank.Height / 2 , ImgBlueTank.Width / 2);
            G.addGameObj(TankBlue);
            //Hero Creation
            ImgBulletHero = Properties.Resources.laserBlue16;
            ImgHero = Properties.Resources.ezgif_com_gif_maker__1_;
            Hero = new Player(ImgBulletHero , ImgHero , this.Height - (imgHero.Height / 2) , this.Width / 2 , new Framwork.Movement.Keyboard(10 , boundary , offsetH , imgHero.Width / 2) , objectTypes.player , PictureBoxSizeMode.StretchImage , ImgHero.Height / 3 , ImgHero.Width / 3);
            G.addGameObj(Hero);
            //Score pills img
            scoringPillImg = Properties.Resources.star_gold;




        }
        private void onGameObjAdded (object sender , EventArgs e)
        {
            this.Controls.Add((PictureBox)sender);
        }
        private void onbulletDel (object sender , EventArgs e)
        {
            this.Controls.Remove((PictureBox)sender);
        }
        private void onPlayerCollideScore (object sender , EventArgs e)
        {
            this.Controls.Remove((PictureBox)sender);
            score += 50;
            lblScore.Text = score.ToString();
        }
        private void gameLoop_Tick (object sender , EventArgs e)
        {
            road.Pb.SendToBack();
            road1.Pb.SendToBack();
            road.Pb.Top += 2;
            road1.Pb.Top += 2;
            if (road.Pb.Top >= this.Height)
            {
                road.Pb.Top = -this.Height;
            }
            if (road1.Pb.Top >= this.Height)
            {
                road1.Pb.Top = -this.Height;
            }
            tankBlueLastTimeToBullet++;
            if (tankBlueLastTimeToBullet == tankBlueTimeToBullet)
            {
                TankBlue.createBullet(G , new Gravity(4) , TankBlue.Pb.Top + TankBlue.Pb.Height , TankBlue.Pb.Left + (TankBlue.Pb.Width / 2));
                tankBlueLastTimeToBullet = 0;
            }
            scoringPillLastGenerationTime++;
            if (scoringPillLastGenerationTime == scoringPillGenerationTime)
            {
                int left = rand.Next(offsetH , this.Width - offsetH);
                int top = rand.Next(5 , this.Height - 20);
                scoringPill = new GameObject(scoringPillImg , top , left , new Framwork.Movement.Gravity(2) , objectTypes.scorePill , PictureBoxSizeMode.StretchImage , scoringPillImg.Height , scoringPillImg.Width);
                G.addGameObj(scoringPill);
                scoringPillLastGenerationTime = 0;
            }
            if (EZInput.Keyboard.IsKeyPressed(Key.Space))
            {
                Hero.createBullet(G , new GravityInvert(10) , Hero.Pb.Top , Hero.Pb.Left + (Hero.Pb.Width / 2));
            }


            TankBlue.rmvBullet(G);
            Hero.rmvBullet(G);
            G.update();

        }


        private void lblLives_Click (object sender , EventArgs e)
        {

        }
    }
}
