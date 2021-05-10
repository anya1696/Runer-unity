using UnityEngine;

public class Obstacle : MonoBehaviour {
    public float speed = 0.5f;

    void Update()
    {
        //Debug.Log("GameArea.CurrentFloatSpeed:" + GameArea.CurrentFloatSpeed);
        transform.Translate(-transform.right * GameArea.CurrentFloatSpeed * speed * Time.deltaTime);
        //transform.Translate(-transform.right * speed * Time.deltaTime);
    }
}
