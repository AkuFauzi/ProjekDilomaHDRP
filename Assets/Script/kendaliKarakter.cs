using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kendaliKarakter : MonoBehaviour
{
    public Camera MyCamera;
    public float  speed       = 5f;
    public float  rotSpeed    = 5f;
    public float  sprintSpeed = 100f;

    CharacterController myController;
    Animator myAnimator;
    float mDesireRotation        = 0f;
    float mDesiredAnimationSpeed = 0f;
    float animationBlendSpeed    = 5f;
    float gravitasi              = -5.8f;
    float mSpeedY                = 0f;
    bool  mSprint                = false;

    public AudioClip[] FootstepAudioClips;
    [Range(0, 1)] public float FootstepAudioVolume = 0.5f;

    //Gamelan
    public GameObject Gamelan;
    public CinemachineFreeLook cinemachineFreeLook;

    public GameObject option;

    // Start is called before the first frame update
    void Start()
    {
        Gamelan.SetActive(false);
        move = true;


        myController = GetComponent<CharacterController>();
        myAnimator   = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayGamelan();
        movement();
        Pause();
    }

    private void OnFootstep(AnimationEvent animationEvent)
        {
            if (animationEvent.animatorClipInfo.weight > 0.5f)
            {
                if (FootstepAudioClips.Length > 0)
                {
                    var index = Random.Range(0, FootstepAudioClips.Length);
                    AudioSource.PlayClipAtPoint(FootstepAudioClips[index], transform.TransformPoint(myController.center), FootstepAudioVolume);
                }
            }
        }

    bool move;
    void movement()
    {
        if (move)
        {
            float x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical");

            // gravitasi
            if (!myController.isGrounded) { mSpeedY += gravitasi * Time.deltaTime; }
            else { mSpeedY = 0; }
            Vector3 verticalMovement = Vector3.up * mSpeedY;
            ////////////////

            mSprint = Input.GetKey(KeyCode.LeftShift);

            Vector3 movement = new Vector3(x, 0, z).normalized;

            Vector3 rotatedMovement = Quaternion.Euler(0, MyCamera.transform.rotation.eulerAngles.y, 0) * movement;

            myController.Move(verticalMovement + rotatedMovement * (mSprint ? sprintSpeed : speed) * Time.deltaTime);

            if (rotatedMovement.magnitude > 0)
            {
                mDesireRotation = Mathf.Atan2(rotatedMovement.x, rotatedMovement.z) * Mathf.Rad2Deg;
                //myAnimator.SetFloat("speed", 1);
                mDesiredAnimationSpeed = mSprint ? 1 : 0.5f;
            }
            else
            {
                //myAnimator.SetFloat("speed", 0);
                mDesiredAnimationSpeed = 0;
            }

            myAnimator.SetFloat("speed", Mathf.Lerp(myAnimator.GetFloat("speed"), mDesiredAnimationSpeed, animationBlendSpeed * Time.deltaTime));

            Quaternion currentRot = transform.rotation;
            Quaternion targetRot = Quaternion.Euler(0, mDesireRotation, 0);
            transform.rotation = Quaternion.Lerp(currentRot, targetRot, rotSpeed * Time.deltaTime);
        }
        
    }

    bool gamelan;
    void PlayGamelan()
    {
        if (Input.GetKeyDown(KeyCode.F) && !gamelan)
        {
            Gamelan.SetActive(true);
            gamelan = true;
            move = false;
            cinemachineFreeLook.m_YAxis.m_InputAxisName = "";
            cinemachineFreeLook.m_XAxis.m_InputAxisName = "";

        }
        else if (Input.GetKeyDown(KeyCode.F) && gamelan)
        {
            Gamelan.SetActive(false);
            gamelan = false;
            move = true;
            cinemachineFreeLook.m_YAxis.m_InputAxisName = "Mouse Y";
            cinemachineFreeLook.m_XAxis.m_InputAxisName = "Mouse X";
        }
    }

    //Pause=========================================================================================================
    public bool pause;
    void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pause)
        {
            pause = true;
            option.SetActive(true);
            Time.timeScale = 0;
        }
        else if(Input.GetKeyDown(KeyCode.Escape)&& pause)
        {
            pause = false;
            option.SetActive(false);
            Time.timeScale = 1;
        }
    }
    public void Unpause()
    {
        option.SetActive(false);
        Time.timeScale = 1;
        pause = false;
    }

}
