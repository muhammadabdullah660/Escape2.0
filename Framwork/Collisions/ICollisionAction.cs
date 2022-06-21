using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Framwork.Movement;
using Framwork.Core;
namespace Framwork.Collisions
{
    public interface ICollisionAction
    {
        void performPlayerScoreCollision (IGame game , GameObject g1 , GameObject g2);
        void performPlayerEnemyCollision (IGame game , GameObject g1 , GameObject g2);
    }
}
