using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SheepCounterManager : MonoBehaviour
{
    public static SheepCounterManager instance;

    private int sheepCounter = 0;
    private int maxSavedSheep;
    [SerializeField]
    private GameObject[] sheepImageUI;
    
    private Color UIImageColor;

    //**
    //AGregado en el codigo de Diana para evitar cargas repetidas
    private bool sceneLoading;
    public bool AllSheepSaved => sheepCounter >= maxSavedSheep; // lo declaro publico para consultarlo desd el scritp del timer
    //**

    private void Awake()
    {
        instance = this;
        UIImageColor = new Color(1, 1, 1, 1);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        print("StartSheepCounter");
        Color UIImageAlphaColor = new Color(1, 1, 1, 0.3f);
        
        sheepImageUI = GameObject.FindGameObjectsWithTag("SheepImageUI").OrderBy(go => go.name).ToArray();
        foreach (var image in sheepImageUI)
        {
            image.GetComponent<Image>().color = UIImageAlphaColor;
        }
        maxSavedSheep = sheepImageUI.Length;
    }

    public void AddSavedSheep()
    {
        
        print("AddSavedSheep");
        if (sheepCounter < maxSavedSheep)
        {
            SetSheepImageUI();
            sheepCounter++;
        }

        //**
        Debug.Log("AddSabedSheep");
        if (sceneLoading)
        {
            return;
        }

        if (sheepCounter >= maxSavedSheep)
        {
            if (CountdownTimerManager.instance != null)
            {
                CountdownTimerManager.instance.StopTimerAndLoad("Level2");
            }
            else
            {
                //  sceneLoading = true;
            SceneManager.LoadScene("Level2");
            }
           
        }

        //**


        // if (sheepCounter >= maxSavedSheep)
        // {
        //    SceneManager.LoadScene(3);
        // }
    }
    private void SetSheepImageUI()
    {
        sheepImageUI[sheepCounter].GetComponent<Image>().color = UIImageColor;
    }
}
