using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private CharacterController m_ch;
    private PlayerInput playerInput;
    private Vector3 movedirection;
    Vector3 FirstPoint;
    Vector3 SecondPoint;
    float xAngle;
    float yAngle;
    float xAngleTemp;
    float yAngleTemp;
    bool moveleft;
    bool moveright;
    float horizontalmove;
    public float ymax;

    float xRotation = 0f;

    public float ymin;
    
    void Start()
    {
        m_ch = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
       
    }

    // Update is called once per frame
    void Update()
    {
          
       
      
       
        computeMovement();
        computeRotation();
 
    }
    void computeMovement()
    {
        //buttons
        if(moveright)
			transform.Translate(Vector3.left * 20 * Time.deltaTime);
		if(moveleft)
			transform.Translate(Vector3.right * 20 * Time.deltaTime);
            //Joystick
       // Vector2 input = playerInput.actions["Move"].ReadValue<Vector2>();

       // movedirection = new Vector3(0, 0, 0.0f)  + (-input.x * transform.right);

       // m_ch.Move( movedirection * 10 * Time.deltaTime);

    }
    void computeRotation()
    {
        if (Input.touchCount > 0)
        {
            bool yclamp = false;
            if (Input.GetTouch(0).phase == UnityEngine.TouchPhase.Began)
            {
                FirstPoint = Input.GetTouch(0).position;
                xAngleTemp = xAngle;
                if (!yclamp)
                    yAngleTemp = yAngle;
            }
            if (yAngle > ymax && yAngle - yAngleTemp > 0 || yAngle < ymin && yAngle - yAngleTemp < 0)
            {
                yclamp = true;

                if (Input.GetTouch(0).phase == UnityEngine.TouchPhase.Moved)
                {
                    SecondPoint = Input.GetTouch(0).position;
                    xAngle = xAngleTemp + (SecondPoint.x - FirstPoint.x) * 180 / Screen.width;
                    yAngle = yAngleTemp + (SecondPoint.y - FirstPoint.y) * 90 / Screen.height;
                    xAngle = Mathf.Clamp(xAngle, -50, 50);
                    yAngle = Mathf.Clamp(yAngle, -50, 50);
                    this.transform.rotation = Quaternion.Euler(yAngle, xAngle, 0.0f);
                }
            }
            else
            {
                if (Input.GetTouch(0).phase == UnityEngine.TouchPhase.Moved)
                {
                    SecondPoint = Input.GetTouch(0).position;
                    xAngle = xAngleTemp + (SecondPoint.x - FirstPoint.x) * 180 / Screen.width;
                    yAngle = yAngleTemp + (SecondPoint.y - FirstPoint.y) * 90 / Screen.height;
                    xAngle = Mathf.Clamp(xAngle, -50, 50);

                    yAngle = Mathf.Clamp(yAngle, -50, 50);
                    this.transform.rotation = Quaternion.Euler(yAngle, xAngle, 0.0f);
                    yclamp = false;
                }


                //Debug.Log(yAngle);
            }
        }
       
    }
     public void PointerUpRight()
     {
moveright = false;
     }
     public void PointerDownRight()
     {
moveright = true;
     }
     public void PointerUpLeft()
     {
moveleft = false;
     }
     public void PointerDownLeft()
     {
moveleft = true;
     }
    
    
}
