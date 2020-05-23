using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MovementController
{
    public AnimalType AnimalType;
}

public enum AnimalType
{
    Fox,
    Wolf
}