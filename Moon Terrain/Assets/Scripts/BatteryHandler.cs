using UnityEngine;
using UnityEngine.UI;


public class BatteryHandler : MonoBehaviour {

    private float globalTimer = 600;
    private float segmentTimer = 60;
    private Transform[] children;
    private int i;

    void Start(){
        children = GameHandler.getChildren(transform);
        i = children.Length - 1;
    }

    void Update(){

        segmentTimer -= Time.deltaTime;
        globalTimer -= Time.deltaTime;
        if(segmentTimer < 0){
            children[i].GetComponent<Image>().enabled = false;
            i--;
            segmentTimer = 60;
        }

        if(globalTimer < 0){
            GameHandler.gameOver(0);
        }

    }

}
