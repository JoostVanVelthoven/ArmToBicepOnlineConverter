namespace ArmToBicepOnlineConverter
{
    public static class Constants
    {
        public static string ExampleInput = @"{
  ""$schema"": ""https://schema.management.azure.com/schemas/2019-04-01/deploymentTemplate.json#"",
  ""contentVersion"": ""1.0.0.0"",
 
  ""parameters"": {
    ""storageAccountName"": {
      ""type"": ""string"",
      ""metadata"": {
        ""description"": ""Specifies the name of the Azure Storage account.""
      }
    },
    ""containerName"": {
      ""type"": ""string"",
      ""defaultValue"": ""logs"",
      ""metadata"": {
        ""description"": ""Specifies the name of the blob container.""
      }
    },
    ""location"": {
      ""type"": ""string"",
      ""defaultValue"": ""[resourceGroup().location]"",
      ""metadata"": {
        ""description"": ""Specifies the location in which the Azure Storage resources should be deployed.""
      }
    }
  },
  ""resources"": [
    {
      ""type"": ""Microsoft.Storage/storageAccounts"",
      ""apiVersion"": ""2021-06-01"",
      ""name"": ""[parameters('storageAccountName')]"",
      ""location"": ""[parameters('location')]"",
      ""sku"": {
        ""name"": ""Standard_LRS""
      },
      ""kind"": ""StorageV2"",
      ""properties"": {
        ""accessTier"": ""Hot""
      }
    },
    {
      ""type"": ""Microsoft.Storage/storageAccounts/blobServices/containers"",
      ""apiVersion"": ""2021-06-01"",
      ""name"": ""[format('{0}/default/{1}', parameters('storageAccountName'), parameters('containerName'))]"",
      ""dependsOn"": [
        ""[resourceId('Microsoft.Storage/storageAccounts', parameters('storageAccountName'))]""
      ]
    }
  ]
}";


        public static string ExampleOutput = @"@description('Specifies the name of the Azure Storage account.')
param storageAccountName string

@description('Specifies the name of the blob container.')
param containerName string = 'logs'

@description('Specifies the location in which the Azure Storage resources should be deployed.')
param location string = resourceGroup().location

resource storageAccountName_resource 'Microsoft.Storage/storageAccounts@2021-06-01' = {
  name: storageAccountName
  location: location
  sku: {
    name: 'Standard_LRS'
  }
  kind: 'StorageV2'
  properties: {
    accessTier: 'Hot'
  }
}

resource storageAccountName_default_containerName 'Microsoft.Storage/storageAccounts/blobServices/containers@2021-06-01' = {
  name: '${storageAccountName}/default/${containerName}'
  dependsOn: [
    storageAccountName_resource
  ]
}";
    }

}
