using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;
    CameraFollow cameraFollow;
    MinimapCameraFollow minimapCameraFollow;
    Animator animator;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI bombsText;
    public Texture2D bombTexture;
    AudioSource moveSound;
    public AudioSource wallHitSound;
    List<Tuple<Vector2,GameObject>> bombsPlaced;
    public float runSpeed = 20.0f;
    public int livesLeft = 3;
    public int bombsLeft = 3;


    void Start()
    {
        cameraFollow = GameObject.FindObjectOfType(typeof(CameraFollow)) as CameraFollow;
        minimapCameraFollow = GameObject.FindObjectOfType(typeof(MinimapCameraFollow)) as MinimapCameraFollow;
        bombsPlaced = new List<Tuple<Vector2,GameObject>>();
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        moveSound = GetComponent<AudioSource>();
        wallHitSound = GetComponent<AudioSource>();
    }
    void Animate()
    {        
        animator.SetBool("walkingLeft", horizontal < 0);
        animator.SetBool("walkingRight", horizontal > 0);
        animator.SetBool("walkingUp", vertical > 0);
        animator.SetBool("walkingDown", vertical < 0);
        animator.SetBool("idle", (horizontal == 0 && vertical == 0));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!wallHitSound.isPlaying)
        {
            wallHitSound.Play();
        }
    }
    void CreateBombAtLoc(float x, float y, float z)
    {
        // create sprite
         Texture2D tex = bombTexture;//Resources.Load<Texture2D>("bomb") as Texture2D;
         Sprite sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
 
         //create gameobject
         GameObject bombSprite = new GameObject();
         var name = $"PlacedBomb{bombsLeft.ToString()}";
         bombSprite.name = name;
         bombSprite.AddComponent<SpriteRenderer>();
         var boxCollider = (BoxCollider2D) bombSprite.AddComponent<BoxCollider2D>();
         SpriteRenderer SR = bombSprite.GetComponent<SpriteRenderer>();
         SR.sprite = sprite;
         bombSprite.transform.localPosition = new Vector3(x,y, z);
         bombSprite.transform.localScale = new Vector3(2f,2f,1f);
         boxCollider.size = new Vector2(0.25f, 0.25f);
         bombsPlaced.Add(new Tuple<Vector2, GameObject>(new Vector2(x,y), bombSprite));
    }
    void DetonateBomb(Tuple<Vector2, GameObject> bomb)
    {
        Debug.Log($"BOMB Detonated at x:{bomb.Item1.x} y:{bomb.Item1.y}, Name: {bomb.Item2.name}");
		//FindObjectOfType<MapDestroyer>().Explode(bomb.Item1, bomb.Item2);
        Destroy(bomb.Item2, 0.5f);
        bombsPlaced.Remove(bomb);
    }
    void Update()
    {
        if(!PauseMenu.GameIsPaused)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
            if (Input.GetKeyDown(KeyCode.Alpha1)){
                if(bombsLeft > 0)
                {
                    CreateBombAtLoc(body.position.x, body.position.y, -1f);
                    bombsLeft--;
                    Debug.Log($"BOMB PLACED at x:{body.position.x} y:{body.position.y}");
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                for(var i = bombsPlaced.Count - 1; i >= 0; i--)
                {
                    var bomb = bombsPlaced[i];
                    DetonateBomb(bomb);
                }
            }
            if(horizontal != 0 || vertical != 0)
            {
                if(!moveSound.isPlaying){
                    moveSound.Play();
                }
            }
            else{
                moveSound.Stop();
            }

            Animate();
            cameraFollow.updateCameraPos(body.position.x, body.position.y);
            minimapCameraFollow.updateCameraPos(body.position.x, body.position.y);
            bombsText.text = $"Bombs Left: {bombsLeft}";
            livesText.text = $"Lives: {livesLeft}";
        }
    }

    private void FixedUpdate()
    {
        if(!PauseMenu.GameIsPaused)
        {
            body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        }
    }
}
