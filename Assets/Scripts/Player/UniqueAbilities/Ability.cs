using UnityEngine;

public class Ability : MonoBehaviour {
    public float duration;

    public float LeftDuration { get; set; } = 0;

    public AbilityModuleBase[] modules;
    public string description;

    bool isActive = false;

    void Update()
    {
        if (!isActive) {
            return;
        }
        LeftDuration -= Time.fixedDeltaTime;
        if (LeftDuration <= 0 ) {
            EndAbylity();
        }
    }

    public void Init(){
        foreach (AbilityModuleBase module in modules) {
            module.Init();
        }
    }

    public void TriggerAbylity()
    {
        LeftDuration = duration;
        RunEffect();
    }

    void EndAbylity()
    {
        isActive = false;
        EventManager.MainEventBus.Publish(new AbilityEnd(this));
        foreach (AbilityModuleBase module in modules) {
            module.EndEffect();
        }
    }

    void RunEffect(){
        isActive = true;
        EventManager.MainEventBus.Publish(new AbilityStart(this));
        foreach (AbilityModuleBase module in modules) {
            module.RunEffect();
        }
    }
}
