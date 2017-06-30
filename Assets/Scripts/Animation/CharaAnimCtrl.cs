using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum WalkMode
{
    idle,
    walking,
    running,
    sneaking
}
public enum InputMode
{
    byTransform,
    byInput,
}
public class CharaAnimCtrl : MonoBehaviour
{

    public Animator anim;
    //public float turnSpeed;
    //public float runSpeed;
    private float walkSpeed;
    public InputMode inputMode = InputMode.byTransform;
    public WalkMode walkmode = WalkMode.idle;

    private RuntimeAnimatorController animCtrl;

    private float inputH;
    private float inputV;
    private float normalizedHorizontal;
    private float normalizedVertical;

    private bool isWalking;
    private bool isRunning;
    private bool isJumping;
    private bool isCatchingGround;
    private bool isCatchingTable;

    private int waitForBoringCounter = 0;
    private int waitForBoringDelay;

    private bool awaitThisUpdate;

    private float waitForActionCounter = 0; //in s
    private float waitForActionDelay; //in s

    private Transform transformOfTheCharacter;
    private Vector3 lastPosition;
    private Quaternion lastRotation;
    private float computedVelocity;

    public CharaAnimCtrl(InputMode inputMode, WalkMode walkmode)
    {
        this.inputMode = inputMode;
        this.walkmode = walkmode;
        waitForBoringDelay = 800;
        animCtrl = (RuntimeAnimatorController)Resources.Load("CharacterLowPo/CharacterAnimation");
        if (animCtrl == null)
        {
            Debug.Log(string.Format("Faild to load Animation Controller"));
        }
    }

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();

        //SECURITY (load the animatorController into the animator if empty)
        if (anim.runtimeAnimatorController == null)
        {
            Debug.Log(string.Format("load default Animation Controller"));
            anim.runtimeAnimatorController = animCtrl;
        }

        transformOfTheCharacter = GetComponent<Transform>();

        isWalking = anim.GetBool("isWalking");
        isRunning = anim.GetBool("isRunning");
        isJumping = anim.GetBool("isJumping");
        isCatchingGround = anim.GetBool("isCatchingGround");
        isCatchingTable = anim.GetBool("isCatchingTable");

        awaitThisUpdate = false;
        waitForActionDelay = 1.0f;
        waitForActionCounter = WaitForActionDelay;

        waitForBoringDelay = 800;
        walkSpeed = 1.2f;
    }

    // Update is called once per frame
    void Update()
    {

        //check if the avatar get bored.
        if (this.gameObject.name == "AstridPlayer")
        {
            GetBored();
        }

        //change the state of the animCtrl according to the environnement
        normalizedHorizontal = (inputMode == InputMode.byTransform) ? Horizontal() : InputH;
        normalizedVertical = (inputMode == InputMode.byTransform) ? Vertical() : InputV;

        ResetBool();
        switch (walkmode)
        {
            case WalkMode.idle:
                break;
            case WalkMode.walking:
                isWalking = (normalizedHorizontal != 0 || normalizedVertical != 0) ? true : false;
                break;
            case WalkMode.running:
                isRunning = (normalizedHorizontal != 0 || normalizedVertical != 0) ? true : false;
                break;
            case WalkMode.sneaking:
                break;
            default:
                break;
        }


        //set the state of animation
        anim.SetFloat("horizontal", normalizedHorizontal);
        anim.SetFloat("vertical", normalizedVertical);

        anim.SetBool("isWalking", isWalking);
        anim.SetBool("isRunning", isRunning);
        anim.SetBool("isJumping", isJumping);

        anim.SetBool("isCatchingGround", isCatchingGround);
        anim.SetBool("isCatchingTable", isCatchingTable);

        //if set to true : no move !
        if (AwaitThisUpdate == true)
        {
            transformOfTheCharacter.position = lastPosition;
        }

        //save the last coordinate for computing
        lastPosition = transformOfTheCharacter.position;
        lastRotation = transformOfTheCharacter.rotation;

        //Debug.Log(string.Format("{0},  {1}, {2},{3}", normalizedVertical, normalizedHorizontal, waitForBoringCounter, isRunning));

    }
    public float InputH { get { return inputH; } set { inputH = Mathf.Clamp(value, -1.0f, 1.0f); } }
    public float InputV { get { return inputV; } set { inputV = Mathf.Clamp(value, -1.0f, 1.0f); } }
    public bool AwaitThisUpdate { get { return awaitThisUpdate; } private set { awaitThisUpdate = value; } }
    public float WaitForActionDelay { get { return waitForActionDelay; } private set { waitForActionDelay = value; } }
    private float WaitForActionResetAt { get { return waitForActionDelay; } set { waitForActionDelay = value; waitForActionCounter = waitForActionDelay; } }
    public WalkMode WalkMode { get { return walkmode; } internal set { walkmode = value; } }
    private float Horizontal()
    {
        return 0.0f;
    }
    private float Vertical()
    {
        computedVelocity = (lastPosition.magnitude - transformOfTheCharacter.position.magnitude) * Time.deltaTime * walkSpeed;
        return Mathf.Clamp(computedVelocity, -1.0f, 1.0f);
    }
    private void GetBored()
    {
        if (normalizedHorizontal == 0 || normalizedVertical == 0)
        {
            waitForBoringCounter++;

            if (waitForBoringCounter > waitForBoringDelay)
            {
                string idleState;
                int randomNumber = UnityEngine.Random.Range(0, 2);
                switch (randomNumber)
                {
                    case 0:
                        idleState = "Idle2cough";
                        break;
                    case 1:
                        idleState = "Idle3Crossarm";
                        break;
                    default:
                        idleState = "Idle2cough";
                        break;
                }
                anim.Play(idleState, -1, 0f);
                waitForBoringCounter = 0;
            }

        }
        else
        {
            waitForBoringCounter = 0;
        }
        //Debug.Log(String.Format("{0},{1}", waitForBoringDelay, waitForBoringCounter));

    }
    private void ResetBool()
    {
        isWalking = false;
        isRunning = false;
        isJumping = false;
        isCatchingGround = false;
        isCatchingTable = false;
    }
}
