using UnityEngine;
using UnityEngine.UI;

public class ButtonComponentBrick : MonoBehaviour
{

    public Sprite onStateBrick;
    public Sprite offStateBrick;
    public bool currentStateBrick = false;
    public Button counterpartBrick;

    private void Start()
    {
        if (currentStateBrick)
        {
            GetComponent<Image>().sprite = onStateBrick;
        }
        else GetComponent<Image>().sprite = offStateBrick;
    }


    public void ClickBrick(bool directBrick = true)
    {
        currentStateBrick = !currentStateBrick;
        if (currentStateBrick)
        {
            GetComponent<Image>().sprite = onStateBrick;
        }
        else GetComponent<Image>().sprite = offStateBrick;
        if(directBrick) counterpartBrick.GetComponent<ButtonComponentBrick>().ClickBrick(false);
    }

}
