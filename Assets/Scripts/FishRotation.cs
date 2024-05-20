using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishRotation : MonoBehaviour
{
    public float rotateTime = 2;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        timer = rotateTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime; //countdown
        Vector3 look = transform.right;
        if (timer <= 0)
        {
            look = Random.insideUnitCircle;
            look.z = 0;

            transform.right = look;

            timer = rotateTime;
        }

    }
}
