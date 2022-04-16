using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace zSpace.Core.Samples
{
    public class Set_stylus : MonoBehaviour
    {
        public ZFrame _Zframe;
        public GameObject stylus_;
        public LineRenderer _Beam;

        // Start is called before the first frame update
        void Start()
        {
            stylus_.transform.localScale = new Vector3(_Zframe.ViewerScale, _Zframe.ViewerScale, _Zframe.ViewerScale);
        }

        // Update is called once per frame
        void Update()
        {
            stylus_.transform.localPosition = new Vector3(0, 0, _Beam.GetPosition(29).z);
        }
    }
}
