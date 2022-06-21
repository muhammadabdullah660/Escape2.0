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
        private static List<Collision> collisionList = new List<Collision>();
        private static List<GameObject> gameObjList = new List<GameObject>();


        public static List<GameObject> GameObjList { get => gameObjList; set => gameObjList = value; }
        public static List<Collision> CollisionList { get => collisionList; set => collisionList = value; }
        public Point Boundary { get => boundary; set => boundary = value; }

        public event EventHandler OnBulletDel;
        public event EventHandler OnPlayerAdd;
        public event EventHandler OnPlayerDie;
        public event EventHandler OnPlayerCollideScore;

        public Game (Point boundary)
        {
            this.Boundary = boundary;
        }
        public void update ()
        {
            for (int i = 0 ; i < GameObjList.Count ; i++)
            {
                detectCollision();
                GameObjList[i].move();
                if (GameObjList[i].Type == objectTypes.player)
                {
                    Player x = (Player)GameObjList[i];
                    x.fireBullet();
                    // x.rmvBullet(this);
                }

            }

        }

        public void addGameObj (GameObject gO)
        {
            // GameObject gO = new GameObject(img , top , left , movement , type , mode , height , width);
            GameObjList.Add(gO);
            OnPlayerAdd?.Invoke(gO.Pb , EventArgs.Empty);
        }
        public void rmvGameObj (GameObject gO)
        {
            // GameObject gO = new GameObject(img , top , left , movement , type , mode , height , width);
            OnBulletDel?.Invoke(gO.Pb , EventArgs.Empty);
            GameObjList.Remove(gO);
        }
        public void RaisePlayerDieEvent (GameObject playerGameObject)
        {
            OnPlayerDie?.Invoke(playerGameObject.Pb , EventArgs.Empty);
        }
        public void RaiseOnPlayerCollideScoreEvent (GameObject playerGameObject)
        {
            OnPlayerCollideScore?.Invoke(playerGameObject.Pb , EventArgs.Empty);
            GameObjList.Remove(playerGameObject);
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
                                //c.Behaviour.performPlayerEnemyCollision(this , gameObjList[x] , gameObjList[y]);
                                c.Behaviour.performPlayerScoreCollision(this , gameObjList[x] , gameObjList[y]);
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
