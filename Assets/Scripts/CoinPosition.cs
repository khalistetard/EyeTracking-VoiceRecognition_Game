using UnityEngine;

public class CoinPosition : MonoBehaviour
{
    public int nb_coins;
    public GameObject coin;
    GameObject instantiatedObject;
    int o_type, last_type;

    void Start()
    {
        for (int i = 1; i <= nb_coins; i++)
        {
            NewRandomNumber();
            switch (o_type)
            {
                case 0:
                    instantiatedObject = Instantiate(coin, new Vector3(-6, 1.5f, 1300 / nb_coins * i + 45), coin.transform.rotation);
                    break;
                case 1:
                    instantiatedObject = Instantiate(coin, new Vector3(-4, 1.5f, 1300 / nb_coins * i + 45), coin.transform.rotation);
                    break;
                case 2:
                    instantiatedObject = Instantiate(coin, new Vector3(-2, 1.5f, 1300 / nb_coins * i + 45), coin.transform.rotation);
                    break;
                case 3:
                    instantiatedObject = Instantiate(coin, new Vector3(0, 1.5f, 1300 / nb_coins * i + 45), coin.transform.rotation);
                    break;
                case 4:
                    instantiatedObject = Instantiate(coin, new Vector3(2, 1.5f, 1300 / nb_coins * i + 45), coin.transform.rotation);
                    break;
                case 5:
                    instantiatedObject = Instantiate(coin, new Vector3(4, 1.5f, 1300 / nb_coins * i + 45), coin.transform.rotation);
                    break;
                case 6:
                    instantiatedObject = Instantiate(coin, new Vector3(6, 1.5f, 1300 / nb_coins * i + 45), coin.transform.rotation);
                    break;
            }
        }
    }


    void NewRandomNumber()
    {
        o_type = Random.Range(0, 7);
        for (int i = 0; o_type == last_type && i < 4; i++)
        {
            o_type = Random.Range(0, 7);
        }
        last_type = o_type;
    }
}
