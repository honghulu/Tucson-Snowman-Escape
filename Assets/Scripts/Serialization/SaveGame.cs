using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Linq;
using UnityEngine.SceneManagement;

public class SaveGame : MonoBehaviour
{
    const string savedSceneKey = "savedLevel";
    const string defaultScene = "Night UA";
    
    DirectoryInfo saveFolder { get { return new DirectoryInfo( Application.persistentDataPath ); } }
    FileInfo saveFile { get { return new FileInfo( savePath ); } }
    string savePath { get { return System.IO.Path.Combine( Application.persistentDataPath, FILE_NAME ); } }
    
    const string FILE_NAME = "Characters State";

    public bool loadOnStart;

    public Transform[] transformsToSave;
    public Damageable[] healthToSave;

    void Start() {
        if( loadOnStart ) DeserializeInfo();
    }

    public void ClearSerializedInfo() {
        if( saveFile.Exists ) {
            saveFile.Delete();
            PlayerPrefs.DeleteKey( savedSceneKey );
        }
    }

    public void SerializeInfo() {
        // create the serializable object to store to disk
        SaveableState characterStateToSave = new SaveableState();
        
        characterStateToSave.xPositions = transformsToSave.Select( thingToSave => thingToSave.position.x ).ToArray();
        characterStateToSave.yPositions = transformsToSave.Select( thingToSave => thingToSave.position.y ).ToArray();
        characterStateToSave.zPositions = transformsToSave.Select( thingToSave => thingToSave.position.z ).ToArray();

        characterStateToSave.otherObjectsHealth = healthToSave.Select( thingToSave => thingToSave.health ).ToArray();
        
        // manage the formatting and file I/O of the serializable data
        if( !saveFolder.Exists ) saveFolder.Create();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create( savePath );
        bf.Serialize( file, characterStateToSave );
        file.Close();

        SaveCurrentScene();
    }

    public void DeserializeInfo() {

        if( saveFile.Exists ) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = saveFile.Open( FileMode.Open );

            // load the data from disk into the correct format
            SaveableState loadedState = (SaveableState)bf.Deserialize( file );
            file.Close();
            
            // apply the data loaded from disk to the runtime objects
            for( int index = 0; index < loadedState.xPositions.Length; index++ ) {
                transformsToSave[index].position = new Vector3( loadedState.xPositions[index], loadedState.yPositions[index], loadedState.zPositions[index] );
            }

            for( int index = 0; index < loadedState.otherObjectsHealth.Length; index++ ) {
                healthToSave[index].health = loadedState.otherObjectsHealth[index];
                if (!(healthToSave[index].healthBar == null)) {
                    healthToSave[index].healthBar.fillAmount = loadedState.otherObjectsHealth[index] / 100f;
                }
            } 
        }
    }
    
    public void LoadSavedScene() {
        SceneManager.LoadScene( PlayerPrefs.GetString( savedSceneKey, defaultScene ) );
    }
    
    void SaveCurrentScene() {
        PlayerPrefs.SetString( savedSceneKey, SceneManager.GetActiveScene().name );
    }
}
