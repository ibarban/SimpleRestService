# Define variables
$resourceGroup = "traffic-balancing-test"
$functionApp1 = "TrafficBalancingApp1"
$functionApp2 = "trafficbalancingapp2"
$zipFile = "deploy.zip"

# Build the project
dotnet publish -c Release -o ./publish

# Create a ZIP file of the published output
if (Test-Path $zipFile) {
    Remove-Item $zipFile
}
Compress-Archive -Path ./publish/* -DestinationPath $zipFile -Force

# Deploy to FunctionApp1
az functionapp deployment source config-zip `
    --resource-group $resourceGroup `
    --name $functionApp1 `
    --src $zipFile

# Deploy to FunctionApp2
az functionapp deployment source config-zip `
    --resource-group $resourceGroup `
    --name $functionApp2 `
    --src $zipFile

# Clean up
Remove-Item $zipFile
Remove-Item -Recurse -Force ./publish