using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;
using WorldState;

namespace Storytelling {
    
    /// <summary>
    /// "A spatial graph 𝑆𝐺 encodes the high-level spatial relations of the virtual characters and items
    /// with the layout of a room at an event frame"
    /// "Each spatial graph SG encodes one possible spatial relations of the virtual characters and items
    /// with the layout of a room for realizing event e."
    /// Section 5.3
    /// </summary>
    public class SpatialGraph {
        public HashSet<RoomNode> Rooms { get; }

        public SpatialGraph(IEnumerable<RoomNode> rooms) {
            Rooms = new HashSet<RoomNode>(rooms);
        }

        public static HashSet<SpatialGraph> CreateAllSpatialGraphs(EventGraph eventGraph) {
            HashSet<Slot> allPossibleCharacterSlots = eventGraph.F.Where(F => F.IsCharacterSlot).Select(furniture => furniture.CharacterSlot).ToHashSet();
            HashSet<NPC> allCharacters = eventGraph.C;
            
            if (allPossibleCharacterSlots.Count < allCharacters.Count) {
                throw new Exception("There are more characters than character slots.");
            }
            
            // Generate all possible permutations of characters and character slots.
            

            throw new NotImplementedException();

        }
    }
    
    public struct RoomNode {
        public Room Room { get; }
        
        public HashSet<FurnitureNode> FurnitureNodes { get; }
    }
    
    public struct FurnitureNode {
        public Furniture Furniture { get; }
        
        public CharacterNode CharacterNode { get; } // Character sitting on this furniture
    }

    public struct CharacterNode {
        public Character Character { get; }
        
        [CanBeNull] public ItemNode ItemNode { get; }
    }
    public class ItemNode {
        public Item Item { get; }
    }
    
    /// <summary>
    /// While a spatial graph 𝑆𝐺 encodes the high-
    /// level spatial relations of the virtual characters and items with the
    /// layout of a room at an event frame, the low-level details regarding
    /// the positions and orientations of the characters and items are not
    /// described. For example, given the context "a virtual character sits
    /// on the sofa", which part of the sofa the character sits on and what
    /// direction it is facing are still unclear. Therefore, each character
    /// node 𝑐 ∈ C is attributed by (𝜌𝑐,𝜃𝑐𝑏,𝜃𝑐h), where 𝜌𝑐 is the position,
    /// 𝜃𝑐𝑏 is the body orientation, and 𝜃𝑐h is the head orientation of the
    /// character. As we discretize the space that a character can occupy
    /// (Section 4), 𝜌𝑐 refers to the position of a character slot. Similarly,
    /// each virtual item node 𝑖 ∈ I is attributed by (𝜌 ,𝜃 ), where 𝜌 𝑖𝑖𝑖
    /// and 𝜃𝑖 refer to the item’s position and root orientation.
    /// In case a character is carrying a virtual item, the item node 𝑖 is attached
    /// to the character node 𝑐, and 𝑖 inherits the position and orientation from 𝑐.
    /// Given a spatial graph 𝑆𝐺, we define an instantiation of the attributes of all
    /// the virtual characters and items as a spatial candidate 𝛾 = {(𝜌𝑐,𝜃𝑐𝑏,𝜃𝑐h)}, {(𝜌𝑖,𝜃𝑖)}.
    /// In other words, a spatial candidate contains the position and orientation information
    /// by which the animator puts virtual characters and items in a scene.
    /// </summary>
    public class SpatialCandidate {
        

    }

    public struct ConcreteRoomNode {
        public Room Room { get; }
        
        public HashSet<ConcreteFurnitureNode> ConcreteFurnitureNodes { get; }
    }
    
    public struct ConcreteFurnitureNode {
        public Furniture Furniture { get; }

        public Vector3 Position => Furniture.Position;
        
        public ConcreteCharacterNode ConcreteCharacterNode { get; } // Character sitting on this furniture
    }
    
    public struct ConcreteCharacterNode {
        public Character Character { get; }
        
        public Vector3 Position { get; }
        public Vector3 ForwardBody { get; }
        public Vector3 ForwardHead { get; }
        
        public ConcreteItemNode ConcreteItemNode { get; }
    }
    
    public struct ConcreteItemNode {
        public Item Item { get; }

        public Vector3 Position { get; }
        public Vector3 Forward { get; }
    }
}