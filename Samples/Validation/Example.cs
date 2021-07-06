using JasonStorey.UiTools;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace JasonStorey
{
    public class Example : MonoBehaviour
    {
        [SerializeField,Required]
        Image _image;
        [SerializeField,Required]
        TMP_Text _label;
        
        void Awake() => this.Validate();
    }
    
}