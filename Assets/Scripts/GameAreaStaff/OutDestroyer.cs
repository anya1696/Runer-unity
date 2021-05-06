using System.Collections;
using System.Collections.Generic;
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
