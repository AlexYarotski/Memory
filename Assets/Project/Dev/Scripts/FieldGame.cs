using System.Linq;
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

    public void Awake()
    {
        Card[,] arrayCard = new Card[length, width];

        int x = 0;

        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < width; j++)
            {
                Card createdCard = Instantiate(_cardPrefab, transform);
                createdCard.transform.position = new Vector2(i - 3f + i, j + 2f - (j * 3));
                arrayCard[i, j] = createdCard;
                createdCard.SetColor(_colors[x]);
                x++;
            }
        }
    }
}
