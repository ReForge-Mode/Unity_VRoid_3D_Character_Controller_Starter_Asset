# Unity VRoid 3D Character Controller Starter Asset
This project will show you how to use VRoid Studio model with the Unity Starter Asset - Third Person Character Controller. This project uses Unity version 2021.2.3f1, earlier versions of Unity might not work. 

I made this project to help with those who want to make Anime-looking game and learning to use the free character controller provided for free from Unity themselves. 

Huge credit to these guys who made this possible!
UniVRM plugin: https://github.com/vrm-c/UniVRM
Unity Starter Assets - Third Person Character Controller: https://assetstore.unity.com/packages/essentials/starter-assets-third-person-character-controller-196526

# Instructions
If you want to start fresh, you can just create a basic 3D project from Unity Hub, import the Character Controller Starter Assets from Unity Asset Store, then import UniVRM plugin and your character. If you don't know how to import your VRoid character to Unity, I have a tutorial about it in here: https://www.youtube.com/watch?v=IrIn9wRYqUI

Now, to use the character controller to your VRoid project
1. Create an empty game object and name it "Unity Starter Character". Then move "Main Camera", "PlayerFollowCamera", and "PlayerArmature" as its child object. This is going to help us differentiate Vita (your VRoid Model) and PlayerArmature object later.
2. Drag your VRoid prefab to the Hierarchy Window.
3. Create a parent object for Vita (your VRoid Model) and call it "ParentVita"
4. Duplicate the "Unity Starter Characters" object. We're going to move some components and child object from "PlayerArmature" object to Vita model
6. Move "Main Camera" object and "PlayerFollowCamera" object from the "UnityStarterCharacter" child to "ParentVita" as its child.
7. Move "PlayerCameraRoot" object from "PlayerArmature" child to Vita as a child object. Change its position in the inspector to (0, 1.375, 0)
8. Move every component from "PlayerArmature" to Vita, except for the Animator. For the Animator, just change the Controller field used in Vita to the one that is used by PlayerArmature. The animation will work with the VRM object.
9. Adjust the CharacterController component so that Vita doesn’t look flying above the ground when walking. Set the collider Y Center to 1.08. This Y value might change depending on how high your character is.
10. Change Vita Tag in the inspector to "Player"
11. There will be an infinite jumping bug. This happens because this controller ground check function keeps colliding with the Vita collider. To fix this, create a new Collision Layer in the inspector and name it “Player”, then assign them into a Vita object.

And that will be it! Let me know if you guys want a video tutorial instead of a written tutorial. If there's enough request, I'll make the short tutorial for it.
