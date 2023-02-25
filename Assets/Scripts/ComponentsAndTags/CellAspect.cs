using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public readonly partial struct CellAspect : IAspect
{
    private readonly TransformAspect _transformAspect;

    private readonly RefRW<CellProperties> _cellProperties;    

    public TransformAspect transform => _transformAspect;
    
    public float3 velocity
    {
        get => _cellProperties.ValueRO.velocity;
        set => _cellProperties.ValueRW.velocity = value;
    }

    public float3 position 
    {
        get => _transformAspect.WorldPosition;
        set => _transformAspect.WorldPosition = value;
    }

    public float detectionRadius => _cellProperties.ValueRO.detectionRadius;

}
