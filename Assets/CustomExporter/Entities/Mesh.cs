using System;
using System.Collections.Generic;

namespace CustomExporter.Entities
{
    [Serializable]
    public class Mesh : EntityBase
    {
        public string tags { get; set; }
        public string materialId { get; set; }
        public List<float> position { get; set; }
        public List<float> rotation { get; set; }
        public object rotationQuaternion { get; set; }
        public List<float> scaling { get; set; }
        public object pivotMatrix { get; set; }
        public bool infiniteDistance { get; set; }
        public bool showBoundingBox { get; set; }
        public bool showSubMeshesBoundingBox { get; set; }
        public bool isEnabled { get; set; }
        public bool isVisible { get; set; }
        public bool pickable { get; set; }
        public bool applyFog { get; set; }
        public int alphaIndex { get; set; }
        public bool checkCollisions { get; set; }
        public int billboardMode { get; set; }
        public bool receiveShadows { get; set; }
        public int physicsImpostor { get; set; }
        public float physicsMass { get; set; }
        public float physicsFriction { get; set; }
        public float physicsRestitution { get; set; }
        public List<float> positions { get; set; }
        public List<float> normals { get; set; }
        public List<float> uvs { get; set; }
        public object colors { get; set; }
        public object matricesIndices { get; set; }
        public object matricesWeights { get; set; }
        public List<int> indices { get; set; }
        public object subMeshes { get; set; }
        public object actions { get; set; }
        public object instances { get; set; }

        public Mesh()
        {
            tags = string.Empty;
            isEnabled = true;
            isVisible = true;
            position = new List<float> {0f, 0f, 0f};
            rotation = new List<float> {0f, 0f, 0f};
            scaling = new List<float> {1f, 1f, 1f};
            billboardMode = 0;
            pickable = true;
        }
    }
}