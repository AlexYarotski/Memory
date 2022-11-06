using System;
using System.Collections;
using UnityEngine;

public class FieldGame : MonoBehaviour
{
    [SerializeField]
    private int length = 0;

    [SerializeField]
    private int width = 0;

    [SerializeField]
    private Card _cardPrefab = null;

    [SerializeField]
    private Color[] _colors = null;

    private Card _firstCard = null;
    private Card _secondCard = null;
    
    public void Awake()
    {
        Card[,] arrayCard = new Card[length, width];

        if ((length * width) % 2 != 0 || _colors.Length != (length * width) / 2)
        {
            Debug.Log("The number of cards must be even");
            
            return;
        }

        int x = 0;

        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < width; j++)
            {
                Card createdCard = Instantiate(_cardPrefab, transform);
                createdCard.transform.position = new Vector2(i - 3f + i,
                    j + 2f - (j * 3));
                arrayCard[i, j] = createdCard;
                createdCard.SetColor(_colors[x++]);

                if (x == _colors.Length)
                {
                    x = 0;
                }
            }
        }
    }

    private void OnEnable()
    {
        Card.Clicked += Card_Clicked;
    }
    
    private void OnDisable()
    {
        Card.Clicked -= Card_Clicked;
    }

    private void Card_Clicked(Card clickedCard)
    {
        if (_firstCard == null)
        {
            _firstCard = clickedCard;

            return;
        }

        _secondCard = clickedCard;
        StartCoroutine(CheckColorsCor());
    }
    
     private void CheckingForSameColors()
    {
        if (_firstCard.color == _secondCard.color)
        {
            SetNull();
            Debug.Log("Same colors!!!");
        }
    }

     private void CheckingForDifferentColors()
     {
         if (_firstCard.color != _secondCard.color)
         {
             ResetSelected();
             SetNull();
             Debug.Log("Different colors!!!");
         }
     }
     
    private void SetNull()
    {
        _firstCard = null;
        _secondCard = null;
    }

    private void ResetSelected()
    {
        _firstCard.SetColorMaterial(Color.white);
        _secondCard.SetColorMaterial(Color.white);
    }

    IEnumerator CheckColorsCor()
    {
        CheckingForSameColors();
        yield return new WaitForSeconds(0.3f);
        CheckingForDifferentColors();
    }
}