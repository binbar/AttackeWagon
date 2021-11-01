using DG.Tweening;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
namespace GameCore.DoTween
{
    public class ImageAlphaTween : MonoBehaviour
    {
        Graphic _graphics = null;

        [SerializeField] bool _tweenOnEnable;

        [SerializeField] float _startAlpha = 1f;
        [SerializeField] float _endAlpha = 0f;
        [SerializeField] float _duration;
        [SerializeField] Ease _ease = Ease.Linear;
        [SerializeField] bool _setLoop;
        [SerializeField] private int _loopsCount;
        [SerializeField] private LoopType _loopType;
        [SerializeField] CanvasGroup _overrideCanvasGroup;
        [SerializeField] UnityEvent _onComplete;
        private Tween tween = null;

        private void OnValidate ()
        {
            ValidateGraphics ();
        }

        private void ValidateGraphics ()
        {
            if (_graphics == null) _graphics = GetComponent<Graphic> ();
        }

        private void OnEnable ()
        {
            ValidateGraphics ();
            if (_tweenOnEnable) DoTween ();
        }
        public void DoTween ()
        {
            // Debug.Log ($"_graphics.color.a : {_graphics.color.a}");
            _graphics.color = _graphics.color.With_a (_startAlpha);
            if (_overrideCanvasGroup)
                _overrideCanvasGroup.alpha = _startAlpha;

            if (tween == null)
                configTween (tween);

            tween.Play ();

        }
        private void OnDisable ()
        {
            tween.Kill (true);
        }

        private void configTween (Tween tween)
        {
            // Debug.Log ($"_graphics.color.a : {_graphics.color.a}");

            if (_overrideCanvasGroup)
                tween = _overrideCanvasGroup.DOFade (_endAlpha, _duration);
            else
                tween = _graphics.DOFade (_endAlpha, _duration);

            tween
                .SetEase (_ease)
                .OnComplete (_onComplete.Invoke);

            if (_setLoop)
                tween.SetLoops (_loopsCount, _loopType);
        }
    }

}