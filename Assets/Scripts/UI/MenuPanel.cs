using UnityEngine;

namespace UI
{
    public class MenuPanel:BasePanel
    {
        public override void OnEnter()
        {
            Debug.Log("Enter");
            this.gameObject.SetActive(true);
        }

        public override void OnPause()
        {
            Debug.Log("Pause");
            this.gameObject.SetActive(false);
        }

        public override void OnResume()
        {
            base.OnResume();
        }

        public override void OnExit()
        {
            base.OnExit();
        }
    }
}