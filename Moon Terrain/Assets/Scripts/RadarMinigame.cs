using UnityEngine;

public class RadarMinigame : MonoBehaviour {

    public GameObject cursor;

    public static bool gameFinished = false;

    public Transform startMarker;
    public Transform endMarker;

    public float speed = 2f;

    private float startTime;
    private float journeyLength;

    void Start(){
        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }

    void Update(){
        _cursorMovement();
    }

    void _game(){

    }

    void _cursorMovement(){
        float distCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distCovered / journeyLength;

        Debug.DrawLine(startMarker.position, endMarker.position, Color.yellow);

        cursor.transform.localPosition = Vector3.Lerp(startMarker.position, endMarker.position, fractionOfJourney);
    }

}