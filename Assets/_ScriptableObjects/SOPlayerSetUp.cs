using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu]
public class SOPlayerSetUp : ScriptableObject
{
   public Animator player;
   public SOString soStringName;
   

   [Header("Speed setup")]
   public Vector2 friction = new Vector2(1f, 0);
   public float speed;
   public float speedRun;
   public float forceJump = 2;

   [Header("Animation setup")]
   public float jumpScaleY = 1.5f;
   public float jumpScaleX = 0.7f;
   public float animationDuration = .3f;
   public Ease ease = Ease.OutBack;

    [Header("Animation player")]
    public string boolRun = "Run";
    public string boolJump = "Jump";
    public string triggerDeath = "Death";
    public float playerSwipeDuration = .1f;

    
}
