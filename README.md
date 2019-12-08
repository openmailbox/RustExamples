# Rust Example Mods
This is a collection of examples to help with learning how to develop custom Rust plugins.

## Development
Currently developed and tested on:
* Visual Studio 2019
* uMod v2.0.4374 or later (12/6/2019)

### Setup
1. Install the [Rust dedicated server](https://developer.valvesoftware.com/wiki/Rust_Dedicated_Server) for local development
2. [Download](https://umod.org/games/rust) and extract the uMod files into any directory. 
3. Copy the extracted uMod files into your server installation directory. Use the [uMod installation guide](https://umod.org/documentation/getting-started) for reference.
4. `git clone` this repo.
5. Additionally copy the extracted uMod files into your repo's `lib` directory. The path should look like `lib/RustDedicated_Data/Managed`.
6. Copy the `resources/start.bat` batch script into your server installation so it's next to `RustDedicated.exe`
7. Open the solution file in Visual Studio.
8. Right click on the SurvivalRoyale project, select properties, and edit the output path in the post-build copy event so your source files are copied into your server plugins directory.
9. Build the project.