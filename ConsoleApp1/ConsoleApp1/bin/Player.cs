namespace ZuulCS
{
    public class Player
    {
        private Room currentRoom;

        public Player()
        {

        }

        public void setCurrentRoom(Room room)
        {
            this.currentRoom = room;
        }

        public Room getCurrentRoom()
        {
            return currentRoom;
        }

    }
}
