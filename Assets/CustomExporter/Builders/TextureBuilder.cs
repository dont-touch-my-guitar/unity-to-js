using System.IO;
using UnityEditor;
using Texture = CustomExporter.Entities.Texture;

namespace CustomExporter.Builders
{
    public class TextureBuilder
    {
        public Texture PrepareLightmapTexture(UnityEngine.Texture texture)
        {
            if (texture == null)
            {
                return null;
            }

            var texturePath = AssetDatabase.GetAssetPath(texture);
            var textureName = Path.GetFileName(texturePath);
            var textureObj = new Texture
            {
                name = textureName
            };
            return textureObj;
        }
    }
}