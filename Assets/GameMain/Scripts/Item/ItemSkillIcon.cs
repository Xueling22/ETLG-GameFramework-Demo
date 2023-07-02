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

        private int sceneID;


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
            // TODO ��ʾ��ǰ���������������Դ��ȷ�ϰ�ť

        }

        private void OnIconPointerEnter()
        {

            // ��ù��ض����λ��
            Vector3 itemPosition = RectTransformUtility.WorldToScreenPoint(null, transform.position);
            Vector3 newPosition = itemPosition + new Vector3(100f, 0f, 0f);


            GameEntry.Data.GetData<DataSkill>().currentSkillID = this.skillData.Id;
            GameEntry.Data.GetData<DataSkill>().skillInfoPosition = newPosition;

            // ��ʾskill info ui ���¼�������UIӦ����ʾ��λ��
            GameEntry.Event.Fire(this, SkillInfoOpenEventArgs.Create());

        }

        private void OnIconPointerExit()
        {
            // �رռ�����ϢUI
            GameEntry.Event.Fire(this, SkillInfoCloseEventArgs.Create());

        }


        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);

        }

        public void SetSkillData(SkillData skillData, int sceneID)
        {
            this.skillData = skillData;

            string texturePath = "";

            // ���ݳ���ID��չʾ��ͬicon
            this.sceneID = sceneID;
            // 3 == �½���Ϸ
            if (sceneID == 3)
            {
                texturePath = AssetUtility.GetSkillIcon(skillData.Id.ToString(), "2");
            }
            // 5 == ��Ҳ˵�
            if (sceneID == 5)
            {
                texturePath = AssetUtility.GetSkillIcon(skillData.Id.ToString(), skillData.ActiveState.ToString());
            }

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
            //inSelectScene = false;

            base.OnHide(isShutdown, userData);

        }

    }
}


