using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private void Update()
    {
        AnimalController activeAnimalController = GameManager.Instance.ActiveAnimalController;
        if (!activeAnimalController.IsMoving)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                activeAnimalController.MoveNorth();
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                activeAnimalController.MoveSouth();
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                activeAnimalController.MoveWest();
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                activeAnimalController.MoveEast();
            }
        }
    }
}
