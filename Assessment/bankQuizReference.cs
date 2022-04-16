using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class bankQuizReference : MonoBehaviour {
	public List<string> desc;
	public List<string> questList_ENG;
	public List<string> questList_INA;
	public List<int> questID;
	public List<string> answerList_ENG;
	public List<string> answerList_INA;
	public List<string> answerListCorrect_ENG;
	public List<string> answerListCorrect_INA;
	public List<string> scoreList = new List<string>();
	public List<string> scoreListCorrection = new List<string> ();
	public string fData;
}
