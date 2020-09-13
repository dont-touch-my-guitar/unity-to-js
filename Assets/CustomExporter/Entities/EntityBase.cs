using System;

namespace CustomExporter.Entities
{
    [Serializable]
    public class EntityBase
    {
        public string name { get; set; }
        public string id { get; set; }
        public string parentId { get; set; }
        public object animations { get; set; }
        public bool autoAnimate { get; set; }
        public int autoAnimateFrom { get; set; }
        public int autoAnimateTo { get; set; }
        public bool autoAnimateLoop { get; set; }

        public EntityBase()
        {
            animations = null;
            autoAnimate = false;
            autoAnimateFrom = 0;
            autoAnimateTo = 0;
            autoAnimateLoop = false;
        }
    }
}