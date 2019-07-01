using System.Collections.Generic;

namespace ZuulCS
{
	public class Room
	{
		private string description;
		private Dictionary<string, Room> exits; // stores exits of this room.
        private Dictionary<string, EntityEnemy> enemyList;
        private Inventory inventory;

        //Rooms can be 'locked' bij boulders and can be 'unlocked' by Dynamite
        private bool isBlocked = false;

        /**
	     * Create a room described "description". Initially, it has no exits.
	     * "description" is something like "in a kitchen" or "in an open court
	     * yard".
	     */
        public Room(string description)
		{
			this.description = description;
            this.exits = new Dictionary<string, Room>();
            this.inventory = new Inventory(100,100F);
            this.enemyList = new Dictionary<string, EntityEnemy>();      
        }

        public Room(string description,bool isLocked)
        {
            this.description = description;
            this.exits = new Dictionary<string, Room>();
            this.inventory = new Inventory(100, 100F);
            this.enemyList = new Dictionary<string, EntityEnemy>();
            this.isBlocked = isLocked;
        }


        public void setEnemies(string entityName, EntityEnemy enemy)
        {
            enemyList[entityName] = enemy;
        }

        public Dictionary<string, EntityEnemy> getEnemyList()
        {
            return enemyList;
        }

        public bool isRoomLocked()
        {
            return this.isBlocked;
        }

        public void unlockRoom()
        {
            this.isBlocked = true;
        }

        public string getEnemystring()
        {
            string returnstring = "Enemies:";

            // because `exits` is a Dictionary, we can't use a `for` loop
            int commas = 0;
            foreach (string key in enemyList.Keys)
            {
                if (commas != 0 && commas != enemyList.Count)
                {
                    returnstring += ",";
                }
                commas++;
                returnstring += " " + key;
            }
            return returnstring;
        }

        /**
	     * Define an exit from this room.
	     */
        public void setExit(string direction, Room neighbor)
		{
			exits[direction] = neighbor;
		}

        public Inventory getInventory()
        {
            return inventory;
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
