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

resource "azurerm_network_interface" "nic" {
  for_each            = { for config in var.vm_configurations : config.prefix => config }
  name                = "nic-${each.value.prefix}-${random_pet.random.id}"
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name

  ip_configuration {
    name                          = "internal"
    subnet_id                     = azurerm_subnet.subnet.id
    private_ip_address_allocation = "Dynamic"
  }
}

resource "azurerm_linux_virtual_machine" "vm" {
  for_each                        = { for config in var.vm_configurations : config.prefix => config }
  name                            = "${each.value.prefix}-${random_pet.random.id}"
  resource_group_name             = azurerm_resource_group.rg.name
  location                        = azurerm_resource_group.rg.location
  size                            = each.value.size
  admin_username                  = var.admin_username
  admin_password                  = var.admin_password
  disable_password_authentication = false

  network_interface_ids = [
    azurerm_network_interface.nic[each.key].id
  ]

  os_disk {
    caching              = "None"
    storage_account_type = "Standard_LRS"
  }

  source_image_reference {
    publisher = split(":", each.value.imageUrn)[0]
    offer     = split(":", each.value.imageUrn)[1]
    sku       = split(":", each.value.imageUrn)[2]
    version   = split(":", each.value.imageUrn)[3]
  }
}

resource "azurerm_virtual_machine_extension" "vm_ext" {
  for_each             = { for config in var.vm_configurations : config.prefix => config }
  name                 = "${each.value.prefix}-${random_pet.random.id}-ext"
  virtual_machine_id   = azurerm_linux_virtual_machine.vm[each.key].id
  publisher            = "Microsoft.Azure.Extensions"
  type                 = "CustomScript"
  type_handler_version = "2.1"
  settings = <<SETTINGS
  {
    "script": "${base64encode(templatefile("install_agent.sh", {
  username     = "${var.admin_username}"
  download_url = "${each.value.runnerDownloadUrl}",
  token        = "${var.actions_token}"
}))}"
  }
  SETTINGS
}
