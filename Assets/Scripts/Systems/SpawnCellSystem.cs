using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

[BurstCompile]
[UpdateInGroup(typeof(InitializationSystemGroup))]
public partial struct SpawnCellSystem : ISystem
{
    [BurstCompile]
    void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<SimulationProperties>();

    }

    [BurstCompile]
    void OnDestroy(ref SystemState state)
    {

    }

    [BurstCompile]
    void OnUpdate(ref SystemState state)
    {
        state.Enabled = false;

        var simulationEntity = SystemAPI.GetSingletonEntity<SimulationProperties>();
        var simulation = SystemAPI.GetAspectRW<SimulationAspect>(simulationEntity);

        var ecb = new EntityCommandBuffer(Unity.Collections.Allocator.Temp);

        for(int i = 0; i < simulation.cellsToSpawn; i++)
        {
            var newCell = ecb.Instantiate(simulation.cellPrefab);
            var newCellTransform = simulation.GetRandomCellTransform();

            ecb.AddComponent(newCell, new LocalTransform { Position = newCellTransform.Position, Rotation = newCellTransform.Rotation, Scale = newCellTransform.Scale });
            ecb.AddComponent(newCell, new CellProperties { detectionRadius = 1.0f, velocity = Unity.Mathematics.float3.zero});
        }

        ecb.Playback(state.EntityManager);
    }
}