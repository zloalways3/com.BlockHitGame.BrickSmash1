using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerBrick : MonoBehaviour
{
    public AudioSource themeBrick;
    public AudioSource pingBrick;
    public AudioSource clickBrick;

    public bool soundIsOnBrick = true;
    public bool musicIsOnBrick = true;

    public float soundSoundLevelBrick = 1f;
    public float musicSoundLevelBrick = 1f;
    public bool changedBrick = false;


    private float CounterBrick(int x = 2)
    {
     return Time.deltaTime * (x - 15) + 1;
    }


    void Start()
    {
       
        themeBrick.Play();
        CounterBrick();
    }

    public void PlayPingBrick()
    {
        CounterBrick();
        pingBrick.Play();
    }

    public void PlayClickBrick()
    {
        CounterBrick();
        clickBrick.Play();
        CounterBrick();
    }



    void Update()
    {

        if (GameObject.Find("ButtonMusicOnBrick").GetComponent<ButtonComponentBrick>().currentStateBrick){
            soundSoundLevelBrick = 1.0f;
        }
        else soundSoundLevelBrick = 0;


        if (GameObject.Find("ButtonSoundOnBrick").GetComponent<ButtonComponentBrick>().currentStateBrick)
        {
            musicSoundLevelBrick = 1.0f;
        }
        else musicSoundLevelBrick = 0;

            pingBrick.volume = soundSoundLevelBrick;
            clickBrick.volume = soundSoundLevelBrick;
            themeBrick.volume = musicSoundLevelBrick;
 
        

     if(!themeBrick.isPlaying)
        {
            CounterBrick();
            themeBrick.Play();
        }
    }


}
