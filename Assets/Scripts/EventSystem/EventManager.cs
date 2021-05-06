using Redbus;
using Redbus.Interfaces;

public class EventManager {
    static IEventBus eventBus = new EventBus();

    public static IEventBus MainEventBus {
        get=> eventBus;
    }
}
