using UnityEngine;

public class PlayersControl : MonoBehaviour {
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode abilityKey = KeyCode.LeftControl;

    public float jumpForce = 1f;
    public float customGravity = 1f;
    Vector3 jumpVector = new Vector3(0f, 1f, 0f);

    private Player player;
    float verticalSpeed;

    bool isGrounded = false;
    bool isJumping = false;

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
        isJumping = true;
        verticalSpeed = jumpForce;

    }

    void CustomJump(){
        if (!isJumping){
            return;
        }
        verticalSpeed -= customGravity * Time.deltaTime;
        if (verticalSpeed != 0f && !isGrounded){
            player.transform.Translate(Vector3.up * verticalSpeed * Time.deltaTime);
        }
    }


    void OnCollisionStay(Collision collision){
        string tag = collision.gameObject.tag;
        if (tag == "Road"){
            isGrounded = true;
            isJumping = false;
        }
        if (tag == "Obstacle"){

        }
        Debug.Log("OnCollisionStay:" + collision.gameObject.name + " | " + collision.gameObject.tag);

    }

    void OnPressAbility(){
        player.TriggerAbility();
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
