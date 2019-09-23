using System;

struct Vec2f
{
    /// <summary>
    /// The x coordinate of the vector
    /// </summary>
	public float x;

    /// <summary>
    /// The y coordinate of the vector
    /// </summary>
	public float y;

    /// <summary>
    /// Decides which value in the struct it returns as if an array of 2 floats
    /// </summary>
    /// <param name="i">index of the "array" to return</param>
    /// <returns>Either the x or y coordinate depending on what is passed in</returns>
	public float this [int i] {
		get {
			if (i == 0) return x;
			if (i == 1) return y;
			throw new InvalidOperationException ();
		}
		set {
			if (i == 0) x = value;
			else if (i == 1) y = value;
			else throw new InvalidOperationException ();
		}
	}

    /// <summary>
    /// Divides the vector by its magnitude to bring the magnitude to 1 but keep direction
    /// </summary>
    /// <returns>The vector as a unit vector</returns>
	public Vec2f Normalize ()
	{
		return this / Norm ();
	}

    /// <summary>
    /// Finds the magnitude of the coordinates
    /// </summary>
    /// <returns>Magnitude as a float</returns>
	public float Norm ()
	{
		return (float)Math.Sqrt (x * x + y * y);
	}

    /// <summary>
    /// Divides both elements in the vector when division is used for this struct
    /// </summary>
    /// <param name="v">The vector being divided</param>
    /// <param name="num">Number dividing by</param>
    /// <returns>Returns divided vector</returns>
	public static Vec2f operator / (Vec2f v, float num)
	{
		v.x /= num;
		v.y /= num;

		return v;
	}

    /// <summary>
    /// Multiplies both elements in the vector when multiplication is used for this struct
    /// </summary>
    /// <param name="v">The vector being multiplied</param>
    /// <param name="num">The number we're multiplying by</param>
    /// <returns>Multiplied vector</returns>
	public static Vec2f operator * (Vec2f v, float num)
	{
		v.x *= num;
		v.y *= num;

		return v;
	}

    /// <summary>
    /// Subtracts a vector from another vector
    /// </summary>
    /// <param name="a">The vector to subtract from</param>
    /// <param name="b">The vector amount being subtracted</param>
    /// <returns>The single vector having been subtracted</returns>
	public static Vec2f operator - (Vec2f a, Vec2f b)
	{
		return new Vec2f { x = a.x - b.x, y = a.y - b.y };
	}

    /// <summary>
    /// Adds a vector to another vector
    /// </summary>
    /// <param name="a">The vector to add to</param>
    /// <param name="b">The vector being added</param>
    /// <returns>The sum of the 2 vectors</returns>
	public static Vec2f operator + (Vec2f a, Vec2f b)
	{
		return new Vec2f { x = a.x + b.x, y = a.y + b.y };
	}
}

public struct Vec3f
{
    /// <summary>
    /// x coordinate of the vector
    /// </summary>
	public float x;

    /// <summary>
    /// Y coordinate of the vector
    /// </summary>
	public float y;

    /// <summary>
    /// Z coordinate of the vector
    /// </summary>
	public float z;

    /// <summary>
    /// Decides which value in the struct it returns as if an array of 3 floats
    /// </summary>
    /// <param name="i">index of the "array" to return</param>
    /// <returns>Either the x or y or z coordinate depending on what is passed in</returns>
	public float this [int i] {
		get {
			switch (i) {
			case 0: return x;
			case 1: return y;
			case 2: return z;
			default: throw new InvalidOperationException ();
			}
		}
		set {
			switch (i) {
			case 0: x = value; break;
			case 1: y = value; break;
			case 2: z = value; break;
			default: throw new InvalidOperationException ();
			}
		}
	}

    /// <summary>
    /// Divides the vector by its magnitude to bring the magnitude to 1 but keep direction
    /// </summary>
    /// <returns>The vector as a unit vector</returns>
    public Vec3f Normalize ()
	{
		return this / Norm ();
	}

    /// <summary>
    /// Finds the magnitude of the coordinates
    /// </summary>
    /// <returns>Magnitude as a float</returns>
    public float Norm ()
	{
		return (float)Math.Sqrt (x * x + y * y + z * z);
	}

    /// <summary>
    /// subtracts one vector from another
    /// </summary>
    /// <param name="a">The vector to subtract from</param>
    /// <param name="b">The vector subtraction amount</param>
    /// <returns>The difference of the 2 vectors</returns>
	public static Vec3f operator - (Vec3f a, Vec3f b)
	{
		return new Vec3f { x = a.x - b.x, y = a.y - b.y, z = a.z - b.z };
	}

    /// <summary>
    /// Divides one vector by a float amount
    /// </summary>
    /// <param name="v">The vector being divided from</param>
    /// <param name="num">The amount to divide by</param>
    /// <returns>The quotient</returns>
	public static Vec3f operator / (Vec3f v, float num)
	{
		v.x /= num;
		v.y /= num;
		v.z /= num;

		return v;
	}

