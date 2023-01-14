variable "location" {
  type        = string
  description = "Azure resource location"
  default     = "eastus"
}

variable "admin_username" {
  type        = string
  description = "Admin username for Vms"
  default     = "shazam"
}

variable "admin_password" {
  type        = string
  description = "Admin password for Vms"
  default     = "p4$$w0RD"
}

variable "actions_token" {
  type        = string
  description = "Github Actions token"
}

variable "vm_configurations" {
  type = list(object({
    prefix            = string
    size              = string
    imageUrn          = string
    runnerDownloadUrl = string
  }))
  description = "VM Configurations"
  default = [{
    imageUrn          = "Canonical:0001-com-ubuntu-server-focal:20_04-lts-gen2:20.04.202301100"
    prefix            = "vm-amd64"
    runnerDownloadUrl = "https://github.com/actions/runner/releases/download/v2.300.2/actions-runner-linux-x64-2.300.2.tar.gz"
    size              = "Standard_D2s_v5"
    }, {
    imageUrn          = "Canonical:0001-com-ubuntu-server-focal:20_04-lts-arm64:20.04.202301100"
    prefix            = "vm-arm64"
    runnerDownloadUrl = "https://github.com/actions/runner/releases/download/v2.300.2/actions-runner-linux-arm64-2.300.2.tar.gz"
    size              = "Standard_D2ps_v5"
  }]
}
