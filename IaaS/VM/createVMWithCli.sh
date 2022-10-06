# önce azure shell üzerine login olun
az login
# ardından çalışacağınız subscription'u belirtin (Özellikle Defacto hesabınızla girdiyseniz :))
az account set --subscription "Azure Sponsorluk"

#1. rg'i listeleyin
az group list --output table
#1.1 gerekirse rg oluşturun:
az group create --name bademo-vm-rg-2 --location "westeurope"
# 2. VM oluştur
az vm create \
     --resource-group "bademo-vm-rg-2" \
     --name "bademo-win-cli" \
     --image "win2019datacenter" \
     --admin-username "turkay" \
     --admin-password "Pa55W0rd1234"

#3. Bağlanmak istenilen port'u aç:
az vm open-port \
     --resource-group "bademo-vm-rg-2" \
     --name "bademo-win-cli" \
     --port "3389" \

#4. Public IP'yi sorgulayın:
az vm list-ip-addresses \
       --resource-group "bademo-vm-rg-2" \
       --name "bademo-win-cli" \
       --output table