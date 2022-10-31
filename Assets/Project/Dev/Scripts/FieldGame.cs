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
        var rnd = Random.Range(0, _colors.Length);
        //_colors = _colors.OrderBy(h => h[rnd]).ToArray();
        int x = 0;

        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < width; j++)
            {
                Card createdCard = Instantiate(_cardPrefab);
                createdCard.transform.position = new Vector2(i - 3f + i, j + 2f - (j * 3));
                createdCard.transform.SetParent(transform);
                arrayCard[i, j] = createdCard;
                createdCard.SetColor(_colors[x]);
                x++;
            }
        }
    }
}
