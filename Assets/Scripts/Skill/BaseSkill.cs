using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Skill
{
    enum SkillState
    {
        Selected,
        UnSelected
    }
    public class BaseSkill:MonoBehaviour
    {
       
        public Image area;
        public Image skillicon;
        public float cd;
        private Timer skillTimer;
        private SkillState _skillState;
        private void Start()
        {
            _skillState = SkillState.UnSelected;
            
            area.gameObject.SetActive(false);
            
            skillTimer=Timer.Register(cd, () =>  {   });
                
           GetComponent<Button>().onClick.AddListener(() =>
            {
                if (!skillTimer.isCompleted)
                {
                    Debug.Log("未完成");
                    return;
                }
                Cursor.visible=false;
                area.gameObject.SetActive(true);
                _skillState = SkillState.Selected;
            });
            area.transform.DOScale(1.3f,0.5f).SetLoops(-1, LoopType.Yoyo);
        }

        private void LateUpdate()
        {
            
            skillicon.fillAmount=1- skillTimer.GetRatioComplete();
            area.transform.position = Input.mousePosition;
            switch (_skillState)
            {
                case SkillState.Selected:
                    if (Input.GetMouseButtonDown(0))
                    {
                        ReleaseSkill();
                        skillTimer=Timer.Register(cd,null);
                        area.gameObject.SetActive(false);
                        Cursor.visible = true;
                        _skillState = SkillState.UnSelected;
                    }

                    if (Input.GetMouseButtonDown(1))
                    {
                        area.gameObject.SetActive(false);
                        Cursor.visible = true;
                        _skillState = SkillState.UnSelected;
                    }
                    break;
                case SkillState.UnSelected:
                    break;
            }
           
        }

        public virtual void ReleaseSkill(){ }
                                                  
                                                 
        
    }
}