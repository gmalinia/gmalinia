using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // The ball that will be controlled
    public Rigidbody ball;

    // The force that will be applied to the ball when the screen is swiped
    public float swipeForce = 10.0f;

    // The minimum swipe distance required to apply the force
    public float minSwipeDistance = 50.0f;

    // The maximum time allowed for a swipe
    public float maxSwipeTime = 0.5f;

    // The start and end positions of the swipe
    private Vector2 startPos;
    private Vector2 endPos;

    // The time when the swipe started
    private float startTime;

    // Update is called once per frame
    void Update()
    {
        // Check for touch input
        if (Input.touchCount > 0)
        {
            // Get the first touch
            Touch touch = Input.GetTouch(0);

            // Check the phase of the touch
            if (touch.phase == TouchPhase.Began)
            {
                // The touch has just started, so store the position and time
                startPos = touch.position;
                startTime = Time.time;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                // The touch has ended, so store the end position
                endPos = touch.position;

                // Calculate the swipe distance
                float swipeDistance = Vector2.Distance(startPos, endPos);

                // Calculate the swipe time
                float swipeTime = Time.time - startTime;

                // Check if the swipe meets the minimum distance and time requirements
                if (swipeDistance >= minSwipeDistance && swipeTime <= maxSwipeTime)
                {
                    // Calculate the swipe direction
                    Vector3 swipeDirection = endPos - startPos;

                    // Normalize the swipe direction
                    swipeDirection.Normalize();

                    // Apply the swipe force to the ball
                    ball.AddForce(swipeDirection * swipeForce, ForceMode.Impulse);
                }
            }
        }
    }
}

