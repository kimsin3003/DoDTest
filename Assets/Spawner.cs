using System.Collections;
using System.Collections.Generic;
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
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                var obj = Instantiate(_prefab);
                obj.transform.position = new Vector3(i - size / 2, 0, j - size / 2);
                SpawnedObjects.Add(obj);
                if (!_isOnDoDMode)
                {
                    if(Random.value > 0.5f ? false : true)
                    {
                        obj.AddComponent<NormalMover>();
                    }
                    else
                    {
                        obj.AddComponent<OppositeMover>();
                    }
                }
            }
        }
    }
}
