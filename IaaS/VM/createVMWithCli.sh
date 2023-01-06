# önce azure shell üzerine login olun
az login
# ardından çalışacağınız subscription'u belirtin (Özellikle Kurumsal şirket hesabınızla girdiyseniz :))
az account set --subscription "Azure Sponsorluk"

#1. rg'i listeleyin
az group list --output table
#1.1 gerekirse rg oluşturun:
az group create --name tudemo-vm-rg --location "westeurope"
# 2. VM oluştur
az vm create \
     --resource-group "tudemo-vm-rg" \
     --name "tudemo-win-cli" \
     --image "win2019datacenter" \
     --admin-username "turkay" \
     --admin-password "Password1234"

#3. Bağlanmak istenilen port'u aç:
az vm open-port \
     --resource-group "tudemo-vm-rg" \
     --name "tudemo-win-cli" \
     --port "3389" \

#4. Public IP'yi sorgulayın:
az vm list-ip-addresses \
       --resource-group "tudemo-vm-rg" \
       --name "tudemo-win-cli" \
       --output table

#DİKKAT!! Burada RDC bağlandık ve test ettik.

#5. Çalıştığınız lab bittiğinde kaynağı siliniz.
 az group delete --name tudemo-vm-rg --no-wait --yes

#-----  UBUNTU with SSH --------------
az vm create \
     --resource-group "tudemo-vm-rg" \
     --name "tudemo-linux-cli" \
     --image "UbuntuLTS" \
     --admin-username "demoadmin" \
     --authentication-type "ssh" \
     --ssh-key-value ~/.ssh/id_rsa.pub \
     --generate-ssh-keys

az vm open-port \
     --resource-group "tudemo-vm-rg" \
     --name "tudemo-linux-cli" \
     --port "22" \

az vm list-ip-addresses \
       --resource-group "tudemo-vm-rg" \
       --name "tudemo-linux-cli" \
       --output table

ssh demoadmin@51.144.84.238       

#İşiniz bittikten sonra tüm kaynağı silmeyi unutmayınız!
az group delete --name tudemo-vm-rg
