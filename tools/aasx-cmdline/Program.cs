﻿using AAS.AASX.ADT;
using AAS.AASX.Support;
using AdminShellNS;
using Azure.Core.Pipeline;
using Azure.DigitalTwins.Core;
using Azure.Identity;
using CommandLine;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;

namespace AAS.AASX.CmdLine
{
    [Verb("import", HelpText = "Manage AAS shells")]
    class ImportOptions
    {
        [Option('f', "file", Required = false, HelpText = "AASX package file path")]
        public string PackageFilePath { get; set; }
        [Option('u', "url", Required = true, HelpText = "ADT instance url")]
        public string Url { get; set; }
    }

    internal class Program
    {
        static int Main(string[] args) => Parser.Default.ParseArguments<ImportOptions>(args)
            .MapResult(
                (ImportOptions options) => RunImportAndReturnExitCode(options),
                errors => 1);
        static int RunImportAndReturnExitCode(ImportOptions importOpts)
        {
            using IHost host = Host.CreateDefaultBuilder()
                .ConfigureServices((_, services) =>
                {
                    services.Configure<DigitalTwinsClientOptions>(options => options.ADTEndpoint = new Uri(importOpts.Url));

                    services.AddAzureClients(builder =>
                    {
                        builder.AddClient<DigitalTwinsClient, DigitalTwinsClientOptions>((options, provider) =>
                        {
                            var appOptions = provider.GetService<IOptions<DigitalTwinsClientOptions>>();

                            var credentials = new DefaultAzureCredential();
                            DigitalTwinsClient client = new DigitalTwinsClient(appOptions.Value.ADTEndpoint,
                                        credentials, new Azure.DigitalTwins.Core.DigitalTwinsClientOptions { Transport = new HttpClientTransport(new HttpClient()) });
                            return client;
                        });

                        // First use DefaultAzureCredentials and second EnvironmentCredential to enable local docker execution
                        builder.UseCredential(new ChainedTokenCredential(new DefaultAzureCredential(), new EnvironmentCredential()));
                    });

                    services.AddSingleton<AASXImporter, ADTAASXPackageImporter>();
                })
                .Build();

            using IServiceScope serviceScope = host.Services.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;

            AASXImporter importer = provider.GetRequiredService<AASXImporter>();
            importer.ImportFromPackageFile(importOpts.PackageFilePath).GetAwaiter().GetResult();

            host.RunAsync().GetAwaiter().GetResult();

            return 0;
        }

        public class DigitalTwinsClientOptions
        {
            public Uri ADTEndpoint { get; set; }
        }

        static void SimpleMain(string[] args)
        {
            Console.WriteLine("Hello World!");

            using var package = new AdminShellPackageEnv(args[0]);

            Console.WriteLine(package.AasEnv.AdministrationShells[0].GetFriendlyName());
        }
    }
}
