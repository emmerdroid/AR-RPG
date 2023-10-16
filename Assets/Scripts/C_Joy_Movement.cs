using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.EnhancedTouch;
using enhancedTouch = UnityEngine.InputSystem.EnhancedTouch;

public class C_Joy_Movement : MonoBehaviour
{
    [SerializeField] Vector2 JoystickSize;
    [SerializeField] CanvasJoystick joyStick;
    //NavMeshAgent Player;
    //from https://github.com/llamacademy/mobile-touch-inputs/blob/main/Assets/Scripts/PlayerTouchMovement.cs
    //but want use Rigid Body to control movement instead

    [SerializeField] Rigidbody Player;

    private enhancedTouch.Finger MovementFinger;
    private Vector2 MovementAmount;


    private void OnEnable() 
    {
       enhancedTouch.EnhancedTouchSupport.Enable(); 
       enhancedTouch.Touch.onFingerDown += FingerDown;
       enhancedTouch.Touch.onFingerUp += FingerUp;
       enhancedTouch.Touch.onFingerMove += FingerMove;

    }

    private void OnDisable() 
    {
        enhancedTouch.Touch.onFingerMove -= FingerMove;
        enhancedTouch.Touch.onFingerUp -= FingerUp;
        enhancedTouch.Touch.onFingerDown -= FingerDown;
        enhancedTouch.EnhancedTouchSupport.Disable();
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 moveDirection = new(MovementAmount.x, 0, MovementAmount.y);
        Player.velocity = moveDirection * Player.velocity.magnitude;

        if(moveDirection != Vector3.zero){
            Player.transform.rotation = Quaternion.LookRotation(moveDirection);
        }
    }

    void FingerDown(Finger TouchFinger)
    {
        if(MovementAmount == null && TouchFinger.screenPosition.y <= Screen.height / 2f)
        {
            MovementFinger = TouchFinger;
            MovementAmount = Vector2.zero;
            joyStick.gameObject.SetActive(true);
            joyStick.normalRect.sizeDelta = JoystickSize;
            joyStick.normalRect.anchoredPosition = ClampStartPosition(TouchFinger.screenPosition);
        }
    }

    void FingerUp(Finger TouchFinger)
    {
       if(TouchFinger == MovementFinger)
       {
        MovementFinger = null;
        joyStick.inner.anchoredPosition = Vector2.zero;
        joyStick.gameObject.SetActive(false);
        MovementAmount = Vector2.zero;
       } 
    }

    void FingerMove(Finger TouchMove)
    {
        if (TouchMove == MovementFinger)
        {
            Vector2 innerPosition;
            float maxMovement = JoystickSize.x / 2f;
            enhancedTouch.Touch currentTouch = TouchMove.currentTouch;

            if(Vector2.Distance(
                currentTouch.screenPosition, joyStick.normalRect.anchoredPosition) > maxMovement)
            {
                innerPosition = (currentTouch.screenPosition - 
                    joyStick.normalRect.anchoredPosition).normalized * maxMovement;
            }
            else
            {
                innerPosition = currentTouch.screenPosition - joyStick.normalRect.anchoredPosition;
            }

            joyStick.inner.anchoredPosition = innerPosition;
            MovementAmount = innerPosition/maxMovement;

        }
    }

    private Vector2 ClampStartPosition(Vector2 StartPosition)
    {
         if (StartPosition.x < JoystickSize.x / 2)
        {
            StartPosition.x = JoystickSize.x / 2;
        }

        if (StartPosition.y < JoystickSize.y / 2)
        {
            StartPosition.y = JoystickSize.y / 2;
        }
        else if (StartPosition.y > Screen.height - JoystickSize.y / 2)
        {
            StartPosition.y = Screen.height - JoystickSize.y / 2;
        }

        return StartPosition;
    }
}
