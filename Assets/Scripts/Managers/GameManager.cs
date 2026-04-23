using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int minSpriteOrderCount = -50;
    public int maxSpriteOrderCount = 50;

    public float maxSpriteYPosition = 50;
    public float minSpriteYPosition = -50;
    
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }


    
}
