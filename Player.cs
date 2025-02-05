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
        // Dodge rating is a big number, that gets converted into a percentage like armour
        public int dodgeRating;
        public float dodgeChance;
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
        public int fiftyPercentDodgeChance;

        public Player()
        {
            playerTexture = "ball";
            // Position is going to be replaced in the Initializa function in Game
            playerPosition = new Vector2(0, 0);
            characterClass = ClassTypes.Witch;
            level = 0;
            str = 0;
            dex = 0;
            intelligence = 0;
            health = 1;
            armour = 0;
            dodgeRating = 0;
            dodgeChance = 0;
            physicalDamageReduction = 0;
            fireRes = 0;
            coldRes = 0;
            lightningRes = 0;
            darkRes = 0;
            damageIncrease = 0;
            atkDamageIncrease = 0;
            spellDamageIncrease = 0;
            fiftyPercentReduction = 150;
            fiftyPercentDodgeChance = 150;
        }

        // Only happens when creating a new character, otherwise it will go to initializeExisting
        public Player initializeNew(ClassTypes classType)
        {
            this.level = 0;
            float baseHP;
            float baseMana;
            float baseDodge;
            switch (classType)
            {
                case ClassTypes.Archer:
                    baseHP = 66;
                    baseMana = 40;
                    baseDodge = 30;
                    break;
                case ClassTypes.Assassin:
                    baseHP = 72;
                    baseMana = 40;
                    baseDodge = 40;
                    break;
                case ClassTypes.Warrior:
                    baseHP = 84;
                    baseMana = 30;
                    baseDodge = 15;
                    break;
                case ClassTypes.Witch:
                    baseHP = 63;
                    baseMana = 50;
                    baseDodge = 20;
                    break;
                default:
                    baseHP = 25;
                    baseMana = 25;
                    baseDodge = 25;
                    break;
            }
            this.health = (int)Math.Ceiling((baseHP + level * 3.1) * (1 + str / 100));
            // Mana could be something replenishable every turn, and you have a whole turn to use it
            this.mana = (int)Math.Ceiling((baseMana + level * 2.5) * (1 + intelligence / 100));
            // Shield comes from gear and increases by 1% for every 2 intelligence
            this.shield = (int)Math.Ceiling(this.shield * (1 + intelligence / 200));
            this.dodgeRating = (int)Math.Ceiling(baseDodge + this.dodgeRating * (1 + dex / 100));
            this.dodgeChance = this.calculateDodgeChance(this.dodgeRating);
            this.atkDamageIncrease = (int)Math.Ceiling(this.atkDamageIncrease * (1 + str / 200));
            this.physicalDamageReduction = this.calculatePhysicalDamageReduction(this.armour);
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

        public float calculateDodgeChance(int dodgeRating)
        {
            return (dodgeRating / (dodgeRating + fiftyPercentDodgeChance));
        }

        public bool isAlive()
        {
            return this.health > 0;
        }
    }
}