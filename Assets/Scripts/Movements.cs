using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using Tobii.Gaming;

public class Movements : MonoBehaviour
{
    //force, position and gaze
    public Rigidbody force;
    public Transform t;
    public GazePoint g;



    //Speech recognition Initialization
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, System.Action> actions = new Dictionary<string, System.Action>();

    //force strength initialization
    public float forwardF = 2000f;
    public float sideF = 500f;
    public float jumpF = 5000f;

    bool endJump, isJumping = false;

    float timenow;
    bool korev = true; //Keyboard (true) or Eye and Voice (false) boolean

    // Start is called before the first frame update
    void Start()
    {
        korev = MenuScript.korev;

        //we add the jump and the system functions to the dictionnary
        actions.Add("jump", () => Up(1.25f));
        actions.Add("restart", Restart);
        actions.Add("stop", Stop);
        actions.Add("menu", Menu);

        //we set the speech recognition function and start it
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray(), ConfidenceLevel.Low);
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        //Debug.LogWarning("jump");
        actions[speech.text].Invoke();
    }

    //Instantally launch the Menu Scene
    void Menu()
    {
        FindObjectOfType<GameManager>().Menu();
    }

    void Restart()
    {
        FindObjectOfType<GameManager>().Restart();
    }

    void Stop()
    {
        FindObjectOfType<GameManager>().Stop();
    }

    void Up(float nb)
    {
        if (force.velocity.y <0)
        { force.AddForce(0, jumpF * Time.deltaTime*nb, 0); }
        else { force.AddForce(0, jumpF * Time.deltaTime *-nb, 0); }
        
    }

    public void EndListening()
    {
       actions.Clear();
       //keywordRecognizer.Stop();
    }

    // FixedUpdate is called once per frame for physics use, it works almost like Update but is made better for cpu interactions with physics law
    void FixedUpdate()
    {
        force.AddForce(0, 0, forwardF * Time.deltaTime);

        if (Input.GetKeyDown("space") && !isJumping)
        {
            Up(1) ;
            isJumping = true;
        }

        if (isJumping)
        {
            if (t.position.y > 3.2f) { force.AddForce(0, -jumpF/1.5f * Time.deltaTime, 0); endJump = true; }
            if (t.position.y < 1.3f && endJump) { isJumping = false; endJump = false; }
        }

        if ( Input.GetKey("d") && !isJumping && korev)
        {
            force.AddForce( sideF/3 * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if ( Input.GetKey("a") && !isJumping && korev)
        {
            force.AddForce(- sideF/3 * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (!korev )
        {
            g = TobiiAPI.GetGazePoint();
            Vector3 view = new Vector3(g.Screen.x, g.Screen.y, t.position.z);
            Vector3 vision = Camera.main.ScreenToWorldPoint(view); //vision point like the mouse
            vision.Normalize();
            float speed = vision.x;
            force.AddForce(sideF * speed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
       


        if (force.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
            EndListening();
        }
        if (!enabled) { EndListening(); }
    }
}
