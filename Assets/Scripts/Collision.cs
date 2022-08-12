using UnityEngine;

public class Collision : MonoBehaviour
{

    //Call player movements in a variable
    public Movements movement;

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            movement.EndListening();
            FindObjectOfType<GameManager>().EndGame();
        }
        
    }
}
