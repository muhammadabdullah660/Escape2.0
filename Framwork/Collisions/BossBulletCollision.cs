using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framwork.Core;
namespace Framwork.Collisions
{
    public class BossBulletCollision : ICollisionAction
    {
        public void performPlayerAction (IGame game , GameObject source1 , GameObject source2)
        {
            GameObject chr;
            GameObject bullet;
            if (source1.Type == Enum.objectTypes.bossFire)
            {
                chr = source2;
                bullet = source1;
            }
            else
            {
                chr = source1;
                bullet = source2;
            }
            game.rmvGameObj(bullet);
            game.RaiseOnPlayerCollideBossBulletEvent(chr);
        }
    }
}
