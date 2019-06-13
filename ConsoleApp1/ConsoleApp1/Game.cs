﻿using System;

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

            caveEntrance.getInventory().placeItemInInventory(new Item("Dynamite" , 1.5F));
            //Water cave
            waterCave.setExit("west", caveEntrance);
            //Stalactite cave
            stalactiteCave.setExit("east", caveEntrance);
            stalactiteCave.setExit("down", darkCave);

            stalactiteCave.getInventory().placeItemInInventory(new Item("Pickaxe", 2.5F));
            //Lava Cave
            lavaCave.setExit("south", caveEntrance);

            lavaCave.getInventory().placeItemInInventory(new BadItem(2F, "LavaRock", 1F));
            //Up cracked cave
            crackedCave.setExit("down", caveEntrance);

            crackedCave.getInventory().placeItemInInventory(new Item("OldSword", 1.8F));
            //Down dark cave
            darkCave.setExit("up", stalactiteCave);

            darkCave.getInventory().placeItemInInventory(new Item("OldPistol", 1F));
            // start game outside
            player.setCurrentRoom(outside);
		}

        public Player getPlayer()
        {
            return player;
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
			while (! finished)
            {
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
			Console.WriteLine("Welcome to The Forest!");
			Console.WriteLine("The Forest is an island Survival Game with cannibals and Mutants running around.");
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

			if(command.isUnknown())
            {
				Console.WriteLine("I don't know what you mean...");
				return false;
			}

			string commandWord = command.getCommandWord();
			switch (commandWord)
            {
				case "help":
					printHelp();
					break;
				case "go":
					goRoom(command);
                    break;
                case "look":
                    goLook();
                    break;
                case "checkInventory":
                    checkInventory();
                    break;
                case "take":
                    take(command);
                    break;
                case "drop":
                    drop(command);
                    break;
                case "use":
                    use(command);
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

                foreach (string key in player.getInventory().getItemList().Keys)
                {
                    player = player.getInventory().getItemList()[key].use(player);
                }

                if (player.getCurrentHealth() < 0)
                {
                    player.setCurrentHealth(0);
                }

                if (player.getCurrentHealth() == 0)
                {
                    Console.WriteLine("The player died...");
                }  
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
            Console.WriteLine(player.getCurrentRoom().getInventory().getItemsstring());
        }

        private void checkInventory()
        {
            Console.WriteLine(player.getInventory().getItemsstring());
        }

        /**
         * Pickup an item and remove it from the room array list
         */
        private void take(Command command)
        {
            if (player.getCurrentRoom().getInventory().getItemList().ContainsKey(command.getSecondWord()))
            {
                Item itemInRoom = player.getCurrentRoom().getInventory().getItemList()[command.getSecondWord()];

                string itenName = itemInRoom.getItemName();
                if (command.getSecondWord().Equals(itenName) && player.getInventory().getInventorySize() + 1 < +player.getInventory().getInventoryMaxSize() && player.getInventory().getItemWeight() + itemInRoom.getItemWeight() <= player.getInventory().getMaxItemWeight())
                {
                    Console.WriteLine("picked up " + itenName);
                    //ToDo: make swap function in inventory and return message to function with check if it is the size or bigger

                    //Add and Remove from the inventorys the size
                    player.getInventory().addToInventory();
                    player.getCurrentRoom().getInventory().removeFromInventory();
                    //Add and remove weight
                    player.getInventory().addItemWeight(itemInRoom.getItemWeight());
                    player.getCurrentRoom().getInventory().removeItemWeight(itemInRoom.getItemWeight());
                    //Swap Item
                    player.getInventory().placeItemInInventory(itemInRoom);
                    player.getCurrentRoom().getInventory().removeItemFromInventory(itenName);
                }
                else if (player.getInventory().getItemWeight() + itemInRoom.getItemWeight() > player.getInventory().getMaxItemWeight())
                {
                    Console.WriteLine("Your inventory is to heavy to pickup anything else.");
                }
                else if (player.getInventory().getInventorySize() + 1 > player.getInventory().getInventoryMaxSize())
                {
                    Console.WriteLine("Your inventory is full.");
                }
            }
            else
            {
                Console.WriteLine("The room does not contain " + command.getSecondWord());
            }
        }

        private void use(Command command)
        {
            foreach (string key in player.getInventory().getItemList().Keys)
            {
                player = player.getInventory().getItemList()[command.getSecondWord()].use(player);
            }
        }

       /**
        * Pickup an item and remove it from the room array list
        */
        private void drop(Command command)
        {
            if (player.getInventory().getItemList().ContainsKey(command.getSecondWord()))
            {
                Item itemInRoom = player.getInventory().getItemList()[command.getSecondWord()];
                string itenName = itemInRoom.getItemName();
                if (command.getSecondWord().Equals(itenName))
                {
                    Console.WriteLine("dropped " + itenName);
                    //Add and Remove from the inventorys the size
                    player.getCurrentRoom().getInventory().addToInventory();
                    player.getInventory().removeFromInventory();
                    //Add and remove weight
                    player.getCurrentRoom().getInventory().addItemWeight(itemInRoom.getItemWeight());
                    player.getInventory().removeItemWeight(itemInRoom.getItemWeight());
                    //Swap Item
                    player.getCurrentRoom().getInventory().placeItemInInventory(itemInRoom);
                    player.getInventory().removeItemFromInventory(itenName);
                }
            }
            else
            {
                Console.WriteLine("The player does not have " + command.getSecondWord() + " in his/her inventory");
            }
        }
    }
}