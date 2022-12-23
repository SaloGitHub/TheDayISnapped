using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   private void OnCollisionEnter2D(Collision2D other) {
      Destroy(gameObject); // Destroy bullet
      Destroy(other.gameObject); // Destroy enemy
   }
}
