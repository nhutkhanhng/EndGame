using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainAndSaw : MonoBehaviour {
    public Rigidbody2D movingPart;
    public Transform rotatePart;
    public Transform startPos;
    public Transform endPos;
    public float moveSpeed = 10;
    public float rotateSpeed = 1000;
    public bool playOnStart = true;

    private bool playing = false;
    private int direction = 1;
    private Vector3 nextLocation;


    private void Start()
    {
        movingPart.position = startPos.position;
        nextLocation = endPos.position;
        if (playOnStart)
            Play();
    }

    private void FixedUpdate()
    {
        if (!playing)
            return;
        rotatePart.transform.Rotate(new Vector3(0, 0, rotateSpeed) * Time.deltaTime);
        float distanceToGo = moveSpeed * Time.deltaTime;
        Vector2 directionVec = nextLocation - movingPart.transform.position;
        if (directionVec.sqrMagnitude < distanceToGo * distanceToGo)
        {
            if (nextLocation.Equals(startPos.position))
            {
                nextLocation = endPos.position;
                direction = 1;
            }
            else
            {
                nextLocation = startPos.position;
                direction = -1;
            }
        }

        Vector2 velocity = directionVec.normalized * distanceToGo;
        movingPart.transform.localPosition = transform.InverseTransformPoint(movingPart.position + velocity);
        //movingPart.MovePosition(movingPart.position + velocity);

    }

    public void Play()
    {
        playing = true;
    }

    public void Stop()
    {
        playing = false;
    }
}
