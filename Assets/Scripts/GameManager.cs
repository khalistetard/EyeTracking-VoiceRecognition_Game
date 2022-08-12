using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool ended = false;
    public float restartT = 2f;

    public GameObject EndLevelUI;
    public void EndGame()
    {

        if (!ended)
        {
            ended = true;
            Invoke("Restart", restartT);
        }
    }
    
    public void Won()
    {
        EndLevelUI.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene( SceneManager.GetActiveScene().name );
    }

    public void Stop()
    {
        SceneManager.LoadScene("EndScene");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
