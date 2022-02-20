using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] LayerMask whatIsGround;
    [SerializeField] Transform groundCheck;
    [SerializeField] Rigidbody2D myBody;
    [SerializeField] Animator myAnim;
    [SerializeField] ParticleSystem dustPS;
    [SerializeField] ParticleSystem bloodPS;

    private GameObject goatEntity;

    private bool grounded = true;
    private bool jump = false;
    private bool facingRight = true;
    public bool moveEnabled = true;
    public string type;

    private float jumpForce;
    private float runSpeed;
    private float groundRadius = 0.2f;
    private Vector3 m_Velocity = Vector3.zero;

    private float horizontalMove = 0f;
    public int goatNumber = 1;
    public int goatDeathCount;

    void Start()
    {
        jumpForce = 295f;
        runSpeed = 30f;

        goatDeathCount = 0;

        StartCoroutine(randomBleat());
    }

    void FixedUpdate()
    {
        grounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundRadius, whatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject.layer == 8)
            {
                grounded = true;
            }
        }
    }

    void Update()
    {
        horizontalMove = runSpeed * Input.GetAxisRaw("Horizontal");
        jump = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);

        myAnim.SetBool("move", !(horizontalMove == 0f));

        if(moveEnabled)
        {
            movement(horizontalMove * Time.fixedDeltaTime, jump);
        }

        if(Input.GetMouseButtonDown(1))
        {
            if(goatNumber==2)
            {
                AudioManagerScript.instance.PlaySound("slash");
                ScreenShakeScript.instance.shakeCamera(1f, 0.1f);
                goatNumber--;
                goatDeathCount++;
                myAnim.SetBool(type, false);
                type = null;
                bloodPS.Play();
                Destroy(goatEntity);
            }
        }

        if(Input.GetKey(KeyCode.R))
        {
            string sceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadSceneAsync(sceneName);
        }
    }

    public void goatAdded(GameObject goat, string type)
    {
        AudioManagerScript.instance.PlaySound("goatjoin");
        this.type = type;
        myAnim.SetBool(type, true);
        goatEntity = goat;
        goatNumber++;
    }

    public void movement(float move, bool jump)
    {
        if(move != 0 && grounded)
        {
            AudioManagerScript.instance.PlaySound("clop1");
        }

        Vector3 targetVelocity = new Vector2(move * 10f, myBody.velocity.y);
        myBody.velocity = Vector3.SmoothDamp(myBody.velocity, targetVelocity, ref m_Velocity, 0.05f);

        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }

        if (jump && grounded)
        {
            grounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce));

            dustPS.Play();
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;

        Vector3 psScale = dustPS.transform.localScale;
        psScale.x *= -1;
        dustPS.transform.localScale = psScale;
        dustPS.Play();

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    IEnumerator randomBleat()
    {
        float randomNum = Random.Range(12f, 25f);
        int randomBleatNum = Random.Range(1, 3);

        yield return new WaitForSeconds(randomNum);

        string bleatType = "bleat" + randomBleatNum;
        AudioManagerScript.instance.PlaySound(bleatType);

        StartCoroutine(randomBleat());
    }
}
