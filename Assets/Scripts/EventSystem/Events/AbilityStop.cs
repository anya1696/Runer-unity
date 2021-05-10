using Redbus.Events;

public class AbilityStop : EventBase {
    public Ability Ability { get; set; }

    public AbilityStop(Ability ability){
        Ability = ability;
    }

}
