using UnityEngine;

public class PlayersControl : MonoBehaviour {
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode abilityKey = KeyCode.LeftControl;

    public float jumpForce = 1f;
    public float customGravity = 1f;

    private Player player;
    float verticalSpeed;

    bool isGrounded = true;
    bool isJump = false;

    bool isTakinfOff = false;
    bool isFallind = false;
    float flyModVerticalSpeed;

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

        TakingOff();
        Falling();
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

    void TakingOff(){
        if (!isTakinfOff) {
            return;
        }
        flyModVerticalSpeed -= customGravity * Time.deltaTime * GameArea.CurrentFloatSpeed;
        if (flyModVerticalSpeed != 0f && !isGrounded) {
            player.transform.Translate(Vector3.up * flyModVerticalSpeed * Time.deltaTime * GameArea.CurrentFloatSpeed);
        }
        if (flyModVerticalSpeed <= 0){
            isTakinfOff = false;
        }
    }

    void Falling(){
        if (!isFallind) {
            return;
        }
        flyModVerticalSpeed -= customGravity * Time.deltaTime * GameArea.CurrentFloatSpeed;
        if (flyModVerticalSpeed != 0f && !isGrounded) {
            player.transform.Translate(Vector3.up * flyModVerticalSpeed * Time.deltaTime * GameArea.CurrentFloatSpeed);
        }

    }

    void OnTriggerEnter(Collider collider){
        string tag = collider.gameObject.tag;
        if (tag == "Road") {
            isGrounded = true;
            isJump = false;
            isFallind = false;
        }
    }

    void OnPressAbility(){
        player.TriggerAbility();
    }

    public void StartFly(){
        isGrounded = false;
        isTakinfOff = true;
        flyModVerticalSpeed = jumpForce;
    }

    public void StopFly(){
        isFallind = true;
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
