//using TreeEditor;
//using Unity.Android.Gradle.Manifest;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float strafeSpeed = 500f;
    public float speed = 500f;
    public bool isMoving = false;
    public bool isSprinting = false;
    public float forceJump = 10f;

    public Material material1;
    public Material material2;
    public Material[] materials;
    private int material_index = 0;
    protected bool IsPainted = false;

    //Можно сделать всяких гелей. Как в портале. Цвет куба - отвечает за способности
    

    protected bool DoJumping = false;
    protected bool strafeLeft = false;
    protected bool strafeRight = false;
    protected bool IsBlueJump = false;
    protected bool IsOrangeSpeed = false;
    protected bool IsPurpleGravity = false;
  
    protected bool IsGrounded = true;

    public int score;
    public Text CountText;
    public GameManager GameManager;
    public GameObject PausePanel;


    private void Start()
    {
        
        if (materials.Length > 0)
        {
            //  foreach (Material mat in materials) { }
            //GetComponent<Renderer>().material = materials[0];
            GetComponent<Renderer>().material = materials[material_index];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d"))
        {
            strafeRight = true;
        }
        else
        {
            strafeRight = false;
        }

        if (Input.GetKey("a"))
        {
            ScreenCapture.CaptureScreenshot("Screen3.png");
            strafeLeft = true;
        }
        else
        {
            strafeLeft = false;
        }
        if(Input.GetKeyDown("space") && IsGrounded)
        {
            
            DoJumping = true;
           // Debug.Log("Update ");
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           //   DoJumping = false;
          //   strafeLeft = false;
            // strafeRight = false;
            // speed = 0;
            //Time.deltaTime = 0;
            Time.timeScale = 0;
            PausePanel.SetActive(true);
           // Debug.Log("ABOBA");
        }
        if (Input.GetKeyDown("e"))
        {
            material_index++;


            //GetComponent<Renderer>().material = materials[material_index];

            if (material_index >= materials.Length)
            {
                material_index = 0;
            }
            if(material_index == 1)
            {
              //  Gravity.NoGravity = true;
              IsBlueJump = true;
            }
            else
            {
                IsBlueJump = false;
            }
            if(material_index == 2)
            {
                IsOrangeSpeed = true;
            }
            else
            {
                IsOrangeSpeed = false;
            }
            if(material_index == 3)
            {
                IsPurpleGravity = true;
            }
            else
            {
                IsPurpleGravity = false;
            }

            GetComponent<Renderer>().material = materials[material_index];
            /*
             GetComponent<Renderer>().material = material2;
             if(GetComponent<Renderer>().material == material2)
             {
                 GetComponent<Renderer>().material = material1;
             }*/
            /*
             if (!IsPainted)
             {
                 GetComponent<Renderer>().material = material2;
                 IsPainted = true;
             }
             else
             {
                 GetComponent<Renderer>().material = material1;
                 IsPainted= false;
             }
             */
            // material = GetComponent<Material>();
            // rb.GetComponent<Material> = material;
            //Debug.Log("ABOBA MAT");

        }


    }

    private void FixedUpdate()
    {
      //  rb.AddForce(0, 0, speed * Time.deltaTime);
      if (IsOrangeSpeed)
        {
            float OrangeSpeed = speed * 2;
            rb.MovePosition(transform.position + Vector3.forward * OrangeSpeed * Time.deltaTime);
        }
      else
        {
            rb.MovePosition(transform.position + Vector3.forward * speed * Time.deltaTime);
        }
     // rb.MovePosition(transform.position + Vector3.forward * speed * Time.deltaTime);
        score++;
        CountText.text = score.ToString();
        /* if (DoJumping)
         {

         } */

        if(IsPurpleGravity)
        {
            //  Gravity.NoGravity.Equals(false);

            rb.useGravity = false; 
            rb.AddForce(new Vector3(0, -16f, 0), ForceMode.Acceleration);
            Debug.Log("GRAVITY!!!");
        }
        else
        {
            rb.useGravity = true;
        }
        if (strafeLeft)
        {
            if (IsOrangeSpeed)
            {
                float OrangeStrafe = strafeSpeed * 1.5f;
                rb.AddForce(-OrangeStrafe * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
            else
            {
                rb.AddForce(-strafeSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
           // rb.AddForce(-strafeSpeed *  Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (strafeRight)
        {
            if (IsOrangeSpeed)
            {
                float OrangeStrafe = strafeSpeed * 1.5f;
                rb.AddForce(OrangeStrafe * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
            else
            {
                rb.AddForce(strafeSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
            // rb.AddForce(strafeSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if(DoJumping)
        {
            
            if (IsBlueJump)
            {
              float forcejump1 = forceJump * 2;
                rb.AddForce(Vector3.up * forcejump1, ForceMode.Impulse);
               // Debug.Log("Used a blue");
            }
            else
            {
                rb.AddForce(Vector3.up * forceJump, ForceMode.Impulse);
            }
          
            DoJumping = false;
            IsGrounded = false;
            score += 200;
        }
        /*
        if(IsPainted)
        {
            material = GetComponent<Material>();
            rb.add
        } */
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
           // Debug.Log("End!");
            GameManager.EndGame();
            
        }
        if (collision.collider.CompareTag("Ground")) 
        {
            IsGrounded = true; 
        }
    }
}

