using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreWorldGame
{
    public class Character : Entity
    {
        public Character()
        {
            //Constructor
        }

        public Character(int hp, string entName, bool canMoveThrough, bool canMove, bool canDamage, int damageDealt, int side)
            :base(hp, entName, canMoveThrough, canMove, canDamage)
        {
            power = damageDealt;
            team = side;
        }

        // properties
        public int power;
        public int team;


        // methods
        public int GetHealthPoints()
        {
            return healthPoints;
        }
    }
}
