/*
  * For agent navigation appoaches
    - We can go with lookat type solution, agent moves in straight line. No Avoidance system. Can get stuck in wall.
    - Local Avoidance with a capsule collider. Works well for smaller/local context. Even unity might be using for avoid agent to agent collision,but this approach fails once we are stuck in a concave/convex place as there is no algo to take the agent out of it.

    - Modern solutions have a hybrid of techniques:
      * Nav Graph - Baked at compile time.
      * Agent path query - this returns a path (waypoints) that can be traversed. Unity returns a corridor (polygons that can be traversed).
      * Agent path Steering - this moves the agent.
      * Local Avoidance - dynamic objects are to be avoided.

 * Nowadays a new component for Navmesh is added NavMeshSurface for baking with access to different bake agents.
 * Bake Process
  - Baking of Navmesh is a complex process where we first get the voxel data generated for all nav static meshes.
  - That voxel data is then interpolated to create nav geometry with some approximations and good algos to decide.
  - Once that is done, we get nav mesh data.
  - Still one problem lies, that static data is interpolated (kinda), so the agent might seem floating while traversing on y axis in certain areas.
  - A solution for this is height mesh data, which includes the surface y distance while travesing and can be baked similar to nav mesh.

 * Agent has a steering target which is the next point the agent is trying to reach good for debugging.
 * It has a desired velocity which is what it wants, not neccesarily get it.

 * Changing navmesh agent properties (Obstacle Avoidance) mostly are for local avoidance not much related to the baked navmesh.
 */