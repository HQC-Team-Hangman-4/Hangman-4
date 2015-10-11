[![Build status](https://ci.appveyor.com/api/projects/status/rpbc2xh2ksgp2w9c/branch/master?retina=true)](https://ci.appveyor.com/project/gbelcheva/hangman-4)


# First steps

* Cleared the code from empty lines and renamed all variables and methods according to style cop requirements.

* Character casing: variables and fields made camelCase; types and methods made PascalCase.

* Formatted the curly braces { and } according to the best practices for the C# language.

* Put { and } after all conditionals and loops (when missing).

* Created OOP structure – including objects that contain valuable information, object that deal with different types of behavior needed for the application. Increased abstraction for each usable object.

# Implementing design patterns

## Creational Patterns 
* Easy creation of words – WordFactory

* Ensuring only one instance is available – Singleton -> ScoreBoard

* Avoiding to use new operator – PlayerPrototype and LetterPrototype.

## Structural patterns

* Easily increasing functionalty – Decorator pattern -> Guessed

* Avoiding coupling between classes – Bridge pattern

* Added DataSerialization and DataBase to deal with using of files and database information.

* Eased user experience when using project – HangmanFacade

## Behavioural

* Easily iterating over object’s information – Iterator pattern - Word

* Abstract communication for different result – Strategy -> ConsoleInputProvider,ConsoleRenderer and etc.

# Testing

* Added Unit tests to verify all active public classes work properly.

* Added Validator class to deal with all validation.

* Added Mocking of DataBase to provide testing capabilities.

* Implemented NUnit tests for testing different scenarios.
