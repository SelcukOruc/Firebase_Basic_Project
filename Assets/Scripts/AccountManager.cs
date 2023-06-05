using UnityEngine;
using Firebase.Auth;
using TMPro;

public class AccountManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField email, password;
    FirebaseAuth auth;
    private void Start()
    {
        auth = FirebaseAuth.DefaultInstance;
        UserID.USERID = "";
    }
        

    public void SignIn()
    {
        auth.SignInWithEmailAndPasswordAsync(email.text, password.text).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            Firebase.Auth.AuthResult result = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                result.User.DisplayName, result.User.UserId);
           
            UserID.USERID = auth.CurrentUser.UserId;
            Debug.LogFormat("Current User Email : {0}", task.Result.User.Email);
           
        });
    }
    public void SignUp()
    {
        auth.CreateUserWithEmailAndPasswordAsync(email.text, password.text).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            // Firebase user has been created.
            Firebase.Auth.AuthResult result = task.Result;
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                result.User.DisplayName, result.User.UserId);
           
            UserID.USERID = auth.CurrentUser.UserId;
            Debug.LogFormat("Current User Email : {0}", task.Result.User.Email);
           
        });
    }
}



