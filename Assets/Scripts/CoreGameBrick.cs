using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoreGameBrick : MonoBehaviour
{

    public Text LevelTextBrick;
    public int winCounterBrick = 0;
    bool winOnceBrick = false;
    public GameObject brick1;
    public GameObject brick2;
    public GameObject brick3;
    public GameObject brick4;
    public GameObject brick5;
    public GameObject brick6;
    public GameObject brick7;
    public GameObject brick8;
    public GameObject brick9;
    public GameObject brick10;
    public GameObject brick11;
    public GameObject brick12;
    public GameObject brick13;
    public GameObject brick14;
    public GameObject brick15;
    public GameObject brick16;

    List<GameObject> bricksBrick;

    private void Start()
    {
        bricksBrick = new List<GameObject>
        {
            brick1,
            brick2,
            brick3,
            brick4,
            brick5,
            brick6,
            brick7,
            brick8,
            brick9,
            brick10,
            brick11,
            brick12,
            brick13,
            brick14,
            brick15,
            brick16
        };
    }
    public void RestartGameBrick(int levelBrick = 1)
    {
        GetComponent<TimerScriptBrick>().RefreshTimerBrick();
        LevelTextBrick.text = "Level "+ levelBrick.ToString();
        int powerBrick = 1;

        if (GameObject.Find("ButtonPowerX2OnBrick").GetComponent<ButtonComponentBrick>().currentStateBrick)
        {
            powerBrick = 2;
        }
        if (GameObject.Find("ButtonSuperOnBrick").GetComponent<ButtonComponentBrick>().currentStateBrick)
        {
            powerBrick = 100;
        }
        GameObject.Find("BallBrick").GetComponent<BallControllerBrick>().StartBallBrick(powerBrick);
        int count = 1;
        foreach (var brick in bricksBrick)
        {
            brick.SetActive(true);
            brick.GetComponent<BrickScript>().RestoreBrick(2);
            if (count > 8) brick.GetComponent<BrickScript>().RestoreBrick(1 + levelBrick);
            count++;
        }
        winCounterBrick = 0;
        winOnceBrick = false;
    }


    private void Update()
    {
        if (!winOnceBrick&&winCounterBrick>=16)
        {
            winOnceBrick= true;
            winCounterBrick = 0;
            GameObject.Find("LevelsCanvasBrick").GetComponent<LevelScriptBrick>().OpenALevelBrick();
            GetComponent<JumpCanvasBrick>().JumpBrick("winBrick");
        }
    }


}
