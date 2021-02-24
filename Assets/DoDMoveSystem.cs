using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class DoDMoveSystem : ComponentSystem
{
    EntityQuery _normalGroup;
    EntityQuery _oppositeGroup;
    protected override void OnCreate()
    {
        Entities.ForEach((Entity entity) =>
        {
            EntityManager.AddSharedComponentData(entity, new MoveData { IsOpposite = UnityEngine.Random.value > 0.5f ? false : true });
        });
        _normalGroup = GetEntityQuery(ComponentType.ReadWrite<Translation>(), ComponentType.ReadOnly<MoveData>());
        _normalGroup.SetSharedComponentFilter(new MoveData { IsOpposite = true });
        _oppositeGroup = GetEntityQuery(ComponentType.ReadWrite<Translation>(), ComponentType.ReadOnly<MoveData>());
        _oppositeGroup.SetSharedComponentFilter(new MoveData { IsOpposite = false });
    }

    protected override void OnUpdate()
    {
        Entities.With(_normalGroup).ForEach((ref Translation translation) =>
        {
            translation.Value += new float3(Time.DeltaTime, 0, 0);
        });
        Entities.With(_oppositeGroup).ForEach((ref Translation translation) =>
        {
            translation.Value -= new float3(Time.DeltaTime, 0, 0);
        });
    }
}
