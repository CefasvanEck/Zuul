using System.Collections.Generic;

namespace ZuulCS
{
    public class Inventory
    {
        private Dictionary<string, Item> itemsDic; //stores the items in this inventory.

        public Inventory()
        {
           this.itemsDic = new Dictionary<string, Item>();
        }

        /**
        * Push items in the array
        */
        public void placeItemInInventoryD(Item item)
        {
            this.itemsDic[item.getItemName()] = item;
        }

        public void removeItemFromInventory(Item itemInList)
        {
            this.itemsDic.Remove(itemInList.getItemName());
        }

        /**
        * Get all the items by there name and print it to a string
        */
        public string getItemsstring()
        {
            string returnstring = "Items:";

            // because `exits` is a Dictionary, we can't use a `for` loop
            int commas = 0;
            foreach (string key in this.itemsDic.Keys)
            {
                if (commas != 0 && commas != this.itemsDic.Count)
                {
                    returnstring += ",";
                }
                commas++;
                returnstring += " " + key;
            }
            return returnstring;
        }

        public Dictionary<string, Item> getItemList()
        {
            return this.itemsDic;
        }

    }
}