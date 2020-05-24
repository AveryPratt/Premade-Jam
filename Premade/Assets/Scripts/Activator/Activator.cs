using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public abstract class Activator : MonoBehaviour
{
    public ActivatorType Type { get; protected set; }
}

public enum ActivatorType
{
    Fox,
    Wolf,
    Kill,
    Light,
    Dark
}