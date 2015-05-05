using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using Renci.SshNet;
using System.IO;
using System.Web.Helpers;

namespace zDeploy
{
    class Program
    {
        static void Main(string[] args)
        {
            //read config
            string text = File.ReadAllText("zDeploy.json",
                                                  Encoding.UTF8);
            var config = Json.Decode(text);

            //read apache config
            string apacheconfig = File.ReadAllText(config.apacheConfig,
                                                 Encoding.UTF8);
            //replace apacheconfig with configed value
            //
            //
            //

            string dir = "";
            ZipFile.CreateFromDirectory("startPath", "zipPath");


            PrivateKeyFile key = new PrivateKeyFile("private");
            using (var sftpClient = new SftpClient(connectionInfo))
            {
                sftpClient.Connect();
                var list = sftpClient.ListDirectory(string.Empty);

                //upload apache config
                sftpClient.UploadFile(File.OpenRead(@"D:\data8.xml"), "small.txt", true);
                //upload web app
                sftpClient.UploadFile(File.OpenRead(@"D:\data8.xml"), "small.txt", true);
            }

            using (var client = new SshClient("10.96.15.6", "admin", key))
        
            {
                client.Connect();
                client.RunCommand("unzip");
                client.RunCommand("apache restart");
                client.Disconnect();
            }
        }
    }
}
