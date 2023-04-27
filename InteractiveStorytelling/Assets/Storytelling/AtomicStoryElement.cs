using System;
using UnityEngine;
using WorldState;

namespace Storytelling {
    
    [Serializable]
    public class AtomicStoryElement {

        [SerializeField] private NPC character;
        [SerializeField] private Room room;
        [SerializeField] private Activity activity;
        
        public NPC Character => character;
        public Room Room => room;
        public Activity Activity => activity;
        
        
    }

    [Serializable]
    public enum Activity {
        WatchTV,
        ReadBook,
        Idle,
    }
}