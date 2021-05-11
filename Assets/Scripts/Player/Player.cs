using System;
using Redbus;
using Redbus.Extensions;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    public float abilityRechacgeTime = 15;
    public Ability ability;
    public int maxLifeCount = 3;
    public PlayersControl playersControl;
    public MeshRenderer model3d;
    public Text energyText;
    public Text lifeLeftText;
    public Text ObstacleText;
    public string desctiption;
    public Camera camera;

    bool isAbilityActivated = false;
    int currentLifeCount;

    float TimeToCollDown { get; set; } = 0;

    public bool IsBeatable { get; set; } = true;

    SubscriptionToken[] tokens;

    public void Init(){
        tokens = new [] {
            EventManager.MainEventBus.Subscribe<AbilityStart>(OnAbilityStart),
            EventManager.MainEventBus.Subscribe<AbilityStop>(OnAbilityEnd),
            EventManager.MainEventBus.Subscribe<OvercomeObstacle>(OnOvercomeObstacle)
        };

        playersControl.Init();
        ability.Init();
        TimeToCollDown = abilityRechacgeTime;
        currentLifeCount = maxLifeCount;
        lifeLeftText.text = "Lifes:" + currentLifeCount;
        energyText.text = "Left: " + Math.Truncate(TimeToCollDown);
    }

    void Update()
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
    }

    void OnAbilityStart(AbilityStart e){
        isAbilityActivated = true;
    }

    public void OnAbilityEnd(AbilityStop e){
        isAbilityActivated = false;
        TimeToCollDown = abilityRechacgeTime;
        IsBeatable = true;
    }

    public void OnOvercomeObstacle(OvercomeObstacle e){
        ObstacleText.text = "Obsctacle:" + e.Value;
    }

    public void StartFly(){
        playersControl.StartFly();
    }

    public void StopFly(){
        playersControl.StopFly();
    }

    void Deafited(){
        EventManager.MainEventBus.Publish(new PlayerDefeated());
        foreach (SubscriptionToken token in tokens) {
            token.Unsubscribe(EventManager.MainEventBus);
        }
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider collider){
        if (collider.tag == "Obstacle") {
            collider.GetComponent<Obstacle>().IsBeaten = true;
            if (IsBeatable) {
                currentLifeCount -= 1;
                lifeLeftText.text = "Lifes:" + currentLifeCount;
                if (currentLifeCount <= 0) {
                    Deafited();
                }
            } else {
                FindObjectOfType<GameArea>().AddObstacleScore();
                Destroy(collider.gameObject);
            }
        }
    }

    public string Description {
        get => desctiption;
        set => desctiption = value;
    }

    public Camera Camera {
        get => camera;
        set => camera = value;
    }
}
