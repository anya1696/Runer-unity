using System.Collections.Generic;
using UnityEngine;

public class GameArea : MonoBehaviour {
    public float timeToGenerateObstacles = 2;
    float timerToGenerateObstacles;

    static GameSpeed CurrentSpeed { get; set; } = GameSpeed.Normal;

    bool GameOver { get; set; } = false;
    //TODO возможно вынести
    static Dictionary<GameSpeed, float> SpeedSettings = new Dictionary<GameSpeed, float>(){
        {GameSpeed.Min, 0.5f},
        {GameSpeed.Normal , 1f},
        {GameSpeed.Max, 2f}
    };

    public ObstaclesGenerator obstaclesGenerator;

    void Update()
    {
        if (GameOver){
            return;
        }
        timerToGenerateObstacles -= Time.deltaTime * CurrentFloatSpeed;
        if (timerToGenerateObstacles <= 0 ) {
            obstaclesGenerator.GenerateSingleObstacle();
            timerToGenerateObstacles = timeToGenerateObstacles;
        }

    }

    void Start()
    {
        Init();
    }

    void Init(){
        EventManager.MainEventBus.Subscribe<PlayerDefeated>(OnPlayerDefeated);
        EventManager.MainEventBus.Subscribe<ChangeGameSpeed>(OnSideChangeGameSpeed);
        FindObjectOfType<Player>().Init();
        timerToGenerateObstacles = timeToGenerateObstacles;
    }

    public void StartGame(){
        GameOver = false;
    }

    public void EndGame(){
        GameOver = true;
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

    public static float CurrentFloatSpeed {
        get=> SpeedSettings[CurrentSpeed];
    }


}
