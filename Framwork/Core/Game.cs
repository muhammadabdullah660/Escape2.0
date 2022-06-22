using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Framwork.Movement;
using Framwork.Enum;
using Framwork.Collisions;
namespace Framwork.Core
{
    public class Game : IGame
    {
        private Point boundary;
        private int offSetV;
        private int offSetH;
        private static List<Collision> collisionList = new List<Collision>();
        private static List<GameObject> gameObjList = new List<GameObject>();


        public static List<GameObject> GameObjList { get => gameObjList; set => gameObjList = value; }
        public static List<Collision> CollisionList { get => collisionList; set => collisionList = value; }
        public Point Boundary { get => boundary; set => boundary = value; }
        public int OffSetH { get => offSetH; set => offSetH = value; }
        public int OffSetV { get => offSetV; set => offSetV = value; }

        public event EventHandler OnBulletDel;
        public event EventHandler OnPlayerAdd;
        public event EventHandler OnProgressBarAdd;
        public event EventHandler OnPlayerDie;
        public event EventHandler OnPlayerCollideScore;
        public event EventHandler OnPlayerCollideHealth;
        public event EventHandler OnPlayerCollideEnemy;
        public event EventHandler OnPlayerScoreIncrease;
        public event EventHandler OnEnemyCollidePlayerBullet;
        public event EventHandler OnPlayerCollideEnemyBullet;
        public event EventHandler OnPlayerCollideBossBullet;

        public Game (Point boundary , int offSetV , int offSetH)
        {
            this.Boundary = boundary;
            this.offSetH = offSetH;
            this.offSetV = offSetV;
        }
        public void update ()
        {
            for (int i = 0 ; i < GameObjList.Count ; i++)
            {
                GameObjList[i].move();
                if (GameObjList[i].Type == objectTypes.player)
                {
                    Player x = (Player)GameObjList[i];
                    x.fireBullet();
                    x.setPositionProgressBar();
                    // x.rmvBullet(this);
                }
                if (GameObjList[i].Type == objectTypes.tank)
                {
                    Player x = (Player)GameObjList[i];
                    x.tankReset(Boundary , offSetH , offSetV);
                    x.setPositionProgressBar();
                }
                if (GameObjList[i].Type == objectTypes.boss)
                {
                    Player x = (Player)GameObjList[i];
                    x.setPositionProgressBar();
                }
                detectCollision();


            }

        }
        public int numOfTanks ()
        {
            int count = 0;
            foreach (GameObject item in GameObjList)
            {
                if (item.Type == objectTypes.tank)
                {
                    count++;
                }
            }
            return count;
        }
        public int numOfBoss ()
        {
            int count = 0;
            foreach (GameObject item in GameObjList)
            {
                if (item.Type == objectTypes.boss)
                {
                    count++;
                }
            }
            return count;
        }
        public bool isWin ()
        {
            if (numOfBoss() == 0 && numOfTanks() == 0)
            {
                return true;
            }
            return false;
        }
        public bool checkPlayer ()
        {
            foreach (GameObject item in GameObjList)
            {
                if (item.Type == objectTypes.player)
                {
                    return true;
                }
            }
            return false;
        }
        public bool isGameOver ()
        {
            if (!checkPlayer())
            {
                return true;
            }
            return false;
        }
        public bool isBossExist ()
        {
            foreach (GameObject item in GameObjList)
            {
                if (item.Type == objectTypes.boss)
                {
                    return true;
                }
            }
            return false;
        }
        public void addGameObj (GameObject gO)
        {
            // GameObject gO = new GameObject(img , top , left , movement , type , mode , height , width);
            if (gO.Type == objectTypes.player || gO.Type == objectTypes.tank || gO.Type == objectTypes.boss)
            {
                Player x = (Player)gO;
                OnProgressBarAdd?.Invoke(x.HealthBar , EventArgs.Empty);
            }
            GameObjList.Add(gO);
            OnPlayerAdd?.Invoke(gO.Pb , EventArgs.Empty);
        }
        public void rmvGameObj (GameObject gO)
        {
            //GameObject gO = new GameObject(img , top , left , movement , type , mode , height , width);
            OnBulletDel?.Invoke(gO.Pb , EventArgs.Empty);
            GameObjList.Remove(gO);
        }
        public void RaisePlayerDieEvent (GameObject playerGameObject)
        {
            OnPlayerDie?.Invoke(playerGameObject.Pb , EventArgs.Empty);
        }
        public void RaiseOnPlayerCollideScoreEvent (GameObject gO)
        {
            OnPlayerCollideScore?.Invoke(gO.Pb , EventArgs.Empty);
            GameObjList.Remove(gO);
        }
        public void RaiseOnPlayerCollideHealthEvent (GameObject gO)
        {
            OnPlayerCollideHealth?.Invoke(gO.Pb , EventArgs.Empty);
            GameObjList.Remove(gO);
        }

