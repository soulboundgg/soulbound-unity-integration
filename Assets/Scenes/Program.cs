using SoulBound;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Program : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {

        // Build your config
        ConfigBuilder configBuilder = new ConfigBuilder();


        // Please ensure you create a game in your Soulbound account dashboard and get its TOKEN.
        
        SoulBound.Client soulClient = SoulBound.Client.GetInstance("GAME_TOKEN", configBuilder.Build());


        Traits traits = new Traits();
        traits.PutWalletAddress("n4GC2FbfWPMR49zHzi6xzLCYTTfdCTzRLS");
        traits.PutPseudonym("haxor1");
        traits.Put("gender", "Male");
        
        soulClient.Identify("some_user_id", traits);


        //send messages
        Dictionary<string, object> eventProperties = new Dictionary<string, object>();
        eventProperties.Add("quest_level", "3");
        eventProperties.Add("quest_completed", "true");

        // create user properties
        Dictionary<string, object> userProperties = new Dictionary<string, object>();
        userProperties.Add("user_time_spent", "10");
        userProperties.Add("trial_nos", "3");

        // create message to track
        MessageBuilder builder = new MessageBuilder();
        builder.EventName("test_event_name");
        builder.EventProperties(eventProperties);
        builder.UserProperties(userProperties);

        soulClient.Track(builder.Build());
    }
}


