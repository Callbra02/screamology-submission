using UnityEngine;
using UnityEngine.InputSystem;

public class PauseScreen : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private InputActionReference _pauseAction;

    private bool isTimeScaled = false;

    public bool isEnabled = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (_pauseAction.action.WasPressedThisFrame() && !isEnabled)
        {
            EnablePauseScreen();
            Debug.Log("PAUSE");
        } else if (_pauseAction.action.WasPressedThisFrame() && isEnabled)
        {
            DisablePauseScreen();
            Debug.Log("UNPAUSE");
        }
        
        HandleTimescale();
    }

    public void EnablePauseScreen()
    {
        isEnabled = true;
        pausePanel.SetActive(true);
        ToggleTimescale();
    }

    public void DisablePauseScreen()
    {
        isEnabled = false;
        pausePanel.SetActive(false);
        ToggleTimescale();
    }

    private void ToggleTimescale()
    {
        isTimeScaled = !isTimeScaled;
    }

    private void HandleTimescale()
    {
        if (isTimeScaled)
        {
            if (Time.timeScale != 0)
                Time.timeScale = 0;
        }
        else
        {
            if (Time.timeScale != 1)
                Time.timeScale = 1;
        }
    }
}
