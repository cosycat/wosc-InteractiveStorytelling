using System;
using System.Collections.Generic;
using UnityEngine;

namespace Storytelling {
    
    public class Story : MonoBehaviour {

        [SerializeField] private List<EventFrame> storyEvents;
        public List<EventFrame> StoryEvents => storyEvents;

        private void Start() {
            foreach (var eventFrame in StoryEvents) {
                eventFrame.GenerateEventGraphFromRawStory();
            }
        }
    }
    
}