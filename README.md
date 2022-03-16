# model-bushbuckridge

Base model for Ulfia's and Florian's firewood collectors and for EMSAfrica scenario.

Start the simulation by running the ``run.sh``-script. 

## Configurate
Use the ``config.json`` to choose time period, amount of involved agents and RCP4.5 or RCP8.5 forecast data. The input data can be found in ``model/model-savanna-trees/model_input``.
Further information about configuration possibilties can be found on the [documentation website](https://mars.haw-hamburg.de/articles/core/model-configuration/index.html).

## Results
The result files are created in the folder ``model/Starter``.
- ```Tree.csv``` holds information about every tree of the simulation.
- ```FirewoodCollector.csv``` holds information about the GOAP-agents that start in a village and cut trees and collect wood based on their preferences and current needs of their household.
- ```Rafiki.csv``` provides statistical information for every year.