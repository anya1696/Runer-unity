using Redbus.Events;

public class PlayerChosen : EventBase {
    public Player Player {get; set;}
    public PlayerChosen(Player player){
        Player = player;
    }
}
