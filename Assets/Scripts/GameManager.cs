using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public GameObject Cube;
    const int cCount = 1000;
    EntityManager mEntityManager;

    static public int sCubeCount { private set; get; }

    void Start()
    {
        mEntityManager = World.Active.GetOrCreateManager<EntityManager>();
        AddCube(cCount);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddCube(cCount);
        }
    }

    void AddCube(int count)
    {
        var entities = new NativeArray<Entity>(count, Allocator.Temp);
        mEntityManager.Instantiate(Cube, entities);

        for (int i = 0; i < count; i++)
        {
            var x = Random.Range(-100, 100);
            var z = Random.Range(0, 450F);
            var s = Random.Range(1F, 100F);
            mEntityManager.SetComponentData(entities[i], new Rotation() { Value = quaternion.identity });
            mEntityManager.SetComponentData(entities[i], new Position() { Value = new float3(x, 0, z) });
            mEntityManager.SetComponentData(entities[i], new RotationSpeed() { Value = s });
        }

        entities.Dispose();

        sCubeCount += count;
    }
}
