# Bushbuckridge Firewood Collection Model

Base model for Ulfia's and Florian's firewood collectors and for EMSAfrica scenario. Developed by Florian Ocker and Ulfia A. Lenfers.

Start the simulation by running the `run.sh`-script.

## Configuration

Use the `config.json` to define the time period, the number of involved agents, and the RCP4.5 or RCP8.5 forecast data.

Detailed information on configuration options can be found on the [MARS documentation website](https://www.mars-group.org/docs/category/configuration).

## Input files

The input files are located in `model_input/` and `model/model-savanna-trees/model_input/`.

> **Note** Due to file size restrictions, some input files had to be zipped or split into multiple files before being added to this repository. Follow the below steps to prepare all input files for your local simulation runs:

1. Unpack the ZIP archive `model_input/tree_bushbuckridge.zip`. This should produce one CSV file with the same name in `model_input/`.
2. The CSV files located in `model/model-savanna-trees/model_input/tree_bushbuckridge` need to be merged into one CSV file. To do this, follow the below steps:
   1. Move the Python script `csv_splitter_merger.py` from `input_processing/` to `model/model-savanna-trees/model_input/`.
   2. Open a terminal and move to `model/model-savanna-trees/model_input/`.
   3. Run the script as follows: `python3 csv_splitter_merger.py -m -ip tree_bushbuckridge/ -op merge_result/`
      1. For additional information on the script, run `python3 csv_splitter_merger.py -h`.
   4. The script should produce one CSV file named `tree_bushbuckridge.csv` in `model/model-savanna-trees/model_input/merge_result/`. This CSV file contains the data of the CSV files in `model/model-savanna-trees/model_input/tree_bushbuckridge/`.
   5. Move the produced CSV file from `model/model-savanna-trees/model_input/merge_result/` to `model/model-savanna-trees/model_input/`.
   6. Delete the directory `merge_result/`.

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
