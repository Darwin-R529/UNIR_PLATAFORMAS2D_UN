using UnityEngine;

public class EnemyController : MovementController
{
    // Update is called once per frame
    protected override void Update()
    {
        desiredMove = Vector2.left;
        base.Update();
    }
}
