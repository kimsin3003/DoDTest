﻿using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

[System.Serializable]
public struct MoveData : ISharedComponentData
{
    public bool IsOpposite;
}
