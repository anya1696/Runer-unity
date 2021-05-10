using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    public float abilityRechacgeTime = 15;

    float TimeToCollDown { get; set; } = 0;

    public Ability ability;
    public int maxLifeCount = 3;
    int currentLifeCount;
    public PlayersControl playersControl;
    public MeshRenderer model3d;
    public Text energyText;
    public Text lifeLeftText;
    public string desctiption;

    bool isAbilityActivated = false;

    public bool IsBeatable { get; set; } = true;

    public void Init(){
        Debug.Log("plaer Init");
//        var tokens[] = new [] {
//            EventManager.MainEventBus.Subscribe<AbilityStart>(OnAbilityStart),
            EventManager.MainEventBus.Subscribe<AbilityStop>(OnAbilityEnd);
//        };
        EventManager.MainEventBus.Subscribe<AbilityStart>(OnAbilityStart);

        playersControl.Init();
        ability.Init();
        TimeToCollDown = abilityRechacgeTime;
        currentLifeCount = maxLifeCount;
        lifeLeftText.text = "Lifes:" + currentLifeCount;
        energyText.text = "Left: " + Math.Truncate(TimeToCollDown);
    }

    void FixedUpdate()
    {
        AbilityCollDownTimer();
    }

    private void AbilityCollDownTimer(){
        if (TimeToCollDown <= 0) {
            return;
        }
        if (isAbilityActivated) {
            energyText.text = "LeftA: " + Math.Truncate(ability.LeftDuration);
        } else {
            if (TimeToCollDown - Time.fixedDeltaTime <= 0 ) {
                TimeToCollDown = 0;
                energyText.text = "Ready";
            } else {
                TimeToCollDown = TimeToCollDown - Time.fixedDeltaTime;
                energyText.text = "Left: " + Math.Truncate(TimeToCollDown);
            }
        }

    }

    public void TriggerAbility(){
        Debug.Log("TriggerAbility" + isAbilityActivated);
        if (isAbilityActivated) {
            return;
        }
        isAbilityActivated = true;
        ability.TriggerAbylity();
     }

    void OnAbilityStart(AbilityStart e){
        isAbilityActivated = true;
    }

    public void OnAbilityEnd(AbilityStop e){
        Debug.Log("Player, OnAbilityEnd");
        isAbilityActivated = false;
        TimeToCollDown = abilityRechacgeTime;
        IsBeatable = true;
    }

    public void StartFly(){
        playersControl.StartFly();
    }

    public void StopFly(){
        playersControl.StopFly();
    }

    void Deafited(){
        //gameObject.SetActive(false);
        Debug.Log("currentLifeCount" + currentLifeCount);
        EventManager.MainEventBus.Publish(new PlayerDefeated());
        //FindObjectOfType<ScreenManager>().OpenGameOverScreen();
    }

    void OnTriggerEnter(Collider collider){
        if (collider.tag == "Obstacle") {
            if (IsBeatable) {
                currentLifeCount -= 1;
                lifeLeftText.text = "Lifes:" + currentLifeCount;
                if (currentLifeCount <= 0) {
                    Deafited();
                }
            }
        }
    }

    public string Description {
        get => desctiption;
        set => desctiption = value;
    }
}
