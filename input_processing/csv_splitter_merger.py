import os
from argparse import ArgumentParser, Namespace, ArgumentError, RawTextHelpFormatter


def split_csv_file(path_to_csv_file: str, num_of_output_files: int, path_to_output_dir: str) -> None:
    """
    Splits the rows of the given CSV file into the given number of CSV files. Stores the produced CSV files in an output
    directory named csv_output.

    :param path_to_csv_file: Path to the CSV file to be split (example: path/to/file.csv)
    :param num_of_output_files: Number of files into which the given CSV file is to be split
    :param path_to_output_dir: Path to the directory in which the generated split CSV files are to be stored
    :return: None
    """
    csv_file_content: list[str] = open(path_to_csv_file, 'r').readlines()
    csv_filename: str = extract_filename_from_path(path_to_csv_file)
    number_of_rows_in_csv_file: int = len(csv_file_content)

    make_directory_at_path(path_to_output_dir)

    number_of_rows_per_output_file: int = number_of_rows_in_csv_file // num_of_output_files
    current_row_number: int = 0
    output_filename_counter: int = 1

    while current_row_number <= number_of_rows_in_csv_file:
        open(f'{path_to_output_dir}{csv_filename}{str(output_filename_counter)}.csv', 'w+').writelines(
            csv_file_content[current_row_number:current_row_number + number_of_rows_per_output_file])
        output_filename_counter += 1
        current_row_number += number_of_rows_per_output_file
    verify_csv_split_or_merge(number_of_rows_in_csv_file, path_to_output_dir)


def verify_csv_split_or_merge(number_of_rows_in_merged_csv_file: int, path_to_dir_with_split_csv_files: str) -> None:
    """
    Verifies a CSV split by comparing the number of rows in the original CSV files to the sum of the number of rows in
    CSV files into which the rows of the original CSV file were split.

    :param number_of_rows_in_merged_csv_file: The number of rows in the CSV file that was split
    :param path_to_dir_with_split_csv_files: The path to the directory containing the split CSV files
    (example: path/to/dir)
    :return: None
    """
    number_of_rows_in_split_csv_files: int = 0

    split_csv_filenames: list[str] = get_filenames_in_dir_with_extension(path_to_dir_with_split_csv_files)

    for csv_filename in split_csv_filenames:
        number_of_rows_in_split_csv_files += len(open(f'{path_to_dir_with_split_csv_files}{csv_filename}', 'r')
                                                 .readlines())

    if number_of_rows_in_split_csv_files == number_of_rows_in_merged_csv_file:
        print('Success: Number of rows original CSV file(s) and generated CSV file(s) match!')
    else:
        print('Error: Number of rows in original CSV file(s) and generated CSV file(s) do not match!')


def merge_csv_files(path_to_dir_with_split_csv_files: str, path_to_dir_with_merged_csv_file: str) -> None:
    """
    Merges the rows of the CSV files contained in the given directory into one CSV file.

    :param path_to_dir_with_split_csv_files: The path to the directory containing the split CSV files
    :param path_to_dir_with_merged_csv_file: The path to the directory in which the generated merged CSV file is to be
    stored
    :return: None
    """
    split_csv_filenames: list[str] = get_filenames_in_dir_with_extension(path_to_dir_with_split_csv_files)
    split_csv_filenames = sorted([path_to_dir_with_split_csv_files + filename for filename in split_csv_filenames])

    output_csv_filename: str = ''.join(c for c in split_csv_filenames[0] if not c.isdigit())[split_csv_filenames[0].
                                                                                             rindex('/') + 1:]
    make_directory_at_path(path_to_dir_with_merged_csv_file)

    with open(f'{path_to_dir_with_merged_csv_file}{output_csv_filename}', 'a') as output_csv_file:
        for csv_filename in split_csv_filenames:
            output_csv_file.writelines(open(csv_filename))

    number_of_rows_in_output_csv_file = sum(1 for _ in open(f'{output_csv_filename}'))
    verify_csv_split_or_merge(number_of_rows_in_output_csv_file, path_to_dir_with_merged_csv_file)


def get_filenames_in_dir_with_extension(path_to_dir: str, file_extension: str = '.csv') -> list[str]:
    """
    Returns a list of names of files contained in the given directory that have the given file extension.

    :param path_to_dir: The given directory (example: path/to/dir)
    :param file_extension: The given file extension (example: .abc)
    :return: A list of identified filenames
    """
    return [filename for filename in os.listdir(path_to_dir) if filename.endswith(file_extension)]


def extract_filename_from_path(path_to_file: str) -> str:
    """
    Returns the filename referred to by the given path.

    :param path_to_file: The given path
    :return: The identified filename
    """
    return os.path.splitext(path_to_file)[0]


def make_directory_at_path(path_to_dir: str) -> None:
    """
    Creates a directory at the given path, if it does not exist.

    :param path_to_dir: The given path
    :return: None
    """
    if not os.path.exists(path_to_dir):
        os.makedirs(path_to_dir)


def define_parse_args() -> Namespace:
    """
    Defines the available command line arguments.

    :return: a Namespace object containing the defined arguments
    """
    parser: ArgumentParser = ArgumentParser(description='''a script that provides two functions for processing CSV files:\n1. Split rows of a CSV file into a given number of CSV files\n2. Merge rows of a set of CSV files into one CSV file.''',
                                            epilog='''example usage:\n1. python3 csv_splitter_merger.py -s -ip file.csv -sc 10 -op split_results/\n2. python3 csv_splitter_merger.py -m -ip split_results/ -op merge_results/''',
                                            formatter_class=RawTextHelpFormatter)

    group = parser.add_mutually_exclusive_group(required=True)
    group.add_argument("-m", "--merge", action='store_true', help="run the CSV merge function of this script")
    group.add_argument("-s", "--split", action='store_true', help="run the CSV split function of this script")

    parser.add_argument("-sc", "--split_count", type=int, help="number of files to split CSV file contents into ("
                                                               "required for split function (-s, --split))")

    parser.add_argument("-ip", "--input_path", type=str, help="path to the CSV file(s) to be processed", required=True)
    parser.add_argument("-op", "--output_path", type=str, help="path to directory to store output files", required=True)

    return parser.parse_args()


def handle_command_line_request(args: Namespace) -> None:
    """
    Verifies the given command line arguments and, upon successful verification, passes the arguments to the requested
    function (split or merge).

    :param args: The given command line arguments
    :return: None
    """
    if args.merge:
        merge_csv_files(args.input_path, args.output_path)
    elif args.split:
        if not args.split_count:
            raise ArgumentError(argument=args.split_count,
                                message='The split function (-s, --split) requires a number of files (-sc, '
                                        '--split_count) to split the CSV file contents into.')
        else:
            split_csv_file(args.input_path, args.split_count, args.output_path)
    else:
        raise ArgumentError(argument=None,
                            message='The script was not run with the required arguments. Please run the script with -h '
                                    'or --help for more information.')


def main():
    args: Namespace = define_parse_args()
    handle_command_line_request(args)


if __name__ == '__main__':
    main()
