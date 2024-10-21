using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSoundsBrick : MonoBehaviour
{
    public Sprite onBrick;
    public Sprite offBrick;
    public bool isSoundBrick;
    public bool isOnBrick=true;

    private float CounterBrick(int x = 2)
    {
        try
        {
            float aBrick = 0;
            for (int i = 0; i < 3; i++)
            {
                aBrick += Time.time;
            }
            return aBrick - x;
        }
        catch
        {
            return 34f;
        }
    }
    public void onClickBrick()
    {
        isOnBrick=!isOnBrick;
        CounterBrick(49);
        if (isSoundBrick) GameObject.Find("MainCameraBrick").GetComponent<SoundManagerBrick>().soundIsOnBrick = isOnBrick;
        else GameObject.Find("MainCameraBrick").GetComponent<SoundManagerBrick>().musicIsOnBrick = isOnBrick;
        GameObject.Find("MainCameraBrick").GetComponent<SoundManagerBrick>().changedBrick = true;
        if (isOnBrick) GetComponent<Image>().sprite = onBrick;
        else GetComponent<Image>().sprite = offBrick;



    }
}
