using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public Score Text;
    public Rigidbody playerforce;
    public float slow = 500f;
    void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "Player") {
            Destroy(gameObject);
            Text.UpdateScore(50);
            playerforce.AddForce(0, 0, -slow * Time.deltaTime);
        }
        
    }
    void Update()
    {
        transform.Rotate(Vector3.up);
    }
}
