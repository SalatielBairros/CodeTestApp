namespace CodeTestApp.Pratices.Bridge
{
  public interface IRenderer
  {
    string WhatToRenderAs { get; }
  }

  public abstract class Shape
  {
    protected abstract string Name { get; }
    private readonly string type;

    protected Shape(IRenderer renderer)
    {
      type = renderer.WhatToRenderAs;
    }

    public override string ToString() => $"Drawing {Name} as {type}";
  }

  public class Triangle : Shape
  {
    public Triangle(IRenderer renderer) : base(renderer)
    {
    }

    protected override string Name => "Triangle";
  }

  public class Square : Shape
  {
    public Square(IRenderer renderer) : base(renderer)
    {
    }

    protected override string Name => "Square";
  }

  public class VectorRenderer : IRenderer
  {
    public string WhatToRenderAs => "lines";
  }

  public class RasterRenderer : IRenderer
  {
    public string WhatToRenderAs => "pixels";
  }
}
