using System;
using System.Collections.Generic;
using System.Linq;
using CustomExporter.Utilities;
using UnityEngine;
using Mesh = CustomExporter.Entities.Mesh;

namespace CustomExporter.Builders
{
    public class MeshBuilder
    {
        public Mesh PrepareMeshObject(UnityEngine.MeshFilter meshFilter, UnityEngine.MeshRenderer meshRenderer,
            string matId)
        {
            var meshObj = new Mesh();

            meshObj.name = meshFilter.gameObject.name;
            meshObj.id = meshFilter.gameObject.GetInstanceID().ToString();

            meshObj.parentId = null;
            if (meshFilter.transform.parent != null)
            {
                meshFilter.transform.parent.gameObject.GetInstanceID().ToString();
            }

            meshObj.materialId = matId;

            meshObj.position =
                SceneSerializationUtilities.ConvertVectorToList(meshFilter.gameObject.transform.localPosition);

            meshObj.rotation = SceneSerializationUtilities.ConvertVectorToList(new Vector3(
                meshFilter.gameObject.transform.localRotation.eulerAngles.x * (float) Math.PI / 180f,
                meshFilter.gameObject.transform.localRotation.eulerAngles.y * (float) Math.PI / 180f,
                meshFilter.gameObject.transform.localRotation.eulerAngles.z * (float) Math.PI / 180f
            ));

            meshObj.rotationQuaternion = null;
            meshObj.scaling =
                SceneSerializationUtilities.ConvertVectorToList(meshFilter.gameObject.transform.localScale);
            meshObj.pivotMatrix = null;
            meshObj.infiniteDistance = false;
            meshObj.showBoundingBox = false;
            meshObj.showSubMeshesBoundingBox = false;
            meshObj.applyFog = false;
            meshObj.alphaIndex = 0;
            meshObj.checkCollisions = false;
            meshObj.receiveShadows = meshRenderer.receiveShadows;
            meshObj.physicsImpostor = 0;
            meshObj.physicsMass = 0;
            meshObj.physicsFriction = 0;
            meshObj.physicsRestitution = 0;
            meshObj.positions = GetVertexPositions(meshFilter.sharedMesh);
            meshObj.normals = GetNormals(meshFilter.sharedMesh);
            meshObj.indices = GetTriangles(meshFilter.sharedMesh);
            meshObj.uvs = GetUVs(meshFilter.sharedMesh);
            meshObj.colors = null;
            meshObj.matricesIndices = null;
            meshObj.matricesWeights = null;
            meshObj.subMeshes = null;
            meshObj.actions = null;
            meshObj.instances = null;

            return meshObj;
        }

        private List<float> GetVertexPositions(UnityEngine.Mesh mesh)
        {
            var verticiesList = new List<float>();

            foreach (Vector3 vertex in mesh.vertices)
            {
                verticiesList.Add(vertex.x);
                verticiesList.Add(vertex.y);
                verticiesList.Add(vertex.z);
            }

            return verticiesList;
        }

        private List<float> GetNormals(UnityEngine.Mesh mesh)
        {
            var normalsList = new List<float>();

            foreach (Vector3 vertex in mesh.normals)
            {
                normalsList.Add(vertex.x);
                normalsList.Add(vertex.y);
                normalsList.Add(vertex.z);
            }

            return normalsList;
        }

        private List<float> GetUVs(UnityEngine.Mesh mesh)
        {
            var uvs = new List<float>();

            foreach (Vector3 vertex in mesh.uv)
            {
                uvs.Add(vertex.x);
                uvs.Add(vertex.y);
            }

            return uvs;
        }

        private List<int> GetTriangles(UnityEngine.Mesh mesh)
        {
            var trianglePointNumber = 0;
            var triangles = new List<int>();
            var vectors = new List<Vector3>();
            var vector = Vector3.zero;
            foreach (int vertexIndex in mesh.triangles)
            {
                if (trianglePointNumber == 0)
                {
                    vector = Vector3.zero;
                    vector.z = vertexIndex;
                }
                else if (trianglePointNumber == 1)
                {
                    vector.y = vertexIndex;
                }
                else if (trianglePointNumber == 2)
                {
                    vector.x = vertexIndex;
                    vectors.Add(vector);
                }

                trianglePointNumber++;
                if (trianglePointNumber >= 3) trianglePointNumber = 0;
            }

            foreach (Vector3 vec in vectors)
            {
                triangles.Add((int) vec.x);
                triangles.Add((int) vec.y);
                triangles.Add((int) vec.z);
            }

            return triangles;
        }
    }
}