using UnityEngine;
using System.Collections;

//Singleton Pattern
public class Records : MonoBehaviour {

	// This field can be accesed through our singleton instance,
	// but it can't be set in the inspector, because we use lazy instantiation
	private static ArrayList records;
	
	// Static singleton instance
	private static Records instance;
	
	// Static singleton property
	public static Records Instance
	{
		// Here we use the ?? operator, to return 'instance' if 'instance' does not equal null
		// otherwise we assign instance to a new component and return that
		get {			return instance ?? (instance = new GameObject("Records").AddComponent<Records>()); 		}
	}
	
	public static void AddRecords(float record)
	{
		if (records == null) {
			records = new ArrayList();
		}
		records.Add (record);
		records.Sort ();
	}

	public static ArrayList GetRecords(){
		return records;
	}
}
