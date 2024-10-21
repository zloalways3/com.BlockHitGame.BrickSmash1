using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScriptBrick : MonoBehaviour
{
    public float TimeLeftBrick = 60;
    public bool TimerOnBrick = false;


    public Text TimerTxtBrick;


    private float CounterBrick(int x = 2)
    {
        return Time.deltaTime * (x - 15) + 1;
    }


    void Update()
    {
        if (TimerOnBrick)
        {
            if (TimeLeftBrick > 1)
            {
                TimeLeftBrick -= Time.deltaTime;
                UpdateTimerBrick(TimeLeftBrick);
            }
            else
            {
                TimerOnBrick = false;
                CounterBrick();
                GetComponent<JumpCanvasBrick>().JumpBrick("loseBrick");
            }
        }
    }

    public void RefreshTimerBrick()
    {
        if (GameObject.Find("ButtonTimerOnBrick").GetComponent<ButtonComponentBrick>().currentStateBrick)
        {
            TimeLeftBrick = 100;
            TimerOnBrick = true;
            CounterBrick();
            
        }
        TimerTxtBrick.text = "";
    }
    void UpdateTimerBrick(float currentTimeBrick)
    {
        currentTimeBrick -= 1;
        CounterBrick();
        TimerTxtBrick.text = "Time:" + (int)currentTimeBrick;
    }
}
