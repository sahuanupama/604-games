using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public float playerSpeed = 1f;
    public float halfPlayerSize = 0.5f;
    public float myTimer = 60f;
    public float dropdownSpeed = -2;
    public int counter = 0;
    public int wincounter = 0;

    [SerializeField] Joystick joystick;
    [SerializeField] float joyHorizontal;
    [SerializeField] float joyVertical;

    [SerializeField] Camera camera;
    public float screenSizeX;
    public float screenSizeY;
    private object timerText;


    [SerializeField] AudioSource explosion;


    // Start is called before the first frame update
    void Start()
    {

        screenSizeY = camera.orthographicSize * 2;
        screenSizeX = screenSizeY * Screen.width / Screen.height;
        // ScoreManager.instance.AddPoints();
        counter = 0;

        if (PlayerPrefs.GetInt("Difficulty").Equals(0))
        {
            dropdownSpeed = -2;
        }
        else if (PlayerPrefs.GetInt("Difficulty").Equals(1))
        {
            dropdownSpeed = -4;
        }
        else
        {
            dropdownSpeed = -6;
        }

    }

    // Update is called once per frame
    void Update()
    {
        joyHorizontal = joystick.Horizontal;
        joyVertical = joystick.Vertical;
        /*
                if ()
                {
                    SpriteRenderer render = this.GetComponent<SpriteRenderer>();
                }*/


        joyHorizontal = joystick.Horizontal;
        joyVertical = joystick.Vertical;

        float horizonalMovement = joystick.Horizontal * playerSpeed * Time.deltaTime;
        float verticalMovement = joystick.Vertical * playerSpeed * Time.deltaTime;

        Vector2 playerPos = new Vector2(this.transform.position.x, this.transform.position.y);
        float newXPos = playerPos.x + horizonalMovement;
        float newYPos = playerPos.y + verticalMovement;



        if ((newXPos < screenSizeX - 0.5f && newXPos > 0.5f)
            && (newYPos < screenSizeY - 0.3f && newYPos > 0.3f))
        {
            transform.position = new Vector2(newXPos, newYPos);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        counter++;

        if (collision.gameObject.tag.Equals("Coin"))
        {
            wincounter++;
            if (wincounter == 3)
            {
                SceneManager.LoadScene("WinScreen");
            }
        }

        /*
                if (collision.gameObject.tag.Equals("Coin"))
                {
                    explosion.Play();

                    Destroy(collision.gameObject);
                }*/


        else if (collision.gameObject.tag.Equals("Pirate"))
        {
            Destroy(collision.gameObject);

            counter++;
            if (counter == 2)
            {
                SceneManager.LoadScene("GameOver");
            }
        }


        /*if (collision.gameObject.tag.Equals("Coin"))
        {
            CoinCatch.Play();
            GameObject.Destroy(Collision.gameObject);
            CoinCount = CounCount + 1;
        }
    }

    *//*  if (collision.gameObject.CompareTag("Pirate"))
      {
          myTimer -= Time.deltaTime;
          timerText.text = myTimer.ToString("f0");
      }

      if (myTimer <= 5)
       {
            SceneManager.LoadScene("WinScreen");
        }
       
    private void OnTiggerEnter2D(Collider2D collision)
    {
         else if (pirateCollision.ganeObject.tag.equals("pirate"))
        {
            Destroy(collision.gameObject.tag.Equals("Pirate"));
        }
    }*/
    }
}

