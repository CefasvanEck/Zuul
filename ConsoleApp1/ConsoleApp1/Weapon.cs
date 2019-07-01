using System;

namespace ZuulCS
{
	public class Weapon : Item
    {
        private float doesDamageToOtherEntitys;
        private Random random = new Random();

        public Weapon(float doDamage, string nameItem, float weightOfItem) : base(nameItem, weightOfItem)
        {
            this.doesDamageToOtherEntitys = doDamage;
        }

        public override float useWeapon(Player player)
        {
            if (this.GetType() == typeof(Weapon))
            {
                float doesDamage = this.random.Next((int)(this.doesDamageToOtherEntitys * 100) / 3, (int)this.doesDamageToOtherEntitys * 100) / 10;
                Console.WriteLine("The Player did " + doesDamage + " damage");
                return doesDamage;
            }
            else
            {
                return 0F;
            }
        }
    }
}
