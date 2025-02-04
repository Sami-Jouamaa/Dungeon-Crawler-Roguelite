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
        public float intelligence;
        public float str;
        public float dex;
        public int level;
        public int health;
        public int mana;
        public int shield;
        public int armour;
        public int dodgeChance;
        // Will be something like 0.8333
        // Example damage calculations :
        // EnemeyAttack * (physicalDamageReduction - EnemyPen) = finalDamage
        // If physicalDamageReduction = 0.8 and EnemyPen = 30 (0.3), then the resulting physicalDamageReduction is 0.3
        // It will read as "enemy ignores 30% of physical damage reduction.
        public float physicalDamageReduction;
        public int fireRes;
        public int coldRes;
        public int lightningRes;
        public int darkRes; // Poison-like damage
        public float damageIncrease;
        public float atkDamageIncrease;
        public float spellDamageIncrease;
        public int attackSpeed;

        // When armour = this value, the physical damage reduction will be 50%
        public int fiftyPercentReduction;

        public Player()
        {
            playerTexture = "ball";
            // Position is going to be replaced in the Initializa function in Game
            playerPosition = new Vector2(0, 0);
            str = 0;
            dex = 0;
            intelligence = 0;
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
            fiftyPercentReduction = 150;
        }

        public Player initializeNew(ClassTypes classType)
        {
            // Shield comes from gear and increases by 1% for every intelligence
            switch (classType)
            {
                case ClassTypes.Archer:
                    this.health = (int)Math.Ceiling((66 + level * 3.1) * (1 + str / 100));
                    // Mana could be something replenishable every turn, and you have a whole turn to use it
                    this.mana = (int)Math.Ceiling((40 + level * 2.5) * (1 + intelligence / 100));
                    this.shield = (int)Math.Ceiling(this.shield * (1 + intelligence / 300));
                    this.dodgeChance = (int)Math.Ceiling(this.dodgeChance * (1 + dex / 200));
                    this.atkDamageIncrease = (int)Math.Ceiling(this.atkDamageIncrease * (1 + str / 200));
                    this.physicalDamageReduction = this.calculatePhysicalDamageReduction(this.armour);
                    break;
                case ClassTypes.Assassin:
                    this.health = (int)Math.Ceiling((72 + level * 3.7) * (1 + str / 100));
                    this.mana = (int)Math.Ceiling((40 + level * 3.0) * (1 + intelligence / 100));
                    this.shield = (int)Math.Ceiling(this.shield * (1 + intelligence / 300));
                    this.dodgeChance = (int)Math.Ceiling(this.dodgeChance * (1 + dex / 200));
                    this.atkDamageIncrease = (int)Math.Ceiling(this.atkDamageIncrease * (1 + str / 200));
                    this.physicalDamageReduction = this.calculatePhysicalDamageReduction(this.armour);
                    break;
                case ClassTypes.Warrior:
                    this.health = (int)Math.Ceiling((84 + level * 4.3) * (1 + str / 100));
                    this.mana = (int)Math.Ceiling((30 + level * 2.2) * (1 + intelligence / 100));
                    this.shield = (int)Math.Ceiling(this.shield * (1 + intelligence / 300));
                    this.dodgeChance = (int)Math.Ceiling(this.dodgeChance * (1 + dex / 200));
                    this.atkDamageIncrease = (int)Math.Ceiling(this.atkDamageIncrease * (1 + str / 200));
                    this.physicalDamageReduction = this.calculatePhysicalDamageReduction(this.armour);
                    break;
                case ClassTypes.Witch:
                    this.health = (int)Math.Ceiling((63 + level * 2.8) * (1 + str / 100));
                    this.mana = (int)Math.Ceiling((50 + level * 3.7) * (1 + intelligence / 100));
                    this.shield = (int)Math.Ceiling(this.shield * (1 + intelligence / 300));
                    this.dodgeChance = (int)Math.Ceiling(this.dodgeChance * (1 + dex / 200));
                    this.atkDamageIncrease = (int)Math.Ceiling(this.atkDamageIncrease * (1 + str / 200));
                    this.physicalDamageReduction = this.calculatePhysicalDamageReduction(this.armour);
                    break;
            }
            return this;
        }

        // public initializeExisting(string saveFile)
        // {
        // Parse every player attributes with the commas
        // }

        // public void addSkillTree(Player player)
        // {

        // }

        public float calculatePhysicalDamageReduction(int armour)
        {
            return (armour / (armour + fiftyPercentReduction));
        }

        public bool isAlive()
        {
            return this.health > 0;
        }
    }
}