using System;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(BoxCollider))]
public class Card : MonoBehaviour, IPointerClickHandler
{
    public static event Action<Card> Clicked = delegate { };
    private Renderer _render = null;
    
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
        _render.material.color = color;
    }

    public void SetColorMaterial(Color color)
    {
        _render.material.color = color;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerId == -1)
        {
            if (color == _render.material.color)
            {
                return;;
            }
            
            SetColorMaterial();
            Clicked(this);
        }
    }
}
