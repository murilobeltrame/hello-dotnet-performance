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
