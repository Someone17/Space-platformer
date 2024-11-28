using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidbody;

    public ParticleSystem jumpVFX;

    public SOPlayerSetUp soPlayerSetUp;
    /*[Header("Speed setup")]
    public Vector2 friction = new Vector2(.1f, 0);
    public float speed;
    public float speedRun;
    public float forceJump = 2;

    [Header("Animation setup")]
    public float jumpScaleY = 1.5f;
    public float jumpScaleX = 0.7f;
    public float animationDuration = .3f;
    public SOFloat soJumpScaleX;
    public SOFloat soJumpScaleY;
    public SOFloat soAnimationDuration;

    [Header("Animation player")]
    public string boolRun = "Run";
    public string boolJump = "Jump";
    public string triggerDeath = "Death";
    public float playerSwipeDuration = .1f;*/
    //public Animator animator;
    private Animator _currentPlayer;
    public Ease ease =  Ease.OutBack;

    [Header("Jump Collision Check")]
    public Collider2D collider2D;
    public float distToGround;
    public float spaceToGround = .1f;

    private float _currentSpeed;
    
    public HealthBase healthBase;

    private void Awake(){
        if(healthBase != null){
            healthBase.OnKill += OnPlayerKill;
        }
        _currentPlayer = Instantiate(soPlayerSetUp.player, transform);

        if(GetComponent<Collider2D>() != null){
            distToGround = GetComponent<Collider2D>().bounds.extents.y;
        }
    }

    private bool IsGrounded(){
        Debug.DrawRay(transform.position, -Vector2.up, Color.magenta, distToGround + spaceToGround);
        return Physics2D.Raycast(transform.position, -Vector2.up, distToGround + spaceToGround);
    }

    private void OnPlayerKill(){
        healthBase.OnKill -= OnPlayerKill;
        _currentPlayer.SetTrigger(soPlayerSetUp.triggerDeath);
    }

    private void Update()
    {
        IsGrounded();
        HandleJump();
        HandleMovement();

    }

    private void HandleMovement(){
        if(Input.GetKey(KeyCode.Space)){
            _currentSpeed = soPlayerSetUp.speedRun;
            _currentPlayer.speed = 2;
            
        }
        else{
            _currentSpeed = soPlayerSetUp.speed;
            _currentPlayer.speed = 1;
            
        }
        
        if(Input.GetKey(KeyCode.LeftArrow)){
            myRigidbody.velocity = new Vector2(-_currentSpeed, myRigidbody.velocity.y);
            if (myRigidbody.transform.localScale.x != -1){
                myRigidbody.transform.DOScaleX(-1, soPlayerSetUp.playerSwipeDuration);
            } 
            _currentPlayer.SetBool(soPlayerSetUp.boolRun, true);
        }
        else if(Input.GetKey(KeyCode.RightArrow)){
            myRigidbody.velocity = new Vector2(_currentSpeed, myRigidbody.velocity.y);
             if (myRigidbody.transform.localScale.x != 1){
                myRigidbody.transform.DOScaleX(1, soPlayerSetUp.playerSwipeDuration);
            } 
            _currentPlayer.SetBool(soPlayerSetUp.boolRun, true);
        }
        else{
            _currentPlayer.SetBool(soPlayerSetUp.boolRun, false);
        }
    
        

        if(myRigidbody.velocity.x > 0){
            myRigidbody.velocity += soPlayerSetUp.friction;
        }
        else if(myRigidbody.velocity.x < 0){
            myRigidbody.velocity -= soPlayerSetUp.friction;
        }
    }

    private void HandleJump(){
        if(Input.GetKey(KeyCode.UpArrow) && IsGrounded()){
            myRigidbody.velocity = Vector2.up * soPlayerSetUp.forceJump;
            myRigidbody.transform.localScale = Vector2.one;

            _currentPlayer.SetBool(soPlayerSetUp.boolJump, true);

            DOTween.Kill(myRigidbody.transform);

            HandleScaleJump();
            PlayJumpVFX();
        }
        else{
            _currentPlayer.SetBool(soPlayerSetUp.boolJump, false);
        }
    }

    private void PlayJumpVFX(){
        if(jumpVFX != null) jumpVFX.Play();
    }

    private void HandleScaleJump(){
        myRigidbody.transform.DOScaleY(soPlayerSetUp.jumpScaleY, soPlayerSetUp.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetUp.ease);
        myRigidbody.transform.DOScaleX(soPlayerSetUp.jumpScaleX, soPlayerSetUp.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetUp.ease);
    }

    public void DestroyMe(){
        Destroy(gameObject);
    }
}
