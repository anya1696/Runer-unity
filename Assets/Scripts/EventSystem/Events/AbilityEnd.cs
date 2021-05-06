using Redbus.Events;

public class AbilityEnd : EventBase {
    public Ability Ability { get; set; }

    public AbilityEnd(Ability ability){
        Ability = ability;
    }

}
