using UnityEngine;
using UnityEngine.Events;

public class SpriteOrderer : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private GameManager _gameManager;
    
    public int spriteOrder = 0;

    [HideInInspector] public UnityEvent OnOrderChanged;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OnOrderChanged ??= new UnityEvent();
        _gameManager = GameManager.instance;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSpriteOrder();
    }

    private void UpdateSpriteOrder()
    {
        // update sort order
        if (_spriteRenderer.sortingOrder != spriteOrder)
        {
            SetOrder();
        }
    }

    private void SetOrder()
    {
        _spriteRenderer.sortingOrder = GetSortingOrder(transform, _gameManager.minSpriteYPosition, _gameManager.maxSpriteYPosition);
        spriteOrder = _spriteRenderer.sortingOrder;
        OnOrderChanged.Invoke();
    }
    
    public int GetSortingOrder(Transform transformToOrder, float minY, float maxY)
    {
        int newOrder = 0;

        float yPosition = Mathf.Clamp(transformToOrder.position.y, minY, maxY);
        
        newOrder = Mathf.FloorToInt(yPosition);
        
        return newOrder;
    }
}
