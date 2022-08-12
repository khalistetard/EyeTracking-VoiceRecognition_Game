using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameManager gM;

    void OnTriggerEnter()
    {
            gM.Won();
    }

}
