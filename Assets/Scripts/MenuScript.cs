using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public static bool korev= true; //Keyboard (true) or Eye and Voice (false) boolean
    public Text text;
    public void StartCoinP() 
    {
        SceneManager.LoadScene("CoinPicking");
    }

    public void StartShooting()
    {
        SceneManager.LoadScene("ShootingGame");
    }

    public void ChangeControl()
    {
        korev = !korev;
        if (korev)
        {
            text.text = "Keyboard";
        }else { text.text = "Eyes and Voice"; }
    }
}
