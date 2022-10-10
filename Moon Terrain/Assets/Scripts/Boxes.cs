using UnityEngine;

public class Boxes : MonoBehaviour
{
    public static bool gameFinished = false;
    public GameObject marker;
    private int sampleCnt = 0;

    void FixedUpdate(){
        if(sampleCnt == 3){gameFinished = true;}
    }

    void OnTriggerEnter(Collider col){
        Debug.Log(col.gameObject.tag + " " + gameObject.tag);

        if(col.gameObject.tag == gameObject.tag){
            sampleCnt++;
            Debug.Log(col.gameObject.tag + " " + sampleCnt.ToString());
            gameObject.SetActive(false);
            col.gameObject.SetActive(false);
            marker.GetComponent<MeshRenderer>().enabled = true;
        }
    }

}
