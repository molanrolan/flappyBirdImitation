using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround_Script : MonoBehaviour
{
    private FlappyBird Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<FlappyBird>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.transform.position.x - transform.position.x > 30)
            transform.position = new Vector3(transform.position.x+69f,transform.position.y,transform.position.z);
    }
}
