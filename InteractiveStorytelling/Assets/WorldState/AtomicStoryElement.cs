using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace WorldState {
    
    [Serializable]
    public class AtomicStoryElement {

        [SerializeField] private Character character;
        [SerializeField] private Room room;
        [SerializeField] private Activity activity;
        
        public Character Character => character;
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