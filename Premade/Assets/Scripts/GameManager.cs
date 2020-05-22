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
        set
        {
            _activeAnimalController = value;
        }
    }

    public AnimalController FoxController;
    public AnimalController WolfController;
    public InputManager InputManager;
}
