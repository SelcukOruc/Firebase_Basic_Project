using Firebase.Firestore;

[FirestoreData]
public struct UserData 
{
 
    [FirestoreProperty]
    public string Role { get; set; }
 
    [FirestoreProperty]
    public int Gold { get; set; }

}

