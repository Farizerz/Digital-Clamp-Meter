using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help_Assessment : MonoBehaviour
{
    public Formative_Assesment script_Asessment;
    public bankQuizReference script_bank;
    public bool SET;

    // Start is called before the first frame update
    void OnValidate()
    {
        if (SET) {
            List<string> temp_string_ =script_bank.answerList_ENG;
            script_Asessment.QuestionsList = script_bank.questList_ENG;
            script_Asessment.answersOPt = script_bank.answerList_ENG;
            script_Asessment.answers_ = script_bank.answerListCorrect_ENG;            
            script_Asessment.halaman = new int[script_Asessment.QuestionsList.Count];
            for (int i = 0; i < script_Asessment.halaman.Length; i++)
            {
                script_Asessment.halaman[i] = 0;
                string huruf_last = temp_string_[i].Substring(temp_string_[i].Length - 1);
                if (huruf_last == "|")
                {
                    script_Asessment.answersOPt[i] = temp_string_[i].Remove(temp_string_[i].Length - 1);
                }
                else
                {
                    script_Asessment.answersOPt[i] = temp_string_[i];
                }
            }

            SET = false;
        }
    }
}
