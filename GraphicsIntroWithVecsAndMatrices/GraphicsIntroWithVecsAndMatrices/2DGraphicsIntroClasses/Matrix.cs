using System;


public struct Matrix2
{
    /// <summary>
    /// provides the length of the matrix
    /// </summary>
    public const int Len = 2;

    /// <summary>
    /// values for 0x0, 0x1, 1x0, and 1x1. "row x, column y".
    /// </summary>
    public float R0C0, R0C1;
    public float R1C0, R1C1;

    /// <summary>
    /// returns the value at a particular coordinate
    /// </summary>
    /// <param name="row">x value of matrix</param>
    /// <param name="column">y value of matrix</param>
    /// <returns></returns>
    public float this[int row, int column]
    {
        get
        {
            switch (row)
            {
                case 0:
                    switch (column)
                    {
                        case 0: return R0C0;
                        case 1: return R0C1;
                    }
                    break;

                case 1:
                    switch (column)
                    {
                        case 0: return R1C0;
                        case 1: return R1C1;
                    }
                    break;
            }

            throw new IndexOutOfRangeException();
        }
        set
        {
            switch (row)
            {
                case 0:
                    switch (column)
                    {
                        case 0: R0C0 = value; return;
                        case 1: R0C1 = value; return;
                    }
                    break;

                case 1:
                    switch (column)
                    {
                        case 0: R1C0 = value; return;
                        case 1: R1C1 = value; return;
                    }
                    break;
            }

            throw new IndexOutOfRangeException();
        }
    }
}

public struct Matrix3
{
    /// <summary>
    /// returns the length of the array
    /// </summary>
    public const int Len = 3;

    /// <summary>
    /// holds values for the matrix
    /// </summary>
    public float R0C0, R0C1, R0C2;
    public float R1C0, R1C1, R1C2;
    public float R2C0, R2C1, R2C2;

    /// <summary>
    /// returns the value at a particular coordinate
    /// </summary>
    /// <param name="row">x value of matrix</param>
    /// <param name="column">y value of matrix</param>
    /// <returns></returns>
    public float this[int row, int column]
    {
        get
        {
            switch (row)
            {
                case 0:
                    switch (column)
                    {
                        case 0: return R0C0;
                        case 1: return R0C1;
                        case 2: return R0C2;
                    }
                    break;

                case 1:
                    switch (column)
                    {
                        case 0: return R1C0;
                        case 1: return R1C1;
                        case 2: return R1C2;
                    }
                    break;

                case 2:
                    switch (column)
                    {
                        case 0: return R2C0;
                        case 1: return R2C1;
                        case 2: return R2C2;
                    }
                    break;
            }

            throw new IndexOutOfRangeException();
        }
        set
        {
            switch (row)
            {
                case 0:
                    switch (column)
                    {
                        case 0: R0C0 = value; return;
                        case 1: R0C1 = value; return;
                        case 2: R0C2 = value; return;
                    }
                    break;

                case 1:
                    switch (column)
                    {
                        case 0: R1C0 = value; return;
                        case 1: R1C1 = value; return;
                        case 2: R1C2 = value; return;
                    }
                    break;

                case 2:
                    switch (column)
                    {
                        case 0: R2C0 = value; return;
                        case 1: R2C1 = value; return;
                        case 2: R2C2 = value; return;
                    }
                    break;
            }

            throw new IndexOutOfRangeException();
        }
    }
    /// <summary>
    /// flips a matrix
    /// </summary>
    /// <returns></returns>
    public Matrix3 Transpose()
    {
        return new Matrix3
        {
            R0C0 = R0C0,
            R0C1 = R1C0,
            R0C2 = R2C0,
            R1C0 = R0C1,
            R1C1 = R1C1,
            R1C2 = R2C1,
            R2C0 = R0C2,
            R2C1 = R1C2,
            R2C2 = R2C2
        };
    }
    /// <summary>
    /// sets all values in a column to a set of values
    /// </summary>
    /// <param name="col">column to be modified</param>
    /// <param name="v">new data to replace old data</param>
    public void SetColumn(int col, Vec3f v)
    {
        this[0, col] = v.x;
        this[1, col] = v.y;
        this[2, col] = v.z;
    }

    /// <summary>
    /// sets all values in a row to a set of values
    /// </summary>
    /// <param name="row">row to be modified</param>
    /// <param name="v">new data to replace old data</param>
    public void SetRow(int row, Vec3f v)
    {
        this[row, 0] = v.x;
        this[row, 1] = v.y;
        this[row, 2] = v.z;
    }
    /// <summary>
    /// prints the matrix as a string, creating a new line for every row.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        var sb = new System.Text.StringBuilder();
        for (int r = 0; r < Len; r++)
        {
            for (int c = 0; c < Len; c++)
                sb.Append(this[r, c]).Append(" ");
            sb.AppendLine();
        }
        return sb.ToString();
    }
}

public struct Matrix4
{
    /// <summary>
    /// the length of the matrix
    /// </summary>
    public const int Len = 4;

