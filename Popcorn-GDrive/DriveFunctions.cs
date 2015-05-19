using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Google.Apis.Drive.v2;
using Google.Apis.Drive.v2.Data;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace Popcorn_GDrive
{
    class DriveFunctions
    {
        private static string GetMimeType(string fileName)
        {
            string mimeType = "application/unknown";
            string ext = System.IO.Path.GetExtension(fileName).ToLower();
            Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
            if (regKey != null && regKey.GetValue("Content Type") != null)
                mimeType = regKey.GetValue("Content Type").ToString();
            return mimeType;
        }
        public static String /*File*/ uploadFile(DriveService service, string localFilePath)
        {
            if (System.IO.File.Exists(localFilePath))
            {
                //File's body
                File body = new File();
                body.Title = System.IO.Path.GetFileName(localFilePath);
                body.Description = "Uploaded by Popcorn-GDrive";
                body.MimeType = GetMimeType(localFilePath);

                //File content
                byte[] byteArray = System.IO.File.ReadAllBytes(localFilePath);
                System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArray);

                try
                {
                    FilesResource.InsertMediaUpload request = service.Files.Insert(body, stream, GetMimeType(localFilePath));
                    request.Upload();

                    //String fileID = request.ResponseBody.Id;
                    return request.ResponseBody.Id;
                }

                catch(Exception e)
                {
                    throw;
                }
            }

            else
            {
                return null;
            }
        }

        //List all the files and directories for the current user
        public static IList<File> getFiles(DriveService service, string searchQuery)
        {
            IList<File> Files = new List<File>();

            try
            {
                FilesResource.ListRequest list = service.Files.List();
                list.MaxResults = 1000;

                if (searchQuery != null)
                {
                    list.Q = searchQuery;
                }

                FileList filesFeed = list.Execute();

                //Loop until arriving at blank page
                while (filesFeed.Items != null)
                {
                    //Add each item into the list
                    foreach(File item in filesFeed.Items)
                    {
                        Files.Add(item);
                    }

                    //If this is the last page, the next page token will be null, so, break at this point

                    if(filesFeed.NextPageToken == null)
                    {
                        return null;
                    }

                    //Prepare the next page
                    list.PageToken = filesFeed.NextPageToken;

                    //Execute and process the next page request
                    filesFeed = list.Execute();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
            return Files;
        }
    }
}
