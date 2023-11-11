Individual Assignment 3: Coding 

Forest Fire

Initial feature 1 – Jet pack 
Multi-directional jet pack movement was implemented to the scene as the first additional feature for this project. Upon spawn, the player is equipped with a jet pack, set with a maximum fuel level of 150, which is used to navigate the map. Control of the jet pack is managed by the right-hand VR controller, using the trigger button to initiate the jet pack thrust and the dynamic movement of the controller to track the desired travel location. As the jet pack is equipped with a fuel gauge, the trust movement gradually decreases the level of fuel available in the jet pack, with no thrust movement applied when the fuel level reaches 0. 
To refill the fuel gauge, fuel tank assets are set to spawn in random locations across the scene floor in 3 second intervals. Each fuel tank replenishes the fuel gauge by 25 upon collision with the jet pack collider, to which the asset is removed from the scene. To track the depletion of the fuel gauge, a health slider has been added to the right-hand VR controller. The player is required to search the scene for tank assets to refill the jet pack fuel gauge.

Initial feature 2 – Fire extinguishing 
The jet pack movement was utilised to initiate the second feature added to the scene; water buckets for extinguishing the fire. Throughout the scene, set above the tree line, water bucket assets are set to spawn in a random cell location in set 3 second intervals. Upon collision with the jet pack collider, the water bucket extinguishes the fire in the corresponding cell location below and remove the asset from the scene after collision. 

YouTube Link: 
