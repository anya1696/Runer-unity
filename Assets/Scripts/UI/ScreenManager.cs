using UnityEngine;

public class ScreenManager : MonoBehaviour {
    public ScreenBase gameOverScreen;
    public ScreenBase startGameScreen;

    public GameArea gameArea;

    Player player;

    void Start(){
        OpenStartGameScreen();
        EventManager.MainEventBus.Subscribe<PlayerChosen>(OnPlayerChose);
    }

    public void OpenGameOverScreen(){
        gameOverScreen.Open();
    }

    public void OpenStartGameScreen(){
        startGameScreen.Open();
    }

    public void OnPlayerChose(PlayerChosen e){
        player = e.Player;
    }

    public void StartGame(){
        gameArea.StartGame(player);
    }

}
