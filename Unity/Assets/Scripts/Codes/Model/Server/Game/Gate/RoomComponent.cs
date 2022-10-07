using System.Collections.Generic;
using System.Linq;

namespace ET.Server
{
	[ComponentOf(typeof(Scene))]
	public class RoomComponent : Entity, IAwake, IDestroy
	{
		public readonly Dictionary<long, Room> idRooms = new Dictionary<long, Room>();

		public readonly LinkedList<Room> waitingRooms = new LinkedList<Room>();

		public readonly Dictionary<long, LinkedListNode<Room>> searchWatingRoom = new Dictionary<long, LinkedListNode<Room>>();
	}
}