using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image blackOverlay;
    private bool _overlayEnabled = true;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _overlayEnabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_overlayEnabled)
        {
            LerpSolid();
        }
        else
        {
            LerpClear();
        }
    }
    
    private void LerpClear()
    {
        if (blackOverlay.color == Color.black)
            return;
        
        blackOverlay.color = BHelper.LerpColor(blackOverlay.color, Color.black, 1.0f);
    }
    
    private void LerpSolid()
    {
        if (blackOverlay.color == Color.clear)
            return;
        
        blackOverlay.color = BHelper.LerpColor(blackOverlay.color, Color.clear, 1.0f);
    }
}
