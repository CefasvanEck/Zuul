using System;

namespace ZuulCS
{
	public class Game
	{
		private Parser parser;
        private Player player = new Player();

        public Game ()
		{
			createRooms();
			parser = new Parser();
		}

		private void createRooms()
		{
			Room outside, caveEntrance, waterCave, stalactiteCave, lavaCave, crackedCave, darkCave;

			// create the rooms
			outside = new Room("You are outside the main cave entrance.");
            caveEntrance = new Room("You are inside the first part of the cave");
            waterCave = new Room("You are inside the water cave, your feet are wet and you see water dripping from the ceiling");
            stalactiteCave = new Room("You are inside the stalactite cave and you see giant stone pointy stalactites hanging from the ceiling");
            lavaCave = new Room("You are inside the lava cave and it's very hot here");
            //Up caves
            crackedCave = new Room("You are just below the surface but can see the sun through the cracks in the ceiling");
            //Down caves
            darkCave = new Room("You are far below the surface and you can't see anything but the exit.");

            // initialise room exits
            //Cave outside
            outside.setExit("north", caveEntrance);
            //Cave main entrance
            caveEntrance.setExit("south", outside);
            caveEntrance.setExit("east", waterCave);
            caveEntrance.setExit("west", stalactiteCave);
            caveEntrance.setExit("north", lavaCave);
            caveEntrance.setExit("up", crackedCave);

            caveEntrance.placeItemInRoom(new Item("Dynamite"));
            //Water cave
            waterCave.setExit("west", caveEntrance);
            //Stalactite cave
            stalactiteCave.setExit("east", caveEntrance);
            stalactiteCave.setExit("down", darkCave);

            stalactiteCave.placeItemInRoom(new Item("Pickaxe"));
            //Lava Cave
            lavaCave.setExit("south", caveEntrance);

            lavaCave.placeItemInRoom(new Item("Lava Rock"));
            //Up cracked cave
            crackedCave.setExit("down", caveEntrance);

            crackedCave.placeItemInRoom(new Item("Old Sword"));
            //Down dark cave
            darkCave.setExit("up", stalactiteCave);

            darkCave.placeItemInRoom(new Item("Old Pistol"));
            // start game outside
            player.setCurrentRoom(outside);
		}


		/**
	     *  Main play routine.  Loops until end of play.
	     */
		public void play()
		{
			printWelcome();

			// Enter the main command loop.  Here we repeatedly read commands and
			// execute them until the game is over.
			bool finished = false;
			while (! finished) {
				Command command = parser.getCommand();
				finished = processCommand(command);
			}
			Console.WriteLine("Thank you for playing.");
		}

		/**
	     * Print out the opening message for the player.
	     */
		private void printWelcome()
		{
			Console.WriteLine();
			Console.WriteLine("Welcome to Cavecraft!");
			Console.WriteLine("Cavecraft is an underground dungeon adventure game.");
			Console.WriteLine("Type 'help' if you need help.");
			Console.WriteLine();
			Console.WriteLine(player.getCurrentRoom().getLongDescription());
		}

		/**
	     * Given a command, process (that is: execute) the command.
	     * If this command ends the game, true is returned, otherwise false is
	     * returned.
	     */
		private bool processCommand(Command command)
		{
			bool wantToQuit = false;

			if(command.isUnknown()) {
				Console.WriteLine("I don't know what you mean...");
				return false;
			}

			string commandWord = command.getCommandWord();
			switch (commandWord) {
				case "help":
					printHelp();
					break;
				case "go":
					goRoom(command);
                    break;
                case "look":
                    goLook();
                    break;
                case "pickup":
                    pickup(command);
                    break;
				case "quit":
					wantToQuit = true;
					break;
			}

			return wantToQuit;
		}
        
        // implementations of user commands:

        /**
	     * Print out some help information.
	     * Here we print some stupid, cryptic message and a list of the
	     * command words.
	     */
        private void printHelp()
		{
			Console.WriteLine("You are lost. You are alone.");
			Console.WriteLine("You wander around the cave entrance.");
			Console.WriteLine();
			Console.WriteLine("Your command words are:");
			parser.showCommands();
		}

		/**
	     * Try to go to one direction. If there is an exit, enter the new
	     * room, otherwise print an error message.
	     */
		private void goRoom(Command command)
		{
			if(!command.hasSecondWord())
            {
				// if there is no second word, we don't know where to go...
				Console.WriteLine("Go where?");
				return;
			}

			string direction = command.getSecondWord();

			// Try to leave current room.
			Room nextRoom = player.getCurrentRoom().getExit(direction);

			if (nextRoom == null)
            {
				Console.WriteLine("There is no cave entrance to the "+direction+"!");
			}
            else if(player.getCurrentHealth() > 0)
            {
                player.setCurrentRoom(nextRoom);
				Console.WriteLine(player.getCurrentRoom().getLongDescription());
                player.damage(1);
                Console.WriteLine("The player took some damage....");
                Console.WriteLine("The player has " + player.getCurrentHealth() + " health left.");
            }
            else
            {
                Console.WriteLine("The player can't go anywhere when he/she is dead.");
            }
		}

        /**
	     * Try to go to one direction. If there is an exit, enter the new
	     * room, otherwise print an error message.
	     */
        private void goLook()
        {
            // Try to leave current room.
            Console.WriteLine(player.getCurrentRoom().getLongDescription());
            //Looks around the room for items and print it.
            Console.WriteLine(player.getCurrentRoom().getItemInRoom());
        }

        /**
         * Pickup an item and remove it from the room array list
         */
        private void pickup(Command command)
        {
            for (int i = 0; i < player.getCurrentRoom().getItemList().Count; ++i)
            {
                string itemInRoom = player.getCurrentRoom().getItemList()[i].getItemName();
                if (command.getSecondWord().Equals(itemInRoom))
                {
                    Console.WriteLine("picked up " + itemInRoom);
                    player.getCurrentRoom().removeItemFromRoom(player.getCurrentRoom().getItemList()[i]);
                }
            }
        }

    }
}
