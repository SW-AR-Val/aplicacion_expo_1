using UnityEngine;
using System.Collections;
using Vuforia;

// el carajito la monto
public class PlayerController : MonoBehaviour 
{
    GameObject cursor;
	public float delta;
	public float delta2;
	public float delta3;
	public float speed;
	Animator playerAnim;

    void Start()
    {
		playerAnim = GetComponentInChildren<Animator>();
        cursor = GameObject.Find("Cursor");

		if(!CameraDevice.Instance.SetFocusMode (CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO)){
			print("---------------------------- Error al hacer focus");
		}else{
			print("---------------------------- Focus correcto");
		}
    }

    void Update()
    {
		bool moving = true;
        Vector3 pos = transform.position;
		float speedModifier = 1;

		float damping = 05f;
		Vector3 lookPos = cursor.transform.position - transform.position;
		lookPos.y = 0;
		Quaternion rotation = Quaternion.LookRotation(lookPos);

		if(Vector3.Distance(pos, cursor.transform.position) > delta3)
		{
			speedModifier += .4f;
			print(Vector3.Distance(pos, cursor.transform.position));
			playerAnim.SetFloat("Velocity", 0.7f);
		}
		else if(Vector3.Distance(pos, cursor.transform.position) > delta2)
		{
			speedModifier += .2f;
			playerAnim.SetFloat("Velocity", 0.5f);
		}
		else if(Vector3.Distance(pos, cursor.transform.position) > delta)
		{
			playerAnim.SetFloat("Velocity", 0.3f);
		}
		else
		{
			moving = false;
		}

		if(!moving){
			playerAnim.SetFloat("Velocity", 0);
		}else{
			pos = Vector3.Lerp(pos, cursor.transform.position, speed * speedModifier * Time.deltaTime);
			transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
		}

        transform.position = pos;
    }
}
