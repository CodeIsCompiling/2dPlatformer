using System;
using Player_2;
using Unity.VisualScripting;
using UnityEngine;

public class JumpBooster : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Player2Mover player2Mover = other.gameObject.GetComponent<Player2Mover>();
        player2Mover.SetBounce(0.75f);
        Destroy(gameObject);
    }
}
