using Redbus.Events;

public class OvercomeObstacle: EventBase {
    public int Value { get; set; }
    public OvercomeObstacle(int value){
        Value = value;
    }
}
