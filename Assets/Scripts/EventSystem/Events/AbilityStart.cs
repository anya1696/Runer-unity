using Redbus.Events;

public class AbilityStart : EventBase {
    public Ability Ability {get; set;}

    public AbilityStart(Ability ability){
        Ability = ability;
    }
}
