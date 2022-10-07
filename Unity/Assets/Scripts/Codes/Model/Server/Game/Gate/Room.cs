using System.Collections.Generic;

namespace ET.Server
{
    public class Room : Entity, IAwake<uint>
    {
        public List<long> idPlayers = new List<long>();

        public uint gameMode;

        public bool waitingFlag;
    }
}