    /// <summary>
    /// values for the coordinate system
    /// </summary>
    public float R0C0, R0C1, R0C2, R0C3;
    public float R1C0, R1C1, R1C2, R1C3;
    public float R2C0, R2C1, R2C2, R2C3;
    public float R3C0, R3C1, R3C2, R3C3;

    /// <summary>
    /// returns a data as if it were in a coordinate/array system
    /// </summary>
    /// <param name="row">x value coordinate</param>
    /// <param name="column">y value coordinate</param>
    /// <returns></returns>
    public float this[int row, int column]
    {
        get
        {
            switch (row)
            {
                case 0:
                    switch (column)
                    {
                        case 0: return R0C0;
                        case 1: return R0C1;
                        case 2: return R0C2;
                        case 3: return R0C3;
                    }
                    break;

                case 1:
                    switch (column)
                    {
                        case 0: return R1C0;
                        case 1: return R1C1;
                        case 2: return R1C2;
                        case 3: return R1C3;
                    }
                    break;

                case 2:
                    switch (column)
                    {
                        case 0: return R2C0;
                        case 1: return R2C1;
                        case 2: return R2C2;
                        case 3: return R2C3;
                    }
                    break;

                case 3:
                    switch (column)
                    {
                        case 0: return R3C0;
                        case 1: return R3C1;
                        case 2: return R3C2;
                        case 3: return R3C3;
                    }
                    break;
            }

            throw new IndexOutOfRangeException();
        }
        set
        {
            switch (row)
            {
                case 0:
                    switch (column)
                    {
                        case 0: R0C0 = value; return;
                        case 1: R0C1 = value; return;
                        case 2: R0C2 = value; return;
                        case 3: R0C3 = value; return;
                    }
                    break;

                case 1:
                    switch (column)
                    {
                        case 0: R1C0 = value; return;
                        case 1: R1C1 = value; return;
                        case 2: R1C2 = value; return;
                        case 3: R1C3 = value; return;
                    }
                    break;

                case 2:
                    switch (column)
                    {
                        case 0: R2C0 = value; return;
                        case 1: R2C1 = value; return;
                        case 2: R2C2 = value; return;
                        case 3: R2C3 = value; return;
                    }
                    break;

                case 3:
                    switch (column)
                    {
                        case 0: R3C0 = value; return;
                        case 1: R3C1 = value; return;
                        case 2: R3C2 = value; return;
                        case 3: R3C3 = value; return;
                    }
                    break;
            }

            throw new IndexOutOfRangeException();
        }
    }
    /// <summary>
    /// flips the matrix
    /// </summary>
    /// <returns></returns>
    public Matrix4 Transpose()
    {
        return new Matrix4
        {
            R0C0 = R0C0,
            R0C1 = R1C0,
            R0C2 = R2C0,
            R0C3 = R3C0,
            R1C0 = R0C1,
            R1C1 = R1C1,
            R1C2 = R2C1,
            R1C3 = R3C1,
            R2C0 = R0C2,
            R2C1 = R1C2,
            R2C2 = R2C2,
            R2C3 = R3C2,
            R3C0 = R0C3,
            R3C1 = R1C3,
            R3C2 = R2C3,
            R3C3 = R3C3
        };
    }

    /// <summary>
    /// sets all diagonal values (where x == y) to 1.
    /// </summary>
    /// <returns></returns>
    public static Matrix4 Identity()
    {
        return new Matrix4 { R0C0 = 1, R1C1 = 1, R2C2 = 1, R3C3 = 1 };
    }
    // sets diagonal values (where x == y) to float "scale".
    public static Matrix4 Zoom(float scale)
    {
        return new Matrix4 { R0C0 = scale, R1C1 = scale, R2C2 = scale, R3C3 = scale };
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="angle"></param>
    /// <returns></returns>
    public static Matrix4 RotationZ(float angle)
    {
        var cosangle = (float)Math.Cos(angle);
        var sinangle = (float)Math.Sin(angle);

        var R = Identity();
        R[0, 0] = R[1, 1] = cosangle;
        R[0, 1] = -sinangle;
        R[1, 0] = sinangle;

        return R;
    }


    public static Matrix4 operator *(Matrix4 l, Matrix4 r)
    {
        var result = new Matrix4();
        for (int i = 0; i < Len; i++)
        {
            for (int j = 0; j < Len; j++)
            {
                result[i, j] = 0;
                for (int k = 0; k < Len; k++)
                {
                    result[i, j] += l[i, k] * r[k, j];
                }
            }
        }
        return result;
    }

    public override string ToString()
    {
        var sb = new System.Text.StringBuilder();
        for (int r = 0; r < Len; r++)
        {
            for (int c = 0; c < Len; c++)
                sb.Append(this[r, c]).Append(" ");
            sb.AppendLine();
        }
        return sb.ToString();
    }
}



// we don't want to declare them in Matrix because we don't need them in lesson which introduces Matrix class
static class MatrixHelpers
{
    // For Matrix4
    // how to calc inverse Matrix https://en.wikipedia.org/w/index.php?title=Invertible_matrix&section=4#In_relation_to_its_adjugate
    public static Matrix4 TransposeInverse(Matrix4 m)
    {
        // returns Transpose(Inverse(m))
        // where Inverse(m) = Transpose(cofactor) / det(m)
        // Transpose(Inverse(m)) = Transpose(Transpose(cofactor) / det(m)) = cofactor / det(m)

        var cofactor = Cofactor(m);

        float det = 0;
        for (int i = 0; i < Matrix4.Len; i++)
            det += m[0, i] * cofactor[0, i];

        for (int r = 0; r < Matrix4.Len; r++)
        {
            for (int c = 0; c < Matrix4.Len; c++)
                cofactor[r, c] /= det;
        }

        return cofactor;
    }

