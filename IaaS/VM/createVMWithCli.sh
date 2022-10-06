# önce azure shell üzerine login olun
az login
# ardından çalışacağınız subscription'u belirtin (Özellikle Defacto hesabınızla girdiyseniz :))
az account set --subscription "Azure Sponsorluk"

#1. rg'i listeleyin
az group list --output table
