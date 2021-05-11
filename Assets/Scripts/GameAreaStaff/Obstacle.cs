using UnityEngine;

public class Obstacle : MonoBehaviour {
    public float speed = 0.5f;

    public bool IsBeaten { get; set; }

    void Update()
    {
        transform.Translate(-transform.right * GameArea.CurrentFloatSpeed * speed * Time.deltaTime);
    }
}
