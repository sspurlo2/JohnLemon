  Timothy Nikolaev: We used linear interpolation (Lerp) to create smooth, natural motion for an object that follows the player. Instead of moving the object at a constant speed, we implemented a gradual easing effect using the Vector3.Lerp() function in Unity.
  Each frame, the object updates its position a little closer to the player's position. Because we reassign the object’s own position as the starting point every frame, it gets closer and closer to the player — but never snaps — creating the appearance of slowing down as it approaches.
  This behavior is implemented in our SmoothFollow.cs script, attached to a candle that follows the player. This makes the movement feel more lifelike and ghostly — perfect for our haunted-themed environment. This method made the candle’s movement look fluid, added polish to the gameplay, and showcased our understanding of linear algebra principles in game physics.

  
  Sam Spurlock: Particle effects were implemented through creating footsteps that the players leaves. This was implemented through creating a footsteps game object, and making that object a FootstepGlow prefab. Then, a FootstepGlowSpawner.cs script was created, with the trigger being when the player walks. Messing with the settings, we made the foot steps pink and set the timing to disappear after half a second. 

  
  Alexia Crawfod: To implement the dot product and add a new sound effect, we created a new script called HeartAudio.cs. We also found a free heart beat sound effect online and dragged it into unity to use it. The heart beat sound is triggered when the player is near an enemy, and increases speed/pitch based on distance and angle that you are looking at the enemy, which is how dot product is incorperated.
  

   Sam Spurlock: To be more creative, we also added a  particle effect at the end of the game to indicate where the exit is. This effect has no trigger, and is constant through the entire game. We also changed the color of the players outfit to be more purple to add personalization to the game. 
