using System;
using System.Collections.Generic;
using UnityEngine;

namespace WorldState {
    public class Room : MonoBehaviour
    {
        public enum RoomType {
            LivingRoom,
            Bedroom,
            Office,
            MeetingRoom,
            Hallway,
        }
        
        public HashSet<Slot> Slots { get; } = new();
        public HashSet<Furniture> Furniture { get; } = new();
        
        // To create the room layout in the inspector
        [SerializeField] private List<Vector2> cornerPoints = new();
        [SerializeField] private float floorHeight = 0f;
        [SerializeField] private RoomType roomType = RoomType.LivingRoom;
        

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

        // private void GenerateRoomBoundaries() {
        //     // generate room boundaries by creating almost flat cubes between each corner point reaching from one corner point to the next
        //     var roomBoundaries = new GameObject("RoomBoundaries");
        //     roomBoundaries.transform.parent = transform;
        //     roomBoundaries.transform.localPosition = Vector3.zero;
        //     roomBoundaries.transform.localRotation = Quaternion.identity;
        //     roomBoundaries.transform.localScale = Vector3.one;
        //     for (var i = 0; i < cornerPoints.Count; i++) {
        //         var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //         go.transform.parent = roomBoundaries.transform;
        //         go.transform.localPosition = new Vector3((cornerPoints[i].x + cornerPoints[(i + 1) % cornerPoints.Count].x) / 2f, floorHeight + 0.5f, (cornerPoints[i].y + cornerPoints[(i + 1) % cornerPoints.Count].y) / 2f);
        //         go.transform.localRotation = Quaternion.Euler(0f, Mathf.Atan2(cornerPoints[(i + 1) % cornerPoints.Count].x - cornerPoints[i].x, cornerPoints[(i + 1) % cornerPoints.Count].y - cornerPoints[i].y) * Mathf.Rad2Deg, 0f);
        //         go.transform.localScale = new Vector3(Vector2.Distance(cornerPoints[i], cornerPoints[(i + 1) % cornerPoints.Count]), 1f, 1f);
        //         go.GetComponent<MeshRenderer>().material = roomMaterial;
        //     }
        //
        //
        // }
        //
        // private void GenerateRoomBoundariesMesh() {
        //     // generate room boundaries from corner points
        //     var meshFilter = gameObject.AddComponent<MeshFilter>();
        //     var meshRenderer = gameObject.AddComponent<MeshRenderer>();
        //     var mesh = new Mesh();
        //     meshFilter.mesh = mesh;
        //     var vertices = new List<Vector3>();
        //     var triangles = new List<int>();
        //     var normals = new List<Vector3>();
        //     var uvs = new List<Vector2>();
        //     var vertexIndex = 0;
        //     for (var i = 0; i < cornerPoints.Count; i++) {
        //         vertices.Add(new Vector3(cornerPoints[i].x, floorHeight, cornerPoints[i].y));
        //         vertices.Add(new Vector3(cornerPoints[(i + 1) % cornerPoints.Count].x, floorHeight, cornerPoints[(i + 1) % cornerPoints.Count].y));
        //         vertices.Add(new Vector3(cornerPoints[i].x, floorHeight + 1f, cornerPoints[i].y));
        //         vertices.Add(new Vector3(cornerPoints[(i + 1) % cornerPoints.Count].x, floorHeight + 1f, cornerPoints[(i + 1) % cornerPoints.Count].y));
        //         triangles.Add(vertexIndex + 0);
        //         triangles.Add(vertexIndex + 2);
        //         triangles.Add(vertexIndex + 1);
        //         triangles.Add(vertexIndex + 1);
        //         triangles.Add(vertexIndex + 2);
        //         triangles.Add(vertexIndex + 3);
        //         normals.Add(Vector3.up);
        //         normals.Add(Vector3.up);
        //         normals.Add(Vector3.up);
        //         normals.Add(Vector3.up);
        //         uvs.Add(new Vector2(0f, 0f));
        //         uvs.Add(new Vector2(0f, 1f));
        //         uvs.Add(new Vector2(1f, 0f));
        //         uvs.Add(new Vector2(1f, 1f));
        //         vertexIndex += 4;
        //     }
        //     mesh.SetVertices(vertices);
        //     mesh.SetTriangles(triangles, 0);
        //     mesh.SetNormals(normals);
        //     mesh.SetUVs(0, uvs);
        //     mesh.RecalculateBounds();
        //     mesh.RecalculateNormals();
        //     mesh.RecalculateTangents();
        //     meshRenderer.material = roomMaterial;
        //     
        // }


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
