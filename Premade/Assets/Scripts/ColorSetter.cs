using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ColorSetter : MonoBehaviour
{
    public SpriteRenderer Renderer;

    [SerializeField]
    private Color _foregroundColor = new Color(0, 0, 0, 1);
    public Color ForegroundColor
    {
        get
        {
            return _foregroundColor;
        }
        set
        {
            _foregroundColor = value;
            Renderer.sharedMaterial.SetColor("_ForegroundColor", value);
        }
    }

    [SerializeField]
    private Color _backgroundColor = new Color(1, 1, 1, 1);
    public Color BackgroundColor
    {
        get
        {
            return _backgroundColor;
        }
        set
        {
            _backgroundColor = value;
            Renderer.sharedMaterial.SetColor("_BackgroundColor", value);
        }
    }

    [SerializeField]
    private bool _useTransparentBackground = true;
    public bool UseTransparentBackground
    {
        get
        {
            return _useTransparentBackground;
        }
        set
        {
            _useTransparentBackground = value;
            Renderer.sharedMaterial.SetFloat("_UseTransparentBackground", value ? 1 : 0);
        }
    }

    private void Start()
    {
        Renderer.sharedMaterial.SetColor("_ForegroundColor", ForegroundColor);
        Renderer.sharedMaterial.SetColor("_BackgroundColor", BackgroundColor);
        Renderer.sharedMaterial.SetFloat("_UseTransparentBackground", UseTransparentBackground ? 1 : 0);
        RenderSettings.ambientLight = Color.white;
    }

    private void Update()
    {
        ForegroundColor = ForegroundColor;
        BackgroundColor = BackgroundColor;
        UseTransparentBackground = UseTransparentBackground;
    }
}
