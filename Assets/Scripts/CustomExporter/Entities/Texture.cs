using System;

namespace CustomExporter.Entities
{
    [Serializable]
    public class Texture
    {
        public string name { get; set; }
        public float level { get; set; }
        public bool hasAlpha { get; set; }
        public float uOffset { get; set; }
        public float vOffset { get; set; }
        public float uScale { get; set; }
        public float vScale { get; set; }
        public float uAng { get; set; }
        public float vAng { get; set; }
        public float wAng { get; set; }
        public int wrapU { get; set; }
        public int wrapV { get; set; }
        public int coordinatesIndex { get; set; }

        public Texture()
        {
            level = 1.0f;
            uOffset = 0f;
            vOffset = 0f;
            uScale = 1.0f;
            vScale = 1.0f;
            uAng = 0f;
            vAng = 0f;
            wAng = 0f;
            wrapU = 1;
            wrapV = 1;
            hasAlpha = false;
            coordinatesIndex = 0;
        }
    }
}