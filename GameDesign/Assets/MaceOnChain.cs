using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaceOnChain : MonoBehaviour {
    public Transform chain;
    public float speed;
    public float startRotationZ;
    public float endRotationZ;
    public bool startClockwise = false;
    public bool playOnStart = true;

    private bool playing;
    private int direction = 1;
    private float targetRotationZ;
    private float currentRotationZ;

    private void Start()
    {
        targetRotationZ = endRotationZ;
        currentRotationZ = startRotationZ;
        chain.rotation = Quaternion.Euler(0, 0, startRotationZ);
        if (startClockwise)
            direction = 1;
        else
            direction = -1;
        if (playOnStart)
            Play();
    }

    private void FixedUpdate()
    {
        if (!playing)
            return;
        
        float dist = speed * direction * Time.deltaTime;
        currentRotationZ = chain.rotation.eulerAngles.z;
        float magnituteBefore = currentRotationZ - targetRotationZ;
        float magnituteAfter = currentRotationZ + dist - targetRotationZ;

        if (magnituteBefore * magnituteAfter < 0)
        {
            direction = -direction;
            if (targetRotationZ == endRotationZ)
                targetRotationZ = startRotationZ;
            else if (targetRotationZ == startRotationZ)
                targetRotationZ = endRotationZ;
        }
        currentRotationZ += dist;
        //Debug.Log(chain.rotation.eulerAngles.z);
        chain.rotation = Quaternion.Euler(0, 0, currentRotationZ);
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
