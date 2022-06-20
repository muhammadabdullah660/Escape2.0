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
        private static List<Collision> collisionList = new List<Collision>();
        private static List<GameObject> gameObjList = new List<GameObject>();
        private static List<GameObject> bulletsList = new List<GameObject>();

        public static List<GameObject> GameObjList { get => gameObjList; set => gameObjList = value; }
        public static List<Collision> CollisionList { get => collisionList; set => collisionList = value; }
        public static List<GameObject> BulletsList { get => bulletsList; set => bulletsList = value; }

        public event EventHandler OnPlayerAdd;
        public event EventHandler OnBulletDel;
        public event EventHandler OnPlayerDie;
        public Game ()
        {

        }
        public void update ()
        {
            foreach (GameObject pb in GameObjList)
            {
                pb.move();
                if (pb.Type == objectTypes.player)
                {
                    Player x = (Player)pb;
                    x.fireBullet();
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
            OnPlayerDie?.Invoke(playerGameObject , EventArgs.Empty);
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
                                c.Behaviour.performAction(this , gameObjList[x] , gameObjList[y]);
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
