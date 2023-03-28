using Abstracts;
using System;

namespace Gameplay.Enemy.Movement
{
    public sealed class EnemyInput : IUnitMovementInput, IUnitTurningHandleInput
    {
        public event Action<float> VerticalAxisInput = _ => { };
        public event Action<float> HorizontalAxisInput = _ => { };

        public void Accelerate()
        {
            VerticalAxisInput(1);
        }
        
        public void Decelerate()
        {
            VerticalAxisInput(-1);
        }
        
        public void HoldSpeed()
        {
            VerticalAxisInput(0);
        }
        
        public void TurnRight(float value = 1.0f)
        {
            HorizontalAxisInput(Math.Abs(value));
        }
        
        public void TurnLeft(float value = 1.0f)
        {
            HorizontalAxisInput(-Math.Abs(value));
        }
        
        public void StopTurning()
        {
            HorizontalAxisInput(0);
        }
    }
}