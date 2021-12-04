using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    bool _isOnDoDMode = false;
    [SerializeField]
    GameObject _prefab;
    List<GameObject> SpawnedObjects = new List<GameObject>();
    void Start()
    {
        int size = 100;
        var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        var setting = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, new BlobAssetStore());
        var entityPrefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(_prefab, setting);
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (!_isOnDoDMode)
                {
                    var obj = Instantiate(_prefab);
                    obj.transform.position = new Vector3(i - size / 2, 0, j - size / 2);
                    SpawnedObjects.Add(obj);
                    var mover = obj.AddComponent<Mover>();
                    mover.IsOpposite = UnityEngine.Random.value > 0.5f;
                }
                else
                {
                    var entity = entityManager.Instantiate(entityPrefab);
                    Translation traslation = new Translation();
                    traslation.Value = new float3(i - size / 2, 0, j - size / 2);
                    entityManager.AddComponentData(entity, traslation);
                }
            }
        }
    }
}
