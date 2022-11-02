using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(BoxCollider))]
public class Card : MonoBehaviour, IPointerClickHandler
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
        if (this.isSelected = true)
        {
            _render.material.color = this.color;    
        }
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerId == -1)
        {
            this.isSelected = true;
            SetColorMaterial();
        }
    }
}
