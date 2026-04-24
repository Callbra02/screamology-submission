using UnityEngine;
using UnityEngine.InputSystem;

public class ComputerScreen : MonoBehaviour
{
    public GameObject cursor;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        cursor.transform.position = Vector3.Lerp(cursor.transform.position, mousePosition, 10.0f);
    }
}
