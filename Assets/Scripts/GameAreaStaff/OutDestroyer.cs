using UnityEngine;

public class OutDestroyer : MonoBehaviour
{
    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Obstacle") {
            Destroy(collider.gameObject);
        }

    }
}
