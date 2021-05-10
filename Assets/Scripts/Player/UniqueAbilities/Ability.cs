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
            StopAbility();
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
        StartAbility();
    }

    void StopAbility()
    {
        isActive = false;
        EventManager.MainEventBus.Publish(new AbilityStop(this));
        foreach (AbilityModuleBase module in modules) {
            module.DisableEffect();
        }
    }

    void StartAbility(){
        isActive = true;
        EventManager.MainEventBus.Publish(new AbilityStart(this));
        foreach (AbilityModuleBase module in modules) {
            module.ApplyEffect();
        }
    }
}
