using UnityEngine;
using System.Collections;

public class FootAligner : MonoBehaviour {

	public Transform rightShoePos;
	public Transform rightShoeHold;

	public Transform leftShoePos;
	public Transform leftShoeHold;

	public Transform angleMeasure;

	public Transform rightShoeHoldPos;
	public Transform leftShoeHoldPos;

	public Transform playerTrans;

	public bool movingLeft;
	public bool movingRight;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		rightShoePos.rotation.eulerAngles.Set(0,rightShoePos.rotation.eulerAngles.y,0);
		leftShoePos.localRotation.eulerAngles.Set(0,leftShoePos.rotation.eulerAngles.y,0);

		//print (Quaternion.Angle(playerTrans.rotation,angleMeasure.rotation).ToString());


		if(movingLeft){

			leftShoeHold.position = Vector3.MoveTowards(leftShoeHold.position, leftShoeHoldPos.position, Time.deltaTime * 8);


		}

		
		if(leftShoeHold.position == leftShoeHoldPos.position){
			movingLeft = false;
			movingRight = true;
		}


		if(movingRight == true && movingLeft == false){
			rightShoeHold.position = Vector3.MoveTowards(rightShoeHold.position, rightShoeHoldPos.position, Time.deltaTime * 8);

		}
		
		if(rightShoeHold.position == rightShoeHoldPos.position){
			movingRight = false;
		}

		if(Quaternion.Angle(playerTrans.rotation,angleMeasure.rotation) > 70){
		

			//transform.position = Vector3.MoveTowards(transform.position, other.position, Time.deltaTime * speed);

			//rightShoeHold.position = rightShoeHoldPos.position;
			//MovePosition(rightShoeHold,rightShoeHold.position,rightShoeHoldPos.position, 0.5f);

			movingLeft = true;


			print ("ALOHA");
			//rightShoeHold.position = Vector3.Lerp(leftShoeHold.position,rightShoeHoldPos.position,0.3f);
			rightShoeHold.rotation = rightShoeHoldPos.rotation;


			//leftShoeHold.position = leftShoeHoldPos.position;
			//MovePosition(leftShoeHold,leftShoeHold.position,leftShoeHoldPos.position, 0.5f);
			//leftShoeHold.position = Vector3.Lerp(leftShoeHold.position,leftShoeHoldPos.position,0.3f);

			leftShoeHold.rotation = leftShoeHoldPos.rotation;


			angleMeasure.rotation = playerTrans.rotation;
		}
	}

	IEnumerator MovePosition( Transform thisTrans, Vector3 start, Vector3 end, float time){

		print("hello");

		float i = 0;
		float rate = 1/time;
		while (i<0){
			i += Time.deltaTime * rate;
			thisTrans.position = Vector3.Lerp (start,end,i);
			yield return new WaitForEndOfFrame();
			print("ello");
		}
	}
}
