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

    public void Awake()
    {
        Color[] colors = new Color[8] { Color.red, Color.yellow, Color.white, Color.blue, Color.red, Color.yellow, Color.white, Color.blue };
        Card[,] arrayCard = new Card[length, width];
        var rnd = Random.Range(0, colors.Length - 1);
        colors = colors.OrderBy(x => x[rnd]).ToArray();
        int x = 0;

        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < width; j++)
            {
                Card createdCard = Instantiate(_cardPrefab);
                createdCard.transform.position = new Vector2(i - 3f + i, j + 2.1f - (j * 3));
                createdCard.transform.SetParent(transform);                
                arrayCard[i, j] = createdCard;
                createdCard.SetColor(colors[x]);
                x++;
            }
        }
    }
}
