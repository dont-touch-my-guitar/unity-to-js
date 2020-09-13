using CustomExporter.Utilities;
using Material = CustomExporter.Entities.Material;

namespace CustomExporter.Builders
{
    public class MaterialBuilder
    {
        public Material PrepareMaterial(UnityEngine.Material material, int lightmapIndex)
        {
            var mat = new Material();

            mat.name = material.name;
            mat.id = material.GetInstanceID().ToString();
            mat.tags = string.Empty;
            mat.ambient = material.HasProperty("_AmbientColor")
                ? SceneSerializationUtilities.ConvertColorToList(material.GetColor("_AmbientColor"))
                : mat.ambient;

            mat.diffuse = material.HasProperty("_Color")
                ? SceneSerializationUtilities.ConvertColorToList(material.GetColor("_Color"))
                : mat.diffuse;

            mat.specular = material.HasProperty("_SpecColor")
                ? SceneSerializationUtilities.ConvertColorToList(material.GetColor("_SpecColor"))
                : mat.specular;

            mat.specularPower = material.HasProperty("_Shininess")
                ? material.GetFloat("_Shininess") * 128
                : mat.specularPower;

            mat.emissive = material.HasProperty("_EmissionColor")
                ? SceneSerializationUtilities.ConvertColorToList(material.GetColor("_EmissionColor"))
                : mat.emissive;
            
            mat.alpha = mat.diffuse[3];
            mat.backFaceCulling = material.HasProperty("_BackFaceCulling") && material.GetInt("_BackFaceCulling") != 0;
            mat.wireframe = material.HasProperty("_Wireframe") && material.GetInt("_Wireframe") != 0;
            mat.diffuseTexture = null;
            mat.ambientTexture = null;
            mat.opacityTexture = null;
            mat.reflectionTexture = null;
            mat.emissiveTexture = null;
            mat.specularTexture = null;
            mat.bumpTexture = null;
            //todo export lightmap texture for shadows
            //use textureBuilder.BuildLightmapTexture(LightmapSettings.lightmaps[lightmapIndex].lightmapColor);
            mat.lightmapTexture = null;
            mat.useLightmapAsShadowmap = mat.lightmapTexture != null;
            mat.useEmissiveAsIllumination = material.HasProperty("_UseEmissiveAsIllumination") &&
                                            material.GetInt("_UseEmissiveAsIllumination") != 0;
            mat.diffuseFresnelParameters = null;
            mat.opacityFresnelParameters = null;
            mat.reflectionFresnelParameters = null;
            mat.emissiveFresnelParameters = null;

            return mat;
        }
    }
}