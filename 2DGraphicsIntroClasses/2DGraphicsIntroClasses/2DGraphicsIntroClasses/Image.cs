using System;
using System.IO;

class Image
{
    /// <summary>
    /// the actual bit array of the image
    /// </summary>
	internal byte [] buffer;

    /// <summary>
    /// Width of the image
    /// </summary>
	public int Width { get; }

    /// <summary>
    /// Height of the image
    /// </summary>
	public int Height { get; }

    /// <summary>
    /// Discribes whether image is grayscale, BGR, or BGRA
    /// </summary>
	public Format Format { get; }

    /// <summary>
    /// Gets how many bytes per row the image is based on the type and the width
    /// </summary>
	public int BytesPerRow {
		get {
			return Width * (int)Format;
		}
	}

    /// <summary>
    /// Sets image size and buffer
    /// </summary>
    /// <param name="width">width of the image</param>
    /// <param name="height">width of the image</param>
    /// <param name="format">Type of image. Grayscale, RGB, or RGBA</param>
	public Image (int width, int height, Format format)
	{
		Width = width;
		Height = height;
		Format = format;

		buffer = new byte [height * BytesPerRow];
	}

    /// <summary>
    /// Flips the image along the horizontal axis using the buffer array as a middleman
    /// </summary>
	public void VerticalFlip ()
	{
		var bpp = (int)Format;
		int bytesPerLine = Width * bpp;

		var half = Height >> 1;
		for (int l = 0; l < half; l++) {
			var l1 = l * bytesPerLine;
			var l2 = (Height - 1 - l) * bytesPerLine;

			for (int i = 0; i < bytesPerLine; i++) {
				byte pixel = buffer [l1 + i];
				buffer [l1 + i] = buffer [l2 + i];
				buffer [l2 + i] = pixel;
			}
		}
	}
    
    /// <summary>
    /// Turns each part of the buffer array back to 0
    /// </summary>
	public void Clear ()
	{
		for (int i = 0; i < buffer.Length; i++)
			buffer [i] = 0;
	}

    /// <summary>
    /// Get color of a coordinate on the image
    /// </summary>
    /// <param name="x">X coordinate of image. Can't be smaller than the width or 0</param>
    /// <param name="y">Y coordinate of the image. Can't be smaller than the height or 0</param>
    /// <returns></returns>
	public Color this [int x, int y] {
		get {
			if (x < 0 || x >= Width) throw new ArgumentException ("x");
			if (y < 0 || y >= Height) throw new ArgumentException ("y");

			var offset = GetOffset (x, y);
			var len = (int)Format;
			int value = 0;
			for (var ch = 0; ch < 4; ch++)
				value = (value << 8) | (ch < len ? buffer [offset++] : 0xFF);

			return new Color (value, Format);
		}
		set {
			if (x < 0 || x >= Width) return; //throw new ArgumentException ($"{nameof(x)}={x} {nameof(Width)}={Width}");
			if (y < 0 || y >= Height) return; // throw new ArgumentException ($"{nameof(y)}={y} {nameof(Height)}={Height}");

			var offset = GetOffset (x, y);
			var v = value.value;
			var len = (int)Format;
			for (int ch = 0; ch < len; ch++)                   // 0123
				buffer [offset++] = (byte)(v >> (3 - ch) * 8); // BGRA
		}
	}

    /// <summary>
    /// 
    /// </summary>
    /// <param name="x">X coordinate of the image</param>
    /// <param name="y">Y coordinate of the image</param>
    /// <returns></returns>
	int GetOffset (int x, int y)
	{
		return y * BytesPerRow + x * (int)Format;
	}

    /// <summary>
    /// Writes the image as a text file 
    /// </summary>
    /// <param name="path">The place the file is going to go</param>
    /// <param name="rle">Whether or not is being compressed</param>
    /// <returns></returns>
	public bool WriteToFile (string path, bool rle = true)
	{
		var bpp = (int)Format;
		using (var writer = new BinaryWriter (File.Create (path))) {
			var header = new TGAHeader {
				IdLength = 0, // The IDLength set to 0 indicates that there is no image identification field in the TGA file
				ColorMapType = 0, // a value of 0 indicates that no palette is included
				BitsPerPixel = (byte)(bpp * 8),
				Width = (short)Width,
				Height = (short)Height,
				DataTypeCode = DataTypeFor (bpp, rle),
				ImageDescriptor = (byte)(0x20 | (Format == Format.BGRA ? 8 : 0)) // top-left origin
			};
			WriteTo (writer, header);
			if (!rle)
				writer.Write (buffer);
			else
				UnloadRleData (writer);
		}
		return true;
	}

    /// <summary>
    /// Loads image from a file
    /// </summary>
    /// <param name="path">File to load it from</param>
    /// <returns></returns>
	public static Image Load (string path)
	{
		using (var reader = new BinaryReader (File.OpenRead (path))) {
			var header = ReadHeader (reader);

			var height = header.Height;
			var width = header.Width;
			var bytespp = header.BitsPerPixel >> 3;
			var format = (Format)bytespp;

			if (width <= 0 || height <= 0)
				throw new InvalidProgramException ($"bad image size: width={width} height={height}");
			if (format != Format.BGR && format != Format.BGRA && format != Format.GRAYSCALE)
				throw new InvalidProgramException ($"unknown format {format}");

			var img = new Image (width, height, format);

			switch (header.DataTypeCode) {
			case DataType.UncompressedTrueColorImage:
			case DataType.UncompressedBlackAndWhiteImage:
				reader.Read (img.buffer, 0, img.buffer.Length);
				break;
			case DataType.RleTrueColorImage:
			case DataType.RleBlackAndWhiteImage:
				img.LoadRleData (reader);
				break;
			default:
				throw new InvalidProgramException ($"unsupported image format {header.DataTypeCode}");
			}

			if ((header.ImageDescriptor & 0x20) == 0)
				img.VerticalFlip ();

			return img;
		}
	}

