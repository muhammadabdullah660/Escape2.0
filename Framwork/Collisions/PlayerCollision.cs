using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framwork.Movement;
using Framwork.Core;
namespace Framwork.Collisions
{
    public class PlayerCollision : ICollisionAction
    {
        public void performPlayerEnemyCollision (IGame game , GameObject source1 , GameObject source2)
        {
            GameObject player;
            if (source1.Type == Enum.objectTypes.player)
            {
                player = source1;
            }
            else
            {
                player = source2;
            }
            game.RaisePlayerDieEvent(player);
        }
        public void performPlayerScoreCollision (IGame game , GameObject source1 , GameObject source2)
        {
            GameObject player;
            if (source1.Type == Enum.objectTypes.scorePill)
            {
                player = source1;
            }
            else
            {
                player = source2;
            }
            game.RaiseOnPlayerCollideScoreEvent(player);
        }

    }
}
