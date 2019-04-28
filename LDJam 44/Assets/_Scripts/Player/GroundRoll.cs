using UnityEngine;

public class GroundRoll : MonoBehaviour {

    //Gets the player's facing direction and player's speed to calculate the rolling speed
    public PlayerMovement playerMovement;

    public Collider2D col;

    private float RollDuration = 0.4f;
    private float currentRollDuration = 0.4f;

    public bool IsRolling { get; set; }

    private void Update()
    {
        Roll();      
        RollDirection();
        EndRoll();
    }

    private void Roll()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(!IsRolling)
            {
                IsRolling = true;
                col.enabled = false;
            }
        }
    }

    private void RollDirection()
    {
        if (IsRolling)
        {
            switch (playerMovement.FacingDirection)
            {
                case 0:
                    transform.parent.position = new Vector3(transform.position.x, transform.position.y - playerMovement.Speed * 1.5f * Time.deltaTime, transform.position.z);
                    break;

                case 1:
                    transform.parent.position = new Vector3(transform.position.x + playerMovement.Speed * 1.5f * Time.deltaTime, transform.position.y, transform.position.z);
                    break;

                case 2:
                    transform.parent.position = new Vector3(transform.position.x, transform.position.y + playerMovement.Speed * 1.5f * Time.deltaTime, transform.position.z);
                    break;

                case 3:
                    transform.parent.position = new Vector3(transform.position.x - playerMovement.Speed * 1.5f * Time.deltaTime, transform.position.y, transform.position.z);
                    break;
            }
        }
    }

    private void EndRoll()
    {
        if (IsRolling)
        {
            currentRollDuration -= Time.deltaTime;
            if (currentRollDuration <= 0)
            {
                IsRolling = false;
                currentRollDuration = RollDuration;
                col.enabled = true;
            }
        }
    }
}
