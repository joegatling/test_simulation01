using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public readonly partial struct SimulationAspect : IAspect
{
    public readonly Entity entity;

    private readonly TransformAspect _transformAspect;

    private readonly RefRO<SimulationProperties> _simulationProperties;
    private readonly RefRW<SimulationRandom> _simulationRandom;

    public int cellsToSpawn => _simulationProperties.ValueRO.cellCount;

    public Entity cellPrefab => _simulationProperties.ValueRO.cellPrefab;

    public LocalTransform GetRandomCellTransform()
    {
        return new LocalTransform
        {
            Position = GetRandomSpawnPosition(),
            Scale = 1.0f,
            Rotation = Quaternion.identity
            
        };
    }

    private float3 GetRandomSpawnPosition()
    {
        float3 randomPosition = _simulationRandom.ValueRW.value.NextFloat3(minCorner, maxCorner);

        return randomPosition;
    }

    private float3 minCorner => _transformAspect.LocalPosition - halfDimensions;
    private float3 maxCorner => _transformAspect.LocalPosition + halfDimensions;

    private float3 halfDimensions => new()
    {
        x = _simulationProperties.ValueRO.dimensions.x * 0.5f,
        y = 0.0f,
        z = _simulationProperties.ValueRO.dimensions.y * 0.5f
    };
    
}
