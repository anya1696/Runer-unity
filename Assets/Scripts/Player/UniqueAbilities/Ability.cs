using Redbus.Events;
using UnityEngine;

public class Ability : MonoBehaviour {
    public float duration;
    float leftDuration = 0;

    public AbilityModuleBase[] modules;
    public string description;

    void Update()
    {
        leftDuration -= Time.deltaTime;
        if (leftDuration < 0 ) {
            EndAbylity();
        }
    }

    public void Init(){
        foreach (AbilityModuleBase module in modules){
            module.Init();
        }
    }

    public void TriggerAbylity()
    {
        leftDuration = duration;
        RunEffect();
    }

    void EndAbylity()
    {
        EventManager.MainEventBus.Publish(new AbilityEnd(this));
    }

    void RunEffect(){
        EventManager.MainEventBus.Publish(new AbilityStart(this));
        foreach (AbilityModuleBase module in modules){
            module.RunEffect();
        }
    }
}
