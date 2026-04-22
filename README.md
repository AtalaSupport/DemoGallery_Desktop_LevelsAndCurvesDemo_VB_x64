# Levels and Curves Demo

Demonstrates how DotImage's Levels and Curves commands will work on an a photographic image as well as a demonstration of AutoLevels.

This is the VB.NET version. We also have a [C# version](https://github.com/AtalaSupport/DemoGallery_Desktop_LevelsAndCurvesDemo_CS_x64) available.  


## Licensing
This application as configured, requires a license for DotImage Photo Pro or  DotImage Document Imaging. Optionally the WinDemoHelperMethods class will include additional codecs such as PDF. PDF support will automaticlly enable if you have a license for our PdfReader addon.


## SDK Dependencies
This app was built based on 2026.2.0.0. It targets .NET Framework 4.6.2 and was created in Visual Studio 2022. However, it's fairly backward compatible as distributed. If you start adding references, you can run into issues if you're using an especially outdated version of DotImage. It should also open and run equally well in Visual Studio 2026 without undue modification.  


### Using NuGet for SDK Dependencies
We do publish our SDK components to NuGet. We have chosen to base the demo on local installed SDK because this leads to much smaller applications (NuGet packages add a lot of overhead due to the way they're packaged and deployed, and many of our demos -- including this one -- are often used to reproduce issues that need to be submitted to support. Apps that use NuGet are often significantly larger and run up against our maximum support case upload size)

Still, if you wish to use NuGet for the dependencies instead of relying on locally installed SDK, you can.

- Take note of each of the references we've included:
    - Atalasoft.DotImage.AdvancedDocClean.dll
    - Atalasoft.DotImage.dll
    - Atalasoft.DotImage.Dicom.dll
    - Atalasoft.DotImage.Dwg.dll
    - Atalasoft.DotImage.Heif.dll
    - Atalasoft.DotImage.Jbig2.dll
    - Atalasoft.DotImage.Jpeg2000.dll
    - Atalasoft.DotImage.Lib.dll
    - Atalasoft.DotImage.Pdf.dll
    - Atalasoft.DotImage.PdfDoc.Bridge.dll
    - Atalasoft.DotImage.PdfReader.dll
    - Atalasoft.DotImage.Raw.dll
    - Atalasoft.DotImage.WinControls.dll
    - Atalasoft.PdfDoc.dll
    - Atalasoft.Shared.dll
- Remove those referneces
- Open the NuGet Package Manger from `Tools -> NuGet Package Manager -> Manage NuGet Packages for this Solution`
- Browse for and install Atalasoft.DotImage.WinControls.x64
    - This will install DotImage, DotImage.Lib, PdfReader, PdfDoc, and our shared dll
- Browse for and install Atalasoft.DotImage.Dicom.x64
- Browse for and install Atalasoft.DotImage.Dwg.x64
- Browse for and install Atalasoft.DotImage.Heif.x64
- Browse for and install Atalasoft.DotImage.Jbig2.x64
- Browse for and install Atalasoft.DotImage.Jpeg2000.x64
- Browse for and install Atalasoft.DotImage.Pdf.x64
    - This will add pdf Encoder as well as AdvancedDocClean


## Downloading source
The sources can be downloaded for [c#](https://github.com/AtalaSupport/DemoGallery_Desktop_LevelsAndCurvesDemo_CS_x64/archive/refs/heads/main.zip) and [VB.NET](https://github.com/AtalaSupport/DemoGallery_Desktop_LevelsAndCurvesDemo_VB_x64/archive/refs/heads/main.zip)


## Cloning
We recommend the following to ensure you clone with the required submodule

Example: git for windows
```bash
git clone https://github.com/AtalaSupport/DemoGallery_Desktop_LevelsAndCurvesDemo_VB_x64.git LevelsAndCurvesDemo
git submodule init
git submodule update
```

If you've got DotImage 2026.2 installed and licensed, it should just build and run.  


## Related documentation
In addition to this README, the Atalasoft documentation set includes the following:  
- API Reference (.chm file) gives the complete Atalasoft WingScan server-side class library for offline use. The latest versions are linked on [Atalasoft's APIs & Developer Guides page](https://www.atalasoft.com/Support/APIs-Dev-Guides).
- In addition, you can also refer to the following Atalasoft resources:
    - [Atalasoft Support](http://www.atalasoft.com/support/)
    - [Atalasoft Knowledgebase](http://www.atalasoft.com/kb2)


## Getting Help for Atalasoft products
Atalasoft regularly updates our support [Knowledgebase](http://www.atalasoft.com/kb2) with the latest information about our products. To access some resources, you must have a valid Support Agreement with an authorized Atalasoft Reseller/Partner or with Atalasoft directly. Use the tools that Atalasoft provides for researching and identifying issues. 

Customers with an active evaluation, or those with active support / maintenance may [create a support case](https://www.atalasoft.com/Support/my-portal/Cases/Create-Case) 24/7, or call in to support ([+1 949 236-6510](tel:19492366510) ) during our normal support hours (Monday - Friday 8:00am to 5:00PM Eastern (New York) time).  

Customers who are unable to create a case or call in may [email our Sales Team](email:sales@atalasoft.com).  

