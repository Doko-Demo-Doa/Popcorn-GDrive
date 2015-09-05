# Popcorn-GDrive
My application using Google API library for Drive.

### Introduction ###

Well, don't expect it to be an awesome application like Dropbox or Zoom's FileUploader or the likes. Popcorn-GDrive is a Windows Form ultility for uploading file(s) to Google Drive using v2 API and .NET wrapper.

### Features ###

- Using v2 API with a lot of bug fixes and security updates.
- Upload to any account using OAuth 2.0.
- Multiple file uploads (in development).

### Requirements ##

- Google account with access to Drive service.
- .NET 4.0 or above.
- Internet connection (of course).

### Compiling ###

- You have to create your own client IDs in https://console.developers.google.com/ and insert them into `MainForm.cs` accordingly.
- This project was originally created by Visual Studio 2013, older version may not support.
- After opening the solution, install Drive API from NuGet package:

`Install-Package Google.Apis.Drive.v2`
