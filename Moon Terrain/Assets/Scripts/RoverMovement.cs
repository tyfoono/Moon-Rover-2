using TMPro;
using UnityEngine;

public class RoverMovement : MonoBehaviour
{
    public float movementSpeed = 1f;
    public float rotationSpeed = 1f;
    public GameObject speedometer;

    public float kph;

    private float movementInput;
    private float rotationInput;
    private float _timer = 30f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rotationInput = Input.GetAxis("Horizontal");
        movementInput = Input.GetAxis("Vertical");

        kph = rb.velocity.magnitude * 3.6f;
        speedometer.GetComponent<TextMeshProUGUI>().text = Mathf.Round(kph) + " км/ч";
        if (kph >= 15){
            _timer -= Time.deltaTime;
            if(_timer <= 0) { WheelsHandler._break(Random.Range(1, 7)); }
        }else { _timer = 30f; }
    }

    private void FixedUpdate()
    {
        if((transform.rotation.x >= 90f || transform.rotation.x <= -90f) || (transform.rotation.z >= 90f || transform.rotation.z <= -90f)) { GameHandler.gameOver(2); }
        if (!WheelsHandler.isBroken && !ManipulatorMovement.isManipulatorMoving){
            _rotate();
            _move();
        }
    }

    private void _rotate()
    {
        float rot = rotationInput * rotationSpeed * Time.deltaTime;

        Quaternion turnRotation = Quaternion.Euler(0, rot, 0);
        rb.MoveRotation(rb.rotation * turnRotation);

    }

    private void _move()
    {
        Vector3 movement = transform.right * -movementInput *  Time.deltaTime * movementSpeed;
        rb.MovePosition(rb.position + movement);

    }
}
