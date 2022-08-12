using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using Tobii.Gaming;

public class MovementsShooting : MonoBehaviour
{
    //force, position and gaze
    public Rigidbody force;
    public Transform t;
    public GazePoint g;
    public GameObject projectile;
    public GameObject[] instantiatedObjects;

    bool isShooting = false;
    Vector3 target;
    //Speech recognition Initialization
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, System.Action> actions = new Dictionary<string, System.Action>();



    // Start is called before the first frame update
    void Start()
    {
        //we add the shooting and the system functions to the dictionnary
        actions.Add("shoot", Shoot);
        actions.Add("restart", Restart);
        actions.Add("stop", Stop);
        actions.Add("menu", Menu);


        instantiatedObjects = new GameObject[10];

        //we set the speech recognition function and start it
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray(), ConfidenceLevel.Low);
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();

    }

    //Instantally restart the game
    void Restart()
    {
        FindObjectOfType<GameManager>().Restart();
    }

    //Instantally launch the credits scene to end the game
    void Stop()
    {
        FindObjectOfType<GameManager>().Stop();
    }

    //Instantally launch the Menu Scene
    void Menu()
    {
        FindObjectOfType<GameManager>().Menu();
    }

    /// Allow the user to shoot in the game 
    public void Shoot()
    {
        isShooting = true;
        Vector3 position = t.position + new Vector3(0, 1, 2);
        int i = 0;
        while (i < 10)
        {
            if (instantiatedObjects[i] == null)
            {
                instantiatedObjects[i] = Instantiate(projectile, position, projectile.transform.rotation) as GameObject;
                instantiatedObjects[i].GetComponent<CollisionProjectile>().setTarget(target);
                i = 10;
            }
            i++;
        }
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        actions[speech.text].Invoke();
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown("space") && isShooting ==false) { Shoot();}

        for (int i = 0; i < 10 && instantiatedObjects[i] != null; i++)
        {
            if (instantiatedObjects[i].transform.position.z > t.position.z + 5) { isShooting = false; } 
        }

        if (force.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

    }

    public bool GetIsShooting() { return isShooting; }

    public void setShooting(bool shooting) { isShooting = shooting; }

    public void setTarget( Vector3 position) { target = position;  }

}
