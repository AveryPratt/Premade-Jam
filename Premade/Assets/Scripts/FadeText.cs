using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeText : MonoBehaviour
{
    public CanvasGroup CanvasGroup;
    public float StartFadeTime = 3;
    public float EndFadeTime = 6;


    private float Timer;

    private void Update()
    {
        Timer += Time.deltaTime;
        CanvasGroup.alpha = Time.timeScale == 0 ? 1 : Mathf.Lerp(1, 0, (Timer - StartFadeTime) / (EndFadeTime - StartFadeTime));
    }
}
