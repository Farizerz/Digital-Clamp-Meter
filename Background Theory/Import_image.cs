using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace zSpace.Core.Input
{
    public class Import_image : MonoBehaviour
    {
        public Button but_prev, but_next;
        public Image[] Page_;
        public Sprite[] gambar_PNG;
        public static int halaman, buka_halaman;
        AutoFlip Script_book;
        BookPro BukuPro;

        // Start is called before the first frame update
        void Start()
        {
            Script_book = GetComponent<AutoFlip>();
            for (int i = 0; i < Page_.Length; i++)
            {
                Page_[i].sprite = gambar_PNG[i];
            }
            BukuPro = GetComponent<BookPro>();
            //BukuPro.CurrentPaper = script_static.halaman_referensi/2;
            BukuPro.UpdatePages();
            halaman = BukuPro.CurrentPaper;
        }

        // Update is called once per frame
        void Update()
        {
            if (Script_Static.buttonPressed_1 && BukuPro.CurrentPaper < Page_.Length / 2) //stylus tombol kanan release
            {
                Script_book.FlipRightPage();
            }
            if (Script_Static.buttonPressed_2 && BukuPro.CurrentPaper > 0) //stylus tombol kiri release
            {
                Script_book.FlipLeftPage();
            }

            if (BukuPro.CurrentPaper == 0)
            {
                but_prev.gameObject.SetActive(false);
            }
            else if (BukuPro.CurrentPaper == Page_.Length / 2)
            {
                but_next.gameObject.SetActive(false);
            }
            else
            {
                but_prev.gameObject.SetActive(true);
                but_next.gameObject.SetActive(true);
            }
        }
        //private void OnValidate()
        //{
        //    for (int i = 0; i < Page_.Length; i++)
        //    {
        //        Page_[i].sprite = gambar_PNG[i];
        //    }
        //}
    }
}
