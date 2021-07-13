using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveScript : MonoBehaviour
{    
    
    public void Save()
    {
        CoinTouch coinTouch = GetComponent<CoinTouch>();
        
        using (StreamWriter writer = new StreamWriter(Application.persistentDataPath + "/save.txt", false))
        {
            writer.WriteLine(coinTouch.clicks);
            writer.Close();
        }
        
       
    }

    public int Load()
    {
        try
        {
            using (StreamReader reader = new StreamReader(Application.persistentDataPath + "/save.txt", true))
            {
                int clickcount;
                clickcount = System.Convert.ToInt32(reader.ReadLine());
                reader.Close();
                return clickcount;
            }
        }
        catch(FileNotFoundException)
        {
            //File.Create(Application.persistentDataPath + "/save.txt").Close();

            Save();

            using (StreamReader reader = new StreamReader(Application.persistentDataPath + "/save.txt", true))
            {                
                int clickcount;
                clickcount = System.Convert.ToInt32(reader.ReadLine());
                reader.Close();
                return clickcount;
            }
        }

    }

    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            Save();
        }
        
    }

}
