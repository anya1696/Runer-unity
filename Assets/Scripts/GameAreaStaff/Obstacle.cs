using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {
    public float speed = 0.5f;

    void Update()
    {
        transform.Translate(-transform.right * GameArea.CurrentFloatSpeed * speed);
    }
}
