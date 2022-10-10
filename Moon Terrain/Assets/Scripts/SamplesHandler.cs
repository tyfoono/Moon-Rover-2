
using UnityEngine;

public class SamplesHandler : MonoBehaviour
{

    public GameObject[] boxes;

    private int box;

    void Update()
    {
        if( Input.GetKey(KeyCode.B) ){
            box = 0;
            _boxChange(0);
        } else if ( Input.GetKey(KeyCode.N) ) {
            box = 1;
            _boxChange(1);
        } else if ( Input.GetKey(KeyCode.M) ) {
            box = 2;
            _boxChange(2);
        }
    }

    void _boxChange(int box){
        for(int i = 0; i < boxes.Length; i++){
            if(i != box){
                boxes[i].GetComponent<MeshRenderer>().enabled = false;
                boxes[i].GetComponent<MeshCollider>().enabled = false;
                boxes[i].GetComponent<BoxCollider>().enabled = false;
            }
        }
        boxes[box].GetComponent<MeshRenderer>().enabled = !boxes[box].GetComponent<MeshRenderer>().enabled;
        boxes[box].GetComponent<MeshCollider>().enabled = !boxes[box].GetComponent<MeshCollider>().enabled;
        boxes[box].GetComponent<BoxCollider>().enabled = !boxes[box].GetComponent<BoxCollider>().enabled;
    }
}
