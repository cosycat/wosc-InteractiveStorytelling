using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldState {
    
    public class World : MonoBehaviour
    {
        // singleton
        public static World Instance { get; private set; }

        // list of rooms
        public HashSet<Room> Rooms { get; } = new();


        private void Awake() {
            // singleton
            if (Instance == null) {
                Instance = this;
            } else {
                Destroy(gameObject);
                Debug.LogError("Duplicate World destroyed");
            }
            
            // add all rooms in children to list
            foreach (var room in GetComponentsInChildren<Room>()) {
                Rooms.Add(room);
            }
        }
        
        
    }
    
}

