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
        }

        public override void OnUpdate()
        {

            
            
        }
    }
}