using ETLG.Data;
using GameFramework.Resource;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

namespace ETLG
{
    public class ItemSkillIcon : ItemLogicEx
    {

        private SkillData skillData;

        public RawImage skillIcon;

        public Button iconButton;


        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            iconButton.onClick.AddListener(OnIconButtonClick);

            EventTrigger trigger = iconButton.gameObject.AddComponent<EventTrigger>();

            // ����������¼�������
            EventTrigger.Entry enterEntry = new EventTrigger.Entry();
            enterEntry.eventID = EventTriggerType.PointerEnter;
            enterEntry.callback.AddListener((data) => { OnIconPointerEnter(); });
            trigger.triggers.Add(enterEntry);

            // �������Ƴ��¼�������
            EventTrigger.Entry exitEntry = new EventTrigger.Entry();
            exitEntry.eventID = EventTriggerType.PointerExit;
            exitEntry.callback.AddListener((data) => { OnIconPointerExit(); });
            trigger.triggers.Add(exitEntry);
        }

        private void OnIconButtonClick()
        {
          /*  GameEntry.Data.GetData<DataSkill>().currentSkillID = this.skillData.Id;

            GameEntry.Event.Fire(this, SkillInfoOpenEventArgs.Create());*/

        }

        private void OnIconPointerEnter()
        {
            Debug.Log("Mouse entered iconButton");

            GameEntry.Data.GetData<DataSkill>().currentSkillID = this.skillData.Id;

            // ��ʾ������ϢUI
            GameEntry.Event.Fire(this, SkillInfoOpenEventArgs.Create());

        }

        private void OnIconPointerExit()
        {
            Debug.Log("Mouse exited iconButton");

            // �رռ�����ϢUI
            GameEntry.Event.Fire(this, SkillInfoCloseEventArgs.Create());


        }


        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);

        }

        public void SetSkillData(SkillData skillData)
        {
            this.skillData = skillData;

            string state = skillData.ActiveState.ToString();
            string texturePath = AssetUtility.GetSkillIcon(skillData.Id.ToString(), state);

            // ���ݵ�ǰ����ID �� ����״̬ ��ȡͼ��
            Texture texture = Resources.Load<Texture>(texturePath);

            if (texture != null)
            {
                // �����ص�����ֵ��Raw Image������
                skillIcon.texture = texture;
            }
            else
            {
                Debug.LogError("Failed to load texture: " + texturePath);
            }

        }

        protected override void OnHide(bool isShutdown, object userData)
        {
            base.OnHide(isShutdown, userData);

        }

    }
}


