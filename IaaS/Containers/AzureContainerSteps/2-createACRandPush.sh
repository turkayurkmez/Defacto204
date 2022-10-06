#1 Az önce portaldan oluşturulan ACR'a bağlandık
az acr login --name bademoacr

az acr show --name bademoacr --query loginServer --output tsv
#gelen sonuç; push ile göndereceğiniz kayıtlı adres:
#bademoacr.azurecr.io
#2. etiketini belirledik
docker tag miniweb:dev bademoacr.azurecr.io/miniweb:dev
#3. local'deki container image'ini acr'a gönderdk:
docker push bademoacr.azurecr.io/miniweb:dev