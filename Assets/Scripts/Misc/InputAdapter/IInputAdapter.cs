using System;

namespace Services.InputAdapter
{
    public interface IInputAdapter
    {
        float Horizontal { get; }
        float Vertical { get; }
        bool Fire { get; }
    }
}