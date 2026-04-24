using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseSelection : MonoBehaviour
{
    private PauseScreen _pauseScreen;
    
    [Header("TMPro Objects")]
    [SerializeField] private TextMeshProUGUI[] _textOptions;

    [Header("Input References")]
    [SerializeField] private InputActionReference _moveUpAction;
    [SerializeField] private InputActionReference _moveDownAction;
    [SerializeField] private InputActionReference[] _selectActions;

    [Header("Text Options")]
    [SerializeField] private bool _useCustomSize = false;
    [SerializeField] private float _selectedTextSizeScalar = 1.5f;
    [SerializeField] private float _defaultTextSize = 36.0f;
    [SerializeField] private float _selectedTextSize = 40.0f;

    private float _textSize;
    private float _selectedSize;

    private int selectionIndex;
    
    private void Start()
    {
        _pauseScreen = GetComponent<PauseScreen>();
        if (_useCustomSize)
        {
            _textSize = _defaultTextSize;
            _selectedSize = _selectedTextSize;
        }
        else
        {
            _textSize = _textOptions[0].fontSize;
            _selectedSize = _textSize * _selectedTextSizeScalar;
        }

        selectionIndex = 0;
    }

    private void Update()
    {
        if (!_pauseScreen.isEnabled)
            return;
        
        HandleNavigate();
        HandleSelection();

    }
    
    
    private void HandleNavigate()
    {

        if (_moveUpAction.action.WasPressedThisFrame())
            selectionIndex--;

        if (_moveDownAction.action.WasPressedThisFrame())
        {
            selectionIndex++;
        }
    }
    
    private void HandleSelection()
    {
        selectionIndex = Mathf.Clamp(selectionIndex, 0, _textOptions.Length);

        SetSelectionText();
        
        foreach (InputActionReference action in _selectActions)
        {
            if (action.action.WasPressedThisFrame())
                Select();
        }
    }

    private void SetSelectionText()
    {
        for (int i = 0; i < _textOptions.Length; i++)
        {
            _textOptions[i].fontSize = i == selectionIndex ? _selectedSize : _textSize;
        }
    }
    

    private void Select()
    {
        switch (selectionIndex)
        {
            case 0:
                _pauseScreen.DisablePauseScreen();
                break;
            case 1:
                // Save / Go to menu
                SceneManager.LoadScene("StartScene");
                break;
        }
    }
}
