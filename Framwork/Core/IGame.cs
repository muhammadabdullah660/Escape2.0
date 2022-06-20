using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framwork.Core
{
    public interface IGame
    {
        // void RaisePlayerHitEvent (GameObject obj);
        void RaisePlayerDieEvent (GameObject obj);
        // void RaiseEnemyDieEvent (GameObject obj);
        // void RaisePlayerBulletRemove (GameObject obj);
    }
}
