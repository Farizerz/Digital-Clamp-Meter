using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace zSpace.Core.Input
{
    public class Set_active_page : MonoBehaviour
    {
        public AutoFlip Script_book;
        public BookPro BukuPro;
        public Import_image var_import_image;
        public int page_number, prev_page_number;
        // Start is called before the first frame update
        void Start()
        {
            //page_number = 0;
            page_number = BukuPro.CurrentPaper;
            for (int i = 0; i < var_import_image.Page_.Length; i++)
            {
                if ((i >= (page_number - 1) * 2) && (i <= (page_number + 1) * 2))
                {
                    var_import_image.Page_[i].gameObject.SetActive(true);
                }
                else
                {
                    var_import_image.Page_[i].gameObject.SetActive(false);
                }
            }
        }

        // Update is called once per frame
        void Update()
        {

        }


        public void Button_next()
        {
            if (prev_page_number != page_number)
            {
                prev_page_number = page_number - 1;
                for (int i = 0; i < var_import_image.Page_.Length; i++)
                {
                    if ((i >= (prev_page_number - 1) * 2) && (i <= (prev_page_number + 1) * 2))
                    {
                        var_import_image.Page_[i].gameObject.SetActive(true);
                    }
                    else
                    {
                        var_import_image.Page_[i].gameObject.SetActive(false);
                    }
                }
                prev_page_number = page_number;
            }
        }
        public void Button_prev()
        {
            if (prev_page_number != page_number)
            {
                prev_page_number = page_number + 1;
                for (int i = 0; i < var_import_image.Page_.Length; i++)
                {
                    if ((i >= (page_number - 1) * 2) && (i <= (page_number + 1) * 2))
                    {
                        var_import_image.Page_[i].gameObject.SetActive(true);
                    }
                    else
                    {
                        var_import_image.Page_[i].gameObject.SetActive(false);
                    }
                }
                prev_page_number = page_number;
            }
        }
    }
}
