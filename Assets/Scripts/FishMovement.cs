using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public float speed = 2;
    private Rigidbody2D body;
    public GameObject waterSurface;
    public GameObject waterSplash; // Declare a variable for the water splash prefab
    public bool inWater = false;
    private float useSpeed;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.drag = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = Vector3.right;
        move.Normalize();
        body.AddRelativeForce(move * useSpeed);

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
