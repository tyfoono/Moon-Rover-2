using UnityEngine;

public class GameHandler {

    void Update(){
        if(Boxes.gameFinished && RadarMinigame.gameFinished);
    }

    public static void gameOver(int code){
        Debug.Log("Game Over! Code: " + code.ToString());
        Application.Quit(code);
    }

    public static Transform[] getChildren(Transform transform){

        Transform[] children = new Transform[transform.childCount];
        for(int i = 0; i < children.Length; i++) children[i] = transform.GetChild(i);
        return children;

    }

}
