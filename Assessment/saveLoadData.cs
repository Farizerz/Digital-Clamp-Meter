
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class saveLoadData{
	public static string firstprefs;
	public string firstprefsQR;
    public static void saveDataQR(Formative_Assesment qClass, string setget, string type)
    {
        string type_ = type + Application.productName;
        if (setget == "set")
        {
            PlayerPrefs.SetInt("totalsoal_" + type_, qClass.totalsoal);
            PlayerPrefs.SetString("dataanswerchace_" + type_, qClass.dataAnswerChace);
            PlayerPrefs.SetString("datacorrect_" + type_, qClass.datacorrect);
            PlayerPrefs.SetInt("questnow_" + type_, qClass.QuestNOW);
            PlayerPrefs.SetInt("hint_" + type_, qClass.hintCount);
            PlayerPrefs.SetInt("skip_" + type_, qClass.skipCount);
            PlayerPrefs.SetInt("cek_" + type_, qClass.cek);
            PlayerPrefs.SetFloat("waktu_" + type_, qClass.waktu);
            firstprefs = "first";
            PlayerPrefs.SetString("first_" + type_, firstprefs);
        }
        else if (setget == "get")
        {
            firstprefs = PlayerPrefs.GetString("first_" + type_);
            if (firstprefs == "first")
            {
                qClass.totalsoal = PlayerPrefs.GetInt("totalsoal_" + type_);// panggil data totalsoal
                qClass.QuestNOW = PlayerPrefs.GetInt("questnow_" + type_);//panggil data questnow
                qClass.hintCount = PlayerPrefs.GetInt("hint_" + type_);//panggil data hintCount
                qClass.skipCount = PlayerPrefs.GetInt("skip_" + type_);//panggil data skipCount
                qClass.cek = PlayerPrefs.GetInt("cek_" + type_);//panggil data cek
                qClass.dataAnswerChace = PlayerPrefs.GetString("dataanswerchace_" + type_);//panggil data answerchace
                qClass.datacorrect = PlayerPrefs.GetString("datacorrect_" + type_);
                qClass.waktu = PlayerPrefs.GetFloat("waktu_" + type_);
            }
            else
            {
                PlayerPrefs.SetInt("totalsoal_" + type_, qClass.QuestionsList.Count);
                PlayerPrefs.SetInt("questnow_" + type_, 0);
                PlayerPrefs.SetInt("hint_" + type_, 0);
                PlayerPrefs.SetInt("skip_" + type_, 0);
                PlayerPrefs.SetInt("cek_" + type_, 0);
                string a = "";// bantu convert int data answerchace to string
                string b = "";// bantu convert int data correct to string
                PlayerPrefs.SetString("dataanswerchace_" + type_, a);
                PlayerPrefs.SetString("datacorrect_" + type_, b);
                PlayerPrefs.SetFloat("waktu_" + type_, 0);
            }
        }
        else if (setget == "reset")
        {
            PlayerPrefs.SetInt("totalsoal_" + type_, qClass.QuestionsList.Count);
            PlayerPrefs.SetInt("questnow_" + type_, 0);
            PlayerPrefs.SetInt("hint_" + type_, 0);
            PlayerPrefs.SetInt("skip_" + type_, 0);
            PlayerPrefs.SetInt("cek_" + type_, 0);
            string a = "";// bantu convert int data answerchace to string
            string b = "";// bantu convert int data correct to string
            for (int i = 0; i < qClass.QuestionsList.Count; i++)
            {
                qClass.AnswerChace.Add(0);
                qClass.correct.Add(1);
                qClass.AnswerChace[i] = 0;
                qClass.correct[i] = 1;
                a += qClass.AnswerChace[i].ToString();
                b += qClass.correct[i].ToString();
            }
            PlayerPrefs.SetString("dataanswerchace_" + type_, a);
            PlayerPrefs.SetString("datacorrect_" + type_, b);
            PlayerPrefs.SetFloat("waktu_" + type_, 0);
        }
    }


}
