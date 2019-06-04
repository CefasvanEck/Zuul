using System.Collections.Generic;

namespace ZuulCS
{
	public class Room
	{
		private string description;
		private Dictionary<string, Room> exits; // stores exits of this room.
        private List<Item> items = new List<Item>(); //stores the items in this room.

        /**
	     * Create a room described "description". Initially, it has no exits.
	     * "description" is something like "in a kitchen" or "in an open court
	     * yard".
	     */
        public Room(string description)
		{
			this.description = description;
			exits = new Dictionary<string, Room>();
		}

        public List<Item> getItemList()
        {
            return items;
        }

        /**
         * Push items in the array
         */
        public void placeItemInRoom(Item item)
        {
            items.Add(item);
        }

        public void removeItemFromRoom(Item itemInList)
        {
            items.Remove(itemInList);
        }

        /**
         * Get all the items by there name and print it to a string
         */
        public string getItemInRoom()
        {
            string itemNamesInRoom = "";
            for(int i = 0;i < items.Count;++i)
            {
                if(i < items.Count - 1)
                {
                    itemNamesInRoom += items[i].getItemName() + ", ";
                }
                else
                {
                    itemNamesInRoom += items[i].getItemName();
                }
            }
            return itemNamesInRoom;
        }

        /**
	     * Define an exit from this room.
	     */
        public void setExit(string direction, Room neighbor)
		{
			exits[direction] = neighbor;
		}

		/**
	     * Return the description of the room (the one that was defined in the
	     * constructor).
	     */
		public string getShortDescription()
		{
			return description;
		}

		/**
	     * Return a long description of this room, in the form:
	     *     You are in the kitchen.
	     *     Exits: north west
	     */
		public string getLongDescription()
		{
			string returnstring = " ";
			returnstring += description;
			returnstring += ".\n";
			returnstring += getExitstring();
			return returnstring;
		}

		/**
	     * Return a string describing the room's exits, for example
	     * "Exits: north, west".
	     */
		public string getExitstring()
		{
			string returnstring = "Exits:";

			// because `exits` is a Dictionary, we can't use a `for` loop
			int commas = 0;
			foreach (string key in exits.Keys) {
				if (commas != 0 && commas != exits.Count) {
					returnstring += ",";
				}
				commas++;
				returnstring += " " + key;
			}
			return returnstring;
		}

		/**
	     * Return the room that is reached if we go from this room in direction
	     * "direction". If there is no room in that direction, return null.
	     */
		public Room getExit(string direction)
		{
			if (exits.ContainsKey(direction)) {
				return (Room)exits[direction];
			} else {
				return null;
			}

		}
	}
}
