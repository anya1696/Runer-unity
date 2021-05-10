using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    public float abilityRechacgeTime = 15;

    float TimeToCollDown { get; set; } = 0;

    public Ability ability;
    public int lifeCount = 3;
    public PlayersControl playersControl;
    public MeshRenderer model3d;
    public Text energyText;
    public Text lifeLeftText;
    public string desctiption;

    bool isAbilityActivated = false;

    public bool IsBeatable { get; set; } = true;

    void Start()
    {
        Init();
    }

    public void Init(){
        EventManager.MainEventBus.Subscribe<AbilityStart>(OnAbilityStart);
        EventManager.MainEventBus.Subscribe<AbilityEnd>(OnAbilityEnd);
        playersControl.Init();
        ability.Init();
        TimeToCollDown = abilityRechacgeTime;
        lifeLeftText.text = "Lifes:" + lifeCount;
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
        if (isAbilityActivated) {
            return;
        }
        isAbilityActivated = true;
        ability.TriggerAbylity();
        Debug.Log("Activate ability");
    }

    void OnAbilityStart(AbilityStart e){
        isAbilityActivated = true;
    }

    public void OnAbilityEnd(AbilityEnd e){
        Debug.Log("Player, OnAbilityEnd");
        isAbilityActivated = false;
        TimeToCollDown = abilityRechacgeTime;
    }

    public void StartFly(){
        playersControl.StartFly();
    }

    public void StopFly(){
        playersControl.StopFly();
    }

    void Deafited(){

    }

    void OnTriggerEnter(Collider collider){
        if (collider.tag == "Obstacle") {
            if (IsBeatable) {
                lifeCount -= 1;
                lifeLeftText.text = "Lifes:" + lifeCount;
                if (lifeCount <= 0) {
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
