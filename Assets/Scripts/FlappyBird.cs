using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class FlappyBird : MonoBehaviour, IPointerDownHandler
{
    public Rigidbody2D rb ;
    [SerializeField] Camera cam;
    [SerializeField] GameObject scoreSquareBox;
    [SerializeField] TMPro.TextMeshProUGUI scoreText;

    private PauseScript pauseScript;
    public int score = 0;
    public float moveSpeed;
    public float flapHeight;
    private bool flapping;
    public GameObject pipeUp;
    public GameObject pipeDown;

    private void Awake() {
        pauseScript=FindObjectOfType<PauseScript>();
        pauseScript.onPause();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector2(moveSpeed,0);
        rb=GetComponent<Rigidbody2D>();
        BuildLevel();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !pauseScript.isPause){
            rb.velocity= new Vector2(rb.velocity.x,flapHeight);
            //flapping=true;
        } else if(Input.GetMouseButtonDown(0) && pauseScript.isPause)
            pauseScript.onResume();
        

        if(transform.position.y<-8 || transform.position.y>8){
            Dead();
        }
        cam.transform.position=new Vector3(transform.position.x,
            Mathf.Min(Mathf.Max(transform.position.y,-4.5f),4.5f),cam.transform.position.z);
    }

    private void FixedUpdate() {
        // if(flapping){
        //     rb.velocity= new Vector2(rb.velocity.x,flapHeight);
        //     flapping=false;
        // }
        if(rb.velocity.y>-0.3f)transform.rotation=Quaternion.Euler(0f,0f,45f);
        else transform.rotation=Quaternion.Euler(0f,0f,-45f);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Score"){
        score+=1;
        Destroy(other);
        scoreText.text=score.ToString();}
    }
    public void Dead(){
        SceneManager.LoadScene(0);
    }


    private void BuildLevel(){

        Instantiate(pipeDown, new Vector3(8, 5), transform.rotation);
        Instantiate(scoreSquareBox, new Vector3(9,0), transform.rotation);
        Instantiate(pipeUp, new Vector3(8, -5), transform.rotation);

        Instantiate(pipeDown, new Vector3(15, 6), transform.rotation);
        Instantiate(scoreSquareBox, new Vector3(16,1), transform.rotation);
        Instantiate(pipeUp, new Vector3(15, -4), transform.rotation);

        Instantiate(pipeDown, new Vector3(23, 5), transform.rotation);
        Instantiate(scoreSquareBox, new Vector3(24,0), transform.rotation);
        Instantiate(pipeUp, new Vector3(23, -5), transform.rotation);

        Instantiate(pipeDown, new Vector3(30, 4), transform.rotation);
        Instantiate(scoreSquareBox, new Vector3(31,-1), transform.rotation);
        Instantiate(pipeUp, new Vector3(30, -6), transform.rotation);

        Instantiate(pipeDown, new Vector3(37, 4), transform.rotation);
        Instantiate(scoreSquareBox, new Vector3(38,-1), transform.rotation);
        Instantiate(pipeUp, new Vector3(37, -6), transform.rotation);
    }

//  currently pressing pause button UI will flap the bird... and then pause the game
    public void OnPointerDown(PointerEventData eventData)       //to ignore UI
    {
        print("OnPointerDown is called");
        Debug.Log("OnPointerDown is called");
    }
}