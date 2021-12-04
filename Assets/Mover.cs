using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public bool IsOpposite = false;
    int movedDir = 1;
    float elapsedTIme = 0;

    private void Start()
    {
        if (IsOpposite)
            movedDir = -1;
        else
            movedDir = 1;
    }
    void Update()
    {
        if (elapsedTIme > 20)
        {
            movedDir *= -1;
            elapsedTIme = 0;
        }

        elapsedTIme += Time.deltaTime;
        transform.position -= new Vector3(Time.deltaTime * movedDir, 0, 0);
    }
}
