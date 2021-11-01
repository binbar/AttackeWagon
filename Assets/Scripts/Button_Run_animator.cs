using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
namespace QuestEngine
{
    public class Button_Run_animator : MonoBehaviour
    {
        Selectable selectable;
        [SerializeField] Image fill;
        [SerializeField] float cdTime = 5f;
        [SerializeField] UnityEvent OnStartCD;
        [SerializeField] UnityEvent OnEndCD;
        public PovokZKA povozka;
        bool started = false;

        private void Awake()
        {
            selectable = GetComponent<Selectable>();
        }

        public void StartCD()
        {
            if (PlayerPrefs.GetInt("Carrot") > 0)
            {
                //                Debug.Log("Carrot######=" + PlayerPrefs.GetInt("Carrot"));
                PlayerPrefs.SetInt("Carrot", PlayerPrefs.GetInt("Carrot") - 1);

                if (povozka.currentState == PovokZKA.State.Horse_Walk_walk)
                {

                    if (started) return;
                    started = true;

                    selectable.interactable = false;
                    fill.enabled = true;
                    fill.fillAmount = 5f; //время ,
                    OnStartCD.Invoke();
                    //    DOVirtual.Float(0, cdTime, cdTime, t => fill.fillAmount = t / cdTime).OnComplete(onComplete);
				//	    DOVirtual.Float(0, cdTime, cdTime, t => fill == null ? 0 : (fill.fillAmount / cdTime) ).OnComplete(onComplete);
                    DOVirtual.Float(0, cdTime, cdTime, t => {if (fill != null){fill.fillAmount = t / cdTime;} }).OnComplete(onComplete);

                }

            }
        }

        private void onComplete()
        {
			if (selectable!=null)
			{
			selectable.interactable = true;
            fill.enabled = false;
            OnEndCD.Invoke();
            started = false;	
			}
        }
    }
}