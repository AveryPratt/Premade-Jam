using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour
{
    public GameObject Model;
    public Collider Collider;
    public bool FallSideways;
    public bool EndsGame;
    public bool GoesDark;

    private bool _isDead;
    public bool IsDead
    {
        get
        {
            return _isDead;
        }
        set
        {
            _isDead = value;
            if (_isDead)
            {
                Collider.gameObject.SetActive(false);
                if (GoesDark)
                {
                    GameManager.Instance.KillLights();
                }
            }
            else
            {
                DeathTimer = DeathTime;
                Model.transform.rotation = Quaternion.Euler(0, Model.transform.rotation.eulerAngles.y, 0);
            }
        }
    }
    public float DeathTime = 2f;

    private float DeathTimer;

    private void OnEnable()
    {
        Collider.gameObject.SetActive(true);
    }

    private void Start()
    {
        DeathTimer = DeathTime;
    }

    private void Update()
    {
        if (IsDead && DeathTimer > 0)
        {
            DeathTimer -= Time.deltaTime;

            if (FallSideways)
            {
                Model.transform.rotation = Quaternion.Euler(0, Model.transform.rotation.eulerAngles.y, Mathf.Lerp(90, 0, DeathTimer / DeathTime));
            }
            else
            {
                Model.transform.rotation = Quaternion.Euler(Mathf.Lerp(-90, 0, DeathTimer / DeathTime), Model.transform.rotation.eulerAngles.y, 0);
            }

            if (DeathTimer < 0)
            {
                if (EndsGame)
                {
                    GameManager.Instance.HUD.Die();
                }
                DeathTimer = 0;
            }
        }
    }
}
