using UnityEngine;

public class ObstaclesGenerator : MonoBehaviour {
    public Obstacle obstaclePrefab;
    public Transform obstacleParent;

    bool isGameOver = true;
    float timerToGenerateObstacles;
    float timeToGenerateObstacles;

    public void GenerateSingleObstacle(){
        Obstacle obstacle = Instantiate(obstaclePrefab);
        obstacle.transform.SetParent(obstacleParent);
    }

    void Update()
    {
        if (isGameOver) {
            return;
        }
        timerToGenerateObstacles -= Time.deltaTime * GameArea.CurrentFloatSpeed;
        if (timerToGenerateObstacles <= 0 ) {
            GenerateSingleObstacle();
            timerToGenerateObstacles = timeToGenerateObstacles;
        }

    }

    public void StartGame(float settingTimeToGenerateObstacles){
        isGameOver = false;
        timeToGenerateObstacles = settingTimeToGenerateObstacles;
        timerToGenerateObstacles = timeToGenerateObstacles;
    }

    public void EndGame(){
        isGameOver = true;
        foreach (Transform child in obstacleParent) {
            Destroy(child.gameObject);
        }
    }
}
