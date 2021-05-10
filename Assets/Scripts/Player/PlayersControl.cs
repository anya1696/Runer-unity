using UnityEngine;

public class PlayersControl : MonoBehaviour {
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode abilityKey = KeyCode.LeftControl;

    public float jumpForce = 1f;
    public float customGravity = 1f;
    Vector3 jumpVector = new Vector3(0f, 1f, 0f);

    private Player player;
    float verticalSpeed;

    bool isGrounded = true;
    bool isJump = false;

    public void Init(){
        player = gameObject.GetComponent<Player>();
        verticalSpeed = jumpForce;
    }

    void Update()
    {
        CustomJump();
        if (Input.GetKeyDown(JumpKey)) {
            OnPressJump();
        }
        if (Input.GetKeyDown(AbilityKey)) {
            OnPressAbility();
        }
    }

    void OnPressJump(){
        if (!isGrounded) {
            return;
        }
        isGrounded = false;
        isJump = true;
        verticalSpeed = jumpForce;
    }

    void CustomJump(){
        if (isGrounded || !isJump) {
            return;
        }
        verticalSpeed -= customGravity * Time.deltaTime * GameArea.CurrentFloatSpeed;
        if (verticalSpeed != 0f && !isGrounded) {
            player.transform.Translate(Vector3.up * verticalSpeed * Time.deltaTime * GameArea.CurrentFloatSpeed);
        }
    }

    void OnTriggerEnter(Collider collider){
        string tag = collider.gameObject.tag;
        if (tag == "Road") {
            isGrounded = true;
            isJump = false;
        }
    }

    void OnPressAbility(){
        player.TriggerAbility();
    }

    public void StartFly(){
        isGrounded = false;
        player.transform.position = new Vector3(
                player.transform.position.x,
                2,
                player.transform.position.z);
        //player.transform.position.y = player.transform.position.y * verticalSpeed;
    }

    public void StopFly(){
//        isGrounded = true;
        player.transform.position = new Vector3(
                player.transform.position.x,
                0,
                player.transform.position.z);
    }

    public KeyCode JumpKey {
        get => jumpKey;
        set => jumpKey = value;
    }

    public KeyCode AbilityKey {
        get => abilityKey;
        set => abilityKey = value;
    }
}
