using Unity.Entities;
using Unity.Mathematics;

public struct CellProperties : IComponentData
{
    public float detectionRadius;
    public float3 velocity;
}