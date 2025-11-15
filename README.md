Find the API Keys section
Click Create new secret key.
Give it a name/project.
Copy the key somewhere safe.

install these packages via NuGet Package Manager:
dotnet add package dotenv.net
dotnet add package OpenAI

Add the key to an .env file in the root of your project and put this in front of it: OpenAI_API_Key=