
using Azure.Storage.Blobs;

var connectionString = "DefaultEndpointsProtocol=https;AccountName=bademostorage;AccountKey=x5/FAyx31r66UzEad5W/mi2dGBbWMtWiaG4KvTZoHCyI0Cu9hHAWEKPWsZRGAYnjuD+KjOZB9u2o+AStDtFumQ==;EndpointSuffix=core.windows.net";

var containerName = "htmlfiles";
var blobName = "uploadFile.html";

try
{
	await createContainerAndUploadBlobAsync();
	await listContainersWithBlobsAsync();
	await downloadBlobAsync();
	await deleteContainerAsync();
}
catch (Exception)
{

	throw;
}



async Task createContainerAndUploadBlobAsync()
{
	BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
	BlobContainerClient blobContainerClient = blobServiceClient.GetBlobContainerClient(containerName);
	Console.WriteLine($"1. Blob container oluşturuluyor....{containerName}");
	await blobContainerClient.CreateIfNotExistsAsync(Azure.Storage.Blobs.Models.PublicAccessType.BlobContainer);

	BlobClient blobClient = blobContainerClient.GetBlobClient(blobName);
	Console.WriteLine($"2. Blob upload ediliyor....{blobClient.Uri} adresine");
	using FileStream fileStream = File.OpenRead(@"..\..\..\uploadFile.html");
	if (!await blobClient.ExistsAsync())
	{
		await blobClient.UploadAsync(fileStream);
	}


}

async Task listContainersWithBlobsAsync()
{
	BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
	Console.WriteLine($"3. {blobServiceClient.AccountName} içindeki container'a erişiliyor");
	await foreach (var container in blobServiceClient.GetBlobContainersAsync())
	{
		Console.WriteLine($"-->{container.Name}");
		BlobContainerClient blobContainerClient = blobServiceClient.GetBlobContainerClient(container.Name);
		await foreach (var blob in blobContainerClient.GetBlobsAsync())
		{
			Console.WriteLine($"----> {blob.Name}");
		}
	}
}

async Task downloadBlobAsync()
{
	string localPath = @"..\\..\\..\\downloadFile.html";
	BlobClient blobClient = new BlobClient(connectionString, containerName, blobName);
	if (await blobClient.ExistsAsync())
	{
		var response = await blobClient.DownloadToAsync(localPath);
	}
}

async Task deleteContainerAsync()
{
	Console.WriteLine("Dikkat!! Siliniyor");
	BlobContainerClient blobContainerClient = new BlobContainerClient(connectionString, containerName);
	await blobContainerClient.DeleteIfExistsAsync();
}