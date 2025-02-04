using System;
using System.Diagnostics;
using System.Net;
using BadMC_Launcher.Constants;
using BadMC_Launcher.Models.Classes;
using BadMC_Launcher.Services.FileManager;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml.Media.Imaging;

namespace BadMC_Launcher.Tests;

public class UnitTest1
{
    class C1 {
        public string indowName { get; set; } = "哼哼啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊！！！！！！！！！！！！！！";

        public int indowName2 { get; set; } = 13333444;
    }
        [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task Test1()
    {
        //IFileService? fileService = new FileService();
        //var cc1 = new C1();
        //fileService.WriteConfig(Path.Combine(AppDataPath.ConfigsPath, @"Settings\C1.json"), cc1);
        ////fileService.ConfigSet<C1, string>(Path.Combine(AppDataPath.ConfigsPath, @"Settings\C1.json"), "indowName", cc1.indowName);
        //var request = new HttpRequestMessage(HttpMethod.Head, @"https://bmclapi2.bangbang93.com/forge/download?mcversion=1.20.1&version=47.3.27&category=installer&format=jar");
        //var response = await new HttpClient().SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
        //if (response.StatusCode == HttpStatusCode.Found) {
        //    var redirectUrl = response.Headers.Location?.AbsoluteUri;
        //}
        //response.EnsureSuccessStatusCode();
        new BitmapImage(new Uri("C:\\Users\\stars\\Pictures\\Camera Roll\\fcxbb.png"));
        Assert.Pass();
    }
}
