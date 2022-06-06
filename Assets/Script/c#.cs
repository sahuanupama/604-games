using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cSharp : MonoBehaviour
{
    float playerSpeed = .50f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3((transform.position.x + Input.GetAxis("Horinzotal") * playerSpeed) * Time.deltaTime, transform.position.y);
    }

    private void OnCollisionEnter2D(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectille"))
        {
            Destroy(collision.gameObject);

            Destroy(gameObject);
        }

    }
}
