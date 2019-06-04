using System;

namespace ZuulCS
{
	public class Item
	{
        private String itemName;

        public Item(string nameItem)
        {
            this.itemName = nameItem;
        }

        public String getItemName()
        {
            return itemName;
        }

    }
}
