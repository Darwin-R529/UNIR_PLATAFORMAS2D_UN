using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MovementController
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    protected override void Update()
    {
        UpdateRawMove();

        base.Update();
    }


    private void UpdateRawMove()
    {
        Vector2 rawMove = Vector2.zero;

        if (Keyboard.current.aKey.isPressed)
        { rawMove += Vector2.left; }
        else if (Keyboard.current.dKey.isPressed)
        { rawMove += Vector2.right; }

        desiredMove = rawMove;

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        { mustJump = true; }

        if (Mouse.current.leftButton.wasPressedThisFrame)
        { mustPunch = true; }
    }
}
