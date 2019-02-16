using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingRobot : MonoBehaviour
{
    public float speed = 1;
    public float angle = 90;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.Translate(new Vector3(0, 0, speed) * Time.deltaTime, Space.Self);
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            TurnRobot(angle);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            TurnRobot(-angle);
        }
    }

    public void TurnRobot(float angle)
    {
        this.transform.Rotate(new Vector3(0, angle, 0) * Time.deltaTime, Space.Self);
    }
}
