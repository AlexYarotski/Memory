using System;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(BoxCollider))]
public class Card : MonoBehaviour, IPointerClickHandler
{
    public static event Action<Card> Clicked = delegate { };
    
    private Renderer _render = null;
    
    public Color Color
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
        Color = color;
    }

    public void SetPosition(Vector3 newPosition)
    {
        transform.position = newPosition;
    }

    public void SetColorMaterial()
    {
        _render.material.color = Color;
    }

    public void SetColorMaterial(Color color)
    {
        _render.material.color = color;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerId == -1)
        {
            if (Color == _render.material.color)
            {
                return;
            }
            
            Clicked(this);
        }
    }
}
