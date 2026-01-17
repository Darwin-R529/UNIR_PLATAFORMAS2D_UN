using System;
using UnityEngine;

public class EnemyController : MovementController
{
    [SerializeField] float distanceToPunch = 0.25f;
    [SerializeField] float timeBetweenPunches = 1f;
    public Transform player;
    float lastPunchTime;

    // Update is called once per frame
    protected override void Update()
    {
        RunToPlayer();

        if (player.gameObject.activeSelf)
        {
            CheckAndPerformPunch();
        }
        else
        {
            desiredMove.x = -desiredMove.x;
            // desiredMove.x *= -1;
        }

        base.Update();
    }

    protected virtual void RunToPlayer()
    {
        if (player.position.x < transform.position.x)
        {
            desiredMove = Vector2.left;
        }
        else
        {
            desiredMove = Vector2.right;
        }
    }

    private void CheckAndPerformPunch()
    {
        if (Math.Abs(player.position.x - transform.position.x) < distanceToPunch)
        {
            desiredMove = Vector2.zero;

            if (Time.time - lastPunchTime > timeBetweenPunches)
            {
                PerformPunch();
                lastPunchTime = Time.time;
            }

        }
    }
}
