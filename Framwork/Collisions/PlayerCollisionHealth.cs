using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framwork.Core;
namespace Framwork.Collisions
{
    public class PlayerCollisionHealth : ICollisionAction
    {
        public void performPlayerAction (IGame game , GameObject source1 , GameObject source2)
        {
            GameObject player;
            if (source1.Type == Enum.objectTypes.healthPill)
            {
                player = source1;
            }
            else
            {
                player = source2;
            }
            game.RaiseOnPlayerCollideHealthEvent(player);
        }
    }
}