    /// <summary>
    /// Writes the header information
    /// </summary>
    /// <param name="writer">Writer to use to write</param>
    /// <param name="header">The header</param>
	static void WriteTo (BinaryWriter writer, TGAHeader header)
	{
		writer.Write (header.IdLength);
		writer.Write (header.ColorMapType);
		writer.Write ((byte)header.DataTypeCode);
		writer.Write (header.ColorMapOrigin);
		writer.Write (header.ColorMapLength);
		writer.Write (header.ColorMapDepth);
		writer.Write (header.OriginX);
		writer.Write (header.OriginY);
		writer.Write (header.Width);
		writer.Write (header.Height);
		writer.Write (header.BitsPerPixel);
		writer.Write (header.ImageDescriptor);
	}
    /// <summary>
    /// Reads header from a TGA file
    /// </summary>
    /// <param name="reader">Type of reader</param>
    /// <returns>Header</returns>
	static TGAHeader ReadHeader (BinaryReader reader)
	{
		var header = new TGAHeader {
			IdLength = reader.ReadByte (),
			ColorMapType = reader.ReadByte (),
			DataTypeCode = (DataType)reader.ReadByte (),
			ColorMapOrigin = reader.ReadInt16 (),
			ColorMapLength = reader.ReadInt16 (),
			ColorMapDepth = reader.ReadByte (),
			OriginX = reader.ReadInt16 (),
			OriginY = reader.ReadInt16 (),
			Width = reader.ReadInt16 (),
			Height = reader.ReadInt16 (),
			BitsPerPixel = reader.ReadByte (),
			ImageDescriptor = reader.ReadByte ()
		};
		return header;
	}

    /// <summary>
    /// takes compressed data and writes it into a less compressed version
    /// </summary>
    /// <param name="writer"></param>
    /// <returns>Bool is true if succeeds</returns>
	bool UnloadRleData (BinaryWriter writer)
	{
		const int max_chunk_length = 128;
		int npixels = Width * Height;
		int curpix = 0;
		var bpp = (int)Format;

		while (curpix < npixels) {
			int chunkstart = curpix * bpp;
			int curbyte = curpix * bpp;
			int run_length = 1;
			bool literal = true;
			while (curpix + run_length < npixels && run_length < max_chunk_length && curpix + run_length < curpix + Width) {
				bool succ_eq = true;
				for (int t = 0; succ_eq && t < bpp; t++)
					succ_eq = (buffer [curbyte + t] == buffer [curbyte + t + bpp]);
				curbyte += bpp;
				if (1 == run_length)
					literal = !succ_eq;
				if (literal && succ_eq) {
					run_length--;
					break;
				}
				if (!literal && !succ_eq)
					break;
				run_length++;
			}
			curpix += run_length;

			writer.Write ((byte)(literal ? run_length - 1 : 128 + (run_length - 1)));
			writer.Write (buffer, chunkstart, literal ? run_length * bpp : bpp);
		}
		return true;
	}


    /// <summary>
    /// Reads compressed data and outputs to the buffer
    /// </summary>
    /// <param name="reader">Thing that reads</param>
	void LoadRleData (BinaryReader reader)
	{
		var pixelcount = Width * Height;
		var currentpixel = 0;
		var currentbyte = 0;

		var bytespp = (int)Format;
		var color = new byte [4];

		do {
			var chunkheader = reader.ReadByte ();
			if (chunkheader < 128) {
				chunkheader++;
				for (int i = 0; i < chunkheader; i++) {
					for (int t = 0; t < bytespp; t++)
						buffer [currentbyte++] = reader.ReadByte ();
					currentpixel++;
					if (currentpixel > pixelcount)
						throw new InvalidProgramException ("Too many pixels read");
				}
			} else {
				chunkheader -= 127;
				reader.Read (color, 0, bytespp);
				for (int i = 0; i < chunkheader; i++) {
					for (int t = 0; t < bytespp; t++)
						buffer [currentbyte++] = color [t];
					currentpixel++;
					if (currentpixel > pixelcount)
						throw new InvalidProgramException ("Too many pixels read");
				}
			}
		} while (currentpixel < pixelcount);
	}

    /// <summary>
    /// Outputs appropriate image type based on format enum
    /// </summary>
    /// <param name="bpp">bits per pixel</param>
    /// <param name="rle"></param>
    /// <returns>Type of data</returns>
	static DataType DataTypeFor (int bpp, bool rle)
	{
		var format = (Format)bpp;
		if (format == Format.GRAYSCALE)
			return rle ? DataType.RleBlackAndWhiteImage : DataType.UncompressedBlackAndWhiteImage;
		return rle ? DataType.RleTrueColorImage : DataType.UncompressedTrueColorImage;
	}
}


