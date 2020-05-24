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
                CameraFollow.Target = _activeAnimalController.gameObject;
            }
            return _activeAnimalController;
        }
        private set
        {
            _activeAnimalController = value;
            CameraFollow.Target = _activeAnimalController.gameObject;
        }
    }

    public AnimalController WolfController;
    public AnimalController FoxController;
    public InputManager InputManager;
    public HUD HUD;
    public CameraFollow CameraFollow;

    public void SwitchActiveAnimalController()
    {
        if (ActiveAnimalController.AnimalType == AnimalType.Fox && WolfController.isActiveAndEnabled)
        {
            ActiveAnimalController = WolfController;
        }
        else if (ActiveAnimalController.AnimalType == AnimalType.Wolf && FoxController.isActiveAndEnabled)
        {
            ActiveAnimalController = FoxController;
        }
    }

    private void Start()
    {
        ActiveAnimalController = WolfController;
    }
}
