using UnityEngine;

public class SwordAttack : MonoBehaviour {

    //Gets which direction player is facing
    public PlayerMovement playerMovement;
    public GroundRoll groundRoll;

    public GameObject sword;

    public float AttackDuration = 0.2f;
    private float currentAttackDuration = 0.2f;

    public bool IsAttacking { get; set; }

    private bool canAttack = true;

    private void Update()
    {
        if (!groundRoll.IsRolling && canAttack)
        {
            Attack();
        }
    }

    private void FixedUpdate()
    {
        EndAttack();
    }

    private void Attack()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!sword.activeSelf)
            {
                IsAttacking = true;
                PositionSword();
                sword.SetActive(true);
            }
        }
    }

    private void PositionSword()
    {
        switch(playerMovement.FacingDirection)
        {
            case 0:
                sword.transform.localPosition = new Vector3(0, -0.35f, 0);
                sword.transform.localEulerAngles = Vector3.zero;
                break;

            case 1:
                sword.transform.localPosition = new Vector3(0.35f, 0, 0);
                sword.transform.localEulerAngles = new Vector3(0, 0, 90.0f);
                break;

            case 2:
                sword.transform.localPosition = new Vector3(0, 0.35f, 0);
                sword.transform.localEulerAngles = new Vector3(0, 0, 180.0f);
                break;

            case 3:
                sword.transform.localPosition = new Vector3(-0.35f, 0, 0);
                sword.transform.localEulerAngles = new Vector3(0, 0, -90.0f);
                break;
        }
    }

    private void EndAttack()
    {
        if (sword.activeSelf)
        {
            currentAttackDuration -= Time.deltaTime;
            if (currentAttackDuration <= 0)
            {
                IsAttacking = false;
                currentAttackDuration = AttackDuration;
                sword.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Shop")
        {
            canAttack = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Shop")
        {
            canAttack = true;
        }
    }
}
