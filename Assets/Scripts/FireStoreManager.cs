using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;
using Firebase.Extensions;
using TMPro;

public class FireStoreManager : MonoBehaviour
{
    FirebaseFirestore db;
    [SerializeField] private int goldAmount = 0;
    [SerializeField] private string role = "";
    [SerializeField] private TextMeshProUGUI debugText;
    private void Start() => db = FirebaseFirestore.DefaultInstance;

    void GetInfoAsText(UserData userData)=> debugText.text = string.Format("User {0}'s \n gold Amount Is : {1}.\n Role : {2}", UserID.USERID, userData.Gold.ToString(),userData.Role.ToString());
    
    public void SetUserInfo()
    {
        UserData userData = new UserData { Gold = goldAmount  , Role = role };
        DocumentReference goldRef = db.Collection("users").Document(UserID.USERID);
        goldRef.SetAsync(userData).ContinueWithOnMainThread(task =>
        {
            GetInfoAsText(userData);
        });
    }

    public void GetUserInfo()
    {
        db.Collection("users").Document(UserID.USERID).GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {
            UserData userData = task.Result.ConvertTo<UserData>();
            GetInfoAsText(userData);
        });       
    }
}
