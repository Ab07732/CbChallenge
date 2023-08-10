# Community Brands Integrations Developer Challenge

## Overview
This is a brief coding challenge designed to evaluate prospective Community Brands developers' skills.

Please do not share this challenge's code with anyone or post it publicly.

* Language: C#
* Framework: .NET 6
* Time to complete: 1 - 3 hours

If you experience any issues with this challenge, please let us know.

#### Requirements

* [.NET 6.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
* [Git](https://git-scm.com/downloads)
* (Optional) An IDE or code editor of your choice, such as [Visual Studio Code](https://code.visualstudio.com/)

## Goal

Using the included code as a starting point, create an integration that fetches data from our sample JSON feeds and transforms it into the provided data models using the specified rules.

Running the project will verify whether or not the challenge has been successfully completed; see the "Testing Your Code" section below for details.

The integration you create will be in the `Integrations/YourIntegration` directory. It contains a few incomplete files to get you started:

* `YourIntegration.cs` - The top-level class for your integration. It contains `Feed` instances that fetch and parse data, and `Importer` instances that transform fetched data into the challenge's data models. There's a placeholder Feed and Importer to get you started, but you'll need to add the rest.
* `YourFeed.cs` - You'll need to write code in the `GetObjects` method that fetches data from the sample URLs (provided below) and parses it with [`System.Text.Json`](https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/overview).
* `YourSpeakersImporter.cs` - You'll need to write code in the `MapObject` method that takes the data fetched by `YourFeed` and transforms it into instances of the `Speaker` data model.
* You'll create additional Importer files that import the `Session` and `Track` data models.

#### Data Models

These are what you'll be importing. The classes for these models are in the `Models` directory. Each model has an "ID" property that uniquely identifies it among other models of the same type.

* `Session` - a scheduled part of an event, meeting, trade show, etc. Has a title, description, location, and start and end time.
* `Speaker` - a person that speaks at (or otherwise participates in) a `Session`. Has a name, other profile fields, and assignments to `Sessions`.
* `Track` - categorizes sessions. Has a title and assignments to `Sessions`. A Track's ID is usually the same as its title.

#### Sample Data Feeds

* Sessions feed URL: https://static.coreapps.net/communitybrands-integration-challenge/sessions.json
* Speakers feed URL: https://static.coreapps.net/communitybrands-integration-challenge/speakers.json

(Tracks are derived from the other two feeds.)


## Rules

* Any code style is fine as long as it is clean and readable
* You may omit error checking and handling
* You may use the [null-forgiving operator](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-forgiving) when working with parsed JSON data
* You may modify code outside the `Integrations/YourIntegration` directory if desired, though should avoid substantially altering the functionality of the project
* You may hard-code URLs and other details instead of using configuration files

#### Speaker Rules

* Speakers should be imported from the Speakers feed URL (above)
* The `Speaker` model's properties should be set from the relevant fields in the feed data (e.g. `speaker.Name` from the "name" field)
* For each entry in the "session_assignments" array in the Speakers feed data, assign the Speaker instance to a Session using the `speaker.AssignSession` method

#### Session Rules

* Sessions should be imported from the Sessions feed URL (above)
* The `Session` model's properties should be set from the relevant fields in the feed data (e.g. `session.Title` from the "name" field, `session.Description` from the "description" field)
* The `session.Start` property should be set from the "date" and "time" fields in the data. You will need to determine the correct format string to use to parse the fields into a `DateTime` instance
    * Time zones should be ignored for the purposes of this challenge, assume all times are in UTC
* The `session.End` property should be set to the start time, plus the value of the "length_minutes" field in minutes

#### Track Rules

* Two types of tracks should be imported
* Tracks from the session data:
    * These tracks should be imported from the Sessions feed URL (above)
    * For each entry in the sessions' "tracks" field, use `.Lookup` to get Track instances, using the track title as the ID parameter
    * Set each `track.Title` property to the respective Track title
    * Use the `track.AssignSession` method to assign the Track to the respective Session's "id" field
* Tracks from the speakers data:
    * These tracks should be imported from the Speakers feed URL (above)
    * The Track's ID and title should be derived from the "company" field, followed by a space and the work "Speakers". Example:
        * `"Example Company A Speakers"`
    * Use the `.Lookup` method to get Track instances, using the derived title as the ID parameter
    * Set the `track.Title` property to the derived title
    * For each entry in the "session_assignments" array in the Speakers feed data, use `track.AssignSession` to assign the track to the respective Session


## Testing Your Code

You should test your code by running this project, either with `dotnet run` in the command line or by using your IDE.

When the project runs, it will execute your Integration and compare your Integration's result with the expected result. If the data differs from what is expected an exception will be raised with details. If the data matches the expectation then a success message will be output to the console.

## Submitting Your Code

Once your code runs successfully, create a source archive using the following shell commands, replacing "Your Name" with your name.

    git init .
    git add .
    git commit -m 'Initial commit'
    git archive -o "Integration Challenge Submission - Your Name.zip" HEAD .

This will create a ZIP file in this directory named "Integration Challenge Submission - Your Name.zip". Reply to the email that invited you to this challenge and attach the ZIP file.