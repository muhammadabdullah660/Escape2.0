using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Framwork.Movement;
using Framwork.Enum;
using Framwork.Core;
namespace Framwork.Collisions
{
    public class Collision
    {
        private objectTypes g1;
        private objectTypes g2;
        private ICollisionAction behaviour;

        public Collision (objectTypes g1 , objectTypes g2 , ICollisionAction behaviour)
        {
            this.G1 = g1;
            this.G2 = g2;
            this.Behaviour = behaviour;
        }

        public objectTypes G1 { get => g1; set => g1 = value; }
        public objectTypes G2 { get => g2; set => g2 = value; }
        internal ICollisionAction Behaviour { get => behaviour; set => behaviour = value; }

    }
}
