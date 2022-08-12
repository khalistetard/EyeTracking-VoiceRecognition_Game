using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform tplayer;
    float sc;
    float bonus =0;
    public Text score;
    // Update is called once per frame
    void Update()
    {
        sc = tplayer.position.z + bonus;
        score.text = sc.ToString("0");
    }
    public void UpdateScore(float s)
    {
        bonus += s;
    }
}
