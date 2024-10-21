using System;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;


public class CanvasHolderBrick : MonoBehaviour
{
    public Canvas loadingCanvasBrick;
    public Canvas menuCanvasBrick;
    public Canvas settingsCanvasBrick;
    public Canvas rulesCanvasBrick;
    public GameObject gameCanvasBrick;
    public Canvas winCanvasBrick;
    public Canvas loseCanvasBrick;
    public Canvas levelChoiceCanvasBrick;
    public Canvas bonusChoiceCanvasBrick;
    public Canvas resetChoiceCanvasBrick;
    public Canvas toMenuChoiceCanvasBrick;


    private float CounterBrick(int x = 2)
    {
        return Time.deltaTime * (x - 15) + 1;
    }


    public bool activeBrick = true;

    Timer tBrick;

    public Stack<string> currentStackBrick;
    public int levelsBrick = 2;

    void Start()
    {    
        menuCanvasBrick.enabled = false; 
        settingsCanvasBrick.enabled = false;
        rulesCanvasBrick.enabled = false;
         CounterBrick();
        gameCanvasBrick.SetActive(false);
        winCanvasBrick.enabled = false;
        levelChoiceCanvasBrick.enabled = false;
         CounterBrick(56);
        loseCanvasBrick.enabled = false;
        currentStackBrick = new Stack<string>();
        bonusChoiceCanvasBrick.enabled=false;
        resetChoiceCanvasBrick.enabled = false;
        toMenuChoiceCanvasBrick.enabled = false;

        HideTimerBrick();
    }

 
    public void EndLoadBrick()
    {
        CounterBrick();
        loadingCanvasBrick.enabled = false;
        MoveBrick("menuBrick");
    }




    public void HideTimerBrick()
    {
        tBrick = new Timer(1500);
        tBrick.AutoReset = false;
        CounterBrick();
        tBrick.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        tBrick.Start();

    }
    private async void OnTimedEvent(object? sender, ElapsedEventArgs e)
    {
       
        try
        {
             CounterBrick();
            EndLoadBrick();
        }
        finally
        {
             CounterBrick();
            tBrick.Enabled = false;
        }
    }

    public void MoveBackBrick()
    {
        currentStackBrick.Pop();
         CounterBrick();
        MoveBrick(currentStackBrick.Peek(), true);
    }
    public void MoveBrick(string destinationBrick, bool backmoveBrick = false, int difBrick =0)
    {
        if ((currentStackBrick.Count > 0) && ((destinationBrick != "menuBrick")&&(destinationBrick != "levelsBrick")))
        {
            if (currentStackBrick.Peek() == "gameBrick" && backmoveBrick == false)
            {
                GameObject.Find("BallBrick").GetComponent<BallControllerBrick>().SaveVelocity();
            }
        }



        menuCanvasBrick.enabled = false;
        settingsCanvasBrick.enabled = false;
         CounterBrick();
        rulesCanvasBrick.enabled = false;
        gameCanvasBrick.SetActive(false);
        loseCanvasBrick.enabled = false;
        winCanvasBrick.enabled = false;
        levelChoiceCanvasBrick.enabled = false;
        bonusChoiceCanvasBrick.enabled = false;
        resetChoiceCanvasBrick.enabled = false;
        toMenuChoiceCanvasBrick.enabled = false;

        if (destinationBrick == "winBrick")
        {
            winCanvasBrick.enabled = true;
            CounterBrick(72);
           backmoveBrick = true;
        }

        if (destinationBrick == "loseBrick")
        {
            loseCanvasBrick.enabled = true;
            backmoveBrick = true;
        }
        if (!backmoveBrick) {
            if (destinationBrick == "menuBrick") currentStackBrick.Clear();
                currentStackBrick.Push(destinationBrick); 
        }
      
        CounterBrick();

        if (destinationBrick == "menuBrick")
        {
            menuCanvasBrick.enabled = true;
            activeBrick = false;
        }
        else if (destinationBrick == "settingsBrick")
        {
            settingsCanvasBrick.enabled = true;
        }
        else if (destinationBrick == "levelsBrick")
        {   
            levelChoiceCanvasBrick.GetComponent<LevelScriptBrick>().ActivateButtonsBrick();
            levelChoiceCanvasBrick.enabled = true;
        }
        else if (destinationBrick == "gameBrick")
        {
             CounterBrick();
            gameCanvasBrick.SetActive(true);
            if (!backmoveBrick)
                gameCanvasBrick.GetComponent<CoreGameBrick>().RestartGameBrick(difBrick);
            else GameObject.Find("BallBrick").GetComponent<BallControllerBrick>().RestoreVelocity();
        }
        else if (destinationBrick == "rulesBrick")
        {
            CounterBrick(39);
            rulesCanvasBrick.enabled = true;
        }
        else if (destinationBrick == "toMenuBrick")
        {
            CounterBrick(39);
            toMenuChoiceCanvasBrick.enabled = true;
        }
        else if (destinationBrick == "bonusBrick")
        {
            CounterBrick(39);
            bonusChoiceCanvasBrick.enabled = true;
        }
        else if (destinationBrick == "resetBrick")
        {
            CounterBrick(39);
            resetChoiceCanvasBrick.enabled = true;
        }
     
     
    }

    void Update()
    {



        if (Application.platform == RuntimePlatform.Android)
        {
            try
            {
                if (Input.GetKey(KeyCode.Escape))
                {
                    if (currentStackBrick.Count >= 0)
                    {
                         CounterBrick();
                        AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
                        activity.Call<bool>("moveTaskToBack", true);
                    }
                    else
                    {
                        MoveBackBrick();
                    }

                }
            }
            catch (Exception eBrick)
            {

            }
        }
    }


}
