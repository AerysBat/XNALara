using Microsoft.Xna.Framework;

namespace XNALara
{
    class BasisTransformMatrix
    {
        // generates a basis transformation matrix 4x4, from coord system #1 to coord system #2
        // assumes all input vectors to be unit vectors
        public static Matrix GenerateMatrix(Vector3 axisX1, Vector3 axisY1, Vector3 axisZ1,
                                            Vector3 axisX2, Vector3 axisY2, Vector3 axisZ2) {
            Matrix m1;
            m1.M11 = axisX1.X;
            m1.M21 = axisY1.X;
            m1.M31 = axisZ1.X;
            m1.M41 = 0;
            m1.M12 = axisX1.Y;
            m1.M22 = axisY1.Y;
            m1.M32 = axisZ1.Y;
            m1.M42 = 0;
            m1.M13 = axisX1.Z;
            m1.M23 = axisY1.Z;
            m1.M33 = axisZ1.Z;
            m1.M43 = 0;
            m1.M14 = 0;
            m1.M24 = 0;
            m1.M34 = 0;
            m1.M44 = 1;

            Matrix m2;
            m2.M11 = axisX2.X;
            m2.M21 = axisY2.X;
            m2.M31 = axisZ2.X;
            m2.M41 = 0;
            m2.M12 = axisX2.Y;
            m2.M22 = axisY2.Y;
            m2.M32 = axisZ2.Y;
            m2.M42 = 0;
            m2.M13 = axisX2.Z;
            m2.M23 = axisY2.Z;
            m2.M33 = axisZ2.Z;
            m2.M43 = 0;
            m2.M14 = 0;
            m2.M24 = 0;
            m2.M34 = 0;
            m2.M44 = 1;

            return Matrix.Invert(m1) * m2;
        }
    }
}
