using System.Collections.Generic;
using UnityEngine;

public class GameArea : MonoBehaviour {
    public float timeToGenerateObstacles = 2;

    float timerToGenerateObstacles;
    //private float fixedDeltaTime;

    static GameSpeed CurrentSpeed { get; set; } = GameSpeed.Normal;

    bool GameOver { get; set; } = false;
    //TODO возможно вынести
    static Dictionary<GameSpeed, float> SpeedSettings = new Dictionary<GameSpeed, float>(){
        {GameSpeed.Min, 0.5f},
        {GameSpeed.Normal , 1f},
        {GameSpeed.Max, 2.0f}
    };

    public ObstaclesGenerator obstaclesGenerator;

    void Update()
    {
        if (GameOver){
            return;
        }
        timerToGenerateObstacles -= Time.deltaTime * CurrentFloatSpeed;
        //timerToGenerateObstacles -= Time.deltaTime;
        if (timerToGenerateObstacles <= 0 ) {
            obstaclesGenerator.GenerateSingleObstacle();
            timerToGenerateObstacles = timeToGenerateObstacles;
        }

    }

    void Init(){
        //fixedDeltaTime = Time.fixedDeltaTime;
        EventManager.MainEventBus.Subscribe<PlayerDefeated>(OnPlayerDefeated);
        EventManager.MainEventBus.Subscribe<ChangeGameSpeed>(OnSideChangeGameSpeed);
        EventManager.MainEventBus.Subscribe<AbilityStop>(OnAbilityEnd);
        timerToGenerateObstacles = timeToGenerateObstacles;
    }

    public void StartGame(Player chosenPlayer){
        Player player = Instantiate(chosenPlayer, transform);
        player.Init();
        Init();
        GameOver = false;
        gameObject.SetActive(true);
    }

    public void EndGame(){
        GameOver = true;
        gameObject.SetActive(false);
        FindObjectOfType<ScreenManager>().OpenGameOverScreen();
    }

    void SetGameSpeed(GameSpeed gameSpeed){
        CurrentSpeed = gameSpeed;
        //Time.timeScale = CurrentFloatSpeed;
        //Time.fixedDeltaTime = this.fixedDeltaTime;
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

    public static float CurrentFloatSpeed {
        get=> SpeedSettings[CurrentSpeed];
    }


}
