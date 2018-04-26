using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XNALara
{
    public class CameraTurnTable
    {
        public delegate void CameraEventDelegate();

        private GraphicsDevice graphicsDevice;

        private float fovHorizontal;
        private float fovVertical;

        private float nearPlane;
        private float farPlane;

        private Vector3 position;
        private Vector3 target;

        private Vector3 forward;
        private Vector3 left;
        private Vector3 up;
        
        private float rotationHorizontal;
        private float rotationVertical;
        private float distance = 1.0f;

        private Matrix matrixProjection;
        private Matrix matrixView;

        public event CameraEventDelegate CameraEvent;


        public CameraTurnTable(GraphicsDevice graphicsDevice, GameWindow window) {
            this.graphicsDevice = graphicsDevice;
            window.ClientSizeChanged += new EventHandler(WindowClientSizeChanged);
            this.nearPlane = 0.1f;
            this.farPlane = 1000.0f;
            FieldOfViewHorizontal = MathHelper.ToRadians(60);
            if (CameraEvent != null) {
                CameraEvent();
            }
        }

        public float FieldOfViewHorizontal {
            get { return fovHorizontal; }
            set {
                fovHorizontal = value;
                float aspect = graphicsDevice.Viewport.AspectRatio;
                fovVertical = (float)(2 * Math.Atan(Math.Tan(fovHorizontal / 2) / aspect));
                UpdateProjectionMatrix();
                if (CameraEvent != null) {
                    CameraEvent();
                }
            }
        }

        public float FieldOfViewVertical {
            get { return fovVertical; }
            set {
                fovVertical = value;
                float aspect = graphicsDevice.Viewport.AspectRatio;
                fovHorizontal = (float)(2 * Math.Atan(Math.Tan(fovVertical / 2) * aspect));
                UpdateProjectionMatrix();
                if (CameraEvent != null) {
                    CameraEvent();
                }
            }
        }

        public void SetClippingPlanes(float nearPlane, float farPlane) {
            this.nearPlane = nearPlane;
            this.farPlane = farPlane;
            UpdateProjectionMatrix();
            if (CameraEvent != null) {
                CameraEvent();
            }
        }

        public float NearPlane {
            get { return nearPlane; }
        }

        public float FarPlane {
            get { return farPlane; }
        }

        public Matrix ProjectionMatrix {
            get { return matrixProjection; }
            set {
                matrixProjection = value;
                fovHorizontal = 0;
                fovVertical = 0;
            }
        }

        public Matrix ViewMatrix {
            get { return matrixView; }
        }

        public Vector3 Position {
            get { return position; }
        }

        public Vector3 Target {
            get { return target; }
            set {
                target = value;
                SetRotation(rotationHorizontal, rotationVertical);
                if (CameraEvent != null) {
                    CameraEvent();
                }
            }
        }

        public Vector3 Forward {
            get { return forward; }
        }

        public Vector3 Left {
            get { return left; }
        }

        public Vector3 Up {
            get { return up; }
        }

        public void SetRotation(float rotationHorizontal, float rotationVertical) {
            float MaxRotationVertical = MathHelper.PiOver2 - 1e-4f;
            if (rotationVertical < -MaxRotationVertical) {
                rotationVertical = -MaxRotationVertical;
            }
            if (rotationVertical > MaxRotationVertical) {
                rotationVertical = MaxRotationVertical;
            }
            this.rotationHorizontal = rotationHorizontal;
            this.rotationVertical = rotationVertical;
            Matrix matrix =
                Matrix.CreateRotationX(-rotationVertical) *
                Matrix.CreateRotationY(rotationHorizontal);
            forward = -Vector3.Transform(new Vector3(0, 0, distance), matrix);
            position = target - forward;
            left = Vector3.Cross(forward, Vector3.Up);
            left.Normalize();
            up = Vector3.Cross(left, forward);
            up.Normalize();
            UpdateViewMatrix();
            if (CameraEvent != null) {
                CameraEvent();
            }
        }

        public float RotationHorizontal {
            get { return rotationHorizontal; }
        }

        public float RotationVertical {
            get { return rotationVertical; }
        }

        public float Distance {
            get { return distance; }
            set { 
                distance = value;
                if (distance < 1e-4f) {
                    distance = 1e-4f;
                }
                SetRotation(rotationHorizontal, rotationVertical);
                if (CameraEvent != null) {
                    CameraEvent();
                }
            }
        }

        private void UpdateProjectionMatrix() {
            matrixProjection = Matrix.CreatePerspectiveFieldOfView(
                fovVertical, graphicsDevice.Viewport.AspectRatio,
                nearPlane, farPlane);
        }

        private void UpdateViewMatrix() {
            matrixView = Matrix.CreateLookAt(position, target, Vector3.Up);
        }

        private void WindowClientSizeChanged(object sender, EventArgs e) {
            FieldOfViewHorizontal = fovHorizontal;
        }

        public CameraTurnTableState CameraState {
            get {
                CameraTurnTableState state = new CameraTurnTableState();
                state.fovHorizontal = fovHorizontal;
                state.nearPlane = nearPlane;
                state.farPlane = farPlane;
                state.target = target;
                state.rotationHorizontal = rotationHorizontal;
                state.rotationVertical = rotationVertical;
                state.distance = distance;
                return state;
            }
            set {
                FieldOfViewHorizontal = value.fovHorizontal;
                SetClippingPlanes(value.nearPlane, value.farPlane);
                Target = value.target;
                SetRotation(value.rotationHorizontal, value.rotationVertical);
                Distance = value.distance;
            }
        }
    }
}
