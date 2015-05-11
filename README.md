##Wit.aiUnityLightsAndMove

It's a very very simple game witth a cube on a plane, you only move forward the cube and switch on/off the ambient light.

#Main Folder
contains the wav ADPCM files with the speech command for Wit.ai, put here new custom command.

#Script/HTTP
contains the C# script that control the HTTP Request from your client and the Wit.ai server. Don't touch that.

#Script/NLP
Here there are the core of the program.
Wit.ai, to works correctly unity, needs 3 type of Classes:
- JSON Class
- Intent Class
- Actuator Class

###JSON Class (O_NLP)
	to parse the JSON message from the Wit.ai during che Process.











