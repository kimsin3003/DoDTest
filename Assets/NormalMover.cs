using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalMover : MonoBehaviour
{
    void Update()
    {
        transform.position += new Vector3(Time.deltaTime, 0, 0);
    }
}