        public void RaiseOnPlayerCollideEnemyBulletEvent (GameObject gO)
        {
            Player x = (Player)gO;
            if (x.HealthBar.Value >= 10)
            {
                x.HealthBar.Value -= 10;
            }
            else
            {
                OnPlayerCollideEnemyBullet?.Invoke(x , EventArgs.Empty);
                GameObjList.Remove(x);
            }
        }
        public void RaiseOnPlayerCollideBossBulletEvent (GameObject gO)
        {
            Player x = (Player)gO;
            if (x.HealthBar.Value >= 30)
            {
                x.HealthBar.Value -= 30;
            }
            else
            {
                OnPlayerCollideBossBullet?.Invoke(x , EventArgs.Empty);
                GameObjList.Remove(x);
            }
        }
        public void RaiseOnEnemyCollidePlayerBulletEvent (GameObject gO)
        {

            Player x = (Player)gO;
            if (x.HealthBar.Value >= 20)
            {
                x.HealthBar.Value -= 20;
                OnPlayerScoreIncrease?.Invoke(x , EventArgs.Empty);
            }
            else
            {
                foreach (GameObject blt in x.MyBullets)
                {
                    GameObjList.Remove(blt);
                }
                OnEnemyCollidePlayerBullet?.Invoke(x , EventArgs.Empty);
                GameObjList.Remove(x);
            }
        }
        public void RaiseOnEnemyBossCollidePlayerBulletEvent (GameObject gO)
        {

            Player x = (Player)gO;
            if (x.HealthBar.Value >= 5)
            {
                x.HealthBar.Value -= 5;
                OnPlayerScoreIncrease?.Invoke(x , EventArgs.Empty);
            }
            else
            {
                foreach (GameObject blt in x.MyBullets)
                {
                    GameObjList.Remove(blt);
                }
                OnEnemyCollidePlayerBullet?.Invoke(x , EventArgs.Empty);
                GameObjList.Remove(x);
            }
        }
        public void RaiseOnPlayerCollideEnemyEvent (GameObject gO)
        {

            Player x = (Player)gO;
            if (x.HealthBar.Value >= 15)
            {
                x.HealthBar.Value -= 15;
                x.Pb.Left = (boundary.X / 2);
                x.Pb.Top = boundary.Y - x.Pb.Height;
            }
            else
            {
                OnPlayerCollideEnemy?.Invoke(x , EventArgs.Empty);
                GameObjList.Remove(x);
            }
        }

        public void detectCollision ()
        {
            for (int x = 0 ; x < gameObjList.Count ; x++)
            {
                for (int y = 0 ; y < gameObjList.Count ; y++)
                {
                    if (gameObjList[x].Pb.Bounds.IntersectsWith(gameObjList[y].Pb.Bounds))
                    {
                        foreach (Collision c in collisionList)
                        {
                            if (gameObjList[x].Type == c.G1 && gameObjList[y].Type == c.G2)
                            {
                                c.Behaviour.performPlayerAction(this , gameObjList[x] , gameObjList[y]);
                                break;
                            }
                        }
                    }

                }
            }
        }
        public void addCollision (Collision c)
        {
            CollisionList.Add(c);
        }
    }
}
