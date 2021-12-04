using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class DoDMoveSystem : SystemBase
{
    protected override void OnCreate()
    {
    }

    protected override void OnUpdate()
    {
        EntityManager entityManager = EntityManager;
        Entities.WithNone<MoveData>().WithStructuralChanges().ForEach((Entity entity, in Translation translation) =>
        {
            entityManager.AddSharedComponentData(entity, new MoveData { IsOpposite = UnityEngine.Random.value > 0.5f ? false : true });
        }).Run();
        float deltaTime = Time.DeltaTime;
        Entities.WithSharedComponentFilter(new MoveData { IsOpposite = true }).ForEach((ref Translation translation) =>
        {
            translation.Value += new float3(deltaTime, 0, 0);
        }).Run();
        Entities.WithSharedComponentFilter(new MoveData { IsOpposite = false }).ForEach((ref Translation translation) =>
        {
            translation.Value -= new float3(deltaTime, 0, 0);
        }).Run();
    }
}
