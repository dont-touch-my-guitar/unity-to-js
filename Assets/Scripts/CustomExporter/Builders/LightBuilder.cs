using System;
using CustomExporter.Utilities;
using UnityEngine;
using Light = CustomExporter.Entities.Light;

namespace CustomExporter.Builders
{
    public class LightBuilder
    {
        public Light PrepareLightObject(UnityEngine.Light light)
        {
            var lightObj = new Light();

            lightObj.name = light.gameObject.name;
            lightObj.id = light.gameObject.GetInstanceID().ToString();
            lightObj.parentId = null;

            if (light.transform.parent != null)
            {
                light.transform.parent.gameObject.GetInstanceID().ToString();
            }

            lightObj.tags = light.gameObject.tag;
            lightObj.type = 1;
            lightObj.position = SceneSerializationUtilities.ConvertVectorToList(light.transform.localPosition);
            lightObj.direction =
                SceneSerializationUtilities.ConvertVectorToList(light.transform.TransformDirection(Vector3.forward));
            lightObj.angle = light.spotAngle * (float) Math.PI / 180;
            lightObj.groundColor = SceneSerializationUtilities.ConvertVectorToList(Vector3.one); //???
            lightObj.intensity = light.intensity;
            lightObj.range = light.range;
            lightObj.diffuse =
                SceneSerializationUtilities.ConvertVectorToList(
                    new Vector3(light.color.r, light.color.g, light.color.b));
            
            return lightObj;
        }
    }
}