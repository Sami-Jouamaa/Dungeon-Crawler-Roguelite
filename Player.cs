using System;
using System.Collections;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Dungeon_Crawler_Roguelite
{
    class Player
    {
        public enum ClassTypes
        {
            Warrior,
            Witch,
            Archer,
            Assassin
        }

        public string playerTexture;
        public Vector2 playerPosition;
        public ClassTypes characterClass;
        public int level;
        public int health;
        public int mana;
        public int shield;
        public int armour;
        public int dodgeChance;
        public float physicalDamageReduction;
        public int fireRes;
        public int coldRes;
        public int lightningRes;
        public int darkRes; // Poison-like damage
        public float damageIncrease;
        public float atkDamageIncrease;
        public float spellDamageIncrease;
        public int attackSpeed;

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
            darkRes = 0;
            damageIncrease = 0;
            atkDamageIncrease = 0;
            spellDamageIncrease = 0;
        }

        public Player initializeNew(ClassTypes classType)
        {
            switch (classType)
            {
                case ClassTypes.Archer:
                    this.health = (int)Math.Ceiling(66 + level * 3.1);
                    // Mana could be something replenishable every turn, and you have a whole turn to use it
                    this.mana = (int)Math.Ceiling(40 + level * 2.5);
                    break;
                case ClassTypes.Assassin:
                    this.health = (int)Math.Ceiling(72 + level * 3.7);
                    this.mana = (int)Math.Ceiling(40 + level * 3.0);
                    break;
                case ClassTypes.Warrior:
                    this.health = (int)Math.Ceiling(84 + level * 4.3);
                    this.mana = (int)Math.Ceiling(30 + level * 2.2);
                    break;
                case ClassTypes.Witch:
                    this.health = (int)Math.Ceiling(63 + level * 2.8);
                    this.mana = (int)Math.Ceiling(50 + level * 3.7);
                    break;
            }
            return this;
        }

        // public void addSkillTree(Player player)
        // {

        // }

        public bool isAlive()
        {
            return this.health > 0;
        }
    }
}