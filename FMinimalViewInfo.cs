using UnityEngine;

namespace Unreal
{
    struct FMinimalViewInfo
    {
        // For convertion use
        public Matrix4x4 ProjectionMatrix;

        // Currently, No implementation yet, as dont what to do...
        public Vector3 Location;

        // Currently, No implementation yet, as dont what to do...
        public Vector3 Rotation;

        // Lens shift XY, in viewport unit
        // x = width, y = height
        public Vector2 OffCenterProjectionOffset;

        // Screen Width
        // Get or auto calculate
        private float? _width;
        private float Width
        {
            get { return _width ?? (float)Screen.width; }
            set { _width = value; }
        }

        // Screen Height
        // Get or auto calculate
        private float? _height;
        private float Height
        {
            get { return _height ?? (float)Screen.height; }
            set { _height = value; }
        }

        // Screen Aspect Ratio
        // Set or auto calculate
        private float? _aspect;
        public float AspectRatio
        {
            get { return _aspect ?? Width / Height; }
            set
            {
                _aspect = value;
                Height = Width / value;
                Width = Height * value;
            }
        }

        // Camera FOV
        // Set, with min 1 and max 180
        // Algo will /2 to get Half FOV and convert to PI for later calculation
        private float? _fov;
        public float FOV
        {
            get { return _fov ?? 1; }
            set { _fov = Mathf.Min(value, 180.0f); }
        }

        // Camera Near clipping plane
        // Default is 1, Unreal has it own algo to control it
        private float? _near;
        public float Near
        {
            private get { return _near ?? 1; }
            set { _near = value; }
        }

        // Camera Far clipping plane
        // Default is 1, Unreal has it own algo to control it
        private float? _far;
        public float Far
        {
            private get { return _far ?? 1; }
            set { _far = value; }
        }

        // Get Projection Matrix from Unity to Unreal
        // Default Near = 0, Far = 1, e = 1
        // Usually use the this method to get the matrix
        // See FMatrix.cs ZReversedProjectionMatrix()
        public FMatrix covert_from_projection_matrix()
        {
            float x = 1.0f / ProjectionMatrix[1, 1];
            float y = ProjectionMatrix[0, 0];
            float u = -ProjectionMatrix[0, 2];
            float v = -ProjectionMatrix[1, 2];

            return FMatrix.ReversedZPerspectiveMatrix(x, y, u, v);
        }

        // Algo from Unreal TReversedZProjectionMatrix
        // To implement its function only, use covert in normal case
        // OffCenterProjectionOffset is tested from Unreal nDisplay
        // See FMatrix.cs ZReversedProjectionMatrix()
        public FMatrix calculate_projection_matrix()
        {
            float halfFOV = Mathf.Tan(FOV * Mathf.PI / 360.0f);
            float x = 1.0f / halfFOV;
            float y = Width / halfFOV / Height;
            float u = -OffCenterProjectionOffset.x;
            float v = -OffCenterProjectionOffset.y;
            float n = (Near == Far) ? 0 : Near / (Near - Far);
            float f = (Near == Far) ? Near : -Far * Near / (Near - Far);
            float e = 1;

            return FMatrix.ReversedZPerspectiveMatrix(x, y, u, v, n, f, e);
        }

        // Override method
        public override string ToString()
        {
            string value =
                $"Location:{Location.ToString()}\nRotation:{Rotation.ToString()}\nFOV:{FOV}\nAspect Ratio:{AspectRatio}\nNear:{Near}\nFar:{Far}";
            return value;
        }
    }
}
