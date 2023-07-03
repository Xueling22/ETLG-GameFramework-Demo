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
    public class ItemArtifactIcon : ItemLogicEx
    {

        //private ArtifactDataBase artifactData;

        private PlayerArtifactData playerArtifact;//

        public RawImage artifactIcon;

        public Button iconButton;

        public TextMeshProUGUI artifactNumber;

        //public bool isEmpty;

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
            /*if (isEmpty)
            {
                return;
            }*/
            // ��ù��ض����λ��
/*            Vector3 itemPosition = RectTransformUtility.WorldToScreenPoint(null, transform.position);
            Vector3 newPosition = itemPosition + new Vector3(100f, 0f, 0f);

            GameEntry.Data.GetData<DataArtifact>().currentArtifactID = this.artifactData.Id;
            GameEntry.Data.GetData<DataArtifact>().artifactInfoPosition = newPosition;
*/
            // ��ʾskill info ui ���¼�������UIӦ����ʾ��λ��
            // GameEntry.Event.Fire(this, ArtifactInfoOpenEventArgs.Create());

        }

        private void OnIconPointerExit()
        {
/*            if (isEmpty)
            {
                return;
            }*/

            // �رռ�����ϢUI
            //GameEntry.Event.Fire(this,  ArtifactInfoCloseEventArgs.Create());

        }


        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);

        }

        public void SetArtifactData(PlayerArtifactData playerArtifact)
        {
            this.playerArtifact = playerArtifact;

            this.artifactNumber.text = playerArtifact.Number.ToString();

            string texturePath = AssetUtility.GetArtifactIcon(playerArtifact.Id.ToString());

            Texture texture = Resources.Load<Texture>(texturePath);

            if (texture == null)
            {
                texturePath = AssetUtility.GetArtifactIcon("iconLost");
                texture = Resources.Load<Texture>(texturePath);
            }

            if (texture != null)
            {
                artifactIcon.texture = texture;
            }
            else
            {
                Debug.LogError("Failed to load texture: " + texturePath);
            }

        }

        /*  public void SetArtifactData(ArtifactDataBase artifactData, int number,  bool isEmpty)
          {
              this.artifactData = artifactData;

              this.artifactNumber.text = number.ToString();

              this.isEmpty = isEmpty;

              if (isEmpty)
              {
                  return;
              }

              string texturePath = AssetUtility.GetArtifactIcon(artifactData.Id.ToString());
              Texture texture = Resources.Load<Texture>(texturePath);

              if(texture == null)
              {
                  texturePath = AssetUtility.GetArtifactIcon("iconLost");
                  texture = Resources.Load<Texture>(texturePath);
              }

              if (texture != null)
              {
                  artifactIcon.texture = texture;
              }
              else
              {
                  Debug.LogError("Failed to load texture: " + texturePath);
              }

          }*/

        protected override void OnHide(bool isShutdown, object userData)
        {
            //inSelectScene = false;

            base.OnHide(isShutdown, userData);

        }

    }
}


