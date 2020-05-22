using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }

    private AnimalController _activeAnimalController { get; set; }
    public AnimalController ActiveAnimalController
    {
        get
        {
            if (_activeAnimalController == null)
            {
                _activeAnimalController = WolfController;
            }
            return _activeAnimalController;
        }
        private set
        {
            _activeAnimalController = value;
        }
    }

    public AnimalController WolfController;
    public AnimalController FoxController;
    public InputManager InputManager;

    public void SwitchActiveAnimalController()
    {
        if (ActiveAnimalController.AnimalType == AnimalType.Fox)
        {
            ActiveAnimalController = WolfController;
        }
        else if (ActiveAnimalController.AnimalType == AnimalType.Wolf)
        {
            ActiveAnimalController = FoxController;
        }
    }
}
