using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private float? NorthTime = null;
    private float? SouthTime = null;
    private float? WestTime = null;
    private float? EastTime = null;

    private void Update()
    {
        AnimalController activeAnimalController = GameManager.Instance.ActiveAnimalController;

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            NorthTime = Time.unscaledTime;
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            SouthTime = Time.unscaledTime;
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            WestTime = Time.unscaledTime;
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            EastTime = Time.unscaledTime;
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            NorthTime = null;
        }
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            SouthTime = null;
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            WestTime = null;
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            EastTime = null;
        }

        if (!activeAnimalController.IsMoving)
        {
            float? latestTime = null;
            Directions? latestInput = null;
            if (NorthTime != null)
            {
                latestTime = NorthTime.Value;
                latestInput = Directions.North;
            }
            if (SouthTime != null && (latestTime == null || SouthTime > latestTime))
            {
                latestTime = SouthTime.Value;
                latestInput = Directions.South;
            }
            if (WestTime != null && (latestTime == null || WestTime > latestTime))
            {
                latestTime = WestTime.Value;
                latestInput = Directions.West;
            }
            if (EastTime != null && (latestTime == null || EastTime > latestTime))
            {
                latestTime = EastTime.Value;
                latestInput = Directions.East;
            }

            switch (latestInput)
            {
                case Directions.North:
                    activeAnimalController.TryMoveNorth();
                    break;
                case Directions.South:
                    activeAnimalController.TryMoveSouth();
                    break;
                case Directions.West:
                    activeAnimalController.TryMoveWest();
                    break;
                case Directions.East:
                    activeAnimalController.TryMoveEast();
                    break;
                default:
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E))
        {
            GameManager.Instance.SwitchActiveAnimalController();
        }

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            GameManager.Instance.HUD.TogglePause();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (GameManager.Instance.HUD.WinPanel.activeInHierarchy)
            {
                GameManager.Instance.HUD.NextLevel();
            }
            else if (GameManager.Instance.HUD.GameOverPanel.activeInHierarchy)
            {
                GameManager.Instance.HUD.Restart();
            }
            else if (GameManager.Instance.HUD.PausePanel.activeInHierarchy)
            {
                GameManager.Instance.HUD.TogglePause();
            }
            else
            {
                GameManager.Instance.SwitchActiveAnimalController();
            }
        }
    }
}

public enum Directions
{
    None,
    North,
    South,
    West,
    East
}