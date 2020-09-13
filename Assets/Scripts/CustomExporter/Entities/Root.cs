using System;
using System.Collections.Generic;

namespace CustomExporter.Entities
{
    [Serializable]
    public class Root
    {
        public bool autoClear { get; set; }
        public List<float> clearColor { get; set; }
        public List<float> ambientColor { get; set; }
        public List<float> gravity { get; set; }
        public List<Camera> cameras { get; set; }
        public List<float> cameraRotationAngle { get; set; }
        public string activeCameraID { get; set; }
        public List<Light> lights { get; set; }
        public List<Material> materials { get; set; }
        public List<Mesh> meshes { get; set; }
        public List<object> multiMaterials { get; set; }
        public List<object> shadowGenerators { get; set; }
        public List<object> skeletons { get; set; }
        public object particleSystems { get; set; }
        public object lensFlareSystems { get; set; }
        public object actions { get; set; }
        public List<object> sounds { get; set; }
        public bool collisionsEnabled { get; set; }
        public bool physicsEnabled { get; set; }
        public object physicsGravity { get; set; }
        public object physicsEngine { get; set; }
        public List<object> animations { get; set; }
    }
}