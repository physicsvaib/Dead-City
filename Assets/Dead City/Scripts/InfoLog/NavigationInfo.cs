/*
  * For agent navigation appoaches
    - We can go with lookat type solution, agent moves in straight line. No Avoidance system. Can get stuck in wall.
    - Local Avoidance with a capsule collider. Works well for smaller/local context. Even unity might be using for avoid agent to agent collision,but this approach fails once we are stuck in a concave/convex place as there is no algo to take the agent out of it.

    - Modern solutions have a hybrid of techniques:
      * Nav Graph - Baked at compile time.
      * Agent path query - this returns a path (waypoints) that can be traversed. Unity returns a corridor (polygons that can be traversed).
      * Agent path Steering - this moves the agent.
      * Local Avoidance - dynamic objects are to be avoided.
*/