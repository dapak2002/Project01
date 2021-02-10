using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class EventManagerScript : MonoBehaviour
{
    //File that will be created or edited
    private string filepath = "log.txt";

    // Start is called before the first frame update
    void Start()
    {
        CreateFile();
        StartMessage();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            SpaceKeyPressed();
        }
    }

    //Creates file at location
    private void CreateFile()
    {
        if (!File.Exists(filepath))
        {
            File.Create(filepath).Close();
        }
    }

    //Prints file content to console
    private void ReadFile()
    {
        using (StreamReader reader = new StreamReader(filepath))
        {
            while (!reader.EndOfStream) //reading the file we haven't reached the end
            {
                Debug.Log(reader.ReadLine());
            }
        }
    }

    //Writes text to file and prints to console
    private void WriteFile(string text)
    {
        using (StreamWriter writer = new StreamWriter(filepath,true))
        {
            writer.WriteLine(text);
            Debug.Log(text);
        }
    }
    

    //Called when button is clicked
    public void ButtonClicked()
    {
        DateTime date1 = DateTime.Now;
        WriteFile(date1 + ": BUTTON WAS CLICKED.");
    }

    //Called when space bar is pressed
    public void SpaceKeyPressed()
    {
        DateTime date1 = DateTime.Now;
        WriteFile(date1 + ": Space key pressed.");
    }

    //Logs and prints message on program startup.
    private void StartMessage()
    {
        DateTime date1 = DateTime.Now;
        WriteFile(date1 + ": Program started.");
    }

    //Logs and prints closing message
    void OnApplicationQuit()
    {

        DateTime date1 = DateTime.Now;
        WriteFile(date1 + ": Program closed.");
    }
}
