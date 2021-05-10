using UnityEngine;

public class CharacterChoiceLayout : MonoBehaviour
{
    public CharacterChoiceLayoutElement element;

    public void Init(){
        Object[] characters = Resources.LoadAll("Characters", typeof(GameObject));
        foreach (Object character in characters){
            GameObject obj = (GameObject) character;
            Player player = obj.GetComponent<Player>();
            CharacterChoiceLayoutElement newElement = Instantiate(element, transform);
            newElement.Player = player;
        }
    }


}
