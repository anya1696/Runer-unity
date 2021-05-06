using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    public float abilityRechacgeTime = 15;
    float TimeToCollDown { get; set; } = 0;

    public PlayersControl playersControl;
    public Ability ability;
    public MeshRenderer model3d;
    public Text energyText;

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
    }

    void Update()
    {
        AbilityCollDownTimer();
    }

    private void AbilityCollDownTimer(){
        if (TimeToCollDown <= 0) {
            return;
        }
        if (TimeToCollDown - Time.deltaTime <= 0 ) {
            TimeToCollDown = 0;
            energyText.text = "Ready";
        }else {
            TimeToCollDown = TimeToCollDown - Time.deltaTime ;
            energyText.text = "Left: " + Math.Truncate(TimeToCollDown);
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

    }

    public void OnAbilityEnd(AbilityEnd e){
        isAbilityActivated = false;
        //TimeToCollDown = abilityRechacgeTime;
    }

    public void StartFly(){

    }

}
