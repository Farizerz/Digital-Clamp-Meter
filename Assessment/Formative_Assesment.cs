using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class Formative_Assesment : MonoBehaviour
{

    [Header("Kumpulan Soal , pilihan , jawaban dan Halaman Referensi")]
    public List<string> QuestionsList = new List<string>();
    public List<string> answersOPt = new List<string>();
    public List<string> answers_ = new List<string>();
    public int[] halaman;
    [Header("All Panels & GameObjects")]
    public GameObject panelChecks;
    public GameObject finalresults;
    public GameObject resultButton;
    public GameObject percentage;
    public GameObject btnNext, btnTry, btnSubmit, btnSkip, btnHint;//tambahan skip
    public GameObject correctText, incorrectText, emptyText;
    public List<Toggle> OptionsTog = new List<Toggle>();
    [Header("All Texts & Strings")]
    public Text QuestionsBox;
    public Text questPage;
    public List<Text> resultText;
    public string[] tempTogQuest;
    [Header("All Counts")]
    public int QuestNOW;
    public int hintCount, skipCount;//tambahan skip
    [HideInInspector] public int cek;//buat cek jika sudah salah dan kemudian langsung diskip
    public int totalsoal;
    public float converthasil;
    public List<int> correct = new List<int>();
    public List<int> AnswerChace = new List<int>();
    public string datacorrect;
    [HideInInspector] public string dataAnswerChace;
    public int True_Answer;
    [Header("TIME")]
    public float waktu;
    public float detik, menit;
    [Header("counter Questions")]
    //public Animation a;
    //public Animation b;
    [HideInInspector] public int CounterLap1, CounterLap2;

    
    bool Cek_Update;
    // Use this for initialization
    void Start()
    {
        Script_Static.halaman_referensi = 0;
        finalresults.SetActive(false);
        totalsoal = QuestionsList.Count;
        saveLoadData.saveDataQR(this, "get", "qr");
        for (int i = 0; i < QuestionsList.Count; i++)
        {
            correct.Add(1);
            AnswerChace.Add(0);
            dataAnswerChace += AnswerChace[i].ToString();
            datacorrect += correct[i].ToString();
            AnswerChace[i] = int.Parse(dataAnswerChace.Substring(i, 1));
            correct[i] = int.Parse(datacorrect.Substring(i, 1));
        }
        updatedata();
        questPage.text = QuestNOW + 1 + " of " + QuestionsList.Count;
        countTogSplit();
        CounterSoal();
        Cek_Update = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Cek_Update)
        {
            True_Answer = (from _number in AnswerChace where _number == 1 || _number == 2 select _number).Count();
        }
        //Debug.Log ("jumlah soal selesai " + countAC);
        if (True_Answer != QuestionsList.Count)
        {
            waktu += Time.deltaTime;
            timer();
        }
        if (Cek_Update)
        {
            if (True_Answer == QuestionsList.Count && !btnNext.activeSelf)
            {
                finalresults.SetActive(true);
                resultText[0].text = QuestionsList.Count.ToString();
                timer();
                resultText[2].text = correct.Count(yh => yh == 1).ToString();
                resultText[3].text = hintCount.ToString();
                resultText[4].text = skipCount.ToString();//tambahan skip
                resultText[5].text = correct.Count(yh => yh == 0).ToString();//tambahan salah jawab
                onoffAllTog(0);
                matikanAll(0);
                matikanAll(1);
                matikanAll(2);
                btnSkip.SetActive(false);
                Debug.Log("namanya " + btnSkip.transform.parent.name);
                btnSubmit.SetActive(false);
                QuestionsBox.text = "You've Completely Questions";
                questPage.text = "Done";
                hitungGrafik();
                percentage.GetComponent<Image>().fillAmount += Time.deltaTime;
                if (percentage.GetComponent<Image>().fillAmount >= converthasil)
                {
                    percentage.GetComponent<Image>().fillAmount = converthasil;
                }
            }
            Cek_Update = false;
        }
    }

    public void check_Update()
    {
        Cek_Update = true;
    }
    void matikanAll(int Help)
    {
        if (Help == 0)
        {//buat matikan panel check 
            for (int i = 0; i < panelChecks.transform.childCount; i++) { panelChecks.transform.GetChild(i).gameObject.SetActive(false); }
        }
        else if (Help == 1)
        {//buat matikan Toggle
            for (int i = 0; i < OptionsTog.Count; i++) { OptionsTog[i].gameObject.SetActive(false); OptionsTog[i].isOn = false; }
        }
        else if (Help == 2)
        {//buat matikan resultButton
            for (int i = 0; i < resultButton.transform.childCount; i++) { resultButton.transform.GetChild(i).gameObject.SetActive(false); }
        }
    }
    void onoffAllTog(int help)
    {
        if (help == 0)
        {//off
            for (int i = 0; i < OptionsTog.Count; i++) { OptionsTog[i].interactable = false; }
        }
        else if (help == 1)
        {//on
            for (int i = 0; i < OptionsTog.Count; i++) { OptionsTog[i].interactable = true; }
        }
    }
    public void save_data_()
    {
        if (correctText.activeSelf && True_Answer != QuestionsList.Count) { QuestNOW++; Debug.Log("deteksi 1"); }//jika sudah benar tapi user klik backToMenu
        if (correctText.activeSelf && True_Answer == QuestionsList.Count) { QuestNOW = 0; Debug.Log("deteksi 2"); } //jika sudah benar dan soal terakhir & user klick backToMenu
        saveLoadData.saveDataQR(this, "set", "qr");
    }

    public void saveplayerpref_()
    {
        saveLoadData.saveDataQR(this, "set", "qr");

    }
    public void deleteprefs()
    {
        PlayerPrefs.DeleteAll();
    }
    public void NextQuest()
    {
        if (cek == 1) SkipQuest();
        else
        {
            QuestNOW++;
            for (int i = 0; i < AnswerChace.Count; i++)
            {
                if (QuestNOW == QuestionsList.Count)
                {
                    QuestNOW = 0;
                }
            }
            countTogSplit();
            questPage.text = QuestNOW + 1 + " of " + QuestionsList.Count;
            matikanAll(0);
            matikanAll(2);
            onoffAllTog(1);
            if (True_Answer == QuestionsList.Count)
            {
                QuestionsBox.text = "You've Completely Questions";
            }
            btnSubmit.SetActive(true);
            btnSkip.SetActive(true);//tambahan skip
        }
    }
    public void TryQuest()
    {
        cek = 1;
        countTogSplit();
        matikanAll(0);
        matikanAll(2);
        onoffAllTog(1);
        btnSubmit.SetActive(true); 
        btnSkip.SetActive(true);
    }
    public void HintQuest()
    {
        hintCount++;
        btnHint.SetActive(true);
        btnTry.SetActive(true);
        if (halaman[QuestNOW]==-1) {
            SceneManager.LoadScene("Component Identification");
        }
        else if (halaman[QuestNOW] == -2)
        {
            SceneManager.LoadScene("Technical Simulation");
        }
        else
        {
            Script_Static.halaman_referensi = halaman[QuestNOW];
            SceneManager.LoadScene("Background Theory");
        }
        //Script_Static.halaman_referensi = halaman[QuestNOW];
        //SceneManager.LoadScene("Background Theory");
        saveLoadData.saveDataQR(this, "set", "qr");
    }
    public void SkipQuest()
    {
        AnswerChace[QuestNOW] = 2;
        totalsoal = totalsoal - 1;
        if (cek == 0)
        {
            skipCount++;//tambahan skip
            correct[QuestNOW] = 2;
        }
        QuestNOW++;
        if (totalsoal == 0) QuestNOW = 0;
        countTogSplit();
        questPage.text = QuestNOW + 1 + " of " + QuestionsList.Count;
        CounterSoal();
        matikanAll(2);
        onoffAllTog(1);//hidupin toggle lagi
        btnSubmit.SetActive(true);
        btnSkip.SetActive(true);
        updatedata();
        matikanAll(0);
        cek = 0;
    }
    public void resetQuiz()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        saveLoadData.saveDataQR(this, "reset", "qr");
    }
    public void SubmitCheck()
    {
        int kosong = 0;
        for (int i = 0; i < tempTogQuest.Length; i++)
        {
            if (!OptionsTog[i].isOn)
            {
                kosong++;
            }
            if (kosong == tempTogQuest.Length)
            {
                matikanAll(0);
                matikanAll(2);
                emptyText.SetActive(true);
                btnSubmit.SetActive(true);
                btnSkip.SetActive(true);//tambahan skip
                updatedata();
            }
            else
            {
                if (OptionsTog[i].isOn && OptionsTog[i].transform.GetChild(2).GetComponent<Text>().text == answers_[QuestNOW])
                {//jika benar
                    if (cek == 1) cek = 0;
                    //s.correct_();
                    matikanAll(0);
                    matikanAll(2);
                    onoffAllTog(0);
                    correctText.SetActive(true);
                    btnSkip.SetActive(false);
                    btnSubmit.SetActive(false);
                    btnNext.SetActive(true);
                    AnswerChace[QuestNOW] = 1;//kalau benar angka jadi 1;
                    totalsoal = totalsoal - 1;//kalau  benar totalsoal berkurang;
                    CounterSoal();
                    updatedata();
                }
                else if (OptionsTog[i].isOn && OptionsTog[i].transform.GetChild(2).GetComponent<Text>().text != answers_[QuestNOW])
                {//jika salah
                    cek = 1;
                    //s.error_();
                    matikanAll(0);
                    matikanAll(2);
                    btnSkip.SetActive(false);
                    btnSubmit.SetActive(false);
                    onoffAllTog(0);
                    incorrectText.SetActive(true);
                    btnHint.SetActive(true);
                    btnTry.SetActive(true);
                    btnNext.SetActive(true);
                    correct[QuestNOW] = 0; //jika soal salah jawab pertama kali maka angka jadi 0;
                    updatedata();
                }
            }
        }
    }
    void updatedata()//update data setelah benar salah atau skip
    {
        dataAnswerChace = null;
        datacorrect = null;
        for (int i = 0; i < QuestionsList.Count; i++)
        {
            dataAnswerChace += AnswerChace[i].ToString();
            datacorrect += correct[i].ToString();
        }
    }
    void hitungGrafik()
    {
        int totalbenar = correct.Count(yh => yh == 1);
        float hasilcount = (totalbenar * 100) / (float)QuestionsList.Count;
        converthasil = hasilcount / 100;
        Debug.Log("hasilgrafik " + hasilcount + " hasil convert " + converthasil);
        percentage.transform.GetChild(1).GetComponent<Text>().text = hasilcount.ToString("0.0") + "%";
        percentage.transform.GetChild(2).GetComponent<Text>().text = totalbenar.ToString() + " out of " + QuestionsList.Count + " correct";
    }
    #region Countersoal
    void CounterSoal()
    {
        int temptotal = totalsoal;
        if (temptotal.ToString().Length == 2)
        {
            if (CounterLap2 == 0)
            {
                //	a.Play (temptotal.ToString ().Substring (0, 1));
                //	b.Play (temptotal.ToString ().Substring (1, 1));
                CounterLap2 = 1;
            }
            if (CounterLap2 == 1)
            {
                //	b.Play (temptotal.ToString ().Substring (1, 1));
            }
            if (CounterLap2 == 1 && temptotal.ToString().Substring(1, 1) == 0.ToString())
            {
                CounterLap2 = 0;
            }
        }
        else if (temptotal.ToString().Length == 1)
        {
            if (CounterLap1 == 0)
            {
                //	a.Play ("0");
                //	b.Play (temptotal.ToString ());
                CounterLap1 = 1;
            }
            if (CounterLap1 == 1)
            {
                //	b.Play (temptotal.ToString ());
            }
        }
    }
    #endregion
    #region Timer
    void timer()
    {
        menit = Mathf.FloorToInt(waktu / 60);
        detik = Mathf.FloorToInt(waktu - menit * 60);
        string detik0 = ""; if (detik < 2) { detik0 = "Second"; } else { detik0 = "Seconds"; }
        string menit0 = ""; if (menit < 2) { menit0 = "Minute"; } else { menit0 = "Minutes"; }
        if (menit == 0)
        {
            resultText[1].text = "Time\t\t\t\t\t\t:  " + detik.ToString() + " " + detik0;
        }
        else
        {
            resultText[1].text = "Time\t\t\t\t\t\t:  " + menit.ToString() + " " + menit0 + " " + detik.ToString() + " " + detik0;
        }
    }
    #endregion
    #region split Toggle
    void countTogSplit()
    {
        tempTogQuest = answersOPt[QuestNOW].Split('|');
        //Debug.Log("jumlah temp "+tempTogQuest.Length);
        matikanAll(1);//matikan toggle
        for (int i = 0; i < tempTogQuest.Length; i++)
        {
            OptionsTog[i].gameObject.SetActive(true);
            OptionsTog[i].transform.GetChild(2).GetComponent<Text>().text = tempTogQuest[i];//untuk label
        }
        QuestionsBox.text = QuestionsList[QuestNOW];
    }
    #endregion
}
