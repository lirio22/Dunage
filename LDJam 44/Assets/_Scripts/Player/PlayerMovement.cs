using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public SwordAttack sword;
    public GroundRoll groundRoll;

    //This will be called by the age manager
    public float Speed; //{get; set;}

    public int FacingDirection; //{get; set;} //0 = front. 1 = right. 2 = up. 3 = left

    private void Update()
    {
        if (!sword.IsAttacking && !groundRoll.IsRolling)
        {
            HorizontalMovement();
            VerticallMovement();
        }
    }

    private void HorizontalMovement()
    {
        if(Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x - Speed * Time.deltaTime, transform.position.y, transform.position.z);
            FacingDirection = 3;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + Speed * Time.deltaTime, transform.position.y, transform.position.z);
            FacingDirection = 1;
        }
    }

    private void VerticallMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + Speed * Time.deltaTime, transform.position.z);
            FacingDirection = 2;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - Speed * Time.deltaTime, transform.position.z);
            FacingDirection = 0;
        }
    }       
}
