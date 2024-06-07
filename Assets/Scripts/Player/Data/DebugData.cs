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
    [SerializeField] TextMeshProUGUI WepStateText;
    [SerializeField] TextMeshProUGUI timer;
    [SerializeField] TextMeshProUGUI gameovertext;
    GameObject playerObject;
    Player playerScript;
    PlayerStateMachine statemachine = new PlayerStateMachine();
    WeaponStateMachine wepStateMachine = new WeaponStateMachine();
    GameObject weaponObject;
    WeaponF weaponScript;
    string state;
    string wepState;
   

    bool grounded;
    Vector3 currentVelocity;
    private void Start()
    {
        timer.text = "0,00";
        playerObject =  GameObject.Find("PlayerMesh");
        weaponObject = GameObject.Find("HalberdSpear");
        playerScript =  playerObject.GetComponent<Player>();
        weaponScript = weaponObject.GetComponent<WeaponF>();
        if (playerScript != null)
        {
            statemachine = playerScript.StateMachine;
            wepStateMachine = weaponScript.StateMachine;
            grounded = playerScript.IsGrounded;
            Debug.Log("Statemachinewep " + wepStateMachine);
            currentVelocity = playerScript.CurrentVelocity;
        }
        
    }

    void Update()
    {
        if (!gameovertext.enabled)
        {
            double time = Time.deltaTime;
            double timertime = double.Parse(timer.text);
            
            timer.text = (time + timertime).ToString();

		}
        state = statemachine.CurrentState.GetAnimationName();
        wepState = wepStateMachine.CurrentState.GetAnimationName();
        grounded = playerScript.IsGrounded;
        GroundedText.text = "Grounded:" + grounded;
        StateText.text = "CurrentState: " + state;
        WepStateText.text = "CurrentWeaponState: " + wepState;
        if (currentVelocity != null)
        {
            currentVelocity = playerScript.CurrentVelocity;
            VelocityText.text = "CurrentVelocity: " + currentVelocity;
        }
        
    }
}
