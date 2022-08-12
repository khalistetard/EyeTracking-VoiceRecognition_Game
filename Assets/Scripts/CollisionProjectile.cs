using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionProjectile : MonoBehaviour
{
    public GameObject player;
    Vector3 target; //target of the projectile

    public bool isInAir = false; //Is it in the air before it hits the ground ?
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if ( collision.collider.name == "Target(Clone)" || collision.collider.name == "Player2" || (isInAir && collision.collider.name == "Platform") || collision.collider.name == "Wall")
        {
            player.GetComponent<MovementsShooting>().setShooting(false);
            Destroy(gameObject);
        }
    }

    public void setTarget(Vector3 obj)
    {
        target = obj;
    }

    public Vector3 getTarget()
    {
        return target;
    }
}
