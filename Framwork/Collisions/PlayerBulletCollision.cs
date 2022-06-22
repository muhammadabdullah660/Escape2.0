using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framwork.Core;
namespace Framwork.Collisions
{
    public class PlayerBulletCollision : ICollisionAction
    {
        public void performPlayerAction (IGame game , GameObject source1 , GameObject source2)
        {
            GameObject chr;
            GameObject bullet;
            if (source1.Type == Enum.objectTypes.tank)
            {
                chr = source1;
                bullet = source2;
            }
            else
            {
                chr = source2;
                bullet = source1;
            }
            game.rmvGameObj(bullet);
            game.RaiseOnEnemyCollidePlayerBulletEvent(chr);
        }
    }
}
