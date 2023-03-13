using Abstracts;
using System;
using UnityEngine;

[Serializable]
public class DamageConfig
{
    [field: SerializeField, Min(0.1f)] public float DamageAmount {  get; private set; }
    [field: SerializeField] public UnitType UnitType { get; private set; }
}
