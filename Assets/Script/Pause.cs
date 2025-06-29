using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject PausePanel;
    protected bool DoJumping = false;
    protected bool strafeLeft = false;
    protected bool strafeRight = false;
    //protected float  speed = 0;
    // public Rigidbody rb;
       // DoJumping = false;
      //  strafeLeft = false;
       // strafeRight = false;
    public void Close()
    {
        PausePanel.SetActive(false);
        // speed = 500f;
        //  DoJumping = true;
        //  strafeLeft = true;
        // strafeRight = true;
        Time.timeScale = 1;
       // Debug.Log("ABOBA");
       /*
       if(PausePanel == true )
        {
            Time.timeScale = 2;
        } */
    }
    
    public void Open()
    {
       // if (Input.GetKeyDown(KeyCode.Escape))
       if (Input.GetKeyDown("escape"))
        {
            PausePanel.SetActive(true);
            Debug.Log("Open");
        }
       
    } 

     void Update()
    {
        // if (Input.GetKeyDown("escape"))
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PausePanel.SetActive(true);
            Debug.Log("Update");
        }
    }
    /*
    private void FixedUpdate()
    {

        if (Input.GetKeyDown("escape"))
        {
            PausePanel.SetActive(true);
            Debug.Log("FixedUpdate");
        }
    } */
}
