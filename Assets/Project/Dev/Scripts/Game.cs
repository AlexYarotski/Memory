using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Project
{
    public class Game : MonoBehaviour
    {
        private readonly Queue<Card> ClickedCards = new Queue<Card>();
        
        [SerializeField] 
        private int _pairsCount = 0;

        [SerializeField]
        private int _countPerGroup = 0;

        [SerializeField]
        private Color[] _colors = null;
        
        [SerializeField]
        private Card _cardPrefab = null;

        [SerializeField]
        private Transform _startPoint = null;

        [SerializeField]
        private float _offsetX = 0f;
        [SerializeField]
        private float _offsetY = 0f;

        private CardGroup[] _cardGroups = null;

        private void OnEnable()
        {
            Card.Clicked += Card_Clicked;
        }

        private void OnDisable()
        {
            Card.Clicked -= Card_Clicked;
        }

        private void Start()
        {
           SpawnCards();

           SetCardsRandomPosition();

           SetCardsColor();
        }

        private void SpawnCards()
        {
            _cardGroups = new CardGroup[_pairsCount];

            for (int i = 0; i < _pairsCount; i++)
            {
                var cards = new Card[_countPerGroup];

                for (int j = 0; j < _countPerGroup; j++)
                {
                    var instantiate = Instantiate(_cardPrefab, transform);
                    
                    cards[j] = instantiate;
                }

                _cardGroups[i] = new CardGroup(cards);
            }
        }
        
        private void SetCardsColor()
        {
            var colorsList = _colors.ToList();
            
            for (int i = 0; i < _cardGroups.Length; i++)
            {
                var cardGroup = _cardGroups[i];
                var randomColor = colorsList[Random.Range(0, colorsList.Count - 1)];

                cardGroup.SetColor(randomColor);
                
                colorsList.Remove(randomColor);
            }
        }

        private void SetCardsRandomPosition()
        {
            var points = GeneratePoints().ToList();

            for (int i = 0; i < _cardGroups.Length; i++)
            {
                var cards = _cardGroups[i].GetCards();

                for (int j = 0; j < _countPerGroup; j++)
                {
                    var randomPoint = points[Random.Range(0, points.Count - 1)]; 
                    
                    cards[j].SetPosition(randomPoint);

                    points.Remove(randomPoint);
                }
            }
        }

        private Vector3[] GeneratePoints()
        {
            var startPosition = _startPoint.position;
            
            Vector3[] points = new Vector3[_pairsCount * _countPerGroup];

            for (int i = 0, iteration = 0; i < _pairsCount; i++)
            {
                for (int j = 0; j < _countPerGroup; j++)
                {
                    points[iteration] = startPosition + new Vector3(_offsetX * i,
                        _offsetY * j, 0);

                    iteration++;
                }
            }

            return points;
        }
        
        private void Card_Clicked(Card card)
        {
            ClickedCards.Enqueue(card);
            card.SetColorMaterial();
            
            if (ClickedCards.Count == _countPerGroup)
            {
                var clickedCardsArray = ClickedCards.ToArray();
                var checkCardsGroup = CheckCardsGroup(clickedCardsArray);

                if (checkCardsGroup != null)
                {
                    checkCardsGroup.SetSolved();
                }
                else
                {
                    ResetCards(clickedCardsArray);
                }
                
                ClickedCards.Clear();

                if (CheckFinish())
                {
                    Debug.Log("YOU WIN");
                }
            }
        }

        private void ResetCards(Card[] cards)
        {
            for (int i = 0; i < cards.Length; i++)
            {
                cards[i].SetColorMaterial(Color.white);
            }
        }

        private CardGroup CheckCardsGroup(Card[] cards)
        {
            for (int i = 0; i < _cardGroups.Length; i++)
            {
                if (_cardGroups[i].IsEquals(cards))
                {
                    return _cardGroups[i];
                }
            }

            return null;
        }

        private bool CheckFinish()
        {
            for (var i = 0; i < _cardGroups.Length; i++)
            {
                if (!_cardGroups[i].IsSolved)
                {
                    return false;
                }
            }

            return true;
        }
    }
}