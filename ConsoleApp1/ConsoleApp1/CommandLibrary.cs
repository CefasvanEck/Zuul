using System;

namespace ZuulCS
{
	public class CommandLibrary
	{
		// an array that holds all valid command words
		private string[] validCommands;
        private string[] commandInfo;

        /**
	     * Constructor - initialise the command words.
	     */
        public CommandLibrary(string[] extraInfo)
		{
            commandInfo = new string[] {
                "go" + extraInfo[0],
                "look" + extraInfo[1],
                "take" + extraInfo[2],
                "drop" + extraInfo[3],
                "use " + extraInfo[4],
                "useWeapon" + extraInfo[5],
                "checkInventory" + extraInfo[6],
                "quit" + extraInfo[7],
                "help" + extraInfo[8]
			};

            validCommands = new string[] {
                "go",
                "look",
                "take",
                "drop",
                "use",
                "useWeapon",
                "checkInventory",
                "quit",
                "help"
            };
        }

		/**
	     * Check whether a given string is a valid command word.
	     * Return true if it is, false if it isn't.
	     */
		public bool isCommand(string instring)
		{
			for(int i = 0; i < validCommands.Length; i++) {
				if (validCommands[i] == instring) {
					return true;
				}
			}
			// if we get here, the string was not found in the commands
			return false;
		}

		/**
	     * Print all valid commands to Console.WriteLine.
	     */
		public void showAll()
		{
			for(int i = 0; i < commandInfo.Length; i++) {
				Console.Write(commandInfo[i]);
				if (i != commandInfo.Length - 1) {
				}
			}
			Console.WriteLine();
		}
	}
}
