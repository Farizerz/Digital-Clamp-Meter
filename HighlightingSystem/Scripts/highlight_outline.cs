using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class highlight_outline : HighlighterController {
	public bool On_,Rainbow_;
	public float Speed_Rainbow;
	public Color outline;
	int posisi;
	float timer;
	// Use this for initialization
	void Start () {
		posisi = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (On_) {
			if (Rainbow_) {
				if (Speed_Rainbow <= 0) {
					Speed_Rainbow = 1;
				}
				timer += Time.deltaTime *Speed_Rainbow;
				if (timer >= 1) {
					timer = 0;
					posisi++;
				}
				if (posisi > 5) {
					posisi = 0;
				}
				switch (posisi) {
				//case 0:
				//	h.ConstantOn (new Color(1,0,0+timer));
				//	break;
				//case 1:
				//	h.ConstantOn (new Color(1-timer,0,1));
				//	break;
				//case 2:
				//	h.ConstantOn (new Color(0,0+timer,1));
				//	break;
				case 1:
					h.ConstantOn (new Color(0,1,1-timer));
					break;
				case 2:
					h.ConstantOn (new Color(0+timer,1,0));
					break;
				//case 3:
				//	h.ConstantOn (new Color(1,1-timer,0));
				//	break;
				}
			} else {
				h.ConstantOn (outline);
			}
		} else {
			h.ConstantOff ();
		}
	}
}
