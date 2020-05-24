using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Persistent : MonoBehaviour
{
    private static Persistent _instance;
    public static Persistent Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Persistent>();
            }
            return _instance;
        }
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
