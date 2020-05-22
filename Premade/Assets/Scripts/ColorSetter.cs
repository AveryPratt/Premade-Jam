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
    private float _transparentClippingLimit = .9f;
    public float TransparentClippingLimit
    {
        get
        {
            return _transparentClippingLimit;
        }
        set
        {
            _transparentClippingLimit = value;
            Renderer.sharedMaterial.SetFloat("_TransparentClippingLimit", value);
        }
    }

    private void Start()
    {
        Renderer.sharedMaterial.SetColor("_ForegroundColor", ForegroundColor);
        Renderer.sharedMaterial.SetColor("_BackgroundColor", BackgroundColor);
        Renderer.sharedMaterial.SetFloat("_TransparentClippingLimit", TransparentClippingLimit);
    }

    private void Update()
    {
        ForegroundColor = ForegroundColor;
        BackgroundColor = BackgroundColor;
        TransparentClippingLimit = TransparentClippingLimit;
    }
}
