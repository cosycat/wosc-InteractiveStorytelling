using System;
using System.Collections.Generic;
using UnityEngine;

namespace WorldState {
    public class Room : MonoBehaviour
    {
        
        public HashSet<Slot> Slots { get; } = new();
        public HashSet<Furniture> Furniture { get; } = new();
        
        // To create the room layout in the inspector
        [SerializeField] private List<Vector2> cornerPoints = new();
        [SerializeField] private float floorHeight = 0f;
        

        private void Awake() {
            // add all slots in children to list
            foreach (var slot in GetComponentsInChildren<Slot>()) {
                Slots.Add(slot);
            }
            
            // add all furniture in children to list
            foreach (var furniture in GetComponentsInChildren<Furniture>()) {
                Furniture.Add(furniture);
            }

        }


        private void OnDrawGizmos() {
            // draw lines between the corner points at floor height
            Gizmos.color = Color.blue;
            for (var i = 0; i < cornerPoints.Count; i++) {
                Gizmos.DrawLine(
                    new Vector3(cornerPoints[i].x, floorHeight, cornerPoints[i].y),
                    new Vector3(cornerPoints[(i + 1) % cornerPoints.Count].x, floorHeight, cornerPoints[(i + 1) % cornerPoints.Count].y)
                );
            }
            // draw pillars at the corner points
            const float pillarHeight = 2f;
            Gizmos.color = Color.blue;
            foreach (var cornerPoint in cornerPoints) {
                Gizmos.DrawWireCube(new Vector3(cornerPoint.x, floorHeight + pillarHeight / 2f, cornerPoint.y), new Vector3(0.1f, pillarHeight, 0.1f));
            }
        }
    }
}
