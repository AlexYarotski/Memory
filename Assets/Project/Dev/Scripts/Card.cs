using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(BoxCollider))]
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
        this.color = color;
    }

    public void SetColorMaterial()
    {
        _render.material.color = this.color;
    }

    public void SetSelected()
    {
        this.isSelected = true;
    }
}
