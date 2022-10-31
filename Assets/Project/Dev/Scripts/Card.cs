using UnityEngine;

public class Card : MonoBehaviour
{
    private Renderer _render = null;
    
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
    
    public void Awake()
    {
        _render = GetComponent<Renderer>();
    }

    public void SetColor(Color color)
    {
        _render.material.color = color;
    }
}
