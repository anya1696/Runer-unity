using UnityEngine;

public class ScreenManager : MonoBehaviour {
    public ScreenBase gameOverScreenPrefab;
     ScreenBase startGameScreenPrefab;

    ScreenBase gameOverScreen;
    public ScreenBase startGameScreen;

    public GameArea gameArea;

    Player player;

    void Start(){
        OpenStartGameScreen();
        EventManager.MainEventBus.Subscribe<PlayerChoisen>(OnPlayerChose);
    }

    public void OpenGameOverScreen(){
        if (gameOverScreen == null) {
            gameOverScreen = Instantiate(gameOverScreenPrefab, transform);
        }
        gameOverScreen.Open();
    }

    public void OpenStartGameScreen(){
//        if (startGameScreen == null) {
//            startGameScreen = Instantiate(startGameScreenPrefab, transform);
//        }
        startGameScreen.Open();
    }

    public void OnPlayerChose(PlayerChoisen e){
        player = e.Player;
    }

    public void StartGame(){
        gameArea.StartGame(player);
    }

}
