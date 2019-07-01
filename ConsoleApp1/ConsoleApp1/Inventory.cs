using System.Collections.Generic;

namespace ZuulCS
{
    public class Inventory
    {
        private Dictionary<string, Item> itemsDic; //stores the items in this inventory.

        /**
         * The size of the inventory
        */
        private int inventoryMaxSize;

        /**
          * MAx weight of items the inventory can have
        */
        private float inventoryItemWeight;
        private float inventoryMaxItemWeight;

        public Inventory(int sizeOfInventory,float maxWeight)
        {
            this.itemsDic = new Dictionary<string, Item>();
            this.inventoryMaxSize = sizeOfInventory;
            this.inventoryMaxItemWeight = maxWeight;
        }

        /**
         * The size of the inventory
         */
        public int getInventoryMaxSize()
        {
            return inventoryMaxSize;
        }

        public int getInventorySize()
        {
            return itemsDic.Count;
        }
 
        /**
         * Item weights
         */
        public void addItemWeight(float weight)
        {
            this.inventoryItemWeight += weight;
        }

        public void removeItemWeight(float weight)
        {
            this.inventoryItemWeight -= weight;
        }

        public float getItemWeight()
        {
            return this.inventoryItemWeight;
        }

        public float getMaxItemWeight()
        {
            return this.inventoryMaxItemWeight;
        }

        /**
        * Push items in the array
        */
        public void placeItemInInventory(Item item)
        {
            this.itemsDic[item.getItemName()] = item;
        }

        public void removeItemFromInventory(string itemInList)
        {
            this.itemsDic.Remove(itemInList);
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