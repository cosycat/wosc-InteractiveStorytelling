using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using WorldState;

namespace Storytelling {
    /// <summary>
    /// Describes the high-level states of all participating characters.
    /// </summary>
    [Serializable]
    public class EventFrame {
        [SerializeField] private List<AtomicStoryElement> atomicStoryElements;
        public List<AtomicStoryElement> AtomicStoryElements => atomicStoryElements;


        public EventGraph AssociatedEventGraph { get; set; } = null;

        public void GenerateEventGraphFromRawStory() {
            AssociatedEventGraph = new EventGraph(
                this,
                atomicStoryElements);
        }
    }
}