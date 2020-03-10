<Query Kind="Statements">
  <Reference Relative="..\..\..\..\ascend-s3uploader\AscendUploader.Tests\bin\Debug\netcoreapp3.0\flux-docs.dll">D:\Dev\ascend-s3uploader\AscendUploader.Tests\bin\Debug\netcoreapp3.0\flux-docs.dll</Reference>
  <Reference Relative="..\..\..\..\ascend-s3uploader\AscendUploader.Tests\bin\Debug\netcoreapp3.0\soe.core.dll">D:\Dev\ascend-s3uploader\AscendUploader.Tests\bin\Debug\netcoreapp3.0\soe.core.dll</Reference>
  <Namespace>Soe.Ascend.Uploader.Services.Documents.Xrays</Namespace>
</Query>

// Add references to flux-docs and soe dlls
// Add namespace 
var localNow = DateTime.Now;
var mediadentTimeStamp = RciImagesUploadService.TryExtractMediadentFileDateTime("436435006670", localNow);
mediadentTimeStamp.Dump();

