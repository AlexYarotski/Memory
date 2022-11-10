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
    private Coroutine _checkColorsCor = null;
    private int  pairsOpen = 0;
    
    private void OnEnable()
    {
        Card.Clicked += Card_Clicked;
    }
    
    private void OnDisable()
    {
        Card.Clicked -= Card_Clicked;
    }
    
    public void Awake()
    {
        if ((length * width) % 2 != 0 || _colors.Length != (length * width) / 2)
        {
            Debug.Log("The number of cards must be even");
            
            return;
        }

        CreateField();
    }

    private void CreateField()
    {
        Card[,] arrayCard = new Card[length, width];
        int x = 0;

        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < width; j++)
            {
                Card createdCard = Instantiate(_cardPrefab, transform);
                createdCard.transform.position = new Vector2(i - 3f + i,
                    j + 1f - (j * 3));
                arrayCard[i, j] = createdCard;
                createdCard.SetColor(_colors[x++]);

                if (x == _colors.Length)
                {
                    x = 0;
                }
            }
        }
    }
    
    private void Card_Clicked(Card clickedCard)
    {
        if(_checkColorsCor != null)
        {
            return;
        }

        clickedCard.SetColorMaterial();
        
        if (_firstCard == null)
        {
            _firstCard = clickedCard;
            
            return;
        }

        _secondCard = clickedCard;
        
        _checkColorsCor = StartCoroutine(CheckColorsCor());
    }
    
    private void CheckColors()
    {
        if (_firstCard.Color == _secondCard.Color)
        {
            ScoreToVictory();
        }
        else
        {
            ResetSelected();
        }
        
        SetNull();
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
        yield return new WaitForSeconds(0.3f);
        
        CheckColors();
        
        _checkColorsCor = null;
    }

    private void ScoreToVictory()
    {
        pairsOpen = Mathf.Clamp(pairsOpen + 1, 0, 10);
        
        pairsOpen++;
        if (pairsOpen == _colors.Length)
        {
            Debug.Log("You Winner");
            
            return;
        }
        
        Debug.Log($"Just a little bit left... \r\n {_colors.Length - pairsOpen} pairs");
    }
}