using UnityEngine;
using UnityEngine.SceneManagement;
public class EndCredit : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
