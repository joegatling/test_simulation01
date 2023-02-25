using Unity.Entities;
using Unity.Mathematics;

public struct SimulationProperties : IComponentData
{
    public int cellCount;
    public float2 dimensions;
    public Entity cellPrefab;
}