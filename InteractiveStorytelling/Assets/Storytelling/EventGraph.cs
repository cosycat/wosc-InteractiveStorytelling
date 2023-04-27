using System.Collections.Generic;
using System.Linq;
using Utility;
using WorldState;

namespace Storytelling {
    
    /// <summary>
    /// "Each event graph comprises multiple alternative spatial graphs,
    /// where each spatial graph SG encodes one possible spatial relations of the virtual characters and items
    /// with the layout of a room for realizing event e." 
    /// </summary>
    public class EventGraph {

        public World World => World.Instance;
        
        
        public EventFrame e { get; private set;}
        public HashSet<SpatialGraph> S { get; private set; }
        public HashSet<Room> R => World.Rooms;
        public HashSet<Furniture> F => World.Rooms.SelectMany(room => room.Furniture).ToHashSet();
        public HashSet<NPC> C { get; private set; }
        public HashSet<Item> I { get; private set; }
        /// <summary>
        /// "P denotes a probability model used for selecting which spatial graph 𝑆𝐺 to use for realizing this event 𝑒"
        /// </summary>
        public ProbabilityModel P { get; set; }

        
        public EventGraph(EventFrame e, IEnumerable<NPC> c, IEnumerable<Item> i, ProbabilityModel p) {
            this.e = e;
            C = new HashSet<NPC>(c);
            I = new HashSet<Item>(i);
            S = SpatialGraph.CreateAllSpatialGraphs(e, R, C, I);
            P = p;
        }

        public EventGraph(EventFrame eventFrame, IEnumerable<AtomicStoryElement> atomicStoryElements) {
            e = eventFrame;
            // S = SpatialGraph.CreateAllSpatialGraphs(eventFrame);
        }
    }

}