using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveTimeScript : MonoBehaviour
{
    public void Save()
    {
        

        try
        {
            DateTime dateCurrent = DateTime.Now;

            using (StreamReader reader = new StreamReader(Application.persistentDataPath + "/savetime.txt", true))
            {
                //get into exception
            }

            using (StreamWriter writer = new StreamWriter(Application.persistentDataPath + "/savetime.txt", false))
            {
                writer.WriteLine(dateCurrent.ToString("yyyy-MM-dd"));
                writer.Close();
            }
            
        }
        catch (FileNotFoundException)
        {
            
            File.Create(Application.persistentDataPath + "/savetime.txt").Close();

            using (StreamWriter writer = new StreamWriter(Application.persistentDataPath + "/savetime.txt", false))
            {
                writer.WriteLine("2003-12-12");
                writer.Close();
                
            }
        }
    }

    public DateTime Load()
    {
        try
        {
            using (StreamReader reader = new StreamReader(Application.persistentDataPath + "/savetime.txt", true))
            {
                DateTime loadedDate;
                loadedDate = System.DateTime.Parse(reader.ReadLine());
                reader.Close();
                return loadedDate;
            }
        }
        catch (FileNotFoundException)
        {
            
            
            Save();

            using (StreamReader reader = new StreamReader(Application.persistentDataPath + "/savetime.txt", true))
            {                
                DateTime loadedDate;
                loadedDate = System.DateTime.Parse(reader.ReadLine());
                reader.Close();
                return loadedDate;
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
