#1. resource group oluştur:
az group create -n bademo-webapp-rg -l westeurope
#2. servis planı oluştur.
az appservice plan create --name bademo-webapp-plan \
  --resource-group bademo-webapp-rg \
  --sku s1
#3. runtime'da desteklenen platformlar:
az webapp list-runtimes
#4.   
az webapp create -g bademo-webapp-rg \
  -p bademo-webapp-plan \
  -n [Eşsiz bir isim] \
  --runtime "dotnet:6"