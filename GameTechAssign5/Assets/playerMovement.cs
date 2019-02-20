using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    public Rigidbody2D playerRb;
    Vector2 movement;
    public float speed = 5;
    public float jumpForce = 1;
    SpriteRenderer playerSpr;
    public Sprite idleSpr;
    public Sprite walkSpr;
    Animator playerAnim;
    public int score;
    public int winningScore;
    public GameObject fireballPrefab;
    public GameObject door1, door2;
    public float openDoorForce;
    public string scenename;

    // Start is called before the first frame update
    void Start()
    {
      playerRb = GetComponent<Rigidbody2D>();
      playerSpr = GetComponent<SpriteRenderer>();
      playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), 0);
        if(movement.x > 0){ //movement to right
          playerAnim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animation/Knight_walk_05");
          playerSpr.flipX = false;
        }else if(movement.x < 0){//movement to left
          playerAnim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animation/Knight_walk_05");
          playerSpr.flipX = true;
        }else{//movement is 0, aka idle
          playerAnim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animation/Knight_idle_02");
        }
        playerRb.AddForce(movement * speed);
        if(Input.GetKeyDown(KeyCode.Space) && playerRb.velocity == new Vector2(playerRb.velocity.x, 0.0f)){
          playerRb.AddForce(new Vector2(0, 1.0f) * jumpForce);
        }

        if(score == winningScore){
          //open doors
          door1.GetComponent<BoxCollider2D>().enabled = false;
          door1.GetComponent<Rigidbody2D>().AddForce(new Vector3(0.0f, openDoorForce, 0.0f));
          door2.GetComponent<BoxCollider2D>().enabled = false;
          door2.GetComponent<Rigidbody2D>().AddForce(new Vector3(0.0f, openDoorForce, 0.0f));

          Debug.Log("You win");
        }

    }
    void OnCollisionEnter2D (Collision2D col)
    {
        if(col.gameObject.tag == "potion")
        {
          GameObject emitFire = Instantiate(fireballPrefab);
          emitFire.transform.position = col.gameObject.transform.position;
          score++;
          Destroy(col.gameObject);
          Destroy(emitFire, 1);
        }
        if(col.gameObject.tag == "gameOver")
        {
          //GameOver
          SceneManager.LoadScene(scenename);
        }
    }
}
