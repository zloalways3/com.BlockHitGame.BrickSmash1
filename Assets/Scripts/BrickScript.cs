using UnityEngine;
using UnityEngine.UI; 

public class BrickScript : MonoBehaviour
{
    public int hitPointsBrick = 3; 
    public Text hitTextBrick; 

    void Start()
    {
        hitTextBrick.text = hitPointsBrick.ToString();
    }

    public void HitBrick(int damageBrick)
    {
        hitPointsBrick=hitPointsBrick-damageBrick;
        hitTextBrick.text = hitPointsBrick.ToString();

        if (hitPointsBrick <= 0)
        {
            gameObject.SetActive(false);
            hitTextBrick.text = "";
            GameObject.Find("MainCameraBrick").GetComponent<SoundManagerBrick>().PlayPingBrick();
            GameObject.Find("GamePartBrick").GetComponent<CoreGameBrick>().winCounterBrick++;
        }
        else GameObject.Find("MainCameraBrick").GetComponent<SoundManagerBrick>().PlayClickBrick();
    }

    public void RestoreBrick(int newhitPoints=2)
    {
        hitPointsBrick = newhitPoints;
        hitTextBrick.text = newhitPoints.ToString();
    }
}
