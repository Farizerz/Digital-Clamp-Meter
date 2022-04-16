using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swap_Quiz : MonoBehaviour
{
    public Formative_Assesment quiz_Copy, quiz_paste;
    public bool Copy_Quiz;

    void OnValidate()
    {
        if (Copy_Quiz)
        {
            quiz_paste.QuestionsList = quiz_Copy.QuestionsList;
            quiz_paste.answersOPt = quiz_Copy.answersOPt;
            quiz_paste.answers_ = quiz_Copy.answers_;
            quiz_paste.halaman = quiz_Copy.halaman;
            Copy_Quiz = false;
        }
    }
}
