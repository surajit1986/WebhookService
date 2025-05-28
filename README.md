# Cornerstone Webhook

This project is a .NET application designed to receive and process JSON data from the Cornerstone API via a webhook. 

## Project Structure

- **CornerstoneWebhook.sln**: Solution file containing project references and structure.
- **src/CornerstoneWebhook/Controllers/WebhookController.cs**: Contains the `WebhookController` class that handles incoming POST requests.
- **src/CornerstoneWebhook/appsettings.json**: Configuration settings, including the API key for Cornerstone.
- **src/CornerstoneWebhook/Program.cs**: Entry point of the application that sets up the web host.
- **src/CornerstoneWebhook/Startup.cs**: Configures services and the request pipeline.
- **src/CornerstoneWebhook/Properties/launchSettings.json**: Settings for launching the application in different environments.

## Hosting Instructions

### Steps to Host the Webhook Program in IIS

1. **Publish the Application**: 
   - Right-click on the project in your IDE and select "Publish".
   - Choose a folder as the target and publish the application.

2. **Install IIS**: 
   - Ensure that IIS is installed on your Windows machine. You can enable it through the "Turn Windows features on or off" settings.

3. **Create a New Site in IIS**:
   - Open IIS Manager.
   - Right-click on "Sites" and select "Add Website".
   - Set the site name, physical path (the folder where you published your application), and port.

4. **Configure Application Pool**:
   - Ensure that the application pool is set to use the .NET CLR version that matches your application (usually .NET CLR Version v4.0).

5. **Set Permissions**:
   - Ensure that the IIS user (IUSR) has read and execute permissions on the published folder.

6. **Configure Web.config**:
   - Ensure that the `web.config` file is present in the published folder. This file is generated during the publish process and contains necessary configurations for IIS.

7. **Test the Webhook**:
   - Use a tool like Postman to send a POST request to the URL of your hosted application to ensure it is receiving data correctly.

8. **Set Application to Run Always**:
   - In IIS, select your site, go to "Advanced Settings", and set "Start Mode" to "AlwaysRunning".

9. **Comment**
   Host in IIS
   Open IIS Manager (inetmgr).

   Add a new Website:

   Site name: WebhookService

   Physical path: path to your ./publish folder.

   Port: e.g., 5000

   Application Pool Settings:

   Use No Managed Code.

   Set to .NET CLR Version = No Managed Code (ASP.NET Core is self-hosted).

   Ensure permissions: IIS AppPool user has read access to publish folder.

By following these steps, your .NET webhook program should be successfully hosted in IIS and ready to receive JSON data from the Cornerstone API.


