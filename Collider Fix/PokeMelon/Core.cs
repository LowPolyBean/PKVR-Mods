using MelonLoader;
using Mirror;
using Mirror.Websocket;
using PokemonUnity.Item;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

[assembly: MelonInfo(typeof(PokeMelon.Core), "First Person Playerbody", "1.0.0", "crazylouie", null)]
[assembly: MelonGame("MSDVR", "Pokemon VR")]

namespace PokeMelon
{   
    // a nice note for other modders, i was able to go through some of the games code, which did help alot in making this.
    public class Core : MelonMod
    {
        // just important references for manipulating the game world, such as the main manager which controls alot of the games systems.
        public GameObject mainManager = GameObject.FindWithTag("MainManager");
        public GameObject localPlayerRig = PlayerMeta.localPlayer;
        public override void OnApplicationStart()
        {
            
            LoggerInstance.Msg("Initialized.");
        }

        // runs after the loading of a scene.
        public override void OnLevelWasLoaded(int level)
        {   // loggerinstance.msg is just simple melonloader debugging.
            // set player rig again. (at the beginning of the game, PlayerMeta.localPlayer is a null reference because you have yet to login.)
            localPlayerRig = PlayerMeta.localPlayer;
            LoggerInstance.Msg("playerrig acquired successfully!" + localPlayerRig.name);
            // a temporary variable for the base parent of every model, "3DModel" which contains every playermodel below it as a child.
            Transform modelbase = localPlayerRig.transform.GetChild(0);
            LoggerInstance.Msg("models parent aqcuired successfully." + modelbase.name);
            // get every child of the model base, and enable visibility.
            foreach (Transform child in modelbase)
            {  
                // this in particular is quite interesting. each playermodel, unless belonging to another player, is set to layer "NoDepthInFirstPerson" which is being culled (you cant see it) by the game camera. this is a unique and interesting approach. what the following bit of code does is set all children of the model to the default layer. the playermodel hierarchy structure is different for each model, Sometimes it contains a camera pivot. in simple terms, There is 3DModel on top, PM_Hero_*insert character name* as a child of 3DModel, and as a child of PM_Hero, there is geometry, under the same name as its parent oftentimes, skeleton, and sometimes camerapivot.
                LoggerInstance.Msg("attempting a playermodel..." + child.name);
                foreach(Transform childsquared in child)
                {
                    childsquared.gameObject.layer = 0;
                }
            }
            // disable hand geometry.
            GameObject.Find("hands:Lhand").SetActive(false);
            GameObject.Find("hands:Rhand").SetActive(false);
        }

        public override void OnUpdate()
        {

            
            
        }
    }
}