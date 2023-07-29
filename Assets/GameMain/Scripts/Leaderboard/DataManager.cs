using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework;
using UnityGameFramework.Runtime;
using ETLG.Data;
using UnityEngine.Networking;
namespace ETLG
{
    public class DataManager : Singleton<DataManager>
    {
        public string responseData;
        List<LeaderboardData> rankList;
        //���а�
        private string leaderboard_url = "https://github.com/xw22087/rbac/tree/main/rbac-backend/src/main/java/com/imyuanxiao/rbac/controller/api/profile/getRank";


        protected override void Awake()
        {
            base.Awake();
            rankList = new List<LeaderboardData>();
        }
        public List<LeaderboardData> GetRankData(int pageNumber, int pageSize, int rankMode)
        {
            StartCoroutine(GetRankDataRoutine(pageNumber, pageSize, rankMode));
            return rankList;
        }

        private IEnumerator GetRankDataRoutine(int pageNumber, int pageSize, int rankMode)
        {
            // ����POST����ı�����
            WWWForm form = new WWWForm();
            form.AddField("pageNumber", pageNumber);
            form.AddField("pageSize", pageSize);
            form.AddField("rankMode", rankMode);

            using (UnityWebRequest www = UnityWebRequest.Post(leaderboard_url, form))
            {
                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.Success)
                {
                    // ��ȡAPI��Ӧ����
                    string responseJson = www.downloadHandler.text;

                    // ����JSON��Ӧ����
                    List<List<object>> rankData = JsonUtility.FromJson<RankData>(responseJson).rankList;

                    // �������а�����
                    foreach (List<object> rowData in rankData)
                    {
                        LeaderboardData data = new LeaderboardData();
                        string userName = (string)rowData[0];
                        data.Name = userName;
                        int id = (int)rowData[1];
                        data.Id = id;
                        int spaceshipScore = (int)rowData[2];
                        data.SpaceshipScore = spaceshipScore;
                        int achievementPoint = (int)rowData[3];
                        data.AchievementScore = achievementPoint;
                        if(rankMode>1)
                        {
                            float boss = (int)rowData[4];
                            //data.boss
                        }
                        Debug.Log("User Name: " + userName + ", Spaceship Score: " + spaceshipScore);
                    }
                }
                else
                {
                    // API����ʧ��
                    Debug.LogError("Error: " + www.error);
                }
            }
        }
        [System.Serializable]
        private class RankData
        {
            public List<List<object>> rankList;
        }
    }
}
