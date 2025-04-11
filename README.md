We used linear interpolation (Lerp) to create smooth, natural motion for an object that follows the player. Instead of moving the object at a constant speed, we implemented a gradual easing effect using the Vector3.Lerp() function in Unity.
Each frame, the object updates its position a little closer to the player's position. Because we reassign the object’s own position as the starting point every frame, it gets closer and closer to the player — but never snaps — creating the appearance of slowing down as it approaches.
This behavior is implemented in our SmoothFollow.cs script, attached to a candle that follows the player. This makes the movement feel more lifelike and ghostly — perfect for our haunted-themed environment. 
This method made the candle’s movement look fluid, added polish to the gameplay, and showcased our understanding of linear algebra principles in game physics.

