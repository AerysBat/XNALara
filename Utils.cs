using Microsoft.Xna.Framework;

namespace XNALara
{
    class Utils
    {
        public static Vector3 GetTransformedBone(Armature.Bone bone, Matrix worldMatrix) {
            Matrix m = bone.absTransform * worldMatrix;
            return Vector3.Transform(Vector3.Zero, m);
        }

        public static void TransformVertex(
                                MeshDesc.Vertex vertex,
                                Matrix worldMatrix, Matrix[] boneMatrices, short[] boneIndexMap,
                                out Vector3 position, out Vector3 normal) {
            Matrix m =
                boneMatrices[boneIndexMap[vertex.boneIndicesLocal[0]]] * vertex.boneWeights[0] +
                boneMatrices[boneIndexMap[vertex.boneIndicesLocal[1]]] * vertex.boneWeights[1] +
                boneMatrices[boneIndexMap[vertex.boneIndicesLocal[2]]] * vertex.boneWeights[2] +
                boneMatrices[boneIndexMap[vertex.boneIndicesLocal[3]]] * vertex.boneWeights[3];
            m *= worldMatrix;
            position = Vector3.Transform(vertex.position, m);
            m.M41 = 0;
            m.M42 = 0;
            m.M43 = 0;
            normal = Vector3.Transform(vertex.normal, m);
        }
    }
}
