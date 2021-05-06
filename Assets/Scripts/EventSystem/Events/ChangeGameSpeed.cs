using Redbus.Events;

public class ChangeGameSpeed : EventBase {
    public GameSpeed GameSpeed { get; set; }

    public ChangeGameSpeed(GameSpeed gameSpeed){
        GameSpeed = gameSpeed;
    }
}
