using System;
using System.Collections.Generic;

namespace CustomExporter.Entities
{
    [Serializable]
    public class Light : EntityBase
    {
        public object tags { get; set; }
        public int type { get; set; }
        public object position { get; set; }
        public List<float> direction { get; set; }
        public float angle { get; set; }
        public float exponent { get; set; }
        public List<float> groundColor { get; set; }
        public float intensity { get; set; }
        public float range { get; set; }
        public List<float> diffuse { get; set; }
        public List<float> specular { get; set; }
        public object excludedMeshesIds { get; set; }
        public object includedOnlyMeshesIds { get; set; }

        public Light()
        {
            diffuse = new List<float> {1f, 1f, 1f};
            specular = new List<float> {1f, 1f, 1f};
            intensity = 1f;
            range = float.MaxValue;
            exponent = 1f;
            includedOnlyMeshesIds = null;
            excludedMeshesIds = null;
        }
    }
}