    public static Matrix4 Inverse(Matrix4 m)
    {
        // where Inverse(m) = Transpose(Cofactor(m)) / det(m)
        var cofactor = Cofactor(m);

        int len = Matrix4.Len;
        float det = 0;
        for (int i = 0; i < len; i++)
            det += m[0, i] * cofactor[0, i];

        cofactor = cofactor.Transpose();

        for (int r = 0; r < len; r++)
        {
            for (int c = 0; c < len; c++)
                cofactor[r, c] /= det;
        }

        return cofactor;
    }

    public static Matrix3 Inverse(Matrix3 m)
    {
        // where Inverse(m) = Transpose(Cofactor(m)) / det(m)
        var cofactor = Cofactor(m);

        int len = Matrix3.Len;
        float det = 0;
        for (int i = 0; i < len; i++)
            det += m[0, i] * cofactor[0, i];

        cofactor = cofactor.Transpose();

        for (int r = 0; r < len; r++)
        {
            for (int c = 0; c < len; c++)
                cofactor[r, c] /= det;
        }

        return cofactor;
    }

    static Matrix4 Cofactor(Matrix4 m)
    {
        var r = new Matrix4();
        for (int row = 0; row < Matrix4.Len; row++)
        {
            for (int col = 0; col < Matrix4.Len; col++)
                r[row, col] = Cofactor(m, row, col);
        }
        return r;
    }

    static Matrix3 Cofactor(Matrix3 m)
    {
        var r = new Matrix3();
        for (int row = 0; row < Matrix3.Len; row++)
        {
            for (int col = 0; col < Matrix3.Len; col++)
                r[row, col] = Cofactor(m, row, col);
        }
        return r;
    }

    static float Cofactor(Matrix4 m, int row, int col)
    {
        int sign = ((row + col) % 2 == 0) ? 1 : -1;
        return Det(Minor(m, row, col)) * sign;
    }

    static float Cofactor(Matrix3 m, int row, int col)
    {
        int sign = ((row + col) % 2 == 0) ? 1 : -1;
        return Det(Minor(m, row, col)) * sign;
    }

    static Matrix3 Minor(Matrix4 m, int row, int col)
    {
        var minor = new Matrix3();
        for (int r = 0; r < Matrix3.Len; r++)
        {
            for (int c = 0; c < Matrix3.Len; c++)
            {
                int y = (r < row) ? r : r + 1;
                int x = (c < col) ? c : c + 1;
                minor[r, c] = m[y, x];
            }
        }
        return minor;
    }

    static Matrix2 Minor(Matrix3 m, int row, int col)
    {
        var minor = new Matrix2();
        for (int r = 0; r < Matrix2.Len; r++)
        {
            for (int c = 0; c < Matrix2.Len; c++)
            {
                int y = (r < row) ? r : r + 1;
                int x = (c < col) ? c : c + 1;
                minor[r, c] = m[y, x];
            }
        }
        return minor;
    }

    static float Det(Matrix3 m)
    {
        float det = 0;
        det += m[0, 0] * (m[1, 1] * m[2, 2] - m[1, 2] * m[2, 1]);
        det -= m[0, 1] * (m[1, 0] * m[2, 2] - m[1, 2] * m[2, 0]);
        det += m[0, 2] * (m[1, 0] * m[2, 1] - m[1, 1] * m[2, 0]);
        return det;
    }

    static float Det(Matrix2 m)
    {
        return m[0, 0] * m[1, 1] - m[0, 1] * m[1, 0];
    }

    public static Vec3f Mult(Matrix3 m, Vec3f v)
    {
        return new Vec3f
        {
            x = m.R0C0 * v.x + m.R0C1 * v.y + m.R0C2 * v.z,
            y = m.R1C0 * v.x + m.R1C1 * v.y + m.R1C2 * v.z,
            z = m.R2C0 * v.x + m.R2C1 * v.y + m.R2C2 * v.z
        };
    }

    public static Vec4f Mult(Matrix4 m, Vec4f v)
    {
        return new Vec4f
        {
            x = m.R0C0 * v.x + m.R0C1 * v.y + m.R0C2 * v.z + m.R0C3 * v.h,
            y = m.R1C0 * v.x + m.R1C1 * v.y + m.R1C2 * v.z + m.R1C3 * v.h,
            z = m.R2C0 * v.x + m.R2C1 * v.y + m.R2C2 * v.z + m.R2C3 * v.h,
            h = m.R3C0 * v.x + m.R3C1 * v.y + m.R3C2 * v.z + m.R3C3 * v.h
        };
    }
}