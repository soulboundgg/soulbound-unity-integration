using SoulBound;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Program : MonoBehaviour
{
    Client soulClient;
    // Start is called before the first frame update
    void Start()
    {

        // Build your config
        ConfigBuilder configBuilder = new ConfigBuilder();


        // Please ensure you create a game in your Soulbound account dashboard and get its TOKEN.
        //Create client.
        SoulBound.Client soulClient = SoulBound.Client.GetInstance("GAME_TOKEN", configBuilder.Build());


        Message identifyMessage = new MessageBuilder().Build();
        Traits traits = new Traits();

        traits.PutEmail("alex@example.com");
        traits.PutAge("40");

        traits.Put("location", "New Orleans");
        traits.Put("gender", "Male");
        traits.Put("consent", "Granted");
        soulClient.Identify("some_user_id", traits, identifyMessage);


        //send messages
        Dictionary<string, object> eventProperties = new Dictionary<string, object>();
        eventProperties.Add("test_key_1", "test_value_1");
        eventProperties.Add("test_key_2", "test_value_2");

        // create user properties
        Dictionary<string, object> userProperties = new Dictionary<string, object>();
        userProperties.Add("test_u_key_1", "test_u_value_1");
        userProperties.Add("test_u_key_2", "test_u_value_2");

        // create message to track
        MessageBuilder builder = new MessageBuilder();
        builder.WithEventName("test_event_name");
        builder.WithEventProperties(eventProperties);
        builder.WithUserProperties(userProperties);

        soulClient.Track(builder.Build());
    }
    int count = 0;


    // Update is called once per frame
    void Update()
    {
        count += 1;

        if (count % 10000 == 0)
        {
            Dictionary<string, object> externalId1 = new Dictionary<string, object>();
            externalId1.Add("id", "some_external_id_1");
            externalId1.Add("type", "brazeExternalId");

            Dictionary<string, object> externalId2 = new Dictionary<string, object>();
            externalId2.Add("id", "some_external_id_2");
            externalId2.Add("type", "brazeExternalId2");

            List<Dictionary<string, object>> externalIds = new List<Dictionary<string, object>>();
            externalIds.Add(externalId1);
            externalIds.Add(externalId2);

            Dictionary<string, object> integrations = new Dictionary<string, object>();
            integrations.Add("All", true);
            integrations.Add("Amplitude", true);

            Dictionary<string, object> options = new Dictionary<string, object>();
            options.Add("integrations", integrations);
            options.Add("externalIds", externalIds);

            // create message to track
            MessageBuilder builder = new MessageBuilder();
            builder.WithEventName("update_event");
            builder.WithEventProperty("foo", "bar");
            Message msg = builder.Build();
            msg.options = options;
            soulClient.Track(msg);
        }

    }



}


