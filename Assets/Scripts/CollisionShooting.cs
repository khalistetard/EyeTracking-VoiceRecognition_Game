using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionShooting : MonoBehaviour
{
    public ScoreShooting score;
    public int points = 500; 
    void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.collider.name == "Projectile(Clone)")
        {
            score.UpdateScore(points);
            Destroy(gameObject);
        }

    }

    public void AddPoint(int p)
    {
        points += p;
    }
}
