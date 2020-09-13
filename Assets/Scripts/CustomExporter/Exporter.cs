using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CustomExporter.Builders;
using CustomExporter.Entities;
using CustomExporter.Utilities;
using Newtonsoft.Json;
using UnityEngine;
using Camera = CustomExporter.Entities.Camera;
using Light = CustomExporter.Entities.Light;
using Material = CustomExporter.Entities.Material;
using Mesh = CustomExporter.Entities.Mesh;

namespace CustomExporter
{
	
    public class Exporter : MonoBehaviour
    {
        public void SerializeScene()
        {
            var root = PrepareSceneObject();
            
            var path = Path.Combine(Application.dataPath, "js-out.json");

            
            using (StreamWriter file =
                new StreamWriter(path, false))
            {
                file.Write(JsonConvert.SerializeObject(root));
            }
            
            Debug.Log("Done");
        }
        
        private Root PrepareSceneObject()
        {
            var sceneObj = new Root();
            var cameraBuilder = new CameraBuilder();
            var lightBuilder = new LightBuilder();
            var meshBuilder = new MeshBuilder();
            var materialBuilder = new MaterialBuilder();

            sceneObj.autoClear = true;
            sceneObj.clearColor = SceneSerializationUtilities.ConvertVectorToList(new Vector3(0.2f, 0.2f, 0.2f));
            sceneObj.ambientColor = SceneSerializationUtilities.ConvertVectorToList(Vector3.zero);
            sceneObj.gravity = SceneSerializationUtilities.ConvertVectorToList(new Vector3(0f, -9.81f, -0.0f));
            sceneObj.multiMaterials = null;
            sceneObj.shadowGenerators = null;
            sceneObj.skeletons = null;
            sceneObj.particleSystems = null;
            sceneObj.lensFlareSystems = null;
            sceneObj.actions = null;
            sceneObj.sounds = null;
            sceneObj.collisionsEnabled = false;
            sceneObj.physicsEnabled = false;
            sceneObj.physicsGravity = null;
            sceneObj.physicsEngine = null;
            sceneObj.animations = null;

            sceneObj.cameras = new List<Camera>();
            sceneObj.lights = new List<Light>();
            sceneObj.materials = new List<Material>();
            sceneObj.meshes = new List<Mesh>();

            var lights = FindObjectsOfType<UnityEngine.Light>().ToList();
            foreach (var light in lights)
            {
                var lght = lightBuilder.PrepareLightObject(light);
                sceneObj.lights.Add(lght);
            }

            var cameras = FindObjectsOfType<UnityEngine.Camera>().ToList();
            foreach (var camera in cameras)
            {
                var cam = cameraBuilder.PrepareCameraObject(camera);
                sceneObj.cameras.Add(cam);
                sceneObj.cameraRotationAngle = SceneSerializationUtilities.ConvertVectorToList(new Vector3(
                    camera.gameObject.transform.localRotation.eulerAngles.x * (float) Math.PI / 180,
                    camera.gameObject.transform.localRotation.eulerAngles.y * (float) Math.PI / 180,
                    camera.gameObject.transform.localRotation.eulerAngles.z * (float) Math.PI / 180
                ));
            }

            
            var meshes = FindObjectsOfType<MeshFilter>().ToList();
            foreach (var mesh in meshes)
            {
                var meshRenderer = mesh.GetComponent<MeshRenderer>();
                var material = materialBuilder.PrepareMaterial(meshRenderer.sharedMaterial, meshRenderer.lightmapIndex);
                sceneObj.materials.Add(material);
                var meshObj = meshBuilder.PrepareMeshObject(mesh, meshRenderer, material.id);
                sceneObj.meshes.Add(meshObj);
            }

            sceneObj.activeCameraID = sceneObj.cameras[0].id;
            return sceneObj;
        }
    }
}