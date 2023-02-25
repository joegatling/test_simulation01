using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.Collections;

[BurstCompile]
[UpdateInGroup(typeof(SimulationSystemGroup))]
public partial struct UpdateSystem : ISystem
{
    [BurstCompile]
    void OnUpdate(ref SystemState state)
    {
        float3 position; 

        foreach(var cell in SystemAPI.Query<CellAspect>())
        {
            // The following operation causes all the objects to be moved to the exact same position!
            position = cell.position;
            cell.position = position;
        }
    }
}