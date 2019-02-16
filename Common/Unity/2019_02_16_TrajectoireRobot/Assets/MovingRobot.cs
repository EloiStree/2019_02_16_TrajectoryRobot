using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingRobot : MonoBehaviour
{
    [Header("Fake with controller")]
    public float speed = 1;
    public float angle = 90;
    // Start is called before the first frame update

    [Header("Angluar input wheel")]
    public float leftWheel;
    public float rightWheel;

    public float rayon = 0.1f;

    public void SetAngluareRotationLeft(float angle)
    {
        leftWheel = angle;
    }
    public void SetAngluareRotationRight(float angle)
    {
        rightWheel = angle;
    }

    // Update is called once per frame
    void Update()
    {


        MoveForward(speed * Input.GetAxis("Vertical"));
        TurnRobot(angle * Input.GetAxis("Horizontal"));

        float fakeRotation = leftWheel + -rightWheel;
        float fakeAngluareMove = leftWheel + rightWheel;

            
        MoveForward( ( Mathf.Deg2Rad*fakeAngluareMove) *rayon * Mathf.PI*2);
        TurnRobot(fakeRotation);

        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    MoveForward(speed);
        //}
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    TurnRobot(angle);
        //}
        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    TurnRobot(-angle);
        //}
    }

    private void MoveForward(float speed )
    {
        this.transform.Translate(new Vector3(0, 0, speed) * Time.deltaTime, Space.Self);
    }

    public void TurnRobot(float angle)
    {
        this.transform.Rotate(new Vector3(0, angle, 0) * Time.deltaTime, Space.Self);
    }
}
