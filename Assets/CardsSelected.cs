using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardsSelected : MonoBehaviour
{
    [SerializeField] private Image _cardImage;
    [SerializeField] private Image _buttonImage;
    [SerializeField] private Sprite _selectedActive;
    [SerializeField] private Sprite _selectedDisable;
    [SerializeField] private TextMeshProUGUI _text;

    public bool ISelected { get; private set; } = false;
    public Card SelectedCard { get; private set; }

    public void SetData(Card data)
    {
        SelectedCard = data;
        _cardImage.sprite = data.SpriteCard;
    }

    public void SelectedSwitch()
    {
        var invertValue = !ISelected;

        if (invertValue)
        {
            _buttonImage.sprite = _selectedActive;
            _text.color = Color.black;
            ISelected = invertValue;
        }
        else
        {
            _buttonImage.sprite = _selectedDisable;
            _text.color = Color.white;
            ISelected = invertValue;
        }
    }
}