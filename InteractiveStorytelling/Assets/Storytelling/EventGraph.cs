using System.Collections.Generic;
using System.Linq;
using Utility;
using WorldState;

namespace Storytelling {
    public class EventGraph {

        public World World => World.Instance; // for convenience and to allow for multiple worlds later
        
        public Event e {get; set;}
        public HashSet<SpatialGraph> S { get; set; }
        public HashSet<Room> R => World.Rooms;
        public HashSet<Furniture> F => World.Rooms.SelectMany(room => room.Furniture).ToHashSet();
        public HashSet<NPC> C { get; set; }
        public HashSet<Item> I { get; set; }
        public ProbabilityModel P { get; set; }

    }

    public class SpatialGraph {
        
    }
    

    /// <summary>
    /// Describes the high-level states of all participating characters.
    /// </summary>
    public class Event {
        
    }
    
}