using System.Collections.Generic;

namespace XNALara
{
    public class ThorWireframeSplitter
    {
        public static void SplitThorWireframe(Model model) {
            MeshDesc meshDesc = model.GetMeshDesc("thorwireframe");
            if (meshDesc == null) {
                return;
            }
            model.RemoveMeshDesc(meshDesc.name);

            Dictionary<MeshDesc.Vertex, ushort> vertexMapBelt = new Dictionary<MeshDesc.Vertex, ushort>();
            Dictionary<MeshDesc.Vertex, ushort> vertexMapGauntletLeft = new Dictionary<MeshDesc.Vertex, ushort>();
            Dictionary<MeshDesc.Vertex, ushort> vertexMapGauntletRight = new Dictionary<MeshDesc.Vertex, ushort>();

            List<MeshDesc.Vertex> vertexListBelt = new List<MeshDesc.Vertex>();
            List<MeshDesc.Vertex> vertexListGauntletLeft = new List<MeshDesc.Vertex>();
            List<MeshDesc.Vertex> vertexListGauntletRight = new List<MeshDesc.Vertex>();

            List<ushort> indicesBelt = new List<ushort>();
            List<ushort> indicesGauntletLeft = new List<ushort>();
            List<ushort> indicesGauntletRight = new List<ushort>();

            for (int i = 0; i < meshDesc.indices.Length; i += 3) {
                ushort i1 = meshDesc.indices[i + 0];
                ushort i2 = meshDesc.indices[i + 1];
                ushort i3 = meshDesc.indices[i + 2];

                MeshDesc.Vertex v1 = meshDesc.vertices[i1];
                MeshDesc.Vertex v2 = meshDesc.vertices[i2];
                MeshDesc.Vertex v3 = meshDesc.vertices[i3];

                if (BelongsToThorBelt(v1) || BelongsToThorBelt(v2) || BelongsToThorBelt(v3)) {
                    RegisterVertex(v1, vertexMapBelt, vertexListBelt, indicesBelt);
                    RegisterVertex(v2, vertexMapBelt, vertexListBelt, indicesBelt);
                    RegisterVertex(v3, vertexMapBelt, vertexListBelt, indicesBelt);
                }
                if (BelongsToThorGauntletLeft(v1) || BelongsToThorGauntletLeft(v2) || BelongsToThorGauntletLeft(v3)) {
                    RegisterVertex(v1, vertexMapGauntletLeft, vertexListGauntletLeft, indicesGauntletLeft);
                    RegisterVertex(v2, vertexMapGauntletLeft, vertexListGauntletLeft, indicesGauntletLeft);
                    RegisterVertex(v3, vertexMapGauntletLeft, vertexListGauntletLeft, indicesGauntletLeft);
                }
                if (BelongsToThorGauntletRight(v1) || BelongsToThorGauntletRight(v2) || BelongsToThorGauntletRight(v3)) {
                    RegisterVertex(v1, vertexMapGauntletRight, vertexListGauntletRight, indicesGauntletRight);
                    RegisterVertex(v2, vertexMapGauntletRight, vertexListGauntletRight, indicesGauntletRight);
                    RegisterVertex(v3, vertexMapGauntletRight, vertexListGauntletRight, indicesGauntletRight);
                }
            }

            MeshDesc meshDescBelt = DeriveMeshDesc(meshDesc, "thorglowbelt", vertexListBelt.ToArray(), indicesBelt.ToArray());
            MeshDesc meshDescGauntletLeft = DeriveMeshDesc(meshDesc, "thorglowgauntletleft", vertexListGauntletLeft.ToArray(), indicesGauntletLeft.ToArray());
            MeshDesc meshDescGauntletRight = DeriveMeshDesc(meshDesc, "thorglowgauntletright", vertexListGauntletRight.ToArray(), indicesGauntletRight.ToArray());

            if (meshDescBelt.vertices.Length > 0) {
                model.AddMeshDesc(meshDescBelt);
            }
            if (meshDescGauntletLeft.vertices.Length > 0) {
                model.AddMeshDesc(meshDescGauntletLeft);
            }
            if (meshDescGauntletRight.vertices.Length > 0) {
                model.AddMeshDesc(meshDescGauntletRight);
            }
        }

        private static bool BelongsToThorBelt(MeshDesc.Vertex vertex) {
            return vertex.position.Y < 1.25;
        }

        private static bool BelongsToThorGauntletLeft(MeshDesc.Vertex vertex) {
            return vertex.position.Y > 1.25 && vertex.position.X > 0;
        }

        private static bool BelongsToThorGauntletRight(MeshDesc.Vertex vertex) {
            return vertex.position.Y > 1.25 && vertex.position.X < 0;
        }

        private static void RegisterVertex(MeshDesc.Vertex vertex,
                                           Dictionary<MeshDesc.Vertex, ushort> vertexMap, List<MeshDesc.Vertex> vertexList, List<ushort> indices) {
            ushort index;
            if (!vertexMap.TryGetValue(vertex, out index)) {
                index = (ushort)vertexList.Count;
                vertexMap[vertex] = index;
                vertexList.Add(vertex);
            }
            indices.Add(index);
        }

        private static MeshDesc DeriveMeshDesc(MeshDesc origMeshDesc, string newName, MeshDesc.Vertex[] newVertices, ushort[] newIndices) {
            MeshDesc newMeshDesc = new MeshDesc();
            newMeshDesc.name = newName;
            newMeshDesc.uvLayerCount = origMeshDesc.uvLayerCount;
            newMeshDesc.textures = origMeshDesc.textures;
            newMeshDesc.vertices = newVertices;
            newMeshDesc.indices = newIndices;
            newMeshDesc.boneIndexMap = origMeshDesc.boneIndexMap;
            newMeshDesc.renderParams = origMeshDesc.renderParams;
            newMeshDesc.isShadeless = origMeshDesc.isShadeless;
            return newMeshDesc;
        }
    }
}
