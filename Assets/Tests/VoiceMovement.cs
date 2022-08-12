using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceMovement : MonoBehaviour
{
    bool continu = false;
    int previous = 0;
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    // Start is called before the first frame update
    void Start()
    {
        actions.Add("devant", Forward) ;
        actions.Add("forward", Forward);

        actions.Add("back", Back);
        actions.Add("derrière", Back);

        actions.Add("left", Left);
        actions.Add("gauche", Left);

        actions.Add("right", Right);
        actions.Add("droite", Right);

        actions.Add("down", Down);
        actions.Add("bas", Down);

        actions.Add("up", Up);
        actions.Add("haut", Up);

        actions.Add("stop", Stop);
        actions.Add("arrête", Stop);

        actions.Add("continue like that", Longer);
        actions.Add("continue comme ça", Longer);
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        Continue();
    }

    void Stop()
    {
        continu = false;
    }

    void Longer()
    {
        continu = true;
    }

    void Continue()
    {
        if (continu)
                {
            switch (previous) {
                case 0:
                    Forward();
                    break;
                case 1:
                    Up();
                    break;
                case 2:
                    Down();
                    break;
                case 3:
                    Left();
                    break;
                case 4:
                    Right();
                    break;
                case 5:
                    Back();
                    break;
            }
        }
    }

    void Up()
    {
        previous = 1;
        transform.Translate(0, 1, 0);
    }

    void Down()
    {
        previous = 2;
        transform.Translate(0, -1, 0);
    }

    void Left()
    {
        previous = 3;
        transform.Translate(-1, 0, 0);
    }

    void Right()
    {
        previous = 4;
        transform.Translate(1,0,0);
    }

    void Back()
    {
        previous = 5;
        transform.Translate(0, 0, -1);
    }

    void Forward()
    {
        previous = 0;
        transform.Translate(0, 0, 1);
    }
}
