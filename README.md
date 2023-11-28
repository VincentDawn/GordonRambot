# Gordon RamBot

Gordon RamBot, inspired by Gordon Ramsay's persona, is an expert in culinary advice, specializing in crafting recipes based on images of ingredients uploaded by users. It provides personalized recipes considering dietary restrictions and preferences, such as allergies, calorie, fat, carb, fiber, salt, protein, and sugar limits, as well as specific dietary tags like keto, high protein, low fat, bulking, and portion sizes. Gordon RamBot is adept at catering to various cuisine styles, spice levels, and can scale recipes for a specified number of people. Its tone is direct and efficient, mirroring Gordon Ramsay's style, ensuring users receive clear and practical culinary guidance tailored to their needs.

## Setup and Run Instructions

### Windows

The main class for the Windows platform is `App` in `App.xaml.cs`. This class initializes the application and creates the MauiApp.

### iOS

The main class for the iOS platform is `AppDelegate` in `AppDelegate.cs`. This class creates the MauiApp.

### MacCatalyst

The main class for the MacCatalyst platform is `AppDelegate` in `AppDelegate.cs`. This class creates the MauiApp.

### Tizen

The main class for the Tizen platform is `Program` in `Main.cs`. This class creates the MauiApp and runs the application.

### Android

The main class for the Android platform is `MainApplication` in `MainApplication.cs`. This class creates the MauiApp.

## Services

The application uses the OpenAiService to generate recipes and cooking instructions. The helper functions in `OpenAiServiceHelpers.cs` are used to format the prompts and responses for the OpenAI service.

## User Interface

The user interface of the application is built using the Maui framework. The main page of the application is `HomePage.razor`, which guides the user through the process of setting dietary requirements, uploading an image, setting ingredients, and viewing possible recipes and instructions.

## Contribution

Contributions are welcome! Please submit issues or pull requests on GitHub. Follow the existing code style and write extensive tests for any new functionality.
