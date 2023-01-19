provider "azurerm" {
  features {}
}

resource "random_pet" "random" {
  separator = ""
  length    = 2
}

resource "azurerm_resource_group" "rg" {
  name     = "rg-${random_pet.random.id}"
  location = var.location
}


resource "azurerm_log_analytics_workspace" "law" {
  name                = "law${random_pet.random.id}"
  resource_group_name = azurerm_resource_group.rg.name
  location            = azurerm_resource_group.rg.location
  sku                 = "PerGB2018"
  retention_in_days   = 30
}

resource "azurerm_kubernetes_cluster" "aks" {
  name                = "aks${random_pet.random.id}"
  resource_group_name = azurerm_resource_group.rg.name
  location            = azurerm_resource_group.rg.location
  dns_prefix          = "aks-${random_pet.random.id}"

  default_node_pool {
    name                         = "default"
    node_count                   = 1
    vm_size                      = "Standard_D2s_v5"
    only_critical_addons_enabled = true
  }

  oms_agent {
    log_analytics_workspace_id = azurerm_log_analytics_workspace.law.id
  }

  identity {
    type = "SystemAssigned"
  }
}

resource "azurerm_kubernetes_cluster_node_pool" "aks-arm-nodepool" {
  name                  = "arm64nodes"
  kubernetes_cluster_id = azurerm_kubernetes_cluster.aks.id
  vm_size               = "Standard_D2ps_v5"
  node_count            = 2
}

resource "azurerm_kubernetes_cluster_node_pool" "aks-amd-nodepool" {
  name                  = "amd64nodes"
  kubernetes_cluster_id = azurerm_kubernetes_cluster.aks.id
  vm_size               = "Standard_D2s_v5"
  node_count            = 2
}
