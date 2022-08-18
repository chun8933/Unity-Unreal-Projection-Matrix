using UnityEngine;

namespace Unreal
{
    struct FMatrix
    {
        // Copy from Matrix4x4
        public float m00;
        public float m10;
        public float m20;
        public float m30;
        public float m01;
        public float m11;
        public float m21;
        public float m31;
        public float m02;
        public float m12;
        public float m22;
        public float m32;
        public float m03;
        public float m13;
        public float m23;
        public float m33;

        // Copy from Matrix4x4 and
        // Re-calculate the order if construct it by Vector4
        public FMatrix(Vector4 column0, Vector4 column1, Vector4 column2, Vector4 column3)
        {
            m00 = column0.x;
            m01 = column0.y;
            m02 = column0.z;
            m03 = column0.w;

            m10 = column1.x;
            m11 = column1.y;
            m12 = column1.z;
            m13 = column1.w;

            m20 = column2.x;
            m21 = column2.y;
            m22 = column2.z;
            m23 = column2.w;

            m30 = column3.x;
            m31 = column3.y;
            m32 = column3.z;
            m33 = column3.w;
        }

        // Copy from Matrix4x4
        public float this[int row, int column]
        {
            get { return this[row + column * 4]; }
            set { this[row + column * 4] = value; }
        }

        // Copy from Matrix4x4 and
        // Convert back from latest c# to older Unity C# library
        public float this[int index]
        {
            get
            {
                float result = -1;
                switch (index)
                {
                    case 0:
                        result = m00;
                        break;
                    case 1:
                        result = m10;
                        break;
                    case 2:
                        result = m20;
                        break;
                    case 3:
                        result = m30;
                        break;
                    case 4:
                        result = m01;
                        break;
                    case 5:
                        result = m11;
                        break;
                    case 6:
                        result = m21;
                        break;
                    case 7:
                        result = m31;
                        break;
                    case 8:
                        result = m02;
                        break;
                    case 9:
                        result = m12;
                        break;
                    case 10:
                        result = m22;
                        break;
                    case 11:
                        result = m32;
                        break;
                    case 12:
                        result = m03;
                        break;
                    case 13:
                        result = m13;
                        break;
                    case 14:
                        result = m23;
                        break;
                    case 15:
                        result = m33;
                        break;
                    default:
                        throw new System.Exception("Invalid matrix index!");
                }

                return result;
            }
            set
            {
                switch (index)
                {
                    case 0:
                        m00 = value;
                        break;
                    case 1:
                        m10 = value;
                        break;
                    case 2:
                        m20 = value;
                        break;
                    case 3:
                        m30 = value;
                        break;
                    case 4:
                        m01 = value;
                        break;
                    case 5:
                        m11 = value;
                        break;
                    case 6:
                        m21 = value;
                        break;
                    case 7:
                        m31 = value;
                        break;
                    case 8:
                        m02 = value;
                        break;
                    case 9:
                        m12 = value;
                        break;
                    case 10:
                        m22 = value;
                        break;
                    case 11:
                        m32 = value;
                        break;
                    case 12:
                        m03 = value;
                        break;
                    case 13:
                        m13 = value;
                        break;
                    case 14:
                        m23 = value;
                        break;
                    case 15:
                        m33 = value;
                        break;
                    default:
                        throw new System.Exception("Invalid matrix index!");
                }
            }
        }

        // Copy from Matrix4x4
        public override string ToString()
        {
            return string.Format(
                "{0:F5}\t{1:F5}\t{2:F5}\t{3:F5}\n{4:F5}\t{5:F5}\t{6:F5}\t{7:F5}\n{8:F5}\t{9:F5}\t{10:F5}\t{11:F5}\n{12:F5}\t{13:F5}\t{14:F5}\t{15:F5}\n",
                m00,
                m01,
                m02,
                m03,
                m10,
                m11,
                m12,
                m13,
                m20,
                m21,
                m22,
                m23,
                m30,
                m31,
                m32,
                m33
            );
        }

        // Form Unreal Matrix
        // The method = Unreal TReversedZPerspectiveMatrix
        public static FMatrix ReversedZPerspectiveMatrix(
            float x,
            float y,
            float u,
            float v,
            float n = 0,
            float f = 1,
            float e = 1
        )
        {
            return new FMatrix(
                new Vector4(x, 0, 0, 0),
                new Vector4(0, y, 0, 0),
                new Vector4(u, v, n, e),
                new Vector4(0, 0, f, 0)
            );
        }

        // Form Unreal Matrix
        // The method = Unreal TReversedZPerspectiveMatrix
        public static FMatrix ReversedZPerspectiveMatrix(float x, float y, float u, float v)
        {
            return ReversedZPerspectiveMatrix(x, y, u, v);
        }
    }
}
