# Unity using Adic DI with persistent container and subcontainers

Currently [Adic](https://github.com/intentor/adic) does not support having a "main" container with subcontainers. It does support persistent container between scenes but for larger projects this adds too much overhead.

This is why a persistent container with subcontainers should be introduced.

How to test the project: Just open and run it. It should start printing messages in the Unity console.
If you start it for the first time you have to add the 3 scenes in the build process (File-> Build Settings -> Add current scene)

Currently the project has 3 scenes setuped. The goal is the container from the first scene to become a persistent one and the declared dependencies to be available to the other scenes.
However dependencies declared outside of the main container should be disposed once the scene is left. 

One possible solution is add new method to Adic - **AddMainContainer** which will add the persistent container. Only one main container should be available per game/application.
When you try to add/bind dependencies to container that is not the main container it should check and error if the dependency has already been declared in the main container.
If this approach is taken, when Adic checks to resolves dependencies it could first look in the main container and then in the "local" container.
The main container should be accessible to the game scripts in every scene.

This is just one solution to the problem. Other solutions solving the problem are accepted as well.
