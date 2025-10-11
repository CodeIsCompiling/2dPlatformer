using System;
using Player;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    public PlayerMover playerMover;
    public float bounce = 10f;
    private void OnTriggerStay2D(Collider2D collision)
    {
        playerMover.Bounce(bounce);
    }
    // Test comment
}
