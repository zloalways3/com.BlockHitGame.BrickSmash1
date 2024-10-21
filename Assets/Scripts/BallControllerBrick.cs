using UnityEngine;
using UnityEngine.UI;

public class BallControllerBrick : MonoBehaviour
{
    public float speedBrick = 5f;
    private Vector2 directionBrick;
    private Vector3 StartPositionBrick;
    private int strengthBrick = 1;
    private bool oncePosBrick = true;
    private Vector2 savedVelocity;

    private void Start()
    {
        StartPositionBrick = transform.position;
  
    }
    public void StartBallBrick(int newStrengthBrick = 1)
    {
        if (oncePosBrick)
        {
            StartPositionBrick = transform.position;
            oncePosBrick = false;
        }
        transform.position= StartPositionBrick;
        directionBrick = new Vector2(1, 1).normalized; 
        GetComponent<Rigidbody2D>().velocity = directionBrick * speedBrick; 
        strengthBrick= newStrengthBrick;
    }

    public void SaveVelocity()
    {
        savedVelocity = directionBrick * speedBrick;
    }

    public void RestoreVelocity()
    {
        GetComponent<Rigidbody2D>().velocity = savedVelocity;
    }

    void Update()
    {
  

        if (transform.localPosition.y < -Camera.main.orthographicSize) 
        {
            Debug.Log("Game Over");
            GetComponent<JumpCanvasBrick>().JumpBrick("loseBrick");

        }


    }

    private void OnCollisionEnter2D(Collision2D collisionBrick)
    {
   
        Debug.Log("Collided with: " + collisionBrick.gameObject.name); 
        if (collisionBrick.gameObject.CompareTag("Brick"))
        {
            BrickScript brick = collisionBrick.gameObject.GetComponent<BrickScript>();
            if (brick != null)
            {
                brick.HitBrick(strengthBrick); 
                directionBrick.y *= -1;
                GetComponent<Rigidbody2D>().velocity = directionBrick * speedBrick;
            }
        }
        else if (collisionBrick.gameObject.CompareTag("Pad"))
        {
            directionBrick.y *= -1;
            GetComponent<Rigidbody2D>().velocity = directionBrick * speedBrick; 
        }
        else if (collisionBrick.gameObject.CompareTag("Pad1"))
        {
            directionBrick.x*= -1;
            GetComponent<Rigidbody2D>().velocity = directionBrick * speedBrick; 
        }
    }
}
