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

    public LightTrigger[] Lights { get; private set; }
    public Vector4[] OnLights { get; private set; }
    public int OnLightCount { get; private set; }

    private Vector4 DefaultLight = new Vector4(0, 1000, 0, 0);

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

    public void KillLights()
    {
        foreach (LightTrigger light in Lights)
        {
            light.GoDark();
        }
    }

    private void Start()
    {
        ActiveAnimalController = WolfController;

        Lights = FindObjectsOfType<LightTrigger>();
        OnLights = new Vector4[100];
        for (int i = 0; i < 100; i++)
        {
            OnLights[i] = DefaultLight;
        }
    }

    private void Update()
    {
        OnLightCount = 0;
        foreach (LightTrigger light in Lights)
        {
            if (light.IsLit)
            {
                OnLights[OnLightCount] = light.transform.position;
                OnLightCount += 1;
            }
        }
        for (int j = OnLightCount; j < 100; j++)
        {
            OnLights[j] = DefaultLight;
        }
    }
}
