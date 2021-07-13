using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinTouch : MonoBehaviour
{

    private Animator animator;
    private SaveScript save;
    private TextMeshProUGUI clicksview;
    private AudioSource coinstartsound;
    private AudioSource coincontsound;
    private StageChange stageChange;

    private bool check = true;
    private bool plus = true;
    private bool candark = true;

    private int delay = 0;
    public int clicks = 0;
    
   

    void Start()
    {
        animator = GetComponent<Animator>();
        clicksview = GameObject.Find("clicksview").GetComponent<TextMeshProUGUI>();
        coinstartsound = GetComponents<AudioSource>()[0];
        coincontsound = GetComponents<AudioSource>()[1];
        save = GetComponent<SaveScript>();
        stageChange = GetComponent<StageChange>();
        clicks = save.Load();
        animator.SetInteger("clickscount", clicks);       
        clicksview.SetText(clicks + "");
    }


    void Update()
    {

        if (stageChange.run && EvriusScript.run2)
        { 

        for (var i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position), Vector2.zero);

                if (hitInfo)
                {
                    animator.SetBool("spinned", true);

                    if (check)
                    {
                        coinstartsound.Play();
                        check = false;
                    }
                    else
                    {
                        coincontsound.Play();
                    }

                    if (plus)
                    {
                        clicks += 500;
                    }
                    animator.SetInteger("clickscount", clicks);

                    if (clicks == 3000 || clicks == 8000 || clicks == 15000)
                    {                           
                           
                        plus = false;
                            
                    }

                    delay = 0;
                }

            }

            delay++;

        }

        if (Input.touchCount == 0)
        {
            delay++;
        }

        

            //if (Input.GetMouseButtonDown(0))
            //{
            //    Vector2 pos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            //    RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(pos), Vector2.zero);

            //    if (hitInfo)
            //    {
            //        animator.SetBool("spinned", true);
            //        clicks++;
            //        clicksview.SetText(clicks + "");
            //        delay = 0;
            //    }
            //    else
            //    {
            //        delay++;
            //    }
            //}
            //else
            //{
            //    delay++;
            //}



        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && (animator.GetCurrentAnimatorStateInfo(0).IsName("CoinSpin") || animator.GetCurrentAnimatorStateInfo(0).IsName("CoinSpin1") || animator.GetCurrentAnimatorStateInfo(0).IsName("CoinSpin2") || animator.GetCurrentAnimatorStateInfo(0).IsName("CoinSpin3")) && (delay >= 20 || !plus))
        {
            Stop();

            if(!plus)
            {                    
                Lighten();
                candark = false;
                stageChange.nextStage();
                plus = true;
            }
        }



        if (animator.GetCurrentAnimatorStateInfo(0).IsName("CoinSpin") || animator.GetCurrentAnimatorStateInfo(0).IsName("CoinSpin1") || animator.GetCurrentAnimatorStateInfo(0).IsName("CoinSpin2") || animator.GetCurrentAnimatorStateInfo(0).IsName("CoinSpin3"))
        {
            if(candark)
            {
                Darken();
            }
            else
            {
                candark = true;
            }
            
        }
        else if (clicksview.color.a == 0)
        {
            Lighten();
        }



        }

    }

    private void Stop()
    {
        animator.SetBool("spinned", false);
        check = true;
        coinstartsound.Stop();
        coincontsound.Stop();
    }

    private void Darken()
    {
        Color col = clicksview.color;
        col.a = 0;
        clicksview.color = col;
    }

    private void Lighten()
    {
        Color col = clicksview.color;
        col.a = 255;
        clicksview.color = col;
        clicksview.SetText(clicks + "");
    }


}
