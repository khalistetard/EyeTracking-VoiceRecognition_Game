using UnityEngine;
using UnityEngine.UI;
public class ScoreShooting : MonoBehaviour
{
    float sc;
    float bonus = 0;
    public Text score;
    // Update is called once per frame
    void Update()
    {
        sc = bonus;
        score.text = sc.ToString("0");
    }
    public void UpdateScore(float s)
    {
        bonus += s;
    }
}
