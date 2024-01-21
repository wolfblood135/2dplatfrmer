using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class twdimcontrollerbyiso : MonoBehaviour
{
    //2 area control per direction (front and back) for ledge climb
    // down control for isinair
    //debug booleans
    [SerializeField] private bool debug_rays = false;
    //var
    [SerializeField] private float velocity = 1 ;
    [SerializeField] private float coyotetime = 1 ;

    [SerializeField] private float ledgecheckamount = 1 ; // raycasthit lenght


    [SerializeField] private Vector2 startstoptm = Vector2.one;

    [SerializeField] private LayerMask groundlayers; //select ground layers
    // Start is called before the first frame update
    [SerializeField] private bool frontupcheck, frontdowncheck, backupcheck, backdowncheck;// booleans for right left checkers
    private bool isinair, hascoyote, canjump;
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        //-----------------------------------//
        //control mechanism for front back down u check
      
        //front up check
        RaycastHit2D frontuphit =  Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y + (0.5F * transform.localScale.y)
            , transform.position.z),Vector3.right*transform.localScale.x,ledgecheckamount ,groundlayers);
        frontupcheck = frontuphit;
        //front down check
        RaycastHit2D frontdownhit =  Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y - (0.5F * transform.localScale.y)
            , transform.position.z),Vector3.right*transform.localScale.x,ledgecheckamount,groundlayers);
        frontdowncheck = frontdownhit;
        //back up check
        RaycastHit2D backupcheckhit  =  Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y + (0.5F * transform.localScale.y)
            , transform.position.z),Vector3.left*transform.localScale.x,ledgecheckamount,groundlayers);
        backupcheck = backupcheckhit;
        //back down check
        RaycastHit2D backdownhit  =  Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y - (0.5F * transform.localScale.y)
            , transform.position.z),Vector3.left*transform.localScale.x,ledgecheckamount,groundlayers);
        backdowncheck = backdownhit;
      
        
        //is in air check
        RaycastHit2D downcHit2D =
            Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - transform.localScale.y),
                Vector2.down, .2F, groundlayers);
        isinair = !downcHit2D;
  //debug part
        if (debug_rays)
        {
            Debug.DrawLine( new Vector3(transform.position.x, transform.position.y + (0.5F * transform.localScale.y),transform.position.z),frontuphit.point,Color.green);
            Debug.DrawLine( new Vector3(transform.position.x, transform.position.y - (0.5F * transform.localScale.y),transform.position.z),frontdownhit.point,Color.yellow);
            Debug.DrawLine( new Vector3(transform.position.x, transform.position.y + (0.5F * transform.localScale.y),transform.position.z),backupcheckhit.point,Color.blue);
            Debug.DrawLine( new Vector3(transform.position.x, transform.position.y - (0.5F * transform.localScale.y),transform.position.z),backdownhit.point,Color.cyan);
            Debug.DrawLine( new Vector2(transform.position.x, transform.position.y - transform.localScale.y),downcHit2D.point,Color.red);

        }
        
        //-----------------------------------//

    }

    // Update is called once per frame
    void Update()
    {
       float inputx =  Input.GetAxis("Horizontal");
       if (inputx > 0)
       {
          transform.localScale = Vector3.one;
          
       }
       else if(inputx < 0 )
       {
           transform.localScale = new Vector3(-1, 1, 1);
       }
    }
}
