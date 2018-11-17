using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

[BurstCompile]
public class RotationSystem : JobComponentSystem
{
    [BurstCompile]
    struct Rotate : IJobProcessComponentData<Rotation, Position, RotationSpeed>
    {
        public float time;
        public void Execute(ref Rotation rotation, ref Position position, [ReadOnly]ref RotationSpeed speed)
        {
            var p1 = position.Value;
            position.Value = new float3(p1.x, time * speed.Value, p1.z);
            rotation.Value = quaternion.AxisAngle(new float3(0, 1, 0), time * speed.Value);
        }
    }

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var rotate = new Rotate()
        {
            time = Time.time
        };
        return rotate.Schedule(this, inputDeps);
    }
}
