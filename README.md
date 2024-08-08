Animated Titan

Animated Titan is a Windows Forms application that creates animated GIFs from a series of PNG images. The application allows users to configure input and output directories, specify the total duration of the GIF, and customize the output filename.
Features

    Select input folder containing PNG images.
    Specify output folder and filename for the GIF.
    Set the total duration for the GIF animation.
    Status updates displayed during processing.

Getting Started
Prerequisites

    .NET 8 SDK
    Visual Studio 2022 or later

Installing

    Clone the repository:

    bash

    git clone https://github.com/yourusername/animated-titan.git
    cd animated-titan

    Open the solution:
        Open the AnimatedTitan.sln file in Visual Studio.

    Restore NuGet packages:
        In Visual Studio, right-click on the solution in the Solution Explorer and select "Restore NuGet Packages."

    Build the solution:
        Press Ctrl+Shift+B to build the solution.

Running the Application

    Run the application:
        Press F5 to start the application.

    Configure the application:
        Set the input folder, output folder, filename, and total duration.
        Click "Create GIF" to generate the animated GIF.

Configuration

The application saves its configuration in a JSON file located in the AppData directory:

arduino

%AppData%\AnimatedTitan\config.json

Example Configuration

json

{
    "image_folder": "C:\\Users\\YourName\\Documents\\AnimatedTitan\\Input",
    "output_path": "C:\\Users\\YourName\\Documents\\AnimatedTitan\\Output",
    "filename": "Animated.gif",
    "total_duration": 5000
}

Contributing

Contributions are welcome! Please fork the repository and submit a pull request.

    Fork the repository

    Create a new branch:

    bash

git checkout -b feature/your-feature-name

Make your changes

Commit your changes:

bash

git commit -m 'Add some feature'

Push to the branch:

bash

    git push origin feature/your-feature-name

    Submit a pull request

License

This project is licensed under the MIT License - see the LICENSE file for details.

This README.md outline should help users understand the purpose of the project, how to set it up, and how to contribute. Feel free to customize it further based on your specific needs.
