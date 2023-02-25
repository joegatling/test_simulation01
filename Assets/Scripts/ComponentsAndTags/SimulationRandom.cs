using Unity.Entities;
using Unity.Mathematics;
public struct SimulationRandom : IComponentData
{
    public Unity.Mathematics.Random value;
}