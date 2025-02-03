using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Dungeon_Crawler_Roguelite
{
    class Player
    {
        string playerTexture;
        Vector2 playerPosition;

        int level;
        int health;
        int armour;
        float physicalDamageReduction;
        int fireRes;
        int coldRes;
        int lightningRes;
        int darkMagicRes; // Poison-like damage
        float damageIncrease;
        float atkDamageIncrease;
        float spellDamageIncrease;

        public Player()
        {
            playerTexture = "ball";
            // Position is going to be replaced in the Initializa function in Game
            playerPosition = new Vector2(0, 0);
            health = 1;
            armour = 0;
            physicalDamageReduction = 0;
            fireRes = 0;
            coldRes = 0;
            lightningRes = 0;
            darkMagicRes = 0;
            damageIncrease = 0;
            atkDamageIncrease = 0;
            spellDamageIncrease = 0;
        }

        public bool isAlive()
        {
            return this.health > 0;
        }
    }
}