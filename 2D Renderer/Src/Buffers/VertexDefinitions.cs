using System;
using OpenTK.Mathematics;

namespace BasicTK_2D_Renderer.Src.Buffers
{
    public readonly struct VertexAttribute(string name, int index, int componentCount, int offset)
    {
        public readonly string Name = name;
        public readonly int Index = index;
        public readonly int ComponentCount = componentCount;
        public readonly int Offset = offset;
    }

    public sealed class VertexInfo
    {
        public readonly Type Type;
        public readonly int SizeInBytes;
        public readonly VertexAttribute[] VertexAttributes;

        public VertexInfo(Type type, params VertexAttribute[] attributes)
        {
            Type = type;
            SizeInBytes = 0;

            VertexAttributes = attributes;

            foreach (var attribute in VertexAttributes)
            {
                SizeInBytes += attribute.ComponentCount * sizeof(float);
            }
        }
    }
    public readonly struct VertexPositionColor(Vector2 position, Color4 color)
    {
        public readonly Vector2 Position = position;
        public readonly Color4 Color = color;

        public static readonly VertexInfo VertexInfo = new VertexInfo(
            typeof(VertexPositionColor),
            new VertexAttribute("Position", 0, 2, 0),
            new VertexAttribute("Color", 1, 4, 2 * sizeof(float))
        );
    }

    public readonly struct VertexPositionTexture(Vector2 position, Vector2 texCoord)
    {
        public readonly Vector2 Position = position;
        public readonly Vector2 TexCoord = texCoord;

        public static readonly VertexInfo VertexInfo = new VertexInfo(
            typeof(VertexPositionTexture),
            new VertexAttribute("Position", 0, 2, 0),
            new VertexAttribute("TextCoord", 1, 2, 2 * sizeof(float))
        );
    }
}