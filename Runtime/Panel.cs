using UnityEngine;
namespace JasonStorey.UiTools
{
    public class Panel : MonoBehaviour
    {
        [ContextMenu("Show")]
        public void Show() => Visibility = 1;
        [ContextMenu("Hide")]
        public void Hide() => Visibility = 0;

        #region Plumbing

        float Visibility
        {
            get => CanvasGroup.alpha;
            set => CanvasGroup.alpha = value;
        }
        
        CanvasGroup CanvasGroup
        {
            get
            {
                if (_canvasGroup == null) _canvasGroup = this.GetOrCreate<CanvasGroup>();
                return _canvasGroup;
            }
        }

        CanvasGroup _canvasGroup;
        #endregion
    }
}