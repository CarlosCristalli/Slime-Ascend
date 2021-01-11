using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    Rigidbody2D rb;

    Animator anim;
    public Animator clockAnim;
    public GameObject PauseMenu;

    public bool isGrounded = false;
    public bool isPaused = false;
    bool isCoolDownOver = true;
    public bool isMoving = false;

    public float jumpForce = 30;
    int screenWidth = 0;
    float midAirStopTime = 1;


    float gravity = 0.75f;
    public float verticalSpeeed = 0;
    public float horizontalSpeeed = 0;
    float verticalSpeedPriorStop;

    public AudioSource JumpSound;

    public float Sensititity = 0.2f;

    
    IEnumerator MidAirStop()
    {
        if (isCoolDownOver)
        {
            clockAnim.SetTrigger("Activate");
            verticalSpeeed = 0;
            isPaused = true;

            //verticalSpeedPriorStop = verticalSpeeed;

            yield return new WaitForSeconds(midAirStopTime);
            //verticalSpeeed = verticalSpeedPriorStop;
            isPaused = false;
            isCoolDownOver = false;
            clockAnim.ResetTrigger("Activate");
            StartCoroutine("MidAirStopCoolDown");
        }
    }
    IEnumerator MidAirStopCoolDown()
    {
        clockAnim.SetTrigger("CoolDown");
        yield return new WaitForSeconds(5);
        isCoolDownOver = true;
        clockAnim.ResetTrigger("CoolDown");
    }

    void Awake()
    {
        

        Sensititity = PlayerPrefs.GetFloat("Sensitivity",0.2f);
        clockAnim = GameObject.FindGameObjectWithTag("Especial").GetComponent<Animator>();
        PauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");
        screenWidth = Screen.width;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        PauseMenu.SetActive(false);
    }

    void Update()
    {
        
        midAirStopTime = GetComponent<BoostCollection>().TimeBoostUpgrade;
        if (isGrounded)
        {
            Jump();
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }
        if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            isMoving = false;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            isMoving = false;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            midAirStop();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            
            Pause();
        }

        if (Input.touchCount > 0)
        {
                Touch touch = Input.GetTouch(0);


                if (touch.position.x > (screenWidth / 2) + (screenWidth / 5))
                {
                    MoveRight();
                isMoving = true;
                }
                if (touch.position.x < (screenWidth / 2) - (screenWidth / 5))
                {
                    MoveLeft();
                isMoving = true;
                }
        }
        else
        {
            isMoving = false;
        }
        
        


    }
    
    
    void FixedUpdate()
    {
        
        Sensititity = PlayerPrefs.GetFloat("Sensitivity",0.2f);
        if (transform.position.x > 7) transform.position = new Vector2(-7f, transform.position.y);
        if (transform.position.x < -7) transform.position = new Vector2(7f, transform.position.y);
        if (verticalSpeeed > 0)
        {
            anim.SetBool("GoingUp", true);
            anim.SetBool("GoingDown", false);
        }
        else
        {
            anim.SetBool("GoingUp", false);
            anim.SetBool("GoingDown", true);
        }
        
        if (!isGrounded && !isPaused)
        {
            verticalSpeeed -= gravity;
        }

        rb.velocity = new Vector2(horizontalSpeeed, verticalSpeeed);

       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Plataform" && verticalSpeeed < 0 && transform.position.x <= other.transform.position.x + 2 && transform.position.x >= other.transform.position.x - 2)
        {
            verticalSpeeed = 0;
            isGrounded = true;
            anim.SetBool("Landed", true);
        }
    }

   
    void Jump()
    {
        verticalSpeeed += jumpForce;
        isGrounded = false;
        JumpSound.Play();
        
    }

    public void midAirStop()
    {
        StartCoroutine("MidAirStop");
    }

    void MoveLeft()
    {
        if(horizontalSpeeed > -20f)
        {
            horizontalSpeeed -= Sensititity;
        }
        
        transform.localRotation = Quaternion.Euler(0, 180, 0);
    }
    void MoveRight()
    {
        if (horizontalSpeeed < 20f)
        {
            horizontalSpeeed += Sensititity;
        }
            
        transform.localRotation = Quaternion.Euler(0, 0, 0);
    }

    public void ButtonMoveRight()
    {
        Debug.Log("R");
        MoveRight();
    }
    public void ButtonMoveLeft()
    {
        Debug.Log("L");
        MoveLeft();
    }

    public void Pause()
    {
        verticalSpeeed = 0;
        horizontalSpeeed = 0;
        GetComponent<BoostCollection>().Killable = false;
        isPaused = true;
        PauseMenu.SetActive(true);
    }

    public void Resume()
    {
        isPaused = false;

        GetComponent<BoostCollection>().Killable = true;
        
        PauseMenu.SetActive(false);
        
        
    }
}
