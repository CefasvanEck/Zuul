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

        
        public override Player use(Player player)
        {
            if (this.GetType() == typeof(BadItem))
            {
                Player player2 = player;
                player2.damage(this.damagePlayer);
                Console.WriteLine("The Player took some damage");
                Console.WriteLine("The player has " + player2.getCurrentHealth() + " left.");
                return player2;
            }
            else
            {
                return player;
            }
        }

    }
}
