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
    public int pirateCounter = 0;
    public int coinCounter = 0;
    public float screenSizeX;
    public float screenSizeY;
    private object timerText;

    [SerializeField] Joystick joystick;
    [SerializeField] float joyHorizontal;
    [SerializeField] float joyVertical;
    [SerializeField] Camera MainCamera;
    [SerializeField] AudioSource explosion;
    [SerializeField] AudioSource yahoo;

    // Start is called before the first frame update
    void Start()
    {
        screenSizeY = MainCamera.orthographicSize * 2;
        screenSizeX = screenSizeY * Screen.width / Screen.height;
        // ScoreManager.instance.AddPoints();

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
        //  this.GetComponent<Rigidbody2D>().AddForce(newVector2(2, dropdownSpeed));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Coin"))
        {
            coinCounter++;
            Debug.Log("Coin: " + coinCounter);
            Destroy(collision.gameObject);
            if (coinCounter == 10)
            {
                Debug.Log("coin counter");
                yahoo.Play();
                SceneManager.LoadScene("WinScreen");
            }
        }
        else if (collision.gameObject.tag.Equals("Pirate"))
        {

            pirateCounter++;
            Debug.Log("Pirate: " + pirateCounter);
            Destroy(collision.gameObject);
            if (pirateCounter == 2)
            {
                Debug.Log("IN Pirate");
                explosion.Play();
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}

