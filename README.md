# Bushbuckridge Firewood Collection Model

Base model for Ulfia's and Florian's firewood collectors and for EMSAfrica scenario. Developed by Florian Ocker and Ulfia A. Lenfers.

Start the simulation by running the `run.sh`-script.

## Configuration

Use the `config.json` to define the time period, the number of involved agents, and the RCP4.5 or RCP8.5 forecast data. The input data can be found in `model/model-savanna-trees/model_input`.

Further information on configuration options can be found on the [MARS documentation website](https://www.mars-group.org/docs/category/configuration).

## Results

The result files are created in the folder `model/Starter`.

- `Tree.csv` holds information about every tree of the simulation.
- `FirewoodCollector.csv` holds information about the GOAP-agents that start in a village and cut trees and collect wood based on their preferences and current needs of their household.
- `Rafiki.csv` provides statistical information for every year.

## Literature

Lenfers, U.A., Ahmady-Moghaddam, N., Glake, D., Ocker, F., Weyl, J., Clemen, T., 2022. Modeling the Future Tree Distribution in a South African Savanna Ecosystem: An Agent-Based Model Approach. Land 11, 619. [https://doi.org/10.3390/land11050619](<https://doi.org/10.3390/land11050619>)

Lenfers, U.A., Weyl, J., Clemen, T., 2018. Firewood collection in South Africa: Adaptive behavior in social-ecological models. Land 7, 97. [https://doi.org/10.3390/land7030097](<https://doi.org/10.3390/land7030097>)

## Availability Disclaimer

Because of file size limits, we can no longer provide model box deployments for different architectures. Please contact [thomas.clemen@haw-hamburg.de](mailto:thomas.clemen@haw-hamburg.de) to receive a download link.
