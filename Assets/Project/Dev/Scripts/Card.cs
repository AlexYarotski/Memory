using UnityEngine;

public class Card : MonoBehaviour
{
    public bool isSelected
    {
        get;
        private set;
    }

    public Color color
    {
        get;
        private set;
    }

     private Renderer _render = null;

    public void Awake()
    {
        _render = GetComponent<Renderer>();
    }

    public Color SetColor(Color color)
    {
        _render.material.color = color;
        return color;
    }
}
