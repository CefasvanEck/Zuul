using System;

namespace ZuulCS
{
	public class Item
	{
        private String itemName;
        private float itemWeight;

        public Item(string nameItem,float weightOfItem)
        {
            this.itemName = nameItem;
            this.itemWeight = weightOfItem;
        }

        public float getItemWeight()
        {
            return this.itemWeight;
        }

        public String getItemName()
        {
            return itemName;
        }

        public virtual void use(Player player){}

        public virtual float useWeapon(Player player)
        {
            return 0;
        }
    }
}
