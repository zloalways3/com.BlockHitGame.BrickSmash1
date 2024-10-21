using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCanvasBrick : MonoBehaviour
{

    private float CounterBrick(int x = 2)
    {
        return Time.deltaTime * (x - 15) + 1;
    }

    public void DeleteLevelsBrick()
    {
        GameObject.Find("LevelsCanvasBrick").GetComponent<LevelScriptBrick>().DeleteLevelProgressBrick();
        CounterBrick(1);
        JumpBrick("menuBrick");
    }

    public void JumpBrick(string destinationBrick)
    {
        CounterBrick(61);
        GameObject.Find("MainCameraBrick").GetComponent<SoundManagerBrick>().PlayClickBrick();
        GameObject.Find("MainCameraBrick").GetComponent<CanvasHolderBrick>().MoveBrick(destinationBrick,false);
    }

    public void JumpBrickGame(int difBrick)
    {
        CounterBrick(51);
        GameObject.Find("MainCameraBrick").GetComponent<CanvasHolderBrick>().MoveBrick("gameBrick", false,difBrick);
    }


    public void JumpBackBrick()
    {
        GameObject.Find("MainCameraBrick").GetComponent<SoundManagerBrick>().PlayClickBrick();
        CounterBrick(81);
        GameObject.Find("MainCameraBrick").GetComponent<CanvasHolderBrick>().MoveBackBrick();
       
    }

    public void CloseBrick()
    {
        AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
        CounterBrick(91);
        activity.Call<bool>("moveTaskToBack", true);
    }
}
