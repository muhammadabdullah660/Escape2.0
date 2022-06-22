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
        void RaiseOnPlayerCollideScoreEvent (GameObject obj);
        void RaiseOnPlayerCollideEnemyBulletEvent (GameObject obj);
        void RaiseOnEnemyCollidePlayerBulletEvent (GameObject obj);
        void RaiseOnPlayerCollideEnemyEvent (GameObject obj);
        void RaiseOnPlayerCollideBossBulletEvent (GameObject obj);
        void RaiseOnEnemyBossCollidePlayerBulletEvent (GameObject obj);
        void RaiseOnPlayerCollideHealthEvent (GameObject obj);
        void rmvGameObj (GameObject gO);
    }
}
