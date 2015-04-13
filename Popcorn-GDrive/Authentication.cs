using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.Threading;
using System.IO;

namespace Popcorn_GDrive
{
    /// <summary>
    /// Authenticate to Google using OAuth2
    /// </summary>
    class Authentication
    {
        public static DriveService AuthenticateOauth(string clientID, string clientSecret, string userName)
        {
            //Google Drive scopes Documentation: https://developers.google.com/drive/web/scopes
            string[] scopes = new string[] {  DriveService.Scope.Drive, //View and manage files and documents
                                            DriveService.Scope.DriveAppdata, //View and manage its own configuration data
                                            DriveService.Scope.DriveAppsReadonly, //View and manage drive apps
                                            DriveService.Scope.DriveFile, //View and manage files created by Popcorn-GDrive
                                            DriveService.Scope.DriveMetadataReadonly, //View metadata for files
                                            DriveService.Scope.DriveReadonly, //View (only) files and documents on your drive
                                            DriveService.Scope.DriveScripts, //View your app scripts
            };

            try
            {
                UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets { ClientId = clientID, ClientSecret = clientSecret }
                                                                                            , scopes
                                                                                            , userName
                                                                                            , CancellationToken.None
                                                                                            , new FileDataStore("Popcorn-GDrive.Auth.Store")).Result;

                DriveService service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Popcorn-GDrive",
                });
                return service;
            }

            catch (Exception e)
            {
                throw e;
                //Console.WriteLine(e.InnerException);
                return null;
            }
        }

        ///<summary>
        ///2nd method: Authenticate to Google using Service account
        ///Docs: https://developers.google.com/accounts/docs/OAuth2#serviceaccount
        ///
        ///</summary>
        
        public static DriveService AuthenticateServiceAccount(string serviceAccountEmail, string keyFilePath)
        {
            //Check if the file exists
            if (!File.Exists(keyFilePath))
            {
                //Console.WriteLine("An error occured - key file does not exist");
                return null;
            }

            string[] scopes = new string[] {    DriveService.Scope.Drive, //View and manage files and documents
                                                DriveService.Scope.DriveAppdata, //View and manage its own configuration data
                                                DriveService.Scope.DriveAppsReadonly, //View and manage drive apps
                                                DriveService.Scope.DriveFile, //View and manage files created by Popcorn-GDrive
                                                DriveService.Scope.DriveMetadataReadonly, //View metadata for files
                                                DriveService.Scope.DriveReadonly, //View (only) files and documents on your drive
                                                DriveService.Scope.DriveScripts, //View your app scripts
            };

            var certificate = new X509Certificate2(keyFilePath, "doko", X509KeyStorageFlags.Exportable);
            try
            {
                ServiceAccountCredential credential = new ServiceAccountCredential(
                    new ServiceAccountCredential.Initializer(serviceAccountEmail)
                    {
                        Scopes = scopes
                    }.FromCertificate(certificate));

                //Create the service
                DriveService service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Popcorn-GDrive",
                });
                return service;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return null;
            }

        }

    }
}
