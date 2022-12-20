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
        traits.PutWalletAddress("add_wallet_address");
        traits.PutPseudonym("add_pseudonym");
        traits.PutEmail("add_email");
        
        soulClient.Identify("traits", traits);

        // Below section is example code to send events. It should be used where the event needs to be triggered. 

        Dictionary<string, object> userProperties = new Dictionary<string, object>();
        userProperties.Add("userid", "add_wallet_address/other identifier");
        Dictionary<string, object> eventProperties = new Dictionary<string, object>();
        eventProperties.Add("name", "Quest");
        eventProperties.Add("value", "CarverCarl");

        MessageBuilder builder = new MessageBuilder();
        builder.EventProperties(eventProperties);
        builder.UserProperties(userProperties);

        soulClient.Track(builder.Build());
    }
}


