using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuoteScene : MonoBehaviour
{
    public float sceneDelay = 1.0f;
    public float quoteIntroTime = 1.0f;
    public float quoteTimerMax = 3.0f;
    public float authorTimerMax = 6.0f;
    public float maxSceneTime = 9.0f;
    private float sceneTimer = 0.0f;
    public string nextScene;
    
    public TextMeshProUGUI quoteText;
    public TextMeshProUGUI authorText;

    private Color defaultTextColor;
    private Color clearColor;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sceneTimer = 0.0f;

        SetQuoteToTransparent();

    }

    // Update is called once per frame
    void Update()
    {
        sceneTimer += Time.deltaTime;

        if (sceneTimer <= sceneDelay)
            return;

        if (sceneTimer < quoteIntroTime + sceneDelay)
        {
            quoteText.color = BHelper.LerpColor(quoteText.color, defaultTextColor, 4.0f);
            authorText.color = BHelper.LerpColor(authorText.color, defaultTextColor, 4.0f);
        }

        if (sceneTimer > maxSceneTime + sceneDelay)
        {
            if (nextScene != null)
                SceneManager.LoadScene(nextScene);
            else
            {
                Debug.LogError("No scene set for scene transition! - Check Start Scene Script!");
            }
        }

        if (sceneTimer >= quoteTimerMax + sceneDelay)
        {
            quoteText.color = BHelper.LerpColor(quoteText.color, Color.clear, 3.0f);
        }

        if (sceneTimer >= authorTimerMax + sceneDelay)
        {
            authorText.color = BHelper.LerpColor(authorText.color, Color.clear, 3.0f);
        }
    }

    private void SetQuoteToTransparent()
    {
        defaultTextColor = quoteText.color;
        clearColor = defaultTextColor;
        clearColor.a = 0.0f;
        quoteText.color = clearColor;
        authorText.color = clearColor;
    }
}
