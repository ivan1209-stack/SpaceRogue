using System;
using UnityEngine;

namespace Abstracts
{
    public interface IUnitTurningInput
    {
    }

    public interface IUnitTurningHandleInput : IUnitTurningInput
    {
        public event Action<float> HorizontalAxisInput;
    }

    public interface IUnitTurningMouseInput : IUnitTurningInput
    {
        public event Action<Vector3> MousePositionInput;
    }
}