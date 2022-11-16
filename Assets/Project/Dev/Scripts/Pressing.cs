using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Pressing : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _gameWindow = null;

    private Text _text = null;
    private Card _card = new Card();
    private int _pressing = 0;
    
    public void FixedUpdate()
    {
        _gameWindow.text = _card.GetPressing().ToString();
    }
}
