using UnityEngine;
using UnityEngine.UI;

public class PaddleControllerBrick : MonoBehaviour
{
    public float speedBrick = 10f;
    private float screenWidthBrick;

    void Start()
    {
        // Get the screen width in world units
        screenWidthBrick = Camera.main.orthographicSize * Camera.main.aspect;
    }

    void Update()
    {
        // Check for touch input
        if (Input.touchCount > 0)
        {
            Touch touchBrick = Input.GetTouch(0);
            Vector3 touchPositionBrick = Camera.main.ScreenToWorldPoint(touchBrick.position);
            touchPositionBrick.z = 0; // Set z to 0 for 2D

            // Update paddle position based on touch
            transform.position = new Vector3(touchPositionBrick.x, transform.position.y, transform.position.z);
        }

        // Clamp the paddle position to screen boundaries
        float paddleWidth = GetComponent<Renderer>().bounds.extents.x; // Half the width of the paddle
        float screenLeft = -screenWidthBrick + paddleWidth;
        float screenRight = screenWidthBrick - paddleWidth;

        Vector3 paddlePosition = transform.position;
        paddlePosition.x = Mathf.Clamp(paddlePosition.x, screenLeft, screenRight);
        transform.position = paddlePosition;
    }
}
