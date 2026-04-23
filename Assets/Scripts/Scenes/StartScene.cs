using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    [SerializeField] private float defaultTextSize = 36.0f;
    [SerializeField] private float selectedTextSize = 40.0f;

    [SerializeField] private TextMeshProUGUI startText;
    [SerializeField] private TextMeshProUGUI quitText;
    
    private int selectionIndex;
    
    public string nextSceneName;

    [SerializeField] private InputActionReference _moveUpAction;
    [SerializeField] private InputActionReference _moveDownAction;
    [SerializeField] private InputActionReference[] _selectActions;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startText.fontSize = defaultTextSize;
        quitText.fontSize = defaultTextSize;
    }

    // Update is called once per frame
    void Update()
    {
        HandleNavigation();
        HandleSelection();

    }

    private void ClampSelection()
    {
        selectionIndex = Mathf.Clamp(selectionIndex, 0, 1);
    }

    private void HandleNavigation()
    {
        if (_moveUpAction.action.WasPressedThisFrame())
        {
            selectionIndex--;
        }

        if (_moveDownAction.action.WasPressedThisFrame())
        {
            selectionIndex++;
        }
    }

    private void HandleSelection()
    {
        ClampSelection();
        
        switch (selectionIndex)
        {
            case 0:
                startText.fontSize = selectedTextSize;
                quitText.fontSize = defaultTextSize;
                break;
            case 1:
                quitText.fontSize = selectedTextSize;
                startText.fontSize = defaultTextSize;
                break;
        }

        foreach (InputActionReference action in _selectActions)
        {
            if (action.action.WasPressedThisFrame())
            {
                Select();
            }
        }

    }

    private void Select()
    {
        if (selectionIndex == 0)
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else if (selectionIndex == 1)
        {
            Application.Quit();
        }
    }
}
