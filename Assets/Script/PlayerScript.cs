using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float playerSpeed = 1f;
    public float halfPlayerSize = 0.5f;

    [SerializeField] Joystick joystick;
    [SerializeField] float joyHorizontal;
    [SerializeField] float joyVertical;

    [SerializeField] Camera camera;
    public float screenSizeX;
    public float screenSizeY;


    //[SerializeField] AudioSource explosion;


    // Start is called before the first frame update
    void Start()
    {

        screenSizeY = camera.orthographicSize * 2;
        screenSizeX = screenSizeY * Screen.width / Screen.height;

    }

    // Update is called once per frame
    void Update()
    {
        /*jooyHorizontal = joystick.Horizontal;
        joyVertical
        if ()) {
            SpriteRenderer render = this.GetComponent<SpriteRenderer>();
        }
*/

        joyHorizontal = joystick.Horizontal;
        joyVertical = joystick.Vertical;

        float horizonalMovement = joystick.Horizontal * playerSpeed * Time.deltaTime;
        float verticalMovement = joystick.Vertical * playerSpeed * Time.deltaTime;

        Vector2 playerPos = new Vector2(this.transform.position.x, this.transform.position.y);
        float newXPos = playerPos.x + horizonalMovement;
        float newYPos = playerPos.y + verticalMovement;



        if ((newXPos < screenSizeX - 1 && newXPos > 0)
            && (newYPos < screenSizeY - 1 && newYPos > 0))
        {
            transform.position = new Vector2(newXPos, newYPos);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            //  explosion.Play();

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }


}

