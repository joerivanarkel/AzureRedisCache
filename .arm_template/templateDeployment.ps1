$Redis_name = 'fillinredisname'
$servers_name = 'fillinservername'
$storageAccounts_name = 'fillinstorageaccountname'

New-AzResourceGroup -Name $resourcegroup -Location northeurope -Force

New-AzResourceGroupDeployment `
    -Name 'new-storage' `
    -ResourceGroupName $resourcegroup `
    -Redis_name $Redis_name `
    -servers_name $servers_name `
    -storageAccounts_name $storageAccounts_name `
    -TemplateFile 'StorageAccountTemplate.json' 