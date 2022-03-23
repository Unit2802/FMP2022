using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagCapture : MonoBehaviour
{
	public GameObject flagCarryPos;
	public GameObject flag;
	public GameObject flagInitialPos;

	public bool hasFlag = false;

	public bool isAttackingTeam = true;

	[Range(0, 5)]public float score = 0f;

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "flag")
		{
			flag.transform.position = flagCarryPos.transform.position;
			flag.transform.parent = flagCarryPos.transform;
			hasFlag = true;
		}

		if(other.tag == "ScoreZone" && hasFlag == true && isAttackingTeam == true)
		{
			score += 1;
			flag.transform.position = flagInitialPos.transform.position;
			flag.transform.parent = null;
			hasFlag = false;
		}
	}

	void Update()
	{
		if(score == 3f)
		{
			Debug.Log("Show win screen");
		}
	}

	
}
