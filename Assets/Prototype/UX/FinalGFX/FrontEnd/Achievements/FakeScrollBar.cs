using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

 public class FakeScrollBar : MonoBehaviour {
     void Awake() {
         transform.GetComponent<Scrollbar>().size = 0;
     }
 }
