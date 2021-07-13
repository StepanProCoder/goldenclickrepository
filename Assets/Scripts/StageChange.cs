using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageChange : MonoBehaviour
{
    AudioSource coincrack;
    CoinTouch coin;
    GameObject reward1, reward2, reward3;

    public bool run = true;
    private bool nextstage = false;
    private bool sendback = false;

    // Start is called before the first frame update
    void Start()
    {
        coincrack = GetComponents<AudioSource>()[2];
        coin = GetComponent<CoinTouch>();
        reward1 = GameObject.Find("reward1");
        reward2 = GameObject.Find("reward2");
        reward3 = GameObject.Find("reward3");
    }

    void Update()
    {
        if(nextstage)
        {
            if(coin.clicks == 3000)
            {
                if (reward1.transform.localPosition.y > 0 && !sendback)
                {
                    reward1.transform.Translate(Vector2.down * Time.deltaTime * 8);
                }
                else if(Input.touchCount > 0)
                {
                    sendback = true;
                }
            }
            else if(coin.clicks == 8000)
            {
                if (reward2.transform.localPosition.y > 0 && !sendback)
                {
                    reward2.transform.Translate(Vector2.down * Time.deltaTime * 8);
                }
                else if (Input.touchCount > 0)
                {
                    sendback = true;
                }
            }
            else if(coin.clicks == 15000)
            {
                if (reward3.transform.localPosition.y > 0 && !sendback)
                {
                    reward3.transform.Translate(Vector2.down * Time.deltaTime * 8);
                }
                else if (Input.touchCount > 0)
                {
                    sendback = true;
                }
            }


            if(sendback)
            {
                if (coin.clicks == 3000)
                {

                    if (reward1.transform.localPosition.y < 15)
                    {
                        reward1.transform.Translate(Vector2.up * Time.deltaTime * 8);
                    }
                    else
                    {
                        sendback = false;
                        nextstage = false;
                        run = true;
                    }
                }
                else if(coin.clicks == 8000)
                {
                    if (reward2.transform.localPosition.y < 15)
                    {
                        reward2.transform.Translate(Vector2.up * Time.deltaTime * 8);
                    }
                    else
                    {
                        sendback = false;
                        nextstage = false;
                        run = true;
                    }
                }
                else if(coin.clicks == 15000)
                {
                    if (reward3.transform.localPosition.y < 15)
                    {
                        reward3.transform.Translate(Vector2.up * Time.deltaTime * 8);
                    }
                    else
                    {
                        sendback = false;
                        nextstage = false;
                        run = true;
                    }
                }


            }

        }

        
    }

    public void nextStage()
    {
        coincrack.Play();
        run = false;
        nextstage = true;
    }
}
