You need a MonoBehaviour script to interact with the Unity GameObject, but you can't istantiate a MonoBehaviour class,
so, for each command, you need to create a class (i.e. light), that open the O_NLP object and extract the command information (i.e. on or off),
and a MonoBehaviour class (i.e. LightActuator), created by the first class and attached to a GameObject.