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

resource "azurerm_virtual_network" "vnet" {
  name                = "vnet${random_pet.random.id}"
  address_space       = ["10.0.0.0/16"]
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
}

resource "azurerm_subnet" "subnet" {
  name                 = "subnet${random_pet.random.id}"
  resource_group_name  = azurerm_resource_group.rg.name
  virtual_network_name = azurerm_virtual_network.vnet.name
  address_prefixes     = ["10.0.2.0/24"]
}

resource "azurerm_network_interface" "amd64nic" {
  name                = "nic-amd64-${random_pet.random.id}"
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name

  ip_configuration {
    name                          = "internal"
    subnet_id                     = azurerm_subnet.subnet.id
    private_ip_address_allocation = "Dynamic"
  }
}

resource "azurerm_linux_virtual_machine" "amd64vm" {
  name                            = "vm-amd64-${random_pet.random.id}"
  resource_group_name             = azurerm_resource_group.rg.name
  location                        = azurerm_resource_group.rg.location
  size                            = "Standard_D2s_v5"
  admin_username                  = var.admin_username
  admin_password                  = var.admin_password
  disable_password_authentication = false

  network_interface_ids = [
    azurerm_network_interface.amd64nic.id
  ]

  os_disk {
    caching              = "None"
    storage_account_type = "Standard_LRS"
  }

  source_image_reference {
    publisher = "Canonical"
    offer     = "0001-com-ubuntu-server-focal"
    sku       = "20_04-lts-gen2" // "20_04-lts-arm64"
    version   = "20.04.202212140"
  }
}

resource "azurerm_virtual_machine_extension" "amd64vmext" {
  name                 = "vm-amd64-ext-${random_pet.random.id}"
  virtual_machine_id   = azurerm_linux_virtual_machine.amd64vm.id
  publisher            = "Microsoft.Azure.Extensions"
  type                 = "CustomScript"
  type_handler_version = "2.1"
  settings = <<SETTINGS
  {
    "script": "${base64encode(templatefile("install_agent.sh", {
  username     = "${var.admin_username}"
  download_url = "https://github.com/actions/runner/releases/download/v2.299.1/actions-runner-linux-x64-2.299.1.tar.gz",
  token        = "${var.actions_token}"
}))}"
  }
  SETTINGS
}
