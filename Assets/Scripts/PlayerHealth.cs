using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 3;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("HurtPlayerOnCollision")) {
            PlayerDamage();
        }
       
    }

    private void PlayerHealthUI() 
    {

    }

    private void PlayerDamage()
    {
        health = health--;
        // TODO Tint player red momentarily
        // TODO Push player back
        // TODO Play hurt sound
        // TODO Make player momentarily invulnerable
        // TODO Destroy player on 0
        // TODO Update UI
    }

    // Debug purposes
    private void CheckForCollision() {
        Debug.Log("PlayerHit");
    }
}
