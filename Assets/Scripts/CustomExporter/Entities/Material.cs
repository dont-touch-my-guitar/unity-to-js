using System;
using System.Collections.Generic;
using CustomExporter.Utilities;
using UnityEngine;

namespace CustomExporter.Entities
{
    [Serializable]
    public class Material
    {
        public string name { get; set; }
        public string id { get; set; }
        public string tags { get; set; }
        public List<float> ambient { get; set; }
        public List<float> diffuse { get; set; }
        public List<float> specular { get; set; }
        public float specularPower { get; set; }
        public List<float> emissive { get; set; }
        public float alpha { get; set; }
        public bool backFaceCulling { get; set; }
        public bool wireframe { get; set; }
        public object diffuseTexture { get; set; }
        public object ambientTexture { get; set; }
        public object opacityTexture { get; set; }
        public Texture reflectionTexture { get; set; }
        public object emissiveTexture { get; set; }
        public object specularTexture { get; set; }
        public object bumpTexture { get; set; }
        public Texture lightmapTexture { get; set; }
        public bool useLightmapAsShadowmap { get; set; }
        public bool useEmissiveAsIllumination { get; set; }
        public object diffuseFresnelParameters { get; set; }
        public object opacityFresnelParameters { get; set; }
        public object reflectionFresnelParameters { get; set; }
        public object emissiveFresnelParameters { get; set; }

        public Material()
        {
            backFaceCulling = true;
            alpha = 1f;
            ambient = SceneSerializationUtilities.ConvertColorToList(Color.black);
            diffuse = SceneSerializationUtilities.ConvertColorToList(Color.white);
            specular = SceneSerializationUtilities.ConvertColorToList(Color.black);
            emissive = SceneSerializationUtilities.ConvertColorToList(Color.black);
            specularPower = 64f;
            useEmissiveAsIllumination = false;
        }
    }
}