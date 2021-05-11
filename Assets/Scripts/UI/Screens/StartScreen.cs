using Redbus;
using Redbus.Extensions;
using UnityEngine.UI;

public class StartScreen : ScreenBase
{
    public CharacterChoiceLayout characterChoiceLayout;
    public Button button;

    SubscriptionToken token;

    public override void Init(){
        base.Init();
        characterChoiceLayout.Init();
    }

    public void OnChosePlayer(PlayerChosen e){
        button.gameObject.SetActive(true);
    }

    public override void Open(){
        button.gameObject.SetActive(false);
        base.Open();
        token = EventManager.MainEventBus.Subscribe<PlayerChosen>(OnChosePlayer);
    }

    public override void Close(){
        token.Unsubscribe(EventManager.MainEventBus);
        base.Close();
    }
}
