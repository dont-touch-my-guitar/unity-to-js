using System;
using CustomExporter.Utilities;
using Camera = CustomExporter.Entities.Camera;

namespace CustomExporter.Builders
{
    public class CameraBuilder
    {
        public Camera PrepareCameraObject(UnityEngine.Camera camera)
        {
            var cam = new Camera();

            cam.name = camera.gameObject.name;
            cam.id = camera.gameObject.GetInstanceID().ToString();
            
            cam.parentId = null;
            if (camera.transform.parent != null)
            {
                cam.parentId = camera.transform.parent.gameObject.GetInstanceID().ToString();
            }
            
            cam.position = SceneSerializationUtilities.ConvertVectorToList(camera.transform.localPosition);
            cam.fov = camera.fieldOfView * (float) Math.PI / 180;
            cam.minZ = camera.nearClipPlane;
            cam.maxZ = camera.farClipPlane;
            cam.type = "FreeCamera";
            cam.tags = camera.tag;
            cam.lockedTargetId = null;
            cam.target = null;
            cam.checkCollisions = false;
            cam.applyGravity = false;
            cam.ellipsoid = null;

            return cam;
        }
    }
}