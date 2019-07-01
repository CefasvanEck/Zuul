using System;

namespace ZuulCS
{
	public class Parser
	{
		private CommandLibrary commands;  // holds all valid command words

		public Parser()
		{
            string[] extraInfo = new string[]
            {
                "\n",
                "\n",
                " <Item Name > \n",
                " <Item Name> \n",
                " <Item Name> \n",
                " <Weapon Name> <Enemy Name> \n",
                "\n",
                "\n",
                ""
            };
            commands = new CommandLibrary(extraInfo);
		}

		/**
	     * Ask and interpret the user input. Return a Command object.
	     */
		public Command getCommand()
		{
			Console.Write("> ");     // print prompt

			string word1 = null;
			string word2 = null;
            string word3 = null;

            string[] words = Console.ReadLine().Split(' ');
			if (words.Length > 0) { word1 = words[0]; }
			if (words.Length > 1) { word2 = words[1]; }
            if (words.Length > 2) { word3 = words[2]; }

            if (words.Length > 3)
            {
                for (int i = 3; i < words.Length; ++i)
                {
                    word3 += " " + words[i];
                    Console.WriteLine(word3);
                }
            }

            // Now check whether this word is known. If so, create a command with it.
            if (commands.isCommand(word1)) {
				return new Command(word1, word2, word3);
			}

			// If not, create a "null" command (for unknown command).
			return new Command(null, null, null);
		}

		/**
	     * Print out a list of valid command words.
	     */
		public void showCommands(string[] extraInfo)
		{
			commands.showAll();
		}
	}
}
