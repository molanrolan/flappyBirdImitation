using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{

    private FlappyBird player;
    public GameObject pipe_down;
    public GameObject GetScoreBox;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<FlappyBird>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x - transform.position.x > 25){

            float yRan = Random.Range(-3, 3);
            float gapRan = Random.Range(-0.5f, 1.5f);

            Instantiate(gameObject, new Vector2(player.transform.position.x + 11, -5 + yRan), transform.rotation);
            Instantiate(pipe_down, new Vector2(player.transform.position.x + 11, 5 + gapRan + yRan), transform.rotation);
            Instantiate(GetScoreBox,new Vector2(player.transform.position.x + 12, + yRan),transform.rotation);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            player.Dead();
        }
    }
}
