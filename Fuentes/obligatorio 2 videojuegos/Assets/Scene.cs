using UnityEngine;
using System.Collections;

//Singleton Pattern
public class Scene : MonoBehaviour {

	// This field can be accesed through our singleton instance,
	// but it can't be set in the inspector, because we use lazy instantiation
	private static ArrayList recordsAirPort;
	private static ArrayList recordsIsland;

	private static int level = 0;
	private static bool isLevelAirPort = false;
	
	// Static singleton instance
	private static Scene instance;
	
	// Static singleton property
	public static Scene Instance
	{
		// Here we use the ?? operator, to return 'instance' if 'instance' does not equal null
		// otherwise we assign instance to a new component and return that
		get {			return instance ?? (instance = new GameObject("Records").AddComponent<Scene>()); 		}
	}
	
	public static void AddRecords(float record)
	{
		if (isLevelAirPort) {
			AddRecordsAirPort (record);
		} else {
			AddRecordsIsland(record);
		}
	}

	private static void AddRecordsAirPort(float record){
		if (recordsAirPort == null) {
			recordsAirPort = new ArrayList();
		}
		recordsAirPort.Add (record);
		recordsAirPort.Sort ();
	}

	private static void AddRecordsIsland(float record){
		if (recordsIsland == null) {
			recordsIsland = new ArrayList();
		}
		recordsIsland.Add (record);
		recordsIsland.Sort ();
	}

	public static ArrayList GetRecords(){
		if (isLevelAirPort) {
			return recordsAirPort;
		} else {
			return recordsIsland;
		}
	}

	//Dont support multiples levels =/
	public static void ChangeLevel(int newLevel){
		isLevelAirPort = newLevel ==1;
		level = newLevel;
		Application.LoadLevel(newLevel);
	}

	public static int GetLevel(){
		return level;
	}

}
