﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject Target { get; set; }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, Target.transform.position, Time.deltaTime * 2);
    }
}
