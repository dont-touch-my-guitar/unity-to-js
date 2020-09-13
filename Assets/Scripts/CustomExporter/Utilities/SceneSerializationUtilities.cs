using System.Collections.Generic;
using UnityEngine;

namespace CustomExporter.Utilities
{
    public class SceneSerializationUtilities
    {
        public static List<float> ConvertVectorToList(Vector3 input)
        {
            {
                var result = new List<float>();
                result.Add(input.x);
                result.Add(input.y);
                result.Add(input.z);
                return result;
            }
        }

        public static List<float> ConvertColorToList(Color color)
        {
            {
                var result = new List<float>();
                result.Add(color.r);
                result.Add(color.g);
                result.Add(color.b);
                result.Add(color.a);
                return result;
            }
        }
    }
}