# Soulbound Unity Integration Guide

By copying, cloning or downloading the contents of this repository partially or fully, you agree to the [license agreement](Soulbound_SDK_Software_License_Agreement.pdf). 


After integrating this SDK with your game, you will be able to track your game events data. 


## **SDK setup requirements**

To configure the Soulbound Unity SDK, you will need the following:

- You will need to set up a **Soulbound account** on Soulbound Dashboard [https://mainframe.soulbound.gg] **.**
- Once signed up, **create a game**. You should then see a **token** for this game.
- Finally, you will need to **integrate the Soulbound Unity SDK**.

## **Integrating the Soulbound sdk with the game**

- Download SDK/soulbound-unity-sdk.unitypackage from soulbound-unity-integration public GitHub repository.
- Import the sdk package file to your project. From the Assets menu, go to Import Package and then Custom Package and select the downloaded unitypackage file. 

## **Initialising the client**

- Add the following code in the `Awake` method of your main `GameObject` Script:

```csharp
ConfigBuilder configBuilder = new ConfigBuilder()
Client client = Client.GetInstance(TOKEN, configBuilder.Build());
```

## **Identify**

The Unity SDK provides an `Identify` method for identifying the user. This helps adding the attributes of the user and then in tracking the user across the application. Once the SDK identifies the user, it persists and passes the user information to the subsequent calls.

The SDK also has some in-built APIs for building the `Identify` object like `PutWalletAddress`, `PutPseudonym` etc. These APIs can be used to set the values of the standard identifications items by directly passing them as parameters.

For the custom identification attributes which we don’t support using our pre-defined APIs, the `Put()` method could be used to pass a key-value pair of the attribute, as shown in the sample `Identify` event below:

```csharp
Traits traits = new Traits();
traits.PutWalletAddress("n4GC2FbfWPMR49zHzi6xzLCYTTfdCTzRLS");
traits.PutPseudonym("haxor1");
traits.Put("gender", "Male");
Client.Identify("some_user_id", traits);
```

If user is not identified in the app then we assign a random user id to the user in order to track properly.

# **Track**

You can record the users' in-game activity through the `track` method. Every user action is called an **event**.

A sample `track` event is as shown:

```csharp

// create user properties
Dictionary<string, object> userProperties = new Dictionary<string, object>();
eventProperties.Add("quest_level", "3");
eventProperties.Add("quest_completed", "true");

// create event properties
Dictionary<string, object> eventProperties = new Dictionary<string, object>();
userProperties.Add("user_time_spent", "10");
userProperties.Add("trial_nos", "3");
// create message to track
MessageBuilder builder = new MessageBuilder();
builder.EventName("test_event_name");
builder.UserId("msg_user_id");
builder.EventProperties(eventProperties);
builder.UserProperties(userProperties);

Client.Track(builder.Build());
```
# Soulbound API Integration Guide

## **SDK setup requirements**

To integrate with Soulbound API, you will need the following:

- You will need to set up a **Soulbound account** on Soulbound Dashboard [https://mainframe.soulbound.gg] **.**
- Once signed up, **create a game**. You should then see a **token** for this game.
- Finally, you will need to **integrate with the Soulbound API**.

## **Integrating with the Soulbound API**

```
GET /events HTTP/1.1
Authorization: Bearer your_token_here
Content-Length: 271
Content-Type: application/json
Host: sdkdata.soulbound.gg
User-Agent: HTTPie

{
  "userid": "alok123",
  "email": "someone@one.com",
  "crypto-address": "0x12345656",
  "params": [
    {
      "name": "Stage",
      "value": "1"
    },
    {
      "name": "Zone",
      "value": "1"
    },
    {
      "name": "World",
      "value": "1"
    }
  ]
}
```
The data must be sent using the format given above. Specifically, the format of the params must match the quest criteria. For example this format is equiavalent to the `Complete Stage 1 Zone 1 World 1` quest. This quest must be created using similar conditions in mainframe.soulbound.gg
