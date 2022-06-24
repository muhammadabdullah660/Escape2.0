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
        private Image imgBoss;
        private Image imgBossBullet;
        private Image imgHero;
        private Image scoringPillImg;
        private Image healthPillImg;
        private Image imgBulletHero;
        private Image imgBlueTank;
        private Image imgBulletBlueTank;
        private Image imgRedTank;
        private Image imgBulletRedTank;
        private Image imgGreenTank;
        private Image imgBulletGreenTank;
        private Player hero;
        private Player tankBlue;
        private Player tankRed;
        private Player tankGreen;
        private Player boss;
        private GameObject road;
        private GameObject road1;
        private GameObject scoringPill;
        private GameObject healthPill;
        private int tankBlueTimeToBullet;
        private int tankBlueLastTimeToBullet;
        private int tankRedTimeToBullet;
        private int tankRedLastTimeToBullet;
        private int tankGreenTimeToBullet;
        private int tankGreenLastTimeToBullet;
        private int bossTimeToBullet;
        private int bossLastTimeToBullet;
        private int healthPillGenerationTime;
        private int healthPillLastGenerationTime;
        private int scoringPillGenerationTime;
        private int scoringPillLastGenerationTime;
        private int score = 0;
        private int gravityBullet = 6;
        bool flag = true;
        bool flag1 = true;
        bool flagwin = true;


        public Game G { get => g; set => g = value; }
        public Image ImgHero { get => imgHero; set => imgHero = value; }
        public Image ImgBlueTank { get => imgBlueTank; set => imgBlueTank = value; }
        public Image ImgBulletBlueTank { get => imgBulletBlueTank; set => imgBulletBlueTank = value; }
        public Image ImgBulletHero { get => imgBulletHero; set => imgBulletHero = value; }
        public Player Hero { get => hero; set => hero = value; }
        public Player TankBlue { get => tankBlue; set => tankBlue = value; }
        System.Drawing.Point boundary;

        public Main ()
        {
            InitializeComponent();
        }

        private void Form1_Load (object sender , EventArgs e)
        {
            boundary = new System.Drawing.Point(this.Width , this.Height);
            tankBlueTimeToBullet = 30;
            tankBlueLastTimeToBullet = 0;
            bossTimeToBullet = 25;
            tankBlueLastTimeToBullet = 0;
            tankRedTimeToBullet = 20;
            tankRedLastTimeToBullet = 0;
            tankGreenTimeToBullet = 30;
            tankGreenLastTimeToBullet = 0;
            scoringPillGenerationTime = 60;
            scoringPillLastGenerationTime = 0;
            healthPillGenerationTime = 40;
            healthPillLastGenerationTime = 0;
            offsetH = 250;
            offsetV = 0;
            G = new Game(boundary , offsetV , offsetH);
            G.OnPlayerAdd += new EventHandler(onGameObjAdded);
            G.OnBulletDel += new EventHandler(onbulletDel);
            G.OnPlayerCollideEnemy += new EventHandler(onPlayerHit);
            G.OnPlayerCollideEnemyBullet += new EventHandler(onPlayerHit);
            G.OnEnemyCollidePlayerBullet += new EventHandler(onEnemyHit);
            G.OnPlayerCollideScore += new EventHandler(onPlayerCollideScore);
            G.OnProgressBarAdd += new EventHandler(onProgBarAdded);
            G.OnPlayerScoreIncrease += new EventHandler(onPlayerHitEnemy);
            G.OnPlayerCollideHealth += new EventHandler(onPlayerCollideHealth);
            G.OnPlayerCollideBossBullet += new EventHandler(onPlayerHit);
            Collision play = new Collision(objectTypes.player , objectTypes.scorePill , new PlayerCollisionScore());
            g.addCollision(play);
            Collision play1 = new Collision(objectTypes.tank , objectTypes.playerfire , new PlayerBulletCollision());
            g.addCollision(play1);
            Collision play2 = new Collision(objectTypes.player , objectTypes.tankFire , new EnemyBulletCollision());
            g.addCollision(play2);
            Collision play3 = new Collision(objectTypes.player , objectTypes.healthPill , new PlayerCollisionHealth());
            g.addCollision(play3);
            Collision play4 = new Collision(objectTypes.player , objectTypes.bossFire , new BossBulletCollision());
            g.addCollision(play4);
            Collision play5 = new Collision(objectTypes.boss , objectTypes.playerfire , new PlayerBulletCollisionBoss());
            g.addCollision(play5);
            Collision play6 = new Collision(objectTypes.player , objectTypes.tank , new PlayerCollision());
            g.addCollision(play6);
            //Road Creation
            imgRoad = Properties.Resources.background_1_0;
            road = new GameObject(imgRoad , 0 , 0 , new Framwork.Movement.Gravity(2) , objectTypes.road , PictureBoxSizeMode.StretchImage , this.Height , this.Width);
            G.addGameObj(road);
            road1 = new GameObject(imgRoad , road.Pb.Top - this.Height , 0 , new Framwork.Movement.Gravity(2) , objectTypes.road , PictureBoxSizeMode.StretchImage , this.Height , this.Width);
            G.addGameObj(road1);
            //Tanks Creation
            //BLUE Tank
            ImgBulletBlueTank = Properties.Resources.laserBlue16;
            ImgBlueTank = Properties.Resources.tanks__3_;
            TankBlue = new Player(ImgBulletBlueTank , ImgBlueTank , 100 , 250 , new Framwork.Movement.Gravity(4) , objectTypes.tank , PictureBoxSizeMode.StretchImage , ImgBlueTank.Height / 2 , ImgBlueTank.Width / 2);
            TankBlue.createHealthBar(TankBlue.Pb.Left - 15 , TankBlue.Pb.Top - 10);
            G.addGameObj(TankBlue);
            //RED Tank
            imgBulletRedTank = Properties.Resources.laserRed16;
            imgRedTank = Properties.Resources.tanks;
            tankRed = new Player(imgBulletRedTank , imgRedTank , 100 , 500 , new Framwork.Movement.Gravity(5) , objectTypes.tank , PictureBoxSizeMode.StretchImage , imgRedTank.Height / 2 , imgRedTank.Width / 2);
            tankRed.createHealthBar(tankRed.Pb.Left - 15 , tankRed.Pb.Top - 10);
            G.addGameObj(tankRed);
            //Green Tank
            imgBulletGreenTank = Properties.Resources.laserGreen10;
            imgGreenTank = Properties.Resources.tanks__4_;
            tankGreen = new Player(imgBulletGreenTank , imgGreenTank , 100 , 800 , new Framwork.Movement.Gravity(6) , objectTypes.tank , PictureBoxSizeMode.StretchImage , imgGreenTank.Height / 2 , imgGreenTank.Width / 2);
            tankGreen.createHealthBar(tankGreen.Pb.Left - 15 , tankGreen.Pb.Top - 10);
            G.addGameObj(tankGreen);
            //Hero Creation
            ImgBulletHero = Properties.Resources.laserBlue16;
            ImgHero = Properties.Resources.ezgif_com_gif_maker__1_;
            Hero = new Player(ImgBulletHero , ImgHero , this.Height - (imgHero.Height / 2) , this.Width / 2 , new Framwork.Movement.Keyboard(10 , boundary , offsetH , imgHero.Width / 2) , objectTypes.player , PictureBoxSizeMode.StretchImage , ImgHero.Height / 3 , ImgHero.Width / 3);
            Hero.createHealthBar(hero.Pb.Left - 10 , hero.Pb.Top + hero.Pb.Height);
            G.addGameObj(Hero);
            //Score pills img
            scoringPillImg = Properties.Resources.star_gold;
            //Health pills img
            healthPillImg = Properties.Resources.bolt_gold;
        }
        private void onPlayerHit (object sender , EventArgs e)
        {
            Player x = ((Player)sender);
            this.Controls.Remove(x.HealthBar);
            this.Controls.Remove(x.Pb);
        }
        private void onPlayerHitEnemy (object sender , EventArgs e)
        {
            score += 100;
            lblScore.Text = score.ToString();
        }
        private void onEnemyHit (object sender , EventArgs e)
        {
            score += 500;
            lblScore.Text = score.ToString();
            Player x = (Player)sender;
            int i = x.MyBullets.Count - 1;
            while (i >= 0)
            {
                this.Controls.Remove(x.MyBullets[i].Pb);
                x.MyBullets.RemoveAt(i);
                i--;
            }
            this.Controls.Remove(x.HealthBar);
            this.Controls.Remove(x.Pb);
            //nullify tank to stop bullet generation in timetick
            checkObjectExist(x);

        }
        private void checkObjectExist (Player x)
        {
            if (x == tankRed)
            {
                tankRed = null;
            }
            else if (x == tankBlue)
            {
                tankBlue = null;
            }
            else if (x == tankGreen)
            {
                tankGreen = null;
            }
            else if (x == boss)
            {
                boss = null;
            }
        }
        private void onGameObjAdded (object sender , EventArgs e)
        {
            this.Controls.Add((PictureBox)sender);
        }
        private void onProgBarAdded (object sender , EventArgs e)
        {
            this.Controls.Add((ProgressBar)sender);
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
        private void onPlayerCollideHealth (object sender , EventArgs e)
        {
            this.Controls.Remove((PictureBox)sender);
            Hero.HealthBar.Value += 10;
        }
        private void gameLoop_Tick (object sender , EventArgs e)
        {

            //Road Movement
            roadMovement();
            tankBlueLastTimeToBullet++;
            if (tankBlueLastTimeToBullet == tankBlueTimeToBullet)
            {
                TankBlue?.createBullet(G , new Gravity(gravityBullet + 4) , TankBlue.Pb.Top + TankBlue.Pb.Height , TankBlue.Pb.Left + (TankBlue.Pb.Width / 2) , objectTypes.tankFire);
                tankBlueLastTimeToBullet = 0;
            }
            tankGreenLastTimeToBullet++;
            if (tankGreenLastTimeToBullet == tankGreenTimeToBullet)
            {
                tankGreen?.createBullet(G , new Gravity(gravityBullet * 3) , tankGreen.Pb.Top + tankGreen.Pb.Height , tankGreen.Pb.Left + (tankGreen.Pb.Width / 2) , objectTypes.tankFire);
                tankGreenLastTimeToBullet = 0;
            }
            tankRedLastTimeToBullet++;
            if (tankRedLastTimeToBullet == tankRedTimeToBullet)
            {
                tankRed?.createBullet(G , new Gravity(gravityBullet * 2) , tankRed.Pb.Top + tankRed.Pb.Height , tankRed.Pb.Left + (tankRed.Pb.Width / 2) , objectTypes.tankFire);
                tankRedLastTimeToBullet = 0;
            }
            if (g.isBossExist())
            {
                bossLastTimeToBullet++;
                if (bossLastTimeToBullet == bossTimeToBullet)
                {
                    boss?.createBullet(G , new Gravity(gravityBullet * 4) , boss.Pb.Top + boss.Pb.Height , boss.Pb.Left + (boss.Pb.Width / 2) , objectTypes.bossFire);
                    bossLastTimeToBullet = 0;
                }
            }

            //Scoring Pill
            scoringPillLastGenerationTime++;
            if (scoringPillLastGenerationTime == scoringPillGenerationTime)
            {
                createScoringPill();
                scoringPillLastGenerationTime = 0;
            }
            healthPillLastGenerationTime++;
            if (healthPillLastGenerationTime == healthPillGenerationTime)
            {
                if (hero.HealthBar.Value < 60)
                {
                    createHealthPill();
                }
                healthPillLastGenerationTime = 0;
            }
            //Player Fire
            if (EZInput.Keyboard.IsKeyPressed(Key.Space) && flag1 == true)
            {
                Hero.createBullet(G , new GravityInvert(10) , Hero.Pb.Top , Hero.Pb.Left + (Hero.Pb.Width / 2) , objectTypes.playerfire);
            }
            if (g.numOfTanks() == 0 && flag == true)
            {
                imgBoss = Properties.Resources.ezgif_com_gif_maker;
                imgBossBullet = Properties.Resources.Explosion_B;
                boss = new Player(imgBossBullet , imgBoss , 0 , this.Width / 2 , new Framwork.Movement.Horizontal(5 , boundary , "Right" , offsetH + 200) , objectTypes.boss , PictureBoxSizeMode.StretchImage , imgBoss.Height / 2 , imgBoss.Width / 2);
                boss.createHealthBar(boss.Pb.Left + boss.Pb.Width , boss.Pb.Top + boss.Pb.Height);
                G.addGameObj(boss);
                flag = false;
            }
            tankGreen?.rmvBullet(G);
            tankRed?.rmvBullet(G);
            TankBlue?.rmvBullet(G);
            boss?.rmvBullet(G);
            Hero.rmvBullet(G);
            G.update();
            if (g.isWin() && flag == false && flagwin == true)
            {
                flagwin = false;
                MessageBox.Show($"You Won, Score = {score.ToString()}");
                gameLoop.Enabled = false;
                this.Close();
            }
            if (g.isGameOver() && flagwin == true)
            {
                flagwin = false;
                MessageBox.Show($"You lost, Score = {score.ToString()}");
                gameLoop.Enabled = false;
                this.Close();
            }
        }
        private void roadMovement ()
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
        }
        private void createScoringPill ()
        {
            try
            {
                int left = rand.Next(offsetH , this.Width - offsetH);
                int top = rand.Next(5 , this.Height - 500);
                scoringPill = new GameObject(scoringPillImg , top , left , new Framwork.Movement.Gravity(5) , objectTypes.scorePill , PictureBoxSizeMode.StretchImage , scoringPillImg.Height , scoringPillImg.Width);
                G.addGameObj(scoringPill);
            }
            catch (Exception e)
            {

            }
        }
        private void createHealthPill ()
        {
            try
            {
                int left = rand.Next(offsetH , this.Width - offsetH);
                int top = rand.Next(5 , this.Height - 500);
                healthPill = new GameObject(healthPillImg , top , left , new Framwork.Movement.Gravity(5) , objectTypes.healthPill , PictureBoxSizeMode.StretchImage , healthPillImg.Height , healthPillImg.Width);
                G.addGameObj(healthPill);
            }
            catch (Exception e)
            {

            }
        }
        private void lblLives_Click (object sender , EventArgs e)
        {

        }
    }
}
