using Redbus.Events;

public class PlayerChoisen: EventBase {
    public Player Player {get; set;}
    public PlayerChoisen(Player player){
        Player = player;
    }
}
