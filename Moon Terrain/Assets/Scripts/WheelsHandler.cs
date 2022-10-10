using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WheelsHandler : MonoBehaviour {

    public Transform wheelsIndicator;
    public static bool isBroken = false;

    public static int brokenNum = 0;
    public static int brokenWheel;
    public static Transform[] wheels;


    void Start(){
        wheels = GameHandler.getChildren(wheelsIndicator);
        wheels = wheels.Skip(1).ToArray();
    }

    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.tag == "Rock" && !isBroken){
            Debug.Log("Bonk");
            int rnd = Random.Range(0, 100);
            if (rnd < 20) { _break(Random.Range(1, 7)); Debug.Log("Broken wheel - " + brokenWheel); }

        }
    }

    void Update(){
        if(Input.GetKey(KeyCode.Alpha1)){ _repair(1);}
        else if(Input.GetKey(KeyCode.Alpha2)){ _repair(2);}
        else if(Input.GetKey(KeyCode.Alpha3)){ _repair(3);}
        else if(Input.GetKey(KeyCode.Alpha4)){ _repair(4);}
        else if(Input.GetKey(KeyCode.Alpha5)){ _repair(5);}
        else if(Input.GetKey(KeyCode.Alpha6)){ _repair(6);}

        if(brokenNum >= 7){ GameHandler.gameOver(3); }

    }

    public static void _break(int number){
        isBroken = true;
        brokenWheel = number;
        brokenNum++;
        wheels[number - 1].GetComponent<Image>().color = Color.red;
    }

    void _repair(int number){
        if (number == brokenWheel){ wheels[number - 1].GetComponent<Image>().color = Color.white; isBroken = false; }
    }

}
