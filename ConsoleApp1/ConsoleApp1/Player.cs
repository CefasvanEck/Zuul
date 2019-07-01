namespace ZuulCS
{
    using System;

    public class Player
    {
        private Room currentRoom;
        private Inventory inventory;
        private float armorProtection;
        private bool hasHelmet = false;
        private bool hasChestplate = false;
        private bool hasLeggings = false;
        private bool hasBoots = false;

        /*
         * The player health is a float so the player can take damage of half a heart, higher or lower.
         * This way you can add as an example small enemy's that do little damage but when the enemy is in a big group they can take down the player.
         * You can implement many damage scenario's with enemy's or objects.
         */
        private float maxHealth, currentHealth;

        public Player()
        {
            this.maxHealth = 20;
            this.currentHealth = this.maxHealth;
            this.inventory = new Inventory(5,20F);
        }

        public void setArmorProtection(float protection)
        {
            this.armorProtection = protection;
        }

        public float getArmorProtection()
        {
            return this.armorProtection;
        }

        public Inventory getInventory()
        {
            return inventory;
        }

        public float getMaxHealth()
        {
            return this.maxHealth;
        }

        public float getCurrentHealth()
        {
            return this.currentHealth;
        }

        public void setCurrentHealth(float health)
        {
            this.currentHealth = health;
        }

        /**
        * Add health to the player or set it to the max health(Player cant have more health then the max health.
        */
        public void heal(float amount)
        {
            if(this.currentHealth + amount <= this.maxHealth)
            {
                this.currentHealth += amount;
            }
            else
            {
                this.currentHealth = 20;
            }
        }

        /*
         * Damage the player or set the health to 0.
         */
        public void damage(float amount)
        {
            if (this.currentHealth - amount >= 0)
            {
                this.currentHealth -= amount;
            }
            else
            {
                this.currentHealth = 0;
                Console.WriteLine("The player died...");
            }
        }

        /*
         * Checks if the player has any health left.
         */
        public bool isAlive()
        {
            if (this.currentHealth > 0)
            {
                return true;
            }
            else return false;
        }

        public void setCurrentRoom(Room room)
        {
            this.currentRoom = room;
        }

        public Room getCurrentRoom()
        {
            return currentRoom;
        }

        public void setHelmet(bool s)
        {
            this.hasHelmet = s;
        }

        public void setChestplate(bool s)
        {
            this.hasChestplate = s;
        }

        public void setLeggings(bool s)
        {
            this.hasLeggings = s;
        }

        public void setBoots(bool s)
        {
            this.hasBoots = s;
        }


        public bool getHelmet()
        {
            return this.hasHelmet;
        }

        public bool getChestplate()
        {
            return this.hasChestplate;
        }

        public bool getLeggings()
        {
            return this.hasLeggings;
        }

        public bool getBootst()
        {
            return this.hasBoots;
        }
    }
}
