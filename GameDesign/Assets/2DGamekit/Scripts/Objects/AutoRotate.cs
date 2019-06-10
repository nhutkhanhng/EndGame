using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour {
    public Transform rotatePart;
    public int speed;
    public Vector2Int range;
    public bool reverse;
    public bool playing;

    private int targetDegree;
    private bool reversing;

    private void Update()
    {
        if (!playing)
            return;
        if (!reversing)
        {
            if (Mathf.Abs(rotatePart.rotation.z - range.y) < Mathf.Epsilon)
            {
                reversing = false & reverse;
                if (!reversing)
                    rotatePart.transform.rotation = Quaternion.Euler(0,0,range.x);
            }
            transform.Rotate(new Vector3(0, 0, speed) * Time.deltaTime);
        }
        else
        {
            if (Mathf.Abs(rotatePart.rotation.z - range.x) < Mathf.Epsilon)
            {
                reversing = false;
            }
            transform.Rotate(new Vector3(0, 0, -speed) * Time.deltaTime);
        }
    }
}
