namespace ET.Server
{
    public static class RoomComponentSystem
    { 
        public static void Add(this RoomComponent self, Room room)
        {
            self.idRooms.Add(room.Id, room);
            self.JoinWaitingList(room);
        }

        public static void Remove(this RoomComponent self, Room room)
        {
            self.idRooms.Remove(room.Id);
            self.TryRemoveWaitingList(room);
        }

        public static void JoinWaitingList(this RoomComponent self, Room room)
        {
            var node = self.waitingRooms.AddLast(room);
            self.searchWatingRoom.Add(room.Id, node);
        }

        public static void TryRemoveWaitingList(this RoomComponent self, Room room)
        {
            if (self.searchWatingRoom.TryGetValue(room.Id, out var node))
            {
                self.waitingRooms.Remove(node);
                self.searchWatingRoom.Remove(room.Id);
            }
        }

        public static Room SearchWatingRoomByGameMode(this RoomComponent self, uint gameMode)
        {
            foreach(var room in self.waitingRooms)
            {
                if (room.gameMode == gameMode)
                {
                    return room;
                }
            }
            return null;
        }
    }
}