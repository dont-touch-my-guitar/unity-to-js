using System;
using System.Collections.Generic;

namespace CustomExporter.Entities
{
    [Serializable]
    public class Camera : EntityBase
    {
        public string type { get; set; }
        public string tags { get; set; }
        public object lockedTargetId { get; set; }
        public List<float> position { get; set; }
        public object target { get; set; }
        public float fov { get; set; }
        public float minZ { get; set; }
        public float maxZ { get; set; }
        public float speed { get; set; }
        public float inertia { get; set; }
        public bool checkCollisions { get; set; }
        public bool applyGravity { get; set; }
        public object ellipsoid { get; set; }

        public Camera()
        {
            position = new List<float> {0f, 0f, 0f};
            fov = 0.8f;
            minZ = 0.1f;
            maxZ = 5000.0f;
            speed = 1.0f;
            inertia = 0.9f;
            type = "FreeCamera";
        }
    }
}