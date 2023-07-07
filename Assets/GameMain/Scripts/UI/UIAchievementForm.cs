using ETLG.Data;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;
namespace ETLG
{
    public class UIAchievementForm : UGuiFormEx
    {

        // buttons
        public Button returnButton;

        // Type name
        public TextMeshProUGUI s_name_1 = null;
        public TextMeshProUGUI s_name_2 = null;
        public TextMeshProUGUI s_name_3 = null;
        public TextMeshProUGUI s_name_4 = null;
        public TextMeshProUGUI s_name_5 = null;
        public TextMeshProUGUI s_name_6 = null;
        public TextMeshProUGUI s_name_7 = null;
        public TextMeshProUGUI s_name_8 = null;
        public TextMeshProUGUI s_name_9 = null;
        public TextMeshProUGUI s_name_10 = null;

        public Transform content_1 = null;
        public Transform content_2 = null;
        public Transform content_3 = null;
        public Transform content_4 = null;
        public Transform content_5 = null;
        public Transform content_6 = null;
        public Transform content_7 = null;
        public Transform content_8 = null;
        public Transform content_9 = null;
        public Transform content_10 = null;
        // initial attrs
        public TextMeshProUGUI s_unlockedNumber = null;
        private Dictionary<int, List<PlayerAchievementData>> playerAchievementData;
        private DataPlayer dataPlayer;

        // ʵ�������
        private EntityLoader entityLoader;


        // ��ʼ���˵�����
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            // �󶨰�ť����¼�
            returnButton.onClick.AddListener(OnReturnButtonClick);


            // ��ȡ������ݹ�����
            dataPlayer = GameEntry.Data.GetData<DataPlayer>();
            entityLoader = EntityLoader.Create(this);
            //��ȡ�ɾ�����
            playerAchievementData = dataPlayer.GetPlayerData().getPlayerAchievements();
            //���سɾ����ƣ��ȼ���
            foreach (KeyValuePair<int, List<PlayerAchievementData>> pair in playerAchievementData)
            {
                if (pair.Key == Constant.Type.ACHV_QUIZ)
                {
                    s_name_1.text = "Quiz";
                    showAchievements(content_1, pair.Value);
                }
                else if (pair.Key == Constant.Type.ACHV_RESOURCE)
                {
                    s_name_2.text = "Resource";
                    showAchievements(content_2, pair.Value);
                }
                //...
            }
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

        }

        protected override void OnClose(bool isShutdown, object userData)
        {
            base.OnClose(isShutdown, userData);
        }

        private void OnReturnButtonClick()
        {
            Log.Debug("Return to Player Menu");
            GameEntry.Sound.PlaySound(EnumSound.ui_sound_back);

            // ͨ�������¼���������������¼��Ӷ�������һ������������
          //  GameEntry.Event.Fire(this, ChangeSceneEventArgs.Create(GameEntry.Config.GetInt("Scene.PlayerMenu")));

        }

        private void showAchievements(Transform container, List<PlayerAchievementData> playerAchievementData)
        {
            for (int i = 0; i < playerAchievementData.Count; i++)
            {
                // ���㵱ǰԪ�����ڵ�����,һ�а�����
                int row = i / 2; 

                Vector3 offset = new Vector3((i % 2) * 325f, row * -150f, 0f) + new Vector3(175f, -80f, 0f);

                PlayerAchievementData playerAchievement = playerAchievementData[i];

                ShowItem<ItemAchievementIcon>(EnumItem.AchievementIcon, (item) =>
                {
                    item.transform.SetParent(container, false);
                    item.transform.localScale = Vector3.one;
                    item.transform.eulerAngles = Vector3.zero;
                    item.transform.localPosition = Vector3.zero + offset;
                    item.GetComponent<ItemAchievementIcon>().SetAchievementData(playerAchievement, container);
                });
            }


        }
    }







}