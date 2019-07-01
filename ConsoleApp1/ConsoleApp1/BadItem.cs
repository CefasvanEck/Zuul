using System;

namespace ZuulCS
{
    public class BadItem : Item
    {

        private float damagePlayer;

        public BadItem(float playerDamage,string nameItem, float weightOfItem) : base(nameItem, weightOfItem)
        {
            this.damagePlayer = playerDamage;
        }
        
        public override void use(Player player)
        {
            if (this.GetType() == typeof(BadItem))
            {
                player.damage(this.damagePlayer);
                Console.WriteLine("The Player took some damage");
                Console.WriteLine("The player has " + player.getCurrentHealth() + " left.");
            }
        }

    }
}
