using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuoteBox : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private Image _background;
    public bool isActive = false;

    private void Start()
    {
        _background = GetComponentInChildren<Image>();
        _text = GetComponentInChildren<TextMeshProUGUI>();

        SetBackgroundColor(new Color(_background.color.r, _background.color.g, _background.color.b, 0.0f));
        SetTextColor(Color.clear);
    }
    // Update is called once per frame
    void Update()
    {
        if (isActive)
            HandleIntro();
        else
            HandleOutro();
    }

    private void HandleIntro()
    {
        if (_text.color.a != 1)
        {
            _text.color = BHelper.LerpColor(_text.color, Color.white, 2.0f);
            _background.color =
                BHelper.LerpColor(_background.color, new Color(_background.color.r, _background.color.g, _background.color.b, 1.0f), 2.0f);
        }
    }

    private void HandleOutro()
    {
        if (_text.color.a != 0)
        {
            _text.color = BHelper.LerpColor(_text.color, Color.clear, 2.0f);
            _background.color =
                BHelper.LerpColor(_background.color, new Color(_background.color.r, _background.color.g, _background.color.b, 0.0f), 2.0f);
        }
    }

    private void SetBackgroundColor(Color newColor)
    {
        _background.color = newColor;
    }

    private void SetTextColor(Color newColor)
    {
        _text.color = newColor;
    }
}
