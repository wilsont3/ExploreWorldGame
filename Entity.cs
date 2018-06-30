using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreWorldGame
{
    class Entity
    {
        // constructor
        public Entity()
        {
            
        }

        protected Entity(int hp, string entName, bool canMoveThrough, bool canMove, bool canDamage)
        {
            healthPoints = hp;
            name = entName;
            isPassable = canMoveThrough;
            isMovable = canMove;
            isDamageable = canDamage;
        }

        // properties
        protected int healthPoints;

        protected string name;

        protected bool isPassable;

        protected bool isMovable;

        protected bool isDamageable;

        // methods
        public void applyDamage(int damage)
        {
            if (damage > healthPoints)
            {
                healthPoints = 0;
            }
            else
            {
                healthPoints -= damage;
            }
        }
    }
}
