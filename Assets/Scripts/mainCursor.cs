using UnityEngine;
using Tobii.Gaming;

public class mainCursor : MonoBehaviour
{

    public GameObject player;
    public Transform camerat;

    Ray ray;
    RaycastHit hit;

    GazePoint gp;

    bool korev = true; //Keyboard (true) or Eye and Voice (false) boolean

    Vector3 cursorpos;
    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        sprite = GetComponent<SpriteRenderer>();
        korev = MenuScript.korev;
    }

    // FixedUpdate is called once per frame for physics use, it works almost like Update but is made better for cpu interactions with physics law
    void FixedUpdate()
    {
        if (korev)
        {
            cursorpos = Input.mousePosition;
            cursorpos += Camera.main.transform.forward * 5f;
            //cursorpos.z = player.transform.position.z - 5;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        }
        else {
            gp = TobiiAPI.GetGazePoint();
            cursorpos = gp.Screen;
            // activate if problem with the beginning of the cursor creation:
            //if (gp.Screen.x == null || gp.Screen.y == null) { cursorpos.x = camerat.position.x; cursorpos.y = camerat.position.y; }
            cursorpos.z = player.transform.position.z - 5;
            ray = Camera.main.ScreenPointToRay(gp.Screen);
        }
        transform.position = Camera.main.ScreenToWorldPoint(cursorpos);
       
        Vector3 target;
        if (Physics.Raycast(ray, out hit, 1000))
        {
            target = transform.position;
            if (hit.transform != null)
            { target = hit.point; }
            
            
        }
        else
        {
            target = transform.position;
        }
        player.GetComponent<MovementsShooting>().setTarget(target);
        if (player.GetComponent<MovementsShooting>().GetIsShooting() == true) { sprite.color = new Color(255, 0, 0, 255); }


    }
}
