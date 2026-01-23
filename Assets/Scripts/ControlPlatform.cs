using UnityEngine;
using UnityEngine.InputSystem;

public class ControlPlatform : MonoBehaviour
{

    PlatformEffector2D PE2D;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PE2D = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.sKey.isPressed)
        {
            PE2D.rotationalOffset = 180;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        PE2D.rotationalOffset = 0;
    }
}
