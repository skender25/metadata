using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace blobproperties
{
    class Program
    {
        static string connstring = "DefaultEndpointsProtocol=https;AccountName=demouser326;AccountKey=bpyz3WyZICH+iDOVsF+kf0cdNaVyfRJ95Zde9Yazz9qh9rzCV7QUDf0uJIfy0e0sJOLXsFxRuBvmfiM0B/inIg==;EndpointSuffix=core.windows.net";
        static string containerName = "demo2";
        static string filename = "sample.txt";
        static async Task Main(string[] args)
        {
            GetProperties();
           // SetMetadata();
            GetMetadata();
            
            Console.WriteLine("Operation complete");
            Console.ReadKey();
        }

        static void GetProperties()
        {
            
            BlobServiceClient blobServiceClient = new BlobServiceClient(connstring);
            
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            
            BlobClient blob = containerClient.GetBlobClient(filename);

            
            BlobProperties properties=blob.GetProperties();
            Console.WriteLine("The Access tier of the blob is {0}",properties.AccessTier);
            Console.WriteLine("The Content Length of the blob is {0}", properties.ContentLength);

            
        }

        static void GetMetadata()
        {
            
            BlobServiceClient blobServiceClient = new BlobServiceClient(connstring);
            
            
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            
            BlobClient blob = containerClient.GetBlobClient(filename);

            
            BlobProperties properties = blob.GetProperties();

            
            foreach(var metadata in properties.Metadata)
            {
                Console.WriteLine(metadata.Key.ToString());
                Console.WriteLine(metadata.Value.ToString());
            }
        }

        static void SetMetadata()
        {
            string p_key = "Departamento";
            string p_value = "Recursos Humanos";

            BlobServiceClient blobServiceClient = new BlobServiceClient(connstring);
            
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            
            BlobClient blob = containerClient.GetBlobClient(filename);
               
            IDictionary<string, string> obj = new Dictionary<string, string>();
            obj.Add(p_key, p_value);
            blob.SetMetadata(obj);
            


        }

    }
}
