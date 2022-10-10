
using UnityEngine;

public class ManipulatorMovement : MonoBehaviour
{

    public static bool isManipulatorMoving = false;
    public float speed;

    private float hor;
    private float ver;

    private bool isTaking = false;
    private bool enter = false;
    private GameObject takenObj = null;
    private GameObject enterObj = null;

    private Rigidbody rb;
    private Vector3 startPos;

    void Start(){
        transform.localPosition = new Vector3(0.865f, -0.38f, 0.122f);
        rb = GetComponent<Rigidbody>();
        GetComponent<MeshRenderer>().enabled = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space)){
            startPos = _getStartPosition();
            isManipulatorMoving = !isManipulatorMoving;
            GetComponent<MeshRenderer>().enabled = !GetComponent<MeshRenderer>().enabled;
            transform.localPosition = new Vector3(0.865f, -0.38f, 0.122f);
        }
        if(isManipulatorMoving){
            hor = Input.GetAxis("Horizontal");
            ver = Input.GetAxis("Vertical");
        }
        if(enter && Input.GetKey(KeyCode.F)){
            isTaking = !isTaking;
            takenObj = enterObj;
            takenObj.GetComponent<Rigidbody>().useGravity = false;
            GetComponent<MeshRenderer>().enabled = false;
        }
    }

    void FixedUpdate(){
        if(isManipulatorMoving){
            if(Vector3.Distance(startPos, transform.position) > 5)
                { hor *= -1; ver *= -1; rb.MovePosition(rb.position + (transform.right * hor * Time.deltaTime * speed) + (transform.forward * ver * Time.deltaTime * speed));}
            else _move();
        }
        if(isTaking){
            takenObj.GetComponent<Rigidbody>().position = rb.position;
        }
        else if(takenObj != null){
            takenObj.GetComponent<Rigidbody>().useGravity = true;
            GetComponent<MeshRenderer>().enabled = true;
            takenObj = null;
        }
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.CompareTag("Yellow Rock") || col.gameObject.CompareTag("Red Rock") || col.gameObject.CompareTag("Green Rock")){
            enter = true;
            enterObj = col.gameObject;
        }
    }

    void OnTriggerExit(Collider col) {
        if(col.gameObject.CompareTag("Yellow Rock") || col.gameObject.CompareTag("Red Rock") || col.gameObject.CompareTag("Green Rock")){
            enter = false;
            enterObj = null;
        }
    }

    private Vector3 _getStartPosition(){
        return transform.position;
    }

    private void _move(){
        Vector3 horizontal = transform.right * hor *  Time.deltaTime * speed;
        Vector3 vertical = transform.forward * ver *  Time.deltaTime * speed;
        rb.MovePosition(rb.position + horizontal + vertical);
    }

}