    /// <summary>
    /// Multiplies one vector by a float amount
    /// </summary>
    /// <param name="v">The vector to multiply</param>
    /// <param name="num">The amount to multiply by</param>
    /// <returns>The result of the multiplication as vector3</returns>
	public static Vec3f operator * (Vec3f v, float num)
	{
		v.x *= num;
		v.y *= num;
		v.z *= num;

		return v;
	}
}

struct Vec4f
{
    /// <summary>
    /// The x coordinate of the vector
    /// </summary>
	public float x;

    /// <summary>
    /// The y coordinate of the vector
    /// </summary>
	public float y;

    /// <summary>
    /// The z coordinate of the vector
    /// </summary>
	public float z;

    /// <summary>
    /// The h coordinate of the vector
    /// </summary>
	public float h;

    /// <summary>
    /// Decides which value in the struct it returns as if an array of 4 floats
    /// </summary>
    /// <param name="i">index of the "array" to return</param>
    /// <returns>Either the x or y or z or h coordinate depending on what is passed in</returns>
    public float this [int i] {
		get {
			switch (i) {
				case 0: return x;
				case 1: return y;
				case 2: return z;
				case 3: return h;
				default: throw new InvalidOperationException ();
			}
		}
		set {
			switch (i) {
				case 0: x = value; break;
				case 1: y = value; break;
				case 2: z = value; break;
				case 3: h = value; break;
				default: throw new InvalidOperationException ();
			}
		}
	}

    /// <summary>
    /// Divides the vector by its magnitude to bring the magnitude to 1 but keep direction
    /// </summary>
    /// <returns>The vector as a unit vector</returns>
	public Vec4f Normalize ()
	{
		var len = Norm ();
		return this / len;
	}

    /// <summary>
    /// Finds the magnitude of the coordinates
    /// </summary>
    /// <returns>Magnitude as a float</returns>
    public float Norm ()
	{
		return (float)Math.Sqrt (x * x + y * y + z * z + h * h);
	}

    /// <summary>
    /// Subtracts a vector by another vector
    /// </summary>
    /// <param name="a">The vector being subtracted from</param>
    /// <param name="b">The vector amount to subtract</param>
    /// <returns>The difference as vector</returns>
	public static Vec4f operator - (Vec4f a, Vec4f b)
	{
		return new Vec4f { x = a.x - b.x, y = a.y - b.y, z = a.z - b.z, h = a.h - b.h };
	}

    /// <summary>
    /// Divides a vector by a float amount
    /// </summary>
    /// <param name="v">The vector being divided by</param>
    /// <param name="num">The amount to divide by as float</param>
    /// <returns>The quotient vector</returns>
	public static Vec4f operator / (Vec4f v, float num)
	{
		v.x /= num;
		v.y /= num;
		v.z /= num;
		v.h /= num;

		return v;
	}
}

struct Vec2i
{
    /// <summary>
    /// The x coordinate as int
    /// </summary>
	public int x;

    /// <summary>
    /// The y coordinate as int
    /// </summary>
	public int y;

    /// <summary>
    /// Subtracts one int vector from another
    /// </summary>
    /// <param name="a">The int vector being subtracted from</param>
    /// <param name="b">The int vector amount to subtract</param>
    /// <returns>The difference as a vector of ints</returns>
	public static Vec2i operator - (Vec2i a, Vec2i b)
	{
		return new Vec2i { x = a.x - b.x, y = a.y - b.y };
	}
}

struct Vec3i
{
    /// <summary>
    /// The x coordinate as int
    /// </summary>
	public int x;

    /// <summary>
    /// The y coordinate as int
    /// </summary>
	public int y;

    /// <summary>
    /// The z coordinate as int
    /// </summary>
	public int z;

    /// <summary>
    /// Subtracts one int vector from another
    /// </summary>
    /// <param name="a">The int vector being subtracted from</param>
    /// <param name="b">The int vector amount to subtract</param>
    /// <returns>The difference as a vector of ints</returns>
	public static Vec3i operator - (Vec3i a, Vec3i b)
	{
		return new Vec3i { x = a.x - b.x, y = a.y - b.y, z = a.z - b.z };
	}
}

static class Geometry
{
   
	public static Vec3f Cross (Vec3f l, Vec3f r)
	{
		return new Vec3f {
			x = l.y * r.z - l.z * r.y,
			y = l.z * r.x - l.x * r.z,
			z = l.x * r.y - l.y * r.x
		};
	}
	public static float Dot (Vec3f l, Vec3f r)
	{
		return l.x * r.x + l.y * r.y + l.z * r.z;
	}

	public static Vec4f Embed4D (Vec3f v, float fill = 1)
	{
		return new Vec4f { x = v.x, y = v.y, z = v.z, h = fill };
	}

	public static Vec2f Project2D (Vec3f v)
	{
		return new Vec2f { x = v.x, y = v.y };
	}

	public static Vec2f Project2D (Vec4f v)
	{
		return new Vec2f { x = v.x, y = v.y };
	}

	public static Vec3f Project3D (Vec4f v)
	{
		return new Vec3f { x = v.x, y = v.y, z = v.z };
	}
}