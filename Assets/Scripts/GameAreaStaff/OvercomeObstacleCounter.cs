using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvercomeObstacleCounter : MonoBehaviour {
    int counter = 0;

    void OnTriggerExit(Collider collider){
        if (collider.tag == "Obstacle") {
            if (!collider.GetComponent<Obstacle>().IsBeaten) {
                Counter += 1;
            }
        }
    }

    public void AddScore(){
        Counter += 1;
    }

    public void StartGame(){
        Counter = 0;
    }

    void OnCounterChange(){
        EventManager.MainEventBus.Publish(new OvercomeObstacle(counter));
    }

    int Counter{
        get => counter;
        set{
            counter = value;
            OnCounterChange();
        }
    }
}
