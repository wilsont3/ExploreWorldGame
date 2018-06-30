using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreWorldGame
{
    public class Tile
    {
        public Tile()
        {

        }

        public Tile(string landType, float speed, int health, int damage, bool canMoveOn)
        {
            terrain = landType;
            speedModifier = speed;
            healthModifier = health;
            damageModifier = damage;
            isPassable = canMoveOn;
        }

        public string terrain;
        public float speedModifier;
        public int healthModifier;
        public int damageModifier;
        public bool isPassable;
    }
}
