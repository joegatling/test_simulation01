using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class SimulationMono : MonoBehaviour
{
    public int cellCount = 100;
    public float2 dimensions = new float2(20,20);
    public GameObject cellPrefab = default;

    public uint seed;
}

public class SimulatioBaker : Baker<SimulationMono>
{
    public override void Bake(SimulationMono authoring)
    {
        AddComponent(new SimulationProperties
        {
            cellCount = authoring.cellCount,
            cellPrefab = GetEntity(authoring.cellPrefab),
            dimensions = authoring.dimensions
        });

        AddComponent(new SimulationRandom
        {
            value = Unity.Mathematics.Random.CreateFromIndex(authoring.seed)
        });
    }
}