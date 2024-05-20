using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D body;
    public GameObject waterSurface;
    public GameObject waterSplash; 
    private float useSpeed;
    public bool inWater = false;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.drag = 0;

    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(hor, ver, 0);
        move.Normalize();
        body.velocity = move * speed;

        if (transform.position.y < waterSurface.transform.position.y)
        {
            body.gravityScale = 0;
            body.drag = 1;
            useSpeed = speed;

            if (!inWater)
            {
                Vector3 splashPos = transform.position;
                splashPos.y = waterSurface.transform.position.y;
                GameObject splashClone = Instantiate(waterSplash, splashPos, Quaternion.identity);
                Destroy(splashClone, 0.5f);
            }
            inWater = true;

        }
        else
        {
            body.gravityScale = 1;
            body.drag = 0;
            useSpeed = 0;

            if (inWater)
            {
                Vector3 splashPos = transform.position;
                splashPos.y = waterSurface.transform.position.y;
                GameObject splashClone = Instantiate(waterSplash, splashPos, Quaternion.identity);
                Destroy(splashClone, 0.5f);
            }

            inWater = false;
        }

    }
}
