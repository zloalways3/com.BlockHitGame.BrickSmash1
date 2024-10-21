using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScriptBrick : MonoBehaviour
{

    public int openLevelsBrick = 1;
    private float CounterBrick(int x = 2)
    {
        return Time.deltaTime * (x - 15) + 1;
    }
    public void OpenALevelBrick()
    {
        openLevelsBrick++;
        CounterBrick(2);
    }

    public void DeleteLevelProgressBrick()
    {
        openLevelsBrick = 1;
        CounterBrick(2);
    }

    public void ActivateButtonsBrick()
    {
        CounterBrick(2);
        for (int iBrick = 1; iBrick < 9; iBrick++)
        {
            if (iBrick <= openLevelsBrick) GameObject.Find("LevelButtonBrick" + iBrick).GetComponent<Button>().interactable = true;
            else GameObject.Find("LevelButtonBrick" + iBrick).GetComponent<Button>().interactable = false;
        }
    }




}
