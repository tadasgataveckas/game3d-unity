using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DebugData : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI GroundedText;
    [SerializeField] TextMeshProUGUI VelocityText;
    [SerializeField] TextMeshProUGUI StateText;
    GameObject playerObject;
    Player playerScript;
    PlayerStateMachine statemachine = new PlayerStateMachine();
    string state;
   

    bool grounded;
    Vector3 currentVelocity;
    private void Start()
    {
        
        playerObject =  GameObject.Find("PlayerMesh");
        playerScript =  playerObject.GetComponent<Player>();
        if (playerScript != null)
        {
            statemachine = playerScript.StateMachine;
            Debug.Log("Statename:" + statemachine);

            grounded = playerScript.IsGrounded;
            //statemachine = playerScript.StateMachine;
            Debug.Log("gr " + grounded);
            currentVelocity = playerScript.CurrentVelocity;
            Debug.Log("Velocity: " + currentVelocity);
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        state = statemachine.CurrentState.GetAnimationName();
        //Debug.Log("Statename:" + state);
        grounded = playerScript.IsGrounded;
        GroundedText.text = "Grounded:" + grounded;
        StateText.text = "CurrentState: " + state;
        if (currentVelocity != null)
        {
            currentVelocity = playerScript.CurrentVelocity;
            VelocityText.text = "CurrentVelocity: " + currentVelocity;
        }

        
    }
}
