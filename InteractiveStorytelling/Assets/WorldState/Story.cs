using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace WorldState {
    
    public class Story : MonoBehaviour {
        
        [SerializeField] private List<StoryEvents> storyEvents;

        public List<StoryEvents> StoryEvents => storyEvents;
        
    }
    
    [Serializable]
    public class StoryEvents {
        
        [SerializeField] private List<AtomicStoryElement> atomicStoryElements;
        
        public List<AtomicStoryElement> AtomicStoryElements => atomicStoryElements;
    }
}