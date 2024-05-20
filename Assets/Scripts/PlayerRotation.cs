using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 mouse = Input.mousePosition;
        Vector3 mouseInUnity = Camera.main.ScreenToWorldPoint(mouse);

        Vector3 player = transform.position;
        Vector3 look = mouseInUnity - player;
        look.z = 0;

        transform.right = look;

    }
}
