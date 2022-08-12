using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManagement : MonoBehaviour
{

    public GameObject player;
    public GameObject target;
    public GameObject[] instantiatedObject;
    Vector3[] offsets;

    int o_type, last_type;
    int bonus = 0;
    void Start()
    {
        instantiatedObject = new GameObject[6];
        offsets = new Vector3[6];
        for (int i = 0; i < 6; i++)
        {
            NewRandomNumber();
            switch (o_type)
            {
                case 0:
                    offsets[i] = new Vector3(-5, 2, 20);
                    break;

                case 1:
                    offsets[i] = new Vector3(-5, 3, 20);
                    break;

                case 2:
                    offsets[i] = new Vector3(-5, 4, 20);
                    break;

                case 3:
                    offsets[i] = new Vector3(0f, 2, 20);
                    break;

                case 4:
                    offsets[i] = new Vector3(0f, 3, 20);
                    break;

                case 5:
                    offsets[i] = new Vector3(0f, 4, 20);
                    break;

                case 6:
                    offsets[i] = new Vector3(5, 2, 20);
                    break;
                case 7:
                    offsets[i] = new Vector3(5, 3, 20);
                    break;
                case 8:
                    offsets[i] = new Vector3(5, 4, 20);
                    break;
                case 9:
                    offsets[i] = new Vector3(-2, 1, 25);
                    bonus = 500;
                    break;
                case 10:
                    offsets[i] = new Vector3(0f, 5f, 25);
                    bonus = 1000;
                    break;
                case 11:
                    offsets[i] = new Vector3(2, 3f, 25);
                    bonus = 500;
                    break;

            }
            instantiatedObject[i] = Instantiate(target, offsets[i], target.transform.rotation) as GameObject;

            if (bonus > 0) { instantiatedObject[i].GetComponent<CollisionShooting>().AddPoint(bonus); bonus = 0; }
        }
    }

    void Update()
    {
        for (int i = 0; i < 6; i++)
        {
            if (instantiatedObject[i] != null)
            { 
            instantiatedObject[i].transform.position = player.transform.position + offsets[i];
            instantiatedObject[i].transform.Rotate(Vector3.up);
            }
        }
    }

    void NewRandomNumber()
    {
        o_type = Random.Range(0, 12);
        for (int i = 0; o_type == last_type && i < 4; i++)
        {
            o_type = Random.Range(0, 12);
        }
        last_type = o_type;
    }
}
