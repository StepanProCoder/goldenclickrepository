using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvriusScript : MonoBehaviour
{
    SaveTimeScript savetime;
    private bool start = false;
    static public bool run2 = true;
    Color col;
    public Sprite evriustoolate;
    



    // Start is called before the first frame update
    void Start()
    {
        savetime = GetComponent<SaveTimeScript>();
        col = GetComponent<Image>().color;



        DateTime date = savetime.Load();
        if (date.ToString("yyyy-MM-dd") == "2003-12-12")
        {

            start = true;            
            savetime.Save();

        }
        else if((DateTime.Now - date).Days > 3)
        {
            GetComponent<Image>().sprite = evriustoolate;
            start = true;
        }

    }

    // Update is called once per frame
    void Update()
    {



        if (start)
        {

            run2 = false;

            if (col.a < 1)
            {
                col.a += 0.01f;
                GetComponent<Image>().color = col;

            }
            else if (Input.touchCount > 0)
            {
                start = false;
            }

        }
        else
        {
            if (col.a > 0)
            {
                col.a -= 0.01f;
                GetComponent<Image>().color = col;
            }
            else
            {
                run2 = true; 
            }
           
            
        }


    }

    

}
