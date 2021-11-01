using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

namespace GameCore
{
    [RequireComponent(typeof(Collider2D))]
    public class TriggerTagActions : MonoBehaviour
    {
        private Collider2D _collider = null;
        public new Collider2D collider { get { if (_collider == null) _collider = GetComponent<Collider2D>(); return _collider; } }
        private void Awake() { collider.isTrigger = true; }

        [SerializeField] List<TagAction> OnEnterTrigger;
        [SerializeField] List<TagAction> OnExitTrigger;
        public void AddOnEnterAction(string Tag, UnityEvent action)
        {
            TagAction tagAction = new TagAction();
            tagAction.Tag = Tag;
            tagAction.Action = action;
            OnEnterTrigger.Add(tagAction);

        }
        public void AddOnExitAction(string Tag, UnityAction action)
        {
            var tagAction = OnExitTrigger.Find(ta => ta.Tag == Tag);
            if (tagAction == null) return;
            tagAction.Action.AddListener(action);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            foreach (var trigger in OnEnterTrigger)
                trigger.Invoke(other.gameObject);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            foreach (var trigger in OnExitTrigger)
                trigger.Invoke(other.gameObject);
        }
    }

    [System.Serializable]
    public class TagAction
    {
        public string Tag;
        public UnityEvent Action;
        public void Invoke(GameObject go)
        {
            if (go.CompareTag(Tag))
            {
                Action.Invoke();
            }
        }
    }
}