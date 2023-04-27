using UnityEngine;

namespace WorldState {
    public class Furniture : Thing {
        public Vector3 Position => transform.position;
    }
}