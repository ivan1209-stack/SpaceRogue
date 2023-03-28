using System;

namespace Abstracts
{
    public interface IUnitMovementInput
    {
        public event Action<float> VerticalAxisInput;
    }
}