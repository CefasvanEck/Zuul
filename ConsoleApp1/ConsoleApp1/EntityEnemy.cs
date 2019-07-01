namespace ZuulCS
{
    using System;

    public class EntityEnemy
    {
   
        /*
         * The player health is a float so the player can take damage of half a heart, higher or lower.
         * This way you can add as an example small enemy's that do little damage but when the enemy is in a big group they can take down the player.
         * You can implement many damage scenario's with enemy's or objects.
         */
        private float maxHealth, currentHealth;
        private String entityName;
        private Random random = new Random();
        private float attackDamage = 0F;


        public EntityEnemy(String name,float attackDamage,float maxHealth)
        {
            this.maxHealth = maxHealth;
            this.currentHealth = this.maxHealth;
            this.entityName = name;
            this.attackDamage = attackDamage;
        }

        public String getEntityname()
        {
            return this.entityName;
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
        public void damage(float amount,Player player)
        {
            if(this.currentHealth != 0)
            {
                if (this.currentHealth - amount >= 0)
                {
                    this.currentHealth -= amount;
                    Console.WriteLine("The " + entityName + " has " + this.currentHealth + " health left...");
                    float doesDamage = this.random.Next((int)(this.attackDamage * 100) / 3, (int)this.attackDamage * 100) / 10;
                    player.damage(doesDamage);
                    Console.WriteLine("The " + entityName + " attacked the player");
                    Console.WriteLine("The player has " + player.getCurrentHealth() + " health left...");
                }
                else
                {
                    this.currentHealth = 0;
                    Console.WriteLine("The " + entityName + " died...");
                }
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
    }
}
