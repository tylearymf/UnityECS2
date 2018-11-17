using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using System.Reflection;
using System.ComponentModel;
using System;

[Serializable]
public struct RotationSpeed : IComponentData
{
    public float Value;
}

public class RotationSpeedComponent : ComponentDataWrapper<RotationSpeed> { }