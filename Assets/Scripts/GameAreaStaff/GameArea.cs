using System.Collections.Generic;
using Redbus;
using Redbus.Extensions;
using UnityEngine;

public class GameArea : MonoBehaviour {
    public float timeToGenerateObstacles = 2;
    public OvercomeObstacleCounter overcomeObstacleCounter;
    public Camera thridViewCamera;
    static GameSpeed CurrentSpeed { get; set; } = GameSpeed.Normal;

    bool isInited = false;
    bool GameOver { get; set; } = false;
    Camera firstPersonCamera;
    SubscriptionToken[] tokens;

    //TODO возможно вынести
    static Dictionary<GameSpeed, float> SpeedSettings = new Dictionary<GameSpeed, float>(){
        {GameSpeed.Min, 0.5f},
        {GameSpeed.Normal , 1f},
        {GameSpeed.Max, 2.0f}
    };

    public ObstaclesGenerator obstaclesGenerator;

    void Init(){
        if (isInited) {
            return;
        }
        tokens = new [] {
            EventManager.MainEventBus.Subscribe<PlayerDefeated>(OnPlayerDefeated),
            EventManager.MainEventBus.Subscribe<ChangeGameSpeed>(OnSideChangeGameSpeed),
            EventManager.MainEventBus.Subscribe<AbilityStop>(OnAbilityEnd)
        };
    }

    public void StartGame(Player chosenPlayer){
        Player player = Instantiate(chosenPlayer, transform);
        player.Init();
        firstPersonCamera = player.Camera;
        Init();
        GameOver = false;
        gameObject.SetActive(true);
        obstaclesGenerator.StartGame(timeToGenerateObstacles);
        overcomeObstacleCounter.StartGame();
        ShowFirstPersonView();
    }

    public void EndGame(){
        GameOver = true;
        gameObject.SetActive(false);
        obstaclesGenerator.EndGame();
        FindObjectOfType<ScreenManager>().OpenGameOverScreen();
        foreach (SubscriptionToken token in tokens) {
            token.Unsubscribe(EventManager.MainEventBus);
        }
        ShowThridView();
    }

    void SetGameSpeed(GameSpeed gameSpeed){
        CurrentSpeed = gameSpeed;
    }

    void OnSideChangeGameSpeed(ChangeGameSpeed e){
        SetGameSpeed(e.GameSpeed);
    }

    void OnPlayerDefeated(PlayerDefeated e){
        EndGame();
    }

    void OnAbilityEnd(AbilityStop e){
        SetGameSpeed(GameSpeed.Normal);
    }

    public void AddObstacleScore(){
        overcomeObstacleCounter.AddScore();
    }

    public void ShowThridView() {
        firstPersonCamera.enabled = false;
        thridViewCamera.enabled = true;
    }

    public void ShowFirstPersonView() {
        firstPersonCamera.enabled = true;
        thridViewCamera.enabled = false;
    }

    public static float CurrentFloatSpeed {
        get=> SpeedSettings[CurrentSpeed];
    }
}
