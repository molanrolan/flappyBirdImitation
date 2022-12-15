using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeDown : MonoBehaviour
{

    private FlappyBird player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<FlappyBird>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x - transform.position.x > 25){
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            player.Dead();
        }
    }
}
