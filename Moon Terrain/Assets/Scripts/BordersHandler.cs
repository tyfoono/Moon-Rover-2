using UnityEngine;
using UnityEngine.UI;

public class BordersHandler : MonoBehaviour
{
    public GameObject signal_icon;
    public GameObject receiver;

    private float dist;
    private float timer = 10;

    void Start(){

    }

    void FixedUpdate() {
        dist = Vector3.Distance(transform.position, receiver.transform.position);

        if(dist >= 500 && dist < 600) { signal_icon.GetComponent<Image>().color = Color.yellow; timer = 10; }
        else if(dist >= 600) { signal_icon.GetComponent<Image>().color = Color.red; timer -= Time.deltaTime; if(timer < 0) GameHandler.gameOver(1); }
        else { signal_icon.GetComponent<Image>().color = Color.green; timer = 10; }
    }

